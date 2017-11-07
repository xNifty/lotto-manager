using System;
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

        BackgroundWorker bgw = new BackgroundWorker();

        private MySqlConnection connection;
        private bool isConnected = false;
        private bool generatedList = false;
        private Dictionary<string, string> dict = new Dictionary<string, string>();
        private List<string> randomList = new List<string>();
        private List<string> winnerList = new List<string>();
        private List<string> guildRoster = new List<string>();

        public Form1() {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            this.DoubleBuffered = true;

            //guildRoster.ForEach(Console.WriteLine);

            userEntryText.AutoCompleteMode = AutoCompleteMode.Suggest;
            userEntryText.AutoCompleteSource = AutoCompleteSource.CustomSource;

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) {
                System.Deployment.Application.ApplicationDeployment cd = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                Version version = cd.CurrentVersion;
                Console.WriteLine(version);
                Text = Text + " - " + version.Major + "." + version.Minor + "." + version.Build + "." + version.Revision;
            } else {
                var version = "Debug Mode";
                Text = Text + " - " + version;
            }

            rollButton.Enabled = false;
            listResetButton.Enabled = false;
            rollBox.Enabled = false;
            richTextBox1.DetectUrls = true;

            if (isConnected == true) {
                clearDatabase.Enabled = true;
            } else {
                clearDatabase.Enabled = false;
            }

            usernameBox.Text = Properties.Settings.Default.usernameBox;
            hostnameBox.Text = Properties.Settings.Default.hostBox;
            databaseBox.Text = Properties.Settings.Default.databaseBox;
            guildapikey.Text = Properties.Settings.Default.guildapikey;
            leaderapikey.Text = Properties.Settings.Default.leaderapikey;
        }

        private void rollBox_TextChanged(object sender, EventArgs e) {
            int rolls;
            //MessageBox.Show(isConnected.ToString());
            try {
                if ((int.TryParse(rollBox.Text, out rolls)) && (isConnected == true) && (randomList.Any())) {
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
            int rollCount;
            int.TryParse(rollBox.Text, out rollCount);
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

            if (!backgroundWorker2.IsBusy) {
                rollButton.Enabled = true;
                rollingProgress.Style = ProgressBarStyle.Continuous;
            }
            
            //winnerBox.Text = randomizeList(rollCount);
        }

        void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e) {

            Tuple<int> rolls = e.Argument as Tuple<int>;
            Tuple<string, List<string>> returnedResults = e.Argument as Tuple<string, List<string>>;


            returnedResults = RandomizeList.selectWinner(rolls.Item1, randomList);

            //String winner = RandomizeList.selectWinner(rolls.Item1, randomList).Item1;
            String winner = returnedResults.Item1;

            if (winnerList.Any()) {
                winnerList.Clear();
                winnerList = returnedResults.Item2;
            } else {
                winnerList = returnedResults.Item2;
            }

            e.Result = Tuple.Create<String>(winner);
        }

        void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            Console.WriteLine("Post-run History: {0}", winnerList.Count);
            Tuple<String> res = e.Result as Tuple<String>;
            winnerBox.Text = res.Item1;
            wonItemsBox.Enabled = true;
        }

        // Controls panel border
        private void panel1_Paint(object sender, PaintEventArgs e) {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.Gold, 3, ButtonBorderStyle.Solid, Color.Gold, 3, ButtonBorderStyle.Solid,
                                    Color.Gold, 3, ButtonBorderStyle.Solid, Color.Gold, 3, ButtonBorderStyle.Solid);
        }


        // Attempt connection to MySQL
        private bool OpenConnection(MySqlConnection connection) {
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
            string databaseUsername;
            string databasePassword;
            string databaseHost;
            string databaseName;
            string guildLeadAPI;
            string leaderAPI;

            databaseUsername = usernameBox.Text;
            databasePassword = passwordBox.Text;
            databaseHost = hostnameBox.Text;
            databaseName = databaseBox.Text;
            guildLeadAPI = guildapikey.Text;
            leaderAPI = leaderapikey.Text;

            //MessageBox.Show(databasePassword.ToString());

            if (databaseUsername == "" || databasePassword == "" || databaseHost == "" || databaseName == "" || guildLeadAPI == "" || leaderAPI == "") {
                MessageBox.Show("Please fill out all connection details.");
                return;
            }

            // Oh god this is bad...really should redo
            string connectionString;
            connectionString = "SERVER=" + databaseHost + "; PORT = 3306 ;" + "DATABASE=" + databaseName + ";" + "UID=" + databaseUsername + ";" + "PASSWORD=" + databasePassword + ";";

            connection = new MySqlConnection(connectionString);

            if (OpenConnection(connection)) {
                connectionLabel.ForeColor = Color.Green;
                connectionLabel.Text = "Database: Connected!";
                connectionButton.Enabled = false;
                usernameBox.Enabled = false;
                passwordBox.Enabled = false;
                hostnameBox.Enabled = false;
                databaseBox.Enabled = false;
                guildapikey.Enabled = false;
                leaderapikey.Enabled = false;
                isConnected = true;
                listResetButton.Enabled = true;
                rollBox.Enabled = true;
                clearDatabase.Enabled = true;
                //MessageBox.Show("Connected!");
            } else {
                connectionLabel.ForeColor = Color.Red;
                connectionLabel.Text = "Database: Not Connected!";
                connectionButton.Enabled = true;
                usernameBox.Enabled = true;
                passwordBox.Enabled = true;
                hostnameBox.Enabled = true;
                databaseBox.Enabled = true;
                guildapikey.Enabled = true;
                leaderapikey.Enabled = true;
                isConnected = false;
                //MessageBox.Show("Connection failed...");
            }

            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    string guildID = guildapikey.Text;
                    string guildLeaderAPI = leaderapikey.Text;
                    string baseURL = "https://api.guildwars2.com/v2/guild/";
                    string accessURL = baseURL + guildID + "/" + "members?access_token=" + guildLeaderAPI;
                    Console.WriteLine(accessURL);
                    var json = webClient.DownloadString(accessURL);
                    dynamic jsonObj = JsonConvert.DeserializeObject(json);

                    foreach (var obj in jsonObj)
                    {
                        //Console.WriteLine(obj.name);
                        guildRoster.Add((string)obj.name);
                    }

                    generatedList = true;
                }
            }
            catch
            {
                generatedList = false;
            }

            if (generatedList)
            {
                userEntryText.AutoCompleteCustomSource = guildRoster.ToAutoCompleteStringCollection();
                apistatus.ForeColor = Color.Green;
                apistatus.Text = "GW2 API Status: Connected";
            }
            else
            {
                apistatus.ForeColor = Color.Red;
                apistatus.Text = "GW2 API Status: Not Connected";
            }
        }

        private void listResetButton_Click(object sender, EventArgs e) {
            var confirmReset = MessageBox.Show("Are you sure you wish to build the roll list for this session?\n" + 
                                                "Doing so will clear any currently created list.",
                                                "Confirm reset!", MessageBoxButtons.YesNo);

            if (confirmReset == DialogResult.Yes) {
                randomList.Clear();
                dict.Clear();
                rollBox.Clear();
                if (!randomList.Any()) {
                    try {
                        MySqlCommand command = new MySqlCommand();
                        MySqlDataReader reader;
                        command.CommandText = "call List_Lotto_Users()";
                        command.Connection = connection;

                        //reader = command.ExecuteReader();

                        using (reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                dict.Add(reader[0].ToString(), reader[1].ToString());
                            }
                        }

                        // Take the number of tickets, and add that many entries to the List
                        foreach (KeyValuePair<string, string> kvpList in dict) {
                            int tickets;
                            int.TryParse(kvpList.Value, out tickets);

                            for (int i = 0; i < tickets; i++) {
                                randomList.Add(kvpList.Key);
                            }
                        }

                        randomList.Shuffle();

                        // Printing out the List
                        //randomList.ForEach(Console.WriteLine);
                        MessageBox.Show("List generation completed.");
                    } catch (Exception ex) {
                        //Console.WriteLine("Error: {0}", ex);
                        //winnerBox.Text = "Error";
                        if (ex is System.InvalidOperationException) {
                            try {
                                OpenConnection(connection);
                            } catch (Exception exp) {
                                MessageBox.Show(string.Format("Error on reconnect: {0}", exp), "Error!");
                            }
                        } else {
                            MessageBox.Show(string.Format("Error: {0}", ex), "Error!");
                        }
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
                int rolls;
                int.TryParse(rollBox.Text, out rolls);
                var items = wonItemsBox.Text;
                string rollHistory;
                DateTime date = DateTime.Now;

                Console.WriteLine("Count: {0}", winnerList.Count);
                for (int j = 0; j < winnerList.Count; j++)
                    Console.WriteLine("History list: {0}", winnerList[j]);

                // Init the MySqlCommand class
                MySqlCommand command = new MySqlCommand();

                // Let's make sure the history list has objects....otherwise, throw an error and do nothing
                if (!winnerList.Any()) {
                    MessageBox.Show("There was an error with the roll history list and it could not be submitted. Please " +
                                    "submit the winner information manually through the site.", "Error!");
                    return;
                }

                rollHistory = string.Join(Environment.NewLine, winnerList);

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
                
                command.Connection = connection;

                command.ExecuteNonQuery();

                winnerBox.Clear();
                wonItemsBox.Clear();
                rollBox.Clear();

                winnerBox.Enabled = false;
                wonItemsBox.Enabled = false;
               
                MessageBox.Show(string.Format("Inserted {0}, with {1} rolls and items: {2}.", winner, rolls, items), "Success!");
                winnerList.Clear();
            } catch (Exception ex) {
                //Console.WriteLine("Error: {0}", ex);
                MessageBox.Show(string.Format("Error occured: {0}", ex), "Error!");
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
            double amount;
            double.TryParse(goldAmount.Text, out amount);
            double percent = 0.70;
            double calculatedAmount = (amount * percent);
            MessageBox.Show(string.Format("Calculated amount: {0}", calculatedAmount), "Calculated gold amount!");
        }

        private void goldAmount_TextChanged(object sender, EventArgs e) {
            int gold;
            if (int.TryParse(goldAmount.Text, out gold)) {
                calculateGoldButton.Enabled = true;
            } else {
                calculateGoldButton.Enabled = false;
            }
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
                int ticketsCounter;
                int ticketsToUpdate = 0;
                var userName = userEntryText.Text;

                if (int.TryParse(ticketsCount.Text, out ticketsCounter)) {
                    ticketsToUpdate = ticketsCounter;
                }

                // Init the MySqlCommand class
                MySqlCommand command = new MySqlCommand();

                /*
                 * Build and execute the stored procedure
                 * 
                 * */
                command.CommandText = "call Add_Lotto_user(@p1, @p2)";
                command.Parameters.AddWithValue("@p1", userName);
                command.Parameters.AddWithValue("@p2", ticketsToUpdate);
                command.Connection = connection;

                command.ExecuteNonQuery();

                userEntryText.Clear();
                ticketsCount.Clear();

                addUserButton.Enabled = false;

                MessageBox.Show(string.Format("Inserted/Updated {0}, with {1} rolls.", userName, ticketsToUpdate), "Success!");
            } catch (Exception ex) {
                //Console.WriteLine("Error: {0}", ex);
                MessageBox.Show(string.Format("Error occured: {0}", ex), "Error!");
            }
        }

        private void userEntryText_TextChanged(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(userEntryText.Text) && (!string.IsNullOrEmpty(ticketsCount.Text)) && isConnected)
            {
                if (generatedList)
                {
                    if (guildRoster.Contains(userEntryText.Text))
                    {
                        addUserButton.Enabled = true;
                    }
                    else
                    {
                        addUserButton.Enabled = false;
                    }
                }
                else
                {
                    addUserButton.Enabled = true;
                }
            }
            else
            {
                addUserButton.Enabled = false;
            }
        }

        private void ticketsCount_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userEntryText.Text) && (!string.IsNullOrEmpty(ticketsCount.Text)) && isConnected)
            {
                if (generatedList)
                {
                    if (guildRoster.Contains(userEntryText.Text))
                    {
                        addUserButton.Enabled = true;
                    }
                    else
                    {
                        addUserButton.Enabled = false;
                    }
                }
                else
                {
                    addUserButton.Enabled = true;
                }
            }
            else
            {
                addUserButton.Enabled = false;
            }
        }

        private void rollsDropdown_SelectedIndexChanged(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(userEntryText.Text) && (!string.IsNullOrEmpty(ticketsCount.Text)) && isConnected == true) {
                addUserButton.Enabled = true;
            } else {
                addUserButton.Enabled = false;
            }
        }

        private void supportForumsToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://snoring.ninja/forums");
        }

        private void lottoSiteToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://endgame.wtf/lotto");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void Link_Clicked(object sender, LinkClickedEventArgs e) {
            Console.WriteLine("Clicked!");
            Console.WriteLine(e.LinkText);
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void clearDatabase_Click(object sender, EventArgs e) {
            if (isConnected == true) {
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
                        MySqlCommand command = new MySqlCommand();
                        command.CommandText = "call Clear_Lotto_Users()";
                        command.Connection = connection;

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

    // I'm not even sure this is doing anything useful at this point....
    class DrawPanel : Panel {
        public DrawPanel() {
            this.DoubleBuffered = true;
        }
    }

    public static class EnumerableExtensionsEx {
        public static AutoCompleteStringCollection ToAutoCompleteStringCollection (
            this IEnumerable<string> enumerable) {
            if (enumerable == null) throw new ArgumentNullException("enumerable");
            var autoComplete = new AutoCompleteStringCollection();
            foreach (var item in enumerable) autoComplete.Add(item);
            return autoComplete;
        }
    }
}