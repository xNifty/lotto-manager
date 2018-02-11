namespace LottoManager {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.aboutTab = new System.Windows.Forms.TabControl();
            this.addMember = new System.Windows.Forms.TabPage();
            this.ticketsCount = new System.Windows.Forms.TextBox();
            this.leaderapikey = new System.Windows.Forms.TextBox();
            this.leaderapi = new System.Windows.Forms.Label();
            this.guildapikey = new System.Windows.Forms.TextBox();
            this.guildApiLabel = new System.Windows.Forms.Label();
            this.apistatus = new System.Windows.Forms.Label();
            this.addUserButton = new System.Windows.Forms.Button();
            this.userEntryText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.databaseBox = new System.Windows.Forms.TextBox();
            this.hostnameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.connectionButton = new System.Windows.Forms.Button();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.Roll = new System.Windows.Forms.TabPage();
            this.wonItemsBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.submitWinnerButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clearDatabase = new System.Windows.Forms.Button();
            this.calculateGoldButton = new System.Windows.Forms.Button();
            this.goldAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listResetButton = new System.Windows.Forms.Button();
            this.rollingProgress = new System.Windows.Forms.ProgressBar();
            this.rollButton = new System.Windows.Forms.Button();
            this.winnerBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rollBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportForumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lottoSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTab.SuspendLayout();
            this.addMember.SuspendLayout();
            this.Roll.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // aboutTab
            // 
            this.aboutTab.Controls.Add(this.addMember);
            this.aboutTab.Controls.Add(this.Roll);
            this.aboutTab.Controls.Add(this.tabPage1);
            this.aboutTab.Location = new System.Drawing.Point(-1, 24);
            this.aboutTab.Name = "aboutTab";
            this.aboutTab.SelectedIndex = 0;
            this.aboutTab.Size = new System.Drawing.Size(707, 517);
            this.aboutTab.TabIndex = 0;
            // 
            // addMember
            // 
            this.addMember.BackColor = System.Drawing.Color.Goldenrod;
            this.addMember.Controls.Add(this.ticketsCount);
            this.addMember.Controls.Add(this.leaderapikey);
            this.addMember.Controls.Add(this.leaderapi);
            this.addMember.Controls.Add(this.guildapikey);
            this.addMember.Controls.Add(this.guildApiLabel);
            this.addMember.Controls.Add(this.apistatus);
            this.addMember.Controls.Add(this.addUserButton);
            this.addMember.Controls.Add(this.userEntryText);
            this.addMember.Controls.Add(this.label3);
            this.addMember.Controls.Add(this.databaseBox);
            this.addMember.Controls.Add(this.hostnameBox);
            this.addMember.Controls.Add(this.label7);
            this.addMember.Controls.Add(this.label6);
            this.addMember.Controls.Add(this.passwordBox);
            this.addMember.Controls.Add(this.usernameBox);
            this.addMember.Controls.Add(this.label5);
            this.addMember.Controls.Add(this.usernameLabel);
            this.addMember.Controls.Add(this.connectionLabel);
            this.addMember.Controls.Add(this.connectionButton);
            this.addMember.Controls.Add(this.saveSettingsButton);
            this.addMember.Location = new System.Drawing.Point(4, 22);
            this.addMember.Name = "addMember";
            this.addMember.Padding = new System.Windows.Forms.Padding(3);
            this.addMember.Size = new System.Drawing.Size(699, 491);
            this.addMember.TabIndex = 0;
            this.addMember.Text = "Add Member";
            // 
            // ticketsCount
            // 
            this.ticketsCount.Font = new System.Drawing.Font("Impact", 12F);
            this.ticketsCount.Location = new System.Drawing.Point(497, 82);
            this.ticketsCount.MaxLength = 2;
            this.ticketsCount.Name = "ticketsCount";
            this.ticketsCount.Size = new System.Drawing.Size(100, 27);
            this.ticketsCount.TabIndex = 28;
            this.ticketsCount.TextChanged += new System.EventHandler(this.ticketsCount_TextChanged);
            // 
            // leaderapikey
            // 
            this.leaderapikey.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderapikey.Location = new System.Drawing.Point(164, 318);
            this.leaderapikey.Name = "leaderapikey";
            this.leaderapikey.Size = new System.Drawing.Size(466, 22);
            this.leaderapikey.TabIndex = 27;
            // 
            // leaderapi
            // 
            this.leaderapi.AutoSize = true;
            this.leaderapi.BackColor = System.Drawing.Color.Transparent;
            this.leaderapi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderapi.ForeColor = System.Drawing.Color.White;
            this.leaderapi.Location = new System.Drawing.Point(75, 318);
            this.leaderapi.Name = "leaderapi";
            this.leaderapi.Size = new System.Drawing.Size(72, 21);
            this.leaderapi.TabIndex = 26;
            this.leaderapi.Text = "API Key:";
            // 
            // guildapikey
            // 
            this.guildapikey.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guildapikey.Location = new System.Drawing.Point(164, 281);
            this.guildapikey.Name = "guildapikey";
            this.guildapikey.Size = new System.Drawing.Size(466, 22);
            this.guildapikey.TabIndex = 25;
            // 
            // guildApiLabel
            // 
            this.guildApiLabel.AutoSize = true;
            this.guildApiLabel.BackColor = System.Drawing.Color.Transparent;
            this.guildApiLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guildApiLabel.ForeColor = System.Drawing.Color.White;
            this.guildApiLabel.Location = new System.Drawing.Point(71, 281);
            this.guildApiLabel.Name = "guildApiLabel";
            this.guildApiLabel.Size = new System.Drawing.Size(76, 21);
            this.guildApiLabel.TabIndex = 24;
            this.guildApiLabel.Text = "Guild ID:";
            // 
            // apistatus
            // 
            this.apistatus.AutoSize = true;
            this.apistatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.apistatus.ForeColor = System.Drawing.Color.Red;
            this.apistatus.Location = new System.Drawing.Point(9, 456);
            this.apistatus.Name = "apistatus";
            this.apistatus.Size = new System.Drawing.Size(222, 21);
            this.apistatus.TabIndex = 23;
            this.apistatus.Text = "GW2 Api Status: Not Pinged";
            // 
            // addUserButton
            // 
            this.addUserButton.Enabled = false;
            this.addUserButton.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addUserButton.Location = new System.Drawing.Point(420, 115);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(177, 28);
            this.addUserButton.TabIndex = 3;
            this.addUserButton.Text = "Submit User";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            // 
            // userEntryText
            // 
            this.userEntryText.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userEntryText.Location = new System.Drawing.Point(105, 82);
            this.userEntryText.Name = "userEntryText";
            this.userEntryText.Size = new System.Drawing.Size(386, 27);
            this.userEntryText.TabIndex = 2;
            this.userEntryText.TextChanged += new System.EventHandler(this.userEntryText_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(205, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 60);
            this.label3.TabIndex = 0;
            this.label3.Text = "Add Lotto User";
            // 
            // databaseBox
            // 
            this.databaseBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::LottoManager.Properties.Settings.Default, "databaseBox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.databaseBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseBox.Location = new System.Drawing.Point(456, 235);
            this.databaseBox.Name = "databaseBox";
            this.databaseBox.Size = new System.Drawing.Size(173, 22);
            this.databaseBox.TabIndex = 14;
            this.databaseBox.Text = global::LottoManager.Properties.Settings.Default.databaseBox;
            // 
            // hostnameBox
            // 
            this.hostnameBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::LottoManager.Properties.Settings.Default, "hostBox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.hostnameBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostnameBox.Location = new System.Drawing.Point(456, 195);
            this.hostnameBox.Name = "hostnameBox";
            this.hostnameBox.Size = new System.Drawing.Size(174, 22);
            this.hostnameBox.TabIndex = 13;
            this.hostnameBox.Text = global::LottoManager.Properties.Settings.Default.hostBox;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(365, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "Database:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(401, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Host:";
            // 
            // passwordBox
            // 
            this.passwordBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordBox.Location = new System.Drawing.Point(164, 235);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(174, 22);
            this.passwordBox.TabIndex = 10;
            // 
            // usernameBox
            // 
            this.usernameBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameBox.Location = new System.Drawing.Point(164, 196);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(174, 22);
            this.usernameBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(61, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Password:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.White;
            this.usernameLabel.Location = new System.Drawing.Point(56, 196);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(91, 21);
            this.usernameLabel.TabIndex = 7;
            this.usernameLabel.Text = "Username:";
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.BackColor = System.Drawing.Color.Transparent;
            this.connectionLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionLabel.ForeColor = System.Drawing.Color.Red;
            this.connectionLabel.Location = new System.Drawing.Point(483, 456);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(209, 21);
            this.connectionLabel.TabIndex = 6;
            this.connectionLabel.Text = "Database: Not Connected!";
            // 
            // connectionButton
            // 
            this.connectionButton.Location = new System.Drawing.Point(555, 346);
            this.connectionButton.Name = "connectionButton";
            this.connectionButton.Size = new System.Drawing.Size(75, 23);
            this.connectionButton.TabIndex = 15;
            this.connectionButton.Text = "Connect";
            this.connectionButton.UseVisualStyleBackColor = true;
            this.connectionButton.Click += new System.EventHandler(this.connectionButton_Click);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.saveSettingsButton.ForeColor = System.Drawing.Color.Black;
            this.saveSettingsButton.Location = new System.Drawing.Point(164, 346);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(111, 23);
            this.saveSettingsButton.TabIndex = 22;
            this.saveSettingsButton.Text = "Save Settings";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // Roll
            // 
            this.Roll.BackColor = System.Drawing.Color.Goldenrod;
            this.Roll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Roll.Controls.Add(this.wonItemsBox);
            this.Roll.Controls.Add(this.label8);
            this.Roll.Controls.Add(this.submitWinnerButton);
            this.Roll.Controls.Add(this.panel1);
            this.Roll.Controls.Add(this.rollingProgress);
            this.Roll.Controls.Add(this.rollButton);
            this.Roll.Controls.Add(this.winnerBox);
            this.Roll.Controls.Add(this.label2);
            this.Roll.Controls.Add(this.rollBox);
            this.Roll.Controls.Add(this.label1);
            this.Roll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Roll.Location = new System.Drawing.Point(4, 22);
            this.Roll.Name = "Roll";
            this.Roll.Padding = new System.Windows.Forms.Padding(3);
            this.Roll.Size = new System.Drawing.Size(699, 491);
            this.Roll.TabIndex = 1;
            this.Roll.Text = "ROLL!";
            // 
            // wonItemsBox
            // 
            this.wonItemsBox.Enabled = false;
            this.wonItemsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wonItemsBox.Location = new System.Drawing.Point(157, 285);
            this.wonItemsBox.Multiline = true;
            this.wonItemsBox.Name = "wonItemsBox";
            this.wonItemsBox.Size = new System.Drawing.Size(394, 44);
            this.wonItemsBox.TabIndex = 19;
            this.wonItemsBox.TextChanged += new System.EventHandler(this.wonItemsBox_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(302, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 39);
            this.label8.TabIndex = 21;
            this.label8.Text = "Items";
            // 
            // submitWinnerButton
            // 
            this.submitWinnerButton.Enabled = false;
            this.submitWinnerButton.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitWinnerButton.Location = new System.Drawing.Point(457, 329);
            this.submitWinnerButton.Name = "submitWinnerButton";
            this.submitWinnerButton.Size = new System.Drawing.Size(95, 30);
            this.submitWinnerButton.TabIndex = 20;
            this.submitWinnerButton.Text = "Submit";
            this.submitWinnerButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.submitWinnerButton.UseVisualStyleBackColor = true;
            this.submitWinnerButton.Click += new System.EventHandler(this.submitWinnerButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.clearDatabase);
            this.panel1.Controls.Add(this.calculateGoldButton);
            this.panel1.Controls.Add(this.goldAmount);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.listResetButton);
            this.panel1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Location = new System.Drawing.Point(10, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 307);
            this.panel1.TabIndex = 18;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // clearDatabase
            // 
            this.clearDatabase.Enabled = false;
            this.clearDatabase.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold);
            this.clearDatabase.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.clearDatabase.Location = new System.Drawing.Point(6, 124);
            this.clearDatabase.Name = "clearDatabase";
            this.clearDatabase.Size = new System.Drawing.Size(111, 46);
            this.clearDatabase.TabIndex = 22;
            this.clearDatabase.Text = "Clear Database";
            this.clearDatabase.UseVisualStyleBackColor = true;
            this.clearDatabase.Click += new System.EventHandler(this.clearDatabase_Click);
            // 
            // calculateGoldButton
            // 
            this.calculateGoldButton.Enabled = false;
            this.calculateGoldButton.Font = new System.Drawing.Font("Georgia", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculateGoldButton.ForeColor = System.Drawing.Color.Black;
            this.calculateGoldButton.Location = new System.Drawing.Point(12, 277);
            this.calculateGoldButton.Name = "calculateGoldButton";
            this.calculateGoldButton.Size = new System.Drawing.Size(98, 23);
            this.calculateGoldButton.TabIndex = 21;
            this.calculateGoldButton.Text = "Calculate Gold";
            this.calculateGoldButton.UseVisualStyleBackColor = true;
            this.calculateGoldButton.Click += new System.EventHandler(this.calculateGoldButton_Click);
            // 
            // goldAmount
            // 
            this.goldAmount.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goldAmount.Location = new System.Drawing.Point(11, 254);
            this.goldAmount.Name = "goldAmount";
            this.goldAmount.Size = new System.Drawing.Size(100, 23);
            this.goldAmount.TabIndex = 20;
            this.goldAmount.TextChanged += new System.EventHandler(this.goldAmount_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(29, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Controls";
            // 
            // listResetButton
            // 
            this.listResetButton.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listResetButton.ForeColor = System.Drawing.Color.Black;
            this.listResetButton.Location = new System.Drawing.Point(6, 32);
            this.listResetButton.Name = "listResetButton";
            this.listResetButton.Size = new System.Drawing.Size(111, 38);
            this.listResetButton.TabIndex = 17;
            this.listResetButton.Text = "Build List";
            this.listResetButton.UseVisualStyleBackColor = true;
            this.listResetButton.Click += new System.EventHandler(this.listResetButton_Click);
            // 
            // rollingProgress
            // 
            this.rollingProgress.Location = new System.Drawing.Point(157, 105);
            this.rollingProgress.Name = "rollingProgress";
            this.rollingProgress.Size = new System.Drawing.Size(393, 11);
            this.rollingProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.rollingProgress.TabIndex = 16;
            // 
            // rollButton
            // 
            this.rollButton.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollButton.Location = new System.Drawing.Point(455, 117);
            this.rollButton.Name = "rollButton";
            this.rollButton.Size = new System.Drawing.Size(95, 30);
            this.rollButton.TabIndex = 5;
            this.rollButton.Text = "Roll!";
            this.rollButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rollButton.UseVisualStyleBackColor = true;
            this.rollButton.Click += new System.EventHandler(this.rollButton_Click);
            // 
            // winnerBox
            // 
            this.winnerBox.BackColor = System.Drawing.SystemColors.Window;
            this.winnerBox.Enabled = false;
            this.winnerBox.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winnerBox.Location = new System.Drawing.Point(157, 198);
            this.winnerBox.Name = "winnerBox";
            this.winnerBox.ReadOnly = true;
            this.winnerBox.Size = new System.Drawing.Size(393, 47);
            this.winnerBox.TabIndex = 3;
            this.winnerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.winnerBox.TextChanged += new System.EventHandler(this.rollBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(291, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "Winner!";
            // 
            // rollBox
            // 
            this.rollBox.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollBox.Location = new System.Drawing.Point(157, 56);
            this.rollBox.MaxLength = 3;
            this.rollBox.Name = "rollBox";
            this.rollBox.Size = new System.Drawing.Size(393, 47);
            this.rollBox.TabIndex = 1;
            this.rollBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rollBox.TextChanged += new System.EventHandler(this.rollBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(159, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter a number and hit \"Roll!\"";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Goldenrod;
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(699, 491);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "About";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(153, 88);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(397, 132);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.Link_Clicked);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(153, 226);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(397, 146);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "New in this Version:\r\n- Internal Code Updates";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Impact", 50F);
            this.label9.Location = new System.Drawing.Point(254, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(193, 82);
            this.label9.TabIndex = 0;
            this.label9.Text = "About";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.linksToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(707, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // linksToolStripMenuItem
            // 
            this.linksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supportForumsToolStripMenuItem,
            this.lottoSiteToolStripMenuItem});
            this.linksToolStripMenuItem.Name = "linksToolStripMenuItem";
            this.linksToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.linksToolStripMenuItem.Text = "Links";
            // 
            // supportForumsToolStripMenuItem
            // 
            this.supportForumsToolStripMenuItem.Name = "supportForumsToolStripMenuItem";
            this.supportForumsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.supportForumsToolStripMenuItem.Text = "Support/Forums";
            this.supportForumsToolStripMenuItem.Click += new System.EventHandler(this.supportForumsToolStripMenuItem_Click);
            // 
            // lottoSiteToolStripMenuItem
            // 
            this.lottoSiteToolStripMenuItem.Name = "lottoSiteToolStripMenuItem";
            this.lottoSiteToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.lottoSiteToolStripMenuItem.Text = "Lotto Site";
            this.lottoSiteToolStripMenuItem.Click += new System.EventHandler(this.lottoSiteToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(707, 541);
            this.Controls.Add(this.aboutTab);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nifty Lotto Manager";
            this.aboutTab.ResumeLayout(false);
            this.addMember.ResumeLayout(false);
            this.addMember.PerformLayout();
            this.Roll.ResumeLayout(false);
            this.Roll.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl aboutTab;
        private System.Windows.Forms.TabPage addMember;
        private System.Windows.Forms.TabPage Roll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rollBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox winnerBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button rollButton;
        private System.Windows.Forms.Label connectionLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox databaseBox;
        private System.Windows.Forms.TextBox hostnameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button connectionButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ProgressBar rollingProgress;
        private System.Windows.Forms.Button listResetButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button submitWinnerButton;
        private System.Windows.Forms.TextBox wonItemsBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button calculateGoldButton;
        private System.Windows.Forms.TextBox goldAmount;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.TextBox userEntryText;
        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supportForumsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lottoSiteToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button clearDatabase;
        private System.Windows.Forms.Label apistatus;
        private System.Windows.Forms.TextBox leaderapikey;
        private System.Windows.Forms.Label leaderapi;
        private System.Windows.Forms.TextBox guildapikey;
        private System.Windows.Forms.Label guildApiLabel;
        private System.Windows.Forms.TextBox ticketsCount;
    }
}

