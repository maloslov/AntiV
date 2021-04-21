
namespace BaseEditor
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textType = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textEnd = new System.Windows.Forms.TextBox();
            this.textStart = new System.Windows.Forms.TextBox();
            this.textLength = new System.Windows.Forms.TextBox();
            this.textPrefix = new System.Windows.Forms.TextBox();
            this.textHash = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.addRow = new System.Windows.Forms.Button();
            this.saveBase = new System.Windows.Forms.Button();
            this.openBase = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnParse = new System.Windows.Forms.Button();
            this.textExe = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textCPath = new System.Windows.Forms.TextBox();
            this.readExe = new System.Windows.Forms.Button();
            this.textCEnd = new System.Windows.Forms.TextBox();
            this.textCStart = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textCSign = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(427, 444);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textType);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.textEnd);
            this.tabPage2.Controls.Add(this.textStart);
            this.tabPage2.Controls.Add(this.textLength);
            this.tabPage2.Controls.Add(this.textPrefix);
            this.tabPage2.Controls.Add(this.textHash);
            this.tabPage2.Controls.Add(this.textName);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.addRow);
            this.tabPage2.Controls.Add(this.saveBase);
            this.tabPage2.Controls.Add(this.openBase);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(419, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Base edit";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textType
            // 
            this.textType.Location = new System.Drawing.Point(306, 56);
            this.textType.Name = "textType";
            this.textType.Size = new System.Drawing.Size(104, 20);
            this.textType.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(251, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "File type:";
            // 
            // textEnd
            // 
            this.textEnd.Location = new System.Drawing.Point(193, 56);
            this.textEnd.Name = "textEnd";
            this.textEnd.Size = new System.Drawing.Size(52, 20);
            this.textEnd.TabIndex = 15;
            // 
            // textStart
            // 
            this.textStart.Location = new System.Drawing.Point(69, 56);
            this.textStart.Name = "textStart";
            this.textStart.Size = new System.Drawing.Size(56, 20);
            this.textStart.TabIndex = 14;
            // 
            // textLength
            // 
            this.textLength.Location = new System.Drawing.Point(313, 30);
            this.textLength.Name = "textLength";
            this.textLength.Size = new System.Drawing.Size(97, 20);
            this.textLength.TabIndex = 13;
            // 
            // textPrefix
            // 
            this.textPrefix.Location = new System.Drawing.Point(313, 4);
            this.textPrefix.Name = "textPrefix";
            this.textPrefix.Size = new System.Drawing.Size(97, 20);
            this.textPrefix.TabIndex = 12;
            // 
            // textHash
            // 
            this.textHash.Location = new System.Drawing.Point(69, 30);
            this.textHash.Name = "textHash";
            this.textHash.Size = new System.Drawing.Size(176, 20);
            this.textHash.TabIndex = 11;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(92, 4);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(153, 20);
            this.textName.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Sign length:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(128, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Offset end:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Offset start:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "SHA-256:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Sign prefix:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Malware name:";
            // 
            // addRow
            // 
            this.addRow.Location = new System.Drawing.Point(251, 82);
            this.addRow.Name = "addRow";
            this.addRow.Size = new System.Drawing.Size(159, 38);
            this.addRow.TabIndex = 3;
            this.addRow.Text = "Add row to base";
            this.addRow.UseVisualStyleBackColor = true;
            this.addRow.Click += new System.EventHandler(this.addRow_Click);
            // 
            // saveBase
            // 
            this.saveBase.Location = new System.Drawing.Point(131, 82);
            this.saveBase.Name = "saveBase";
            this.saveBase.Size = new System.Drawing.Size(114, 38);
            this.saveBase.TabIndex = 2;
            this.saveBase.Text = "Save base file";
            this.saveBase.UseVisualStyleBackColor = true;
            this.saveBase.Click += new System.EventHandler(this.saveBase_Click);
            // 
            // openBase
            // 
            this.openBase.Location = new System.Drawing.Point(4, 82);
            this.openBase.Name = "openBase";
            this.openBase.Size = new System.Drawing.Size(121, 38);
            this.openBase.TabIndex = 1;
            this.openBase.Text = "Open base file";
            this.openBase.UseVisualStyleBackColor = true;
            this.openBase.Click += new System.EventHandler(this.openBase_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MalName,
            this.FileType,
            this.Prefix,
            this.Hash,
            this.Length,
            this.OStart,
            this.OEnd});
            this.dataGridView1.Location = new System.Drawing.Point(6, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(407, 286);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnParse);
            this.tabPage1.Controls.Add(this.textExe);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textCPath);
            this.tabPage1.Controls.Add(this.readExe);
            this.tabPage1.Controls.Add(this.textCEnd);
            this.tabPage1.Controls.Add(this.textCStart);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textCSign);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(419, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Malware file";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(247, 59);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(166, 32);
            this.btnParse.TabIndex = 11;
            this.btnParse.Text = "Parse chosen signature";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // textExe
            // 
            this.textExe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textExe.Location = new System.Drawing.Point(6, 97);
            this.textExe.Name = "textExe";
            this.textExe.ReadOnly = true;
            this.textExe.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textExe.Size = new System.Drawing.Size(407, 315);
            this.textExe.TabIndex = 10;
            this.textExe.Text = "";
            this.textExe.SelectionChanged += new System.EventHandler(this.textExe_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "File path:";
            // 
            // textCPath
            // 
            this.textCPath.Location = new System.Drawing.Point(66, 33);
            this.textCPath.Name = "textCPath";
            this.textCPath.ReadOnly = true;
            this.textCPath.Size = new System.Drawing.Size(174, 20);
            this.textCPath.TabIndex = 8;
            // 
            // readExe
            // 
            this.readExe.Location = new System.Drawing.Point(6, 59);
            this.readExe.Name = "readExe";
            this.readExe.Size = new System.Drawing.Size(234, 32);
            this.readExe.TabIndex = 7;
            this.readExe.Text = "Read malware exe file";
            this.readExe.UseVisualStyleBackColor = true;
            this.readExe.Click += new System.EventHandler(this.readExe_Click);
            // 
            // textCEnd
            // 
            this.textCEnd.Location = new System.Drawing.Point(313, 33);
            this.textCEnd.Name = "textCEnd";
            this.textCEnd.ReadOnly = true;
            this.textCEnd.Size = new System.Drawing.Size(100, 20);
            this.textCEnd.TabIndex = 6;
            // 
            // textCStart
            // 
            this.textCStart.Location = new System.Drawing.Point(313, 3);
            this.textCStart.Name = "textCStart";
            this.textCStart.ReadOnly = true;
            this.textCStart.Size = new System.Drawing.Size(100, 20);
            this.textCStart.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Offset end:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Offset start:";
            // 
            // textCSign
            // 
            this.textCSign.Location = new System.Drawing.Point(105, 4);
            this.textCSign.Name = "textCSign";
            this.textCSign.ReadOnly = true;
            this.textCSign.Size = new System.Drawing.Size(135, 20);
            this.textCSign.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chosen signature:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MalName
            // 
            this.MalName.HeaderText = "Malware name";
            this.MalName.Name = "MalName";
            this.MalName.Width = 60;
            // 
            // FileType
            // 
            this.FileType.HeaderText = "File type";
            this.FileType.Name = "FileType";
            this.FileType.Width = 30;
            // 
            // Prefix
            // 
            this.Prefix.HeaderText = "Signature prefix";
            this.Prefix.Name = "Prefix";
            this.Prefix.Width = 60;
            // 
            // Hash
            // 
            this.Hash.HeaderText = "SHA-256 without prefix";
            this.Hash.Name = "Hash";
            this.Hash.Width = 60;
            // 
            // Length
            // 
            this.Length.HeaderText = "Signature length";
            this.Length.Name = "Length";
            this.Length.Width = 60;
            // 
            // OStart
            // 
            this.OStart.HeaderText = "Offset start";
            this.OStart.Name = "OStart";
            this.OStart.Width = 50;
            // 
            // OEnd
            // 
            this.OEnd.HeaderText = "Offset end";
            this.OEnd.Name = "OEnd";
            this.OEnd.Width = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "BaseEditor";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textCEnd;
        private System.Windows.Forms.TextBox textCStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCSign;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button readExe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textCPath;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button addRow;
        private System.Windows.Forms.Button saveBase;
        private System.Windows.Forms.Button openBase;
        private System.Windows.Forms.TextBox textLength;
        private System.Windows.Forms.TextBox textPrefix;
        private System.Windows.Forms.TextBox textHash;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textEnd;
        private System.Windows.Forms.TextBox textStart;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox textExe;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.TextBox textType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn MalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hash;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn OStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn OEnd;
    }
}

