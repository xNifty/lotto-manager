﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Drawing.Drawing2D;
using LottoManager.Properties;
using System.Reflection;
using Newtonsoft.Json;

// @TODO : rewrite all of this stuff

namespace LottoManager {

    public partial class Form1 : Form {
        private BackgroundWorker _bgw = new BackgroundWorker();

        private MySqlConnection _connection;
        private bool _isConnected = false;
        private bool _generatedList = false;
        private readonly Dictionary<string, string> _dict = new Dictionary<string, string>();
        private readonly List<string> _randomList = new List<string>();
        private List<string> _winnerList = new List<string>();
        private readonly List<string> _guildRoster = new List<string>();

        public Form1() {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            this.DoubleBuffered = true;
            
            // Version object

            //guildRoster.ForEach(Console.WriteLine);

            userEntryText.AutoCompleteMode = AutoCompleteMode.Suggest;
            userEntryText.AutoCompleteSource = AutoCompleteSource.CustomSource;

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) {
                var cd = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                var version = cd.CurrentVersion;
                Console.WriteLine(version);
                Text = Text + " - " + version.Major + "." + version.Minor + @"." + version.Build + "." + version.Revision;
            } else
            {
                const string versionText = "Debug Mode";
                Text = Text + " - " + versionText;
            }

            rollButton.Enabled = false;
            listResetButton.Enabled = false;
            rollBox.Enabled = false;
            richTextBox1.DetectUrls = true;

            clearDatabase.Enabled = _isConnected == true;

            usernameBox.Text = Properties.Settings.Default.usernameBox;
            hostnameBox.Text = Properties.Settings.Default.hostBox;
            databaseBox.Text = Properties.Settings.Default.databaseBox;
            guildapikey.Text = Properties.Settings.Default.guildapikey;
            leaderapikey.Text = Properties.Settings.Default.leaderapikey;
        }

        [Localizable(false)]
        public sealed override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void rollBox_TextChanged(object sender, EventArgs e) {
            //MessageBox.Show(isConnected.ToString());
            try {
                if ((int.TryParse(rollBox.Text, out _)) && (_isConnected == true) && (_randomList.Any())) {
                    rollButton.Enabled = true;
                    //MessageBox.Show("Entry was a number.");
                } else {
                    rollButton.Enabled = false;
                    //MessageBox.Show("Entry not a number.");
                }
            } catch (Exception error) {
                Console.WriteLine(error);
                rollButton.Enabled = false;
            }
        }

        private void rollButton_Click(object sender, EventArgs e) {
            int.TryParse(rollBox.Text, out var rollCount);
            var passedCounter = Tuple.Create<int>(rollCount);

            rollingProgress.Visible = true;

            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker2_RunWorkerCompleted);

            backgroundWorker2.DoWork += new DoWorkEventHandler(backgroundWorker2_DoWork);
            backgroundWorker2.RunWorkerAsync(passedCounter);

            rollingProgress.Style = ProgressBarStyle.Marquee;
            rollingProgress.MarqueeAnimationSpeed = 100;

            while (backgroundWorker2.IsBusy) {
                rollButton.Enabled = false;
                Application.DoEvents();
            }

            if (backgroundWorker2.IsBusy) return;
            rollButton.Enabled = true;
            rollingProgress.Style = ProgressBarStyle.Continuous;

            //winnerBox.Text = randomizeList(rollCount);
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e) {
            if (!(e.Argument is Tuple<int> rolls)) return;
            var returnedResults = RandomizeList.SelectWinner(rolls.Item1, _randomList);

            //String winner = RandomizeList.selectWinner(rolls.Item1, randomList).Item1;
            var winner = returnedResults.Item1;

            if (_winnerList.Any()) {
                _winnerList.Clear();
                _winnerList = returnedResults.Item2;
            } else {
                _winnerList = returnedResults.Item2;
            }

            e.Result = Tuple.Create<string>(winner);
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            Console.WriteLine("Post-run History: {0}", _winnerList.Count);
            var res = e.Result as Tuple<string>;
            try
            {
                winnerBox.Text = res.Item1;
                wonItemsBox.Enabled = true;
            }
            catch (System.NullReferenceException)
            {
                
            }
        }

        // Controls panel border
        private void panel1_Paint(object sender, PaintEventArgs e) {
            ControlPaint.DrawBorder(
                e.Graphics, this.panel1.ClientRectangle, Color.Gold, 3, ButtonBorderStyle.Solid, 
                Color.Gold, 3, ButtonBorderStyle.Solid, Color.Gold, 3, ButtonBorderStyle.Solid, Color.Gold, 3, 
                ButtonBorderStyle.Solid
            );
        }


        // Attempt connection to MySQL
        private static bool OpenConnection(IDbConnection connection) {
            try {
                connection.Open();
                return true;
            } catch (SqlException ex) {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                //MessageBox.Show(ex.Number.ToString());
                switch (ex.Number) {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private void connectionButton_Click(object sender, EventArgs e) {
            var databaseUsername = usernameBox.Text;
            var databasePassword = passwordBox.Text;
            var databaseHost = hostnameBox.Text;
            var databaseName = databaseBox.Text;
            var guildLeadApi = guildapikey.Text;
            var leaderApi = leaderapikey.Text;

            //MessageBox.Show(databasePassword.ToString());

            if (
                databaseUsername == "" || 
                databasePassword == "" || 
                databaseHost == "" || 
                databaseName == "" || 
                guildLeadApi == "" || 
                leaderApi == ""
               ) {
                MessageBox.Show(Constants.MissingConnectionDetails);
                return;
            }

            // Oh god this is bad...really should redo
            var connectionString = "SERVER=" + databaseHost + 
                                   "; PORT = 3306 ;" + "DATABASE=" + databaseName + 
                                   ";" + "UID=" + databaseUsername + ";" + 
                                   "PASSWORD=" + databasePassword + ";";

            _connection = new MySqlConnection(connectionString);

            if (OpenConnection(_connection)) {
                connectionLabel.ForeColor = Color.Green;
                connectionLabel.Text = Constants.DatabaseConnected;
                connectionButton.Enabled = false;
                usernameBox.Enabled = false;
                passwordBox.Enabled = false;
                hostnameBox.Enabled = false;
                databaseBox.Enabled = false;
                guildapikey.Enabled = false;
                leaderapikey.Enabled = false;
                _isConnected = true;
                listResetButton.Enabled = true;
                rollBox.Enabled = true;
                clearDatabase.Enabled = true;
                //MessageBox.Show("Connected!");
            } else {
                connectionLabel.ForeColor = Color.Red;
                connectionLabel.Text = Constants.DatabaseNotConnected;
                connectionButton.Enabled = true;
                usernameBox.Enabled = true;
                passwordBox.Enabled = true;
                hostnameBox.Enabled = true;
                databaseBox.Enabled = true;
                guildapikey.Enabled = true;
                leaderapikey.Enabled = true;
                _isConnected = false;
                //MessageBox.Show("Connection failed...");
            }

            try
            {
                using (var webClient = new System.Net.WebClient())
                {   
                    var guildId = guildapikey.Text;
                    var guildLeaderApi = leaderapikey.Text;
                    var accessUrl = VariableConstants.BaseUrl + guildId + "/" + "members?access_token=" + guildLeaderApi;
                    var json = webClient.DownloadString(accessUrl);
                    dynamic jsonObj = JsonConvert.DeserializeObject(json);

                    foreach (var obj in jsonObj)
                    {
                        //Console.WriteLine(obj.name);
                        _guildRoster.Add((string)obj.name);
                    }

                    _generatedList = true;
                }
            }
            catch
            {
                _generatedList = false;
            }

            if (_generatedList)
            {
                userEntryText.AutoCompleteCustomSource = _guildRoster.ToAutoCompleteStringCollection();
                apistatus.ForeColor = Color.Green;
                apistatus.Text = Constants.Gw2ApiConnected;
            }
            else
            {
                apistatus.ForeColor = Color.Red;
                apistatus.Text = Constants.Gw2ApiNotConnected;
            }
        }

        private void listResetButton_Click(object sender, EventArgs e) {
            var confirmReset = MessageBox.Show(Constants.ResetListClearWarning, Constants.ConfirmReset, MessageBoxButtons.YesNo);

            if (confirmReset == DialogResult.Yes) {
                _randomList.Clear();
                _dict.Clear();
                rollBox.Clear();
                if (_randomList.Any()) return;
                try {
                    var command = new MySqlCommand();
                    MySqlDataReader reader;
                    command.CommandText = "call List_Lotto_Users()";
                    command.Connection = _connection;

                    //reader = command.ExecuteReader();

                    using (reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            _dict.Add(reader[0].ToString(), reader[1].ToString());
                        }
                    }

                    // Take the number of tickets, and add that many entries to the List
                    foreach (var kvpList in _dict) {
                        int.TryParse(kvpList.Value, out var tickets);

                        for (var i = 0; i < tickets; i++) {
                            _randomList.Add(kvpList.Key);
                        }
                    }

                    _randomList.Shuffle();

                    // Printing out the List
                    //randomList.ForEach(Console.WriteLine);
                    MessageBox.Show(Constants.ListGenerationComplete);
                } catch (Exception ex) {
                    //Console.WriteLine("Error: {0}", ex);
                    //winnerBox.Text = "Error";
                    if (ex is System.InvalidOperationException) {
                        try {
                            OpenConnection(_connection);
                        } catch (Exception exp) {
                            MessageBox.Show(string.Format(Constants.ErrorWithVar, exp), Constants.ErrorText);
                        }
                    } else {
                        MessageBox.Show(string.Format(Constants.ErrorWithVar, ex), Constants.ErrorText);
                    }
                }
                //randomList.ForEach(Console.WriteLine);
            } else {
                //randomList.ForEach(Console.WriteLine);
                return;
            }
        }

        private void submitWinnerButton_Click(object sender, EventArgs e) {
            try {
                var winner = winnerBox.Text;
                int.TryParse(rollBox.Text, out var rolls);
                var items = wonItemsBox.Text;
                var date = DateTime.Now;
                
                // Uncomment this for testing
                /*
                 Console.WriteLine("Count: {0}", _winnerList.Count);
                 foreach (var t in _winnerList)
                     Console.WriteLine("History list: {0}", t);
                */

                // Init the MySqlCommand class
                var command = new MySqlCommand();

                // Let's make sure the history list has objects....otherwise, throw an error and do nothing
                if (!_winnerList.Any()) {
                    MessageBox.Show(Constants.WinnerListError, Constants.ErrorText);
                    return;
                }

                var rollHistory = string.Join(Environment.NewLine, _winnerList);

                /*
                 * Build and execute the stored procedure
                 * I really hate how this is done, but oh well...it works, and yeah.
                 * 
                 * */
                command.CommandText = "call Add_Lotto_Winner(@p1, @p2, @p3, @p4, @p5)";
                command.Parameters.AddWithValue("@p1", winner);
                command.Parameters.AddWithValue("@p2", rolls);
                command.Parameters.AddWithValue("@p3", items);
                command.Parameters.AddWithValue("@p4", date);
                command.Parameters.AddWithValue("@p5", rollHistory);
                
                command.Connection = _connection;

                command.ExecuteNonQuery();

                winnerBox.Clear();
                wonItemsBox.Clear();
                rollBox.Clear();

                winnerBox.Enabled = false;
                wonItemsBox.Enabled = false;
               
                MessageBox.Show(string.Format(Constants.InsertedWinnerText, winner, rolls, items), Constants.SuccessText);
                _winnerList.Clear();
            } catch (Exception ex) {
                //Console.WriteLine("Error: {0}", ex);
                MessageBox.Show(string.Format(Constants.ErrorWithVar, ex), Constants.ErrorText);
            }
        }

        private void wonItemsBox_TextChanged(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(winnerBox.Text) && !string.IsNullOrEmpty(wonItemsBox.Text)) {
                submitWinnerButton.Enabled = true;
            } else {
                submitWinnerButton.Enabled = false;
            }
        }

        private void calculateGoldButton_Click(object sender, EventArgs e) {
            double.TryParse(goldAmount.Text, out var amount);
            const double percent = 0.70;
            var calculatedAmount = (amount * percent);
            MessageBox.Show(string.Format(Constants.CalculatedAmount, calculatedAmount), Constants.CalculatedAmountSuccess);
        }

        private void goldAmount_TextChanged(object sender, EventArgs e)
        {
            calculateGoldButton.Enabled = int.TryParse(goldAmount.Text, out _);
        }

        private void saveSettingsButton_Click(object sender, EventArgs e) {
            Properties.Settings.Default.usernameBox = usernameBox.Text;
            Properties.Settings.Default.hostBox = hostnameBox.Text;
            Properties.Settings.Default.databaseBox = databaseBox.Text;
            Properties.Settings.Default.guildapikey = guildapikey.Text;
            Properties.Settings.Default.leaderapikey = leaderapikey.Text;
            Properties.Settings.Default.Save();
        }

        private void addUserButton_Click(object sender, EventArgs e) {
            try {
                var ticketsToUpdate = 0;
                var userName = userEntryText.Text;

                if (int.TryParse(ticketsCount.Text, out var ticketsCounter)) {
                    ticketsToUpdate = ticketsCounter;
                }

                // Init the MySqlCommand class
                var command = new MySqlCommand
                {
                    CommandText = "call Add_Lotto_user(@p1, @p2)"
                };

                /*
                 * Build and execute the stored procedure
                 * 
                 * */
                command.Parameters.AddWithValue("@p1", userName);
                command.Parameters.AddWithValue("@p2", ticketsToUpdate);
                command.Connection = _connection;

                command.ExecuteNonQuery();

                userEntryText.Clear();
                ticketsCount.Clear();

                addUserButton.Enabled = false;

                MessageBox.Show($"Inserted/Updated {userName}, with {ticketsToUpdate} rolls.", "Success!");
            } catch (Exception ex) {
                //Console.WriteLine("Error: {0}", ex);
                MessageBox.Show(string.Format(Constants.ErrorWithVar, ex), Constants.ErrorText);
            }
        }

        private void userEntryText_TextChanged(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(userEntryText.Text) && (!string.IsNullOrEmpty(ticketsCount.Text)) && _isConnected)
            {
                addUserButton.Enabled = !_generatedList || _guildRoster.Contains(userEntryText.Text);
            }
            else
            {
                addUserButton.Enabled = false;
            }
        }

        private void ticketsCount_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userEntryText.Text) && (!string.IsNullOrEmpty(ticketsCount.Text)) && _isConnected)
            {
                addUserButton.Enabled = !_generatedList || _guildRoster.Contains(userEntryText.Text);
            }
            else
            {
                addUserButton.Enabled = false;
            }
        }

        private void rollsDropdown_SelectedIndexChanged(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(userEntryText.Text) && (!string.IsNullOrEmpty(ticketsCount.Text)) && _isConnected == true) {
                addUserButton.Enabled = true;
            } else {
                addUserButton.Enabled = false;
            }
        }

        private void supportForumsToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(VariableConstants.SupportForums);
        }

        private void lottoSiteToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(VariableConstants.LottoWebPage);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void Link_Clicked(object sender, LinkClickedEventArgs e) {
//            Console.WriteLine("Clicked!");
//            Console.WriteLine(e.LinkText);
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void clearDatabase_Click(object sender, EventArgs e) {
            if (_isConnected == true) {
                var confirmReset = MessageBox.Show("!!! WARNING WARNING WARNING WARNING WARNING !!!\n" +
                                                "Clicking yes will clear all current lotto participants.",
                                                "Confirm database clear!?", MessageBoxButtons.YesNo);

                if (confirmReset == DialogResult.Yes) {
                    /*
                    * Confirm again...then build
                    * Build and execute the stored procedure
                    * 
                    */
                    var confirmReset2 = MessageBox.Show("!!! WARNING WARNING WARNING WARNING WARNING !!!\n" +
                                                "ARE YOU 100% SURE YOU WANT TO CLEAR THE DATABASE?\n" +
                                                "THERE IS NO GOING BACK FROM THIS!!!!",
                                                "ARE YOU 100% SURE?", MessageBoxButtons.YesNo);
                    if (confirmReset2 == DialogResult.Yes) {
                        var command = new MySqlCommand();
                        command.CommandText = "call Clear_Lotto_Users()";
                        command.Connection = _connection;

                        command.ExecuteNonQuery();
                    } else {
                        return;
                    }
                } else {
                    return;
                }
            } else {
                // This should never happen, since the button is disabled at launch, but to be safe
                MessageBox.Show("Please connect to the database.", "Error");
            }
        }
    }

    public static class EnumerableExtensionsEx {
        public static AutoCompleteStringCollection ToAutoCompleteStringCollection (
            this IEnumerable<string> enumerable) {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            var autoComplete = new AutoCompleteStringCollection();
            foreach (var item in enumerable) autoComplete.Add(item);
            return autoComplete;
        }
    }
}