namespace BatteryMonitorApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblBatteryPercentage = new Label();
            lblMountStatus = new Label();
            lblChargingStatus = new Label();
            lblConnectionStatus = new Label();
            cboPorts = new ComboBox();
            btnRefreshPorts = new Button();
            btnConnect = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            cbxLow = new ComboBox();
            cbxHigh = new ComboBox();
            btnSetLow = new Button();
            btnSetHigh = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            groupBox1 = new GroupBox();
            label10 = new Label();
            txtHighMessage = new TextBox();
            txtLowMessage = new TextBox();
            label9 = new Label();
            label8 = new Label();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            closeToolStripMenuItem = new ToolStripMenuItem();
            linkLabel1 = new LinkLabel();
            statusStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblBatteryPercentage
            // 
            lblBatteryPercentage.AutoSize = true;
            lblBatteryPercentage.Location = new Point(174, 10);
            lblBatteryPercentage.Name = "lblBatteryPercentage";
            lblBatteryPercentage.Size = new Size(72, 20);
            lblBatteryPercentage.TabIndex = 0;
            lblBatteryPercentage.Text = "Loading...";
            // 
            // lblMountStatus
            // 
            lblMountStatus.AutoSize = true;
            lblMountStatus.Location = new Point(174, 52);
            lblMountStatus.Name = "lblMountStatus";
            lblMountStatus.Size = new Size(72, 20);
            lblMountStatus.TabIndex = 1;
            lblMountStatus.Text = "Loading...";
            // 
            // lblChargingStatus
            // 
            lblChargingStatus.AutoSize = true;
            lblChargingStatus.Location = new Point(174, 99);
            lblChargingStatus.Name = "lblChargingStatus";
            lblChargingStatus.Size = new Size(72, 20);
            lblChargingStatus.TabIndex = 2;
            lblChargingStatus.Text = "Loading...";
            // 
            // lblConnectionStatus
            // 
            lblConnectionStatus.AutoSize = true;
            lblConnectionStatus.Location = new Point(174, 140);
            lblConnectionStatus.Name = "lblConnectionStatus";
            lblConnectionStatus.Size = new Size(72, 20);
            lblConnectionStatus.TabIndex = 3;
            lblConnectionStatus.Text = "Loading...";
            // 
            // cboPorts
            // 
            cboPorts.FormattingEnabled = true;
            cboPorts.Location = new Point(174, 183);
            cboPorts.Margin = new Padding(3, 4, 3, 4);
            cboPorts.Name = "cboPorts";
            cboPorts.Size = new Size(138, 28);
            cboPorts.TabIndex = 4;
            // 
            // btnRefreshPorts
            // 
            btnRefreshPorts.Location = new Point(14, 243);
            btnRefreshPorts.Margin = new Padding(3, 4, 3, 4);
            btnRefreshPorts.Name = "btnRefreshPorts";
            btnRefreshPorts.Size = new Size(115, 31);
            btnRefreshPorts.TabIndex = 5;
            btnRefreshPorts.Text = "Refresh Ports";
            btnRefreshPorts.UseVisualStyleBackColor = true;
            btnRefreshPorts.Click += btnRefreshPorts_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(174, 243);
            btnConnect.Margin = new Padding(3, 4, 3, 4);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(138, 31);
            btnConnect.TabIndex = 6;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 10);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 7;
            label1.Text = "Battery Percentage :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 52);
            label2.Name = "label2";
            label2.Size = new Size(124, 20);
            label2.TabIndex = 8;
            label2.Text = "Mounting Status :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 99);
            label3.Name = "label3";
            label3.Size = new Size(120, 20);
            label3.TabIndex = 9;
            label3.Text = "Charging Status :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 140);
            label4.Name = "label4";
            label4.Size = new Size(135, 20);
            label4.TabIndex = 10;
            label4.Text = "Connection Status :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 187);
            label5.Name = "label5";
            label5.Size = new Size(114, 20);
            label5.TabIndex = 11;
            label5.Text = "Available Ports :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 302);
            label6.Name = "label6";
            label6.Size = new Size(109, 20);
            label6.TabIndex = 12;
            label6.Text = "Low threshold :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 351);
            label7.Name = "label7";
            label7.Size = new Size(114, 20);
            label7.TabIndex = 13;
            label7.Text = "High threshold :";
            // 
            // cbxLow
            // 
            cbxLow.FormattingEnabled = true;
            cbxLow.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100" });
            cbxLow.Location = new Point(121, 298);
            cbxLow.Margin = new Padding(3, 4, 3, 4);
            cbxLow.Name = "cbxLow";
            cbxLow.Size = new Size(57, 28);
            cbxLow.TabIndex = 14;
            // 
            // cbxHigh
            // 
            cbxHigh.FormattingEnabled = true;
            cbxHigh.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100" });
            cbxHigh.Location = new Point(121, 347);
            cbxHigh.Margin = new Padding(3, 4, 3, 4);
            cbxHigh.Name = "cbxHigh";
            cbxHigh.Size = new Size(57, 28);
            cbxHigh.TabIndex = 15;
            // 
            // btnSetLow
            // 
            btnSetLow.Location = new Point(189, 296);
            btnSetLow.Margin = new Padding(3, 4, 3, 4);
            btnSetLow.Name = "btnSetLow";
            btnSetLow.Size = new Size(86, 31);
            btnSetLow.TabIndex = 16;
            btnSetLow.Text = "Set";
            btnSetLow.UseVisualStyleBackColor = true;
            btnSetLow.Click += btnSetLow_Click;
            // 
            // btnSetHigh
            // 
            btnSetHigh.Location = new Point(191, 346);
            btnSetHigh.Margin = new Padding(3, 4, 3, 4);
            btnSetHigh.Name = "btnSetHigh";
            btnSetHigh.Size = new Size(83, 31);
            btnSetHigh.TabIndex = 17;
            btnSetHigh.Text = "set";
            btnSetHigh.UseVisualStyleBackColor = true;
            btnSetHigh.Click += btnSetHigh_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 574);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(352, 26);
            statusStrip1.TabIndex = 18;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(50, 20);
            toolStripStatusLabel1.Text = "Ready";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtHighMessage);
            groupBox1.Controls.Add(txtLowMessage);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Location = new Point(14, 384);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(325, 153);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "Messages";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.AppWorkspace;
            label10.Location = new Point(16, 121);
            label10.Name = "label10";
            label10.Size = new Size(274, 19);
            label10.TabIndex = 4;
            label10.Text = "Set Messages to be sent to Cntroled device";
            // 
            // txtHighMessage
            // 
            txtHighMessage.Location = new Point(179, 80);
            txtHighMessage.Margin = new Padding(3, 4, 3, 4);
            txtHighMessage.Name = "txtHighMessage";
            txtHighMessage.Size = new Size(138, 27);
            txtHighMessage.TabIndex = 3;
            txtHighMessage.Text = "%LEVEL%";
            // 
            // txtLowMessage
            // 
            txtLowMessage.Location = new Point(179, 37);
            txtLowMessage.Margin = new Padding(3, 4, 3, 4);
            txtLowMessage.Name = "txtLowMessage";
            txtLowMessage.Size = new Size(138, 27);
            txtLowMessage.TabIndex = 2;
            txtLowMessage.Text = "%LEVEL%";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 84);
            label9.Name = "label9";
            label9.Size = new Size(176, 20);
            label9.TabIndex = 1;
            label9.Text = "High threshold message :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 41);
            label8.Name = "label8";
            label8.Size = new Size(171, 20);
            label8.TabIndex = 0;
            label8.Text = "Low threshold Message :";
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Battery Monitor";
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { closeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(115, 28);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(114, 24);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(264, 541);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(62, 20);
            linkLabel1.TabIndex = 20;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Settings";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 600);
            Controls.Add(linkLabel1);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip1);
            Controls.Add(btnSetHigh);
            Controls.Add(btnSetLow);
            Controls.Add(cbxHigh);
            Controls.Add(cbxLow);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnConnect);
            Controls.Add(btnRefreshPorts);
            Controls.Add(cboPorts);
            Controls.Add(lblConnectionStatus);
            Controls.Add(lblChargingStatus);
            Controls.Add(lblMountStatus);
            Controls.Add(lblBatteryPercentage);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Battery Monitor";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Resize += Form1_Resize;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBatteryPercentage;
        private Label lblMountStatus;
        private Label lblChargingStatus;
        private Label lblConnectionStatus;
        private ComboBox cboPorts;
        private Button btnRefreshPorts;
        private Button btnConnect;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox cbxLow;
        private ComboBox cbxHigh;
        private Button btnSetLow;
        private Button btnSetHigh;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private GroupBox groupBox1;
        private TextBox txtHighMessage;
        private TextBox txtLowMessage;
        private Label label9;
        private Label label8;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem closeToolStripMenuItem;
        private Label label10;
        private LinkLabel linkLabel1;
    }
}
