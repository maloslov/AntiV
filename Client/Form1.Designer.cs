﻿
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnDelPlan = new System.Windows.Forms.Button();
            this.dataPlan = new System.Windows.Forms.DataGridView();
            this.path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddPlan = new System.Windows.Forms.Button();
            this.tabQarantine = new System.Windows.Forms.TabPage();
            this.dataQarantine = new System.Windows.Forms.DataGridView();
            this.QFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Found = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QVirus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
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
            this.tabQarantine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataQarantine)).BeginInit();
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
            this.textPath.Text = "c:\\antiv\\testfolder";
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
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "PE file|*.exe|ZIP-archive|*.zip";
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
            this.tabControl1.Controls.Add(this.tabQarantine);
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
            this.tabScan.Size = new System.Drawing.Size(491, 199);
            this.tabScan.TabIndex = 0;
            this.tabScan.Text = "Scan";
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
            this.tabMonitor.Size = new System.Drawing.Size(491, 199);
            this.tabMonitor.TabIndex = 1;
            this.tabMonitor.Text = "Monitor";
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
            this.tabPlan.Controls.Add(this.dateTimePicker1);
            this.tabPlan.Controls.Add(this.btnDelPlan);
            this.tabPlan.Controls.Add(this.dataPlan);
            this.tabPlan.Controls.Add(this.label4);
            this.tabPlan.Controls.Add(this.btnAddPlan);
            this.tabPlan.Location = new System.Drawing.Point(23, 4);
            this.tabPlan.Name = "tabPlan";
            this.tabPlan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlan.Size = new System.Drawing.Size(491, 199);
            this.tabPlan.TabIndex = 2;
            this.tabPlan.Text = "Plan";
            this.tabPlan.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(109, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 20);
            this.dateTimePicker1.TabIndex = 8;
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
            this.btnAddPlan.Location = new System.Drawing.Point(243, 3);
            this.btnAddPlan.Name = "btnAddPlan";
            this.btnAddPlan.Size = new System.Drawing.Size(120, 23);
            this.btnAddPlan.TabIndex = 0;
            this.btnAddPlan.Text = "Add to plan list";
            this.btnAddPlan.UseVisualStyleBackColor = true;
            this.btnAddPlan.Click += new System.EventHandler(this.btnAddPlan_Click);
            // 
            // tabQarantine
            // 
            this.tabQarantine.Controls.Add(this.dataQarantine);
            this.tabQarantine.Controls.Add(this.btnRestore);
            this.tabQarantine.Controls.Add(this.btnDelete);
            this.tabQarantine.Location = new System.Drawing.Point(23, 4);
            this.tabQarantine.Name = "tabQarantine";
            this.tabQarantine.Size = new System.Drawing.Size(491, 199);
            this.tabQarantine.TabIndex = 3;
            this.tabQarantine.Text = "Qarantine";
            this.tabQarantine.UseVisualStyleBackColor = true;
            // 
            // dataQarantine
            // 
            this.dataQarantine.AllowUserToAddRows = false;
            this.dataQarantine.AllowUserToDeleteRows = false;
            this.dataQarantine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataQarantine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataQarantine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QFile,
            this.Found,
            this.QVirus});
            this.dataQarantine.Location = new System.Drawing.Point(4, 34);
            this.dataQarantine.Name = "dataQarantine";
            this.dataQarantine.ReadOnly = true;
            this.dataQarantine.Size = new System.Drawing.Size(484, 162);
            this.dataQarantine.TabIndex = 2;
            // 
            // QFile
            // 
            this.QFile.Frozen = true;
            this.QFile.HeaderText = "Infected file";
            this.QFile.Name = "QFile";
            this.QFile.ReadOnly = true;
            this.QFile.Width = 200;
            // 
            // Found
            // 
            this.Found.Frozen = true;
            this.Found.HeaderText = "Was found in";
            this.Found.Name = "Found";
            this.Found.ReadOnly = true;
            // 
            // QVirus
            // 
            this.QVirus.Frozen = true;
            this.QVirus.HeaderText = "Found virus ";
            this.QVirus.Name = "QVirus";
            this.QVirus.ReadOnly = true;
            this.QVirus.Width = 200;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(235, 4);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(253, 23);
            this.btnRestore.TabIndex = 1;
            this.btnRestore.Text = "restore file";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(225, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "delete file";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.tabQarantine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataQarantine)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn path;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.Button btnDelScan;
        private System.Windows.Forms.DataGridView dataScan;
        private System.Windows.Forms.DataGridViewTextBoxColumn scanPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.Button btnAddScan;
        private System.Windows.Forms.Button btnDelMonitor;
        private System.Windows.Forms.Button btnDelPlan;
        private System.Windows.Forms.TabPage tabQarantine;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataQarantine;
        private System.Windows.Forms.DataGridViewTextBoxColumn QFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Found;
        private System.Windows.Forms.DataGridViewTextBoxColumn QVirus;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

