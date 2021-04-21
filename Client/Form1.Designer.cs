
namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSRun = new System.Windows.Forms.Button();
            this.btnSStop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textPath = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnScanStart = new System.Windows.Forms.Button();
            this.btnScanStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabScan = new System.Windows.Forms.TabPage();
            this.btnDelScan = new System.Windows.Forms.Button();
            this.dataScan = new System.Windows.Forms.DataGridView();
            this.scanPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddScan = new System.Windows.Forms.Button();
            this.tabMonitor = new System.Windows.Forms.TabPage();
            this.btnDelMonitor = new System.Windows.Forms.Button();
            this.dataMonitor = new System.Windows.Forms.DataGridView();
            this.dir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddMonitor = new System.Windows.Forms.Button();
            this.tabPlan = new System.Windows.Forms.TabPage();
            this.btnDelPlan = new System.Windows.Forms.Button();
            this.dataPlan = new System.Windows.Forms.DataGridView();
            this.path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.comboMinute1 = new System.Windows.Forms.ComboBox();
            this.comboMinute2 = new System.Windows.Forms.ComboBox();
            this.comboHour = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddPlan = new System.Windows.Forms.Button();
            this.textLog = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.tabScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataScan)).BeginInit();
            this.tabMonitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataMonitor)).BeginInit();
            this.tabPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPlan)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(96, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "no data";
            // 
            // btnSRun
            // 
            this.btnSRun.Enabled = false;
            this.btnSRun.Location = new System.Drawing.Point(193, 4);
            this.btnSRun.Name = "btnSRun";
            this.btnSRun.Size = new System.Drawing.Size(163, 23);
            this.btnSRun.TabIndex = 2;
            this.btnSRun.Text = "Run service";
            this.btnSRun.UseVisualStyleBackColor = true;
            this.btnSRun.Click += new System.EventHandler(this.btnSRun_Click);
            // 
            // btnSStop
            // 
            this.btnSStop.Enabled = false;
            this.btnSStop.Location = new System.Drawing.Point(362, 4);
            this.btnSStop.Name = "btnSStop";
            this.btnSStop.Size = new System.Drawing.Size(156, 23);
            this.btnSStop.TabIndex = 3;
            this.btnSStop.Text = "Stop service";
            this.btnSStop.UseVisualStyleBackColor = true;
            this.btnSStop.Click += new System.EventHandler(this.btnSStop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chosen path:";
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(88, 36);
            this.textPath.Name = "textPath";
            this.textPath.ReadOnly = true;
            this.textPath.Size = new System.Drawing.Size(429, 20);
            this.textPath.TabIndex = 5;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(12, 62);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(120, 23);
            this.btnFile.TabIndex = 6;
            this.btnFile.Text = "Choose file";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(138, 62);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(120, 23);
            this.btnFolder.TabIndex = 7;
            this.btnFolder.Text = "Choose directory";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // btnScanStart
            // 
            this.btnScanStart.Enabled = false;
            this.btnScanStart.Location = new System.Drawing.Point(272, 62);
            this.btnScanStart.Name = "btnScanStart";
            this.btnScanStart.Size = new System.Drawing.Size(120, 23);
            this.btnScanStart.TabIndex = 8;
            this.btnScanStart.Text = "Start scan";
            this.btnScanStart.UseVisualStyleBackColor = true;
            this.btnScanStart.Click += new System.EventHandler(this.btnScanStart_Click);
            // 
            // btnScanStop
            // 
            this.btnScanStop.Enabled = false;
            this.btnScanStop.Location = new System.Drawing.Point(398, 62);
            this.btnScanStop.Name = "btnScanStop";
            this.btnScanStop.Size = new System.Drawing.Size(120, 23);
            this.btnScanStop.TabIndex = 9;
            this.btnScanStop.Text = "Stop scan";
            this.btnScanStop.UseVisualStyleBackColor = true;
            this.btnScanStop.Click += new System.EventHandler(this.btnScanStop_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabScan);
            this.tabControl1.Controls.Add(this.tabMonitor);
            this.tabControl1.Controls.Add(this.tabPlan);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(518, 207);
            this.tabControl1.TabIndex = 10;
            // 
            // tabScan
            // 
            this.tabScan.Controls.Add(this.btnDelScan);
            this.tabScan.Controls.Add(this.dataScan);
            this.tabScan.Controls.Add(this.btnAddScan);
            this.tabScan.Location = new System.Drawing.Point(23, 4);
            this.tabScan.Name = "tabScan";
            this.tabScan.Padding = new System.Windows.Forms.Padding(3);
            this.tabScan.Size = new System.Drawing.Size(491, 232);
            this.tabScan.TabIndex = 0;
            this.tabScan.Text = "Scanning";
            this.tabScan.UseVisualStyleBackColor = true;
            // 
            // btnDelScan
            // 
            this.btnDelScan.Location = new System.Drawing.Point(257, 7);
            this.btnDelScan.Name = "btnDelScan";
            this.btnDelScan.Size = new System.Drawing.Size(228, 23);
            this.btnDelScan.TabIndex = 2;
            this.btnDelScan.Text = "Remove chosen rows";
            this.btnDelScan.UseVisualStyleBackColor = true;
            this.btnDelScan.Click += new System.EventHandler(this.btnDelScan_Click);
            // 
            // dataScan
            // 
            this.dataScan.AllowUserToAddRows = false;
            this.dataScan.AllowUserToDeleteRows = false;
            this.dataScan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataScan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataScan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.scanPath,
            this.status});
            this.dataScan.Location = new System.Drawing.Point(7, 37);
            this.dataScan.Name = "dataScan";
            this.dataScan.ReadOnly = true;
            this.dataScan.Size = new System.Drawing.Size(478, 189);
            this.dataScan.TabIndex = 1;
            // 
            // scanPath
            // 
            this.scanPath.Frozen = true;
            this.scanPath.HeaderText = "File or directory path";
            this.scanPath.Name = "scanPath";
            this.scanPath.ReadOnly = true;
            this.scanPath.Width = 330;
            // 
            // status
            // 
            this.status.Frozen = true;
            this.status.HeaderText = "Scan status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 120;
            // 
            // btnAddScan
            // 
            this.btnAddScan.Location = new System.Drawing.Point(7, 7);
            this.btnAddScan.Name = "btnAddScan";
            this.btnAddScan.Size = new System.Drawing.Size(243, 23);
            this.btnAddScan.TabIndex = 0;
            this.btnAddScan.Text = "Add file or directory to scan list";
            this.btnAddScan.UseVisualStyleBackColor = true;
            this.btnAddScan.Click += new System.EventHandler(this.btnAddScan_Click);
            // 
            // tabMonitor
            // 
            this.tabMonitor.Controls.Add(this.btnDelMonitor);
            this.tabMonitor.Controls.Add(this.dataMonitor);
            this.tabMonitor.Controls.Add(this.btnAddMonitor);
            this.tabMonitor.Location = new System.Drawing.Point(23, 4);
            this.tabMonitor.Name = "tabMonitor";
            this.tabMonitor.Padding = new System.Windows.Forms.Padding(3);
            this.tabMonitor.Size = new System.Drawing.Size(491, 232);
            this.tabMonitor.TabIndex = 1;
            this.tabMonitor.Text = "Monitoring";
            this.tabMonitor.UseVisualStyleBackColor = true;
            // 
            // btnDelMonitor
            // 
            this.btnDelMonitor.Location = new System.Drawing.Point(260, 7);
            this.btnDelMonitor.Name = "btnDelMonitor";
            this.btnDelMonitor.Size = new System.Drawing.Size(225, 23);
            this.btnDelMonitor.TabIndex = 2;
            this.btnDelMonitor.Text = "Remove chosen rows";
            this.btnDelMonitor.UseVisualStyleBackColor = true;
            this.btnDelMonitor.Click += new System.EventHandler(this.btnDelMonitor_Click);
            // 
            // dataMonitor
            // 
            this.dataMonitor.AllowUserToAddRows = false;
            this.dataMonitor.AllowUserToDeleteRows = false;
            this.dataMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMonitor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dir});
            this.dataMonitor.Location = new System.Drawing.Point(7, 37);
            this.dataMonitor.Name = "dataMonitor";
            this.dataMonitor.ReadOnly = true;
            this.dataMonitor.Size = new System.Drawing.Size(478, 189);
            this.dataMonitor.TabIndex = 1;
            // 
            // dir
            // 
            this.dir.HeaderText = "Directory ";
            this.dir.Name = "dir";
            this.dir.ReadOnly = true;
            this.dir.Width = 430;
            // 
            // btnAddMonitor
            // 
            this.btnAddMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMonitor.Location = new System.Drawing.Point(7, 7);
            this.btnAddMonitor.Name = "btnAddMonitor";
            this.btnAddMonitor.Size = new System.Drawing.Size(246, 23);
            this.btnAddMonitor.TabIndex = 0;
            this.btnAddMonitor.Text = "Add directory to monitoring list";
            this.btnAddMonitor.UseVisualStyleBackColor = true;
            this.btnAddMonitor.Click += new System.EventHandler(this.btnAddMonitor_Click);
            // 
            // tabPlan
            // 
            this.tabPlan.Controls.Add(this.btnDelPlan);
            this.tabPlan.Controls.Add(this.dataPlan);
            this.tabPlan.Controls.Add(this.label5);
            this.tabPlan.Controls.Add(this.comboMinute1);
            this.tabPlan.Controls.Add(this.comboMinute2);
            this.tabPlan.Controls.Add(this.comboHour);
            this.tabPlan.Controls.Add(this.label4);
            this.tabPlan.Controls.Add(this.btnAddPlan);
            this.tabPlan.Location = new System.Drawing.Point(23, 4);
            this.tabPlan.Name = "tabPlan";
            this.tabPlan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlan.Size = new System.Drawing.Size(491, 199);
            this.tabPlan.TabIndex = 2;
            this.tabPlan.Text = "Planning";
            this.tabPlan.UseVisualStyleBackColor = true;
            // 
            // btnDelPlan
            // 
            this.btnDelPlan.Location = new System.Drawing.Point(369, 2);
            this.btnDelPlan.Name = "btnDelPlan";
            this.btnDelPlan.Size = new System.Drawing.Size(116, 23);
            this.btnDelPlan.TabIndex = 7;
            this.btnDelPlan.Text = "Remove chosen rows";
            this.btnDelPlan.UseVisualStyleBackColor = true;
            this.btnDelPlan.Click += new System.EventHandler(this.btnDelPlan_Click);
            // 
            // dataPlan
            // 
            this.dataPlan.AllowUserToAddRows = false;
            this.dataPlan.AllowUserToDeleteRows = false;
            this.dataPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.path,
            this.time});
            this.dataPlan.Location = new System.Drawing.Point(6, 35);
            this.dataPlan.Name = "dataPlan";
            this.dataPlan.ReadOnly = true;
            this.dataPlan.Size = new System.Drawing.Size(479, 158);
            this.dataPlan.TabIndex = 6;
            // 
            // path
            // 
            this.path.Frozen = true;
            this.path.HeaderText = "File or directory path";
            this.path.Name = "path";
            this.path.ReadOnly = true;
            this.path.Width = 350;
            // 
            // time
            // 
            this.time.Frozen = true;
            this.time.HeaderText = "Time";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = ":";
            // 
            // comboMinute1
            // 
            this.comboMinute1.FormattingEnabled = true;
            this.comboMinute1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboMinute1.Location = new System.Drawing.Point(171, 4);
            this.comboMinute1.Name = "comboMinute1";
            this.comboMinute1.Size = new System.Drawing.Size(33, 21);
            this.comboMinute1.TabIndex = 4;
            this.comboMinute1.Text = "1";
            this.comboMinute1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboHour_KeyPress);
            // 
            // comboMinute2
            // 
            this.comboMinute2.FormattingEnabled = true;
            this.comboMinute2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboMinute2.Location = new System.Drawing.Point(210, 4);
            this.comboMinute2.Name = "comboMinute2";
            this.comboMinute2.Size = new System.Drawing.Size(33, 21);
            this.comboMinute2.TabIndex = 3;
            this.comboMinute2.Text = "5";
            this.comboMinute2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboHour_KeyPress);
            // 
            // comboHour
            // 
            this.comboHour.FormattingEnabled = true;
            this.comboHour.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.comboHour.Location = new System.Drawing.Point(109, 4);
            this.comboHour.Name = "comboHour";
            this.comboHour.Size = new System.Drawing.Size(40, 21);
            this.comboHour.TabIndex = 2;
            this.comboHour.Text = "6";
            this.comboHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboHour_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Select time to scan:";
            // 
            // btnAddPlan
            // 
            this.btnAddPlan.Location = new System.Drawing.Point(249, 2);
            this.btnAddPlan.Name = "btnAddPlan";
            this.btnAddPlan.Size = new System.Drawing.Size(114, 23);
            this.btnAddPlan.TabIndex = 0;
            this.btnAddPlan.Text = "Add to plan list";
            this.btnAddPlan.UseVisualStyleBackColor = true;
            this.btnAddPlan.Click += new System.EventHandler(this.btnAddPlan_Click);
            // 
            // textLog
            // 
            this.textLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLog.Location = new System.Drawing.Point(3, 241);
            this.textLog.Name = "textLog";
            this.textLog.ReadOnly = true;
            this.textLog.Size = new System.Drawing.Size(518, 109);
            this.textLog.TabIndex = 11;
            this.textLog.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Addictional information:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textLog, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 96);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(524, 353);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnScanStop);
            this.Controls.Add(this.btnScanStart);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSStop);
            this.Controls.Add(this.btnSRun);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "AntiV client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabScan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataScan)).EndInit();
            this.tabMonitor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataMonitor)).EndInit();
            this.tabPlan.ResumeLayout(false);
            this.tabPlan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPlan)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSRun;
        private System.Windows.Forms.Button btnSStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnScanStart;
        private System.Windows.Forms.Button btnScanStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabScan;
        private System.Windows.Forms.TabPage tabMonitor;
        private System.Windows.Forms.TabPage tabPlan;
        private System.Windows.Forms.RichTextBox textLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataMonitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dir;
        private System.Windows.Forms.Button btnAddMonitor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddPlan;
        private System.Windows.Forms.DataGridView dataPlan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboMinute1;
        private System.Windows.Forms.ComboBox comboMinute2;
        private System.Windows.Forms.ComboBox comboHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn path;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.Button btnDelScan;
        private System.Windows.Forms.DataGridView dataScan;
        private System.Windows.Forms.DataGridViewTextBoxColumn scanPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.Button btnAddScan;
        private System.Windows.Forms.Button btnDelMonitor;
        private System.Windows.Forms.Button btnDelPlan;
    }
}

