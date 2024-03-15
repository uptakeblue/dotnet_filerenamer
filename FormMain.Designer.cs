namespace FileRenamer
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lstRenamedFiles = new System.Windows.Forms.ListBox();
            this.lblRenamedFiles = new System.Windows.Forms.Label();
            this.lstSourceFiles = new System.Windows.Forms.ListBox();
            this.lblSourceFiles = new System.Windows.Forms.Label();
            this.tabFiles = new System.Windows.Forms.TabPage();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pgbRename = new System.Windows.Forms.ProgressBar();
            this.lblAudiobook = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtAudiobook = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblGenerateName = new System.Windows.Forms.Label();
            this.btnGenerateName = new System.Windows.Forms.Button();
            this.txtRename = new System.Windows.Forms.TextBox();
            this.spltFiles = new System.Windows.Forms.SplitContainer();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblFolder = new System.Windows.Forms.Label();
            this.btnFolder = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.lblSelectAuthor = new System.Windows.Forms.Label();
            this.cboAuthor = new System.Windows.Forms.ComboBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabData = new System.Windows.Forms.TabPage();
            this.lblRowcount = new System.Windows.Forms.Label();
            this.lblConnection = new System.Windows.Forms.Label();
            this.llRefresh = new System.Windows.Forms.LinkLabel();
            this.grdAudiobook = new System.Windows.Forms.DataGridView();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.ofDialog = new System.Windows.Forms.OpenFileDialog();
            this.file_renamer_log_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Current = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.is_read = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.tabFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltFiles)).BeginInit();
            this.spltFiles.Panel1.SuspendLayout();
            this.spltFiles.Panel2.SuspendLayout();
            this.spltFiles.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAudiobook)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // lstRenamedFiles
            // 
            this.lstRenamedFiles.DisplayMember = "TargetFileName";
            this.lstRenamedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRenamedFiles.FormattingEnabled = true;
            this.lstRenamedFiles.Location = new System.Drawing.Point(0, 13);
            this.lstRenamedFiles.Name = "lstRenamedFiles";
            this.lstRenamedFiles.Size = new System.Drawing.Size(263, 248);
            this.lstRenamedFiles.TabIndex = 0;
            // 
            // lblRenamedFiles
            // 
            this.lblRenamedFiles.AutoSize = true;
            this.lblRenamedFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRenamedFiles.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRenamedFiles.Location = new System.Drawing.Point(0, 0);
            this.lblRenamedFiles.Name = "lblRenamedFiles";
            this.lblRenamedFiles.Size = new System.Drawing.Size(80, 13);
            this.lblRenamedFiles.TabIndex = 18;
            this.lblRenamedFiles.Text = "Renamed Files:";
            // 
            // lstSourceFiles
            // 
            this.lstSourceFiles.DisplayMember = "SourceFileName";
            this.lstSourceFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSourceFiles.FormattingEnabled = true;
            this.lstSourceFiles.Location = new System.Drawing.Point(0, 13);
            this.lstSourceFiles.Name = "lstSourceFiles";
            this.lstSourceFiles.Size = new System.Drawing.Size(250, 248);
            this.lstSourceFiles.TabIndex = 0;
            // 
            // lblSourceFiles
            // 
            this.lblSourceFiles.AutoSize = true;
            this.lblSourceFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSourceFiles.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSourceFiles.Location = new System.Drawing.Point(0, 0);
            this.lblSourceFiles.Name = "lblSourceFiles";
            this.lblSourceFiles.Size = new System.Drawing.Size(31, 13);
            this.lblSourceFiles.TabIndex = 16;
            this.lblSourceFiles.Text = "Files:";
            // 
            // tabFiles
            // 
            this.tabFiles.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabFiles.Controls.Add(this.btnExit);
            this.tabFiles.Controls.Add(this.lblTitle);
            this.tabFiles.Controls.Add(this.pgbRename);
            this.tabFiles.Controls.Add(this.lblAudiobook);
            this.tabFiles.Controls.Add(this.txtAuthor);
            this.tabFiles.Controls.Add(this.txtAudiobook);
            this.tabFiles.Controls.Add(this.lblAuthor);
            this.tabFiles.Controls.Add(this.lblGenerateName);
            this.tabFiles.Controls.Add(this.btnGenerateName);
            this.tabFiles.Controls.Add(this.txtRename);
            this.tabFiles.Controls.Add(this.spltFiles);
            this.tabFiles.Controls.Add(this.btnRename);
            this.tabFiles.Controls.Add(this.btnClear);
            this.tabFiles.Controls.Add(this.lblFolder);
            this.tabFiles.Controls.Add(this.btnFolder);
            this.tabFiles.Controls.Add(this.txtFolder);
            this.tabFiles.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabFiles.Location = new System.Drawing.Point(4, 28);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabFiles.Size = new System.Drawing.Size(540, 571);
            this.tabFiles.TabIndex = 0;
            this.tabFiles.Text = "Files";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(222, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(92, 17);
            this.lblTitle.TabIndex = 122;
            this.lblTitle.Text = "File Renamer";
            // 
            // pgbRename
            // 
            this.pgbRename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbRename.Location = new System.Drawing.Point(175, 542);
            this.pgbRename.Name = "pgbRename";
            this.pgbRename.RightToLeftLayout = true;
            this.pgbRename.Size = new System.Drawing.Size(355, 23);
            this.pgbRename.Step = 1;
            this.pgbRename.TabIndex = 120;
            this.pgbRename.Visible = false;
            // 
            // lblAudiobook
            // 
            this.lblAudiobook.AutoSize = true;
            this.lblAudiobook.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAudiobook.Location = new System.Drawing.Point(13, 87);
            this.lblAudiobook.Name = "lblAudiobook";
            this.lblAudiobook.Size = new System.Drawing.Size(84, 13);
            this.lblAudiobook.TabIndex = 119;
            this.lblAudiobook.Text = "Audiobook Title:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtAuthor.Location = new System.Drawing.Point(16, 155);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(178, 20);
            this.txtAuthor.TabIndex = 114;
            // 
            // txtAudiobook
            // 
            this.txtAudiobook.BackColor = System.Drawing.SystemColors.Window;
            this.txtAudiobook.Location = new System.Drawing.Point(16, 106);
            this.txtAudiobook.Name = "txtAudiobook";
            this.txtAudiobook.Size = new System.Drawing.Size(360, 20);
            this.txtAudiobook.TabIndex = 113;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAuthor.Location = new System.Drawing.Point(13, 139);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(38, 13);
            this.lblAuthor.TabIndex = 117;
            this.lblAuthor.Text = "Author";
            // 
            // lblGenerateName
            // 
            this.lblGenerateName.AutoSize = true;
            this.lblGenerateName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGenerateName.Location = new System.Drawing.Point(13, 193);
            this.lblGenerateName.Name = "lblGenerateName";
            this.lblGenerateName.Size = new System.Drawing.Size(103, 13);
            this.lblGenerateName.TabIndex = 118;
            this.lblGenerateName.Text = "New Filename Root:";
            // 
            // btnGenerateName
            // 
            this.btnGenerateName.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGenerateName.Location = new System.Drawing.Point(199, 209);
            this.btnGenerateName.Name = "btnGenerateName";
            this.btnGenerateName.Size = new System.Drawing.Size(137, 21);
            this.btnGenerateName.TabIndex = 116;
            this.btnGenerateName.Tag = "GenerateFilenames";
            this.btnGenerateName.Text = "Generate Filenames";
            this.btnGenerateName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGenerateName.UseVisualStyleBackColor = true;
            // 
            // txtRename
            // 
            this.txtRename.Location = new System.Drawing.Point(16, 209);
            this.txtRename.Name = "txtRename";
            this.txtRename.Size = new System.Drawing.Size(178, 20);
            this.txtRename.TabIndex = 115;
            // 
            // spltFiles
            // 
            this.spltFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spltFiles.Location = new System.Drawing.Point(13, 270);
            this.spltFiles.Name = "spltFiles";
            // 
            // spltFiles.Panel1
            // 
            this.spltFiles.Panel1.Controls.Add(this.lstSourceFiles);
            this.spltFiles.Panel1.Controls.Add(this.lblSourceFiles);
            // 
            // spltFiles.Panel2
            // 
            this.spltFiles.Panel2.Controls.Add(this.lstRenamedFiles);
            this.spltFiles.Panel2.Controls.Add(this.lblRenamedFiles);
            this.spltFiles.Panel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.spltFiles.Size = new System.Drawing.Size(517, 261);
            this.spltFiles.SplitterDistance = 250;
            this.spltFiles.TabIndex = 112;
            this.spltFiles.TabStop = false;
            // 
            // btnRename
            // 
            this.btnRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRename.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRename.Location = new System.Drawing.Point(94, 540);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 25);
            this.btnRename.TabIndex = 111;
            this.btnRename.Tag = "RenameFiles";
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClear.Location = new System.Drawing.Point(13, 540);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 108;
            this.btnClear.Tag = "Clear";
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFolder.Location = new System.Drawing.Point(13, 15);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(76, 13);
            this.lblFolder.TabIndex = 107;
            this.lblFolder.Text = "Source Folder:";
            // 
            // btnFolder
            // 
            this.btnFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFolder.Location = new System.Drawing.Point(493, 30);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(37, 21);
            this.btnFolder.TabIndex = 104;
            this.btnFolder.Tag = "BrowseFolders";
            this.btnFolder.Text = "...";
            this.btnFolder.UseVisualStyleBackColor = true;
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(16, 31);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(471, 20);
            this.txtFolder.TabIndex = 103;
            // 
            // lblSelectAuthor
            // 
            this.lblSelectAuthor.AutoSize = true;
            this.lblSelectAuthor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSelectAuthor.Location = new System.Drawing.Point(8, 12);
            this.lblSelectAuthor.Name = "lblSelectAuthor";
            this.lblSelectAuthor.Size = new System.Drawing.Size(38, 13);
            this.lblSelectAuthor.TabIndex = 1;
            this.lblSelectAuthor.Text = "Author";
            // 
            // cboAuthor
            // 
            this.cboAuthor.DisplayMember = "Value";
            this.cboAuthor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAuthor.FormattingEnabled = true;
            this.cboAuthor.Location = new System.Drawing.Point(11, 28);
            this.cboAuthor.Name = "cboAuthor";
            this.cboAuthor.Size = new System.Drawing.Size(210, 21);
            this.cboAuthor.TabIndex = 0;
            this.cboAuthor.ValueMember = "Key";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabFiles);
            this.tabMain.Controls.Add(this.tabData);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Drawing.Point(6, 6);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(548, 603);
            this.tabMain.TabIndex = 103;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabData
            // 
            this.tabData.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabData.Controls.Add(this.lblRowcount);
            this.tabData.Controls.Add(this.lblConnection);
            this.tabData.Controls.Add(this.llRefresh);
            this.tabData.Controls.Add(this.grdAudiobook);
            this.tabData.Controls.Add(this.lblSelectAuthor);
            this.tabData.Controls.Add(this.cboAuthor);
            this.tabData.Location = new System.Drawing.Point(4, 28);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(540, 571);
            this.tabData.TabIndex = 1;
            this.tabData.Text = "Data";
            // 
            // lblRowcount
            // 
            this.lblRowcount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowcount.AutoSize = true;
            this.lblRowcount.BackColor = System.Drawing.Color.Transparent;
            this.lblRowcount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRowcount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRowcount.Location = new System.Drawing.Point(470, 642);
            this.lblRowcount.Name = "lblRowcount";
            this.lblRowcount.Padding = new System.Windows.Forms.Padding(2);
            this.lblRowcount.Size = new System.Drawing.Size(70, 17);
            this.lblRowcount.TabIndex = 104;
            this.lblRowcount.Text = "lblRowcount";
            this.lblRowcount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblConnection
            // 
            this.lblConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblConnection.AutoSize = true;
            this.lblConnection.BackColor = System.Drawing.Color.Transparent;
            this.lblConnection.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblConnection.Location = new System.Drawing.Point(8, 642);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Padding = new System.Windows.Forms.Padding(2);
            this.lblConnection.Size = new System.Drawing.Size(75, 17);
            this.lblConnection.TabIndex = 103;
            this.lblConnection.Text = "lblConnection";
            this.lblConnection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // llRefresh
            // 
            this.llRefresh.AutoSize = true;
            this.llRefresh.Location = new System.Drawing.Point(8, 61);
            this.llRefresh.Name = "llRefresh";
            this.llRefresh.Size = new System.Drawing.Size(63, 13);
            this.llRefresh.TabIndex = 3;
            this.llRefresh.TabStop = true;
            this.llRefresh.Text = "data refresh";
            // 
            // grdAudiobook
            // 
            this.grdAudiobook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAudiobook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.file_renamer_log_id,
            this.title,
            this.date,
            this.Current,
            this.is_read});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdAudiobook.DefaultCellStyle = dataGridViewCellStyle10;
            this.grdAudiobook.Location = new System.Drawing.Point(8, 87);
            this.grdAudiobook.MultiSelect = false;
            this.grdAudiobook.Name = "grdAudiobook";
            this.grdAudiobook.RowHeadersVisible = false;
            this.grdAudiobook.RowHeadersWidth = 28;
            this.grdAudiobook.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.SteelBlue;
            this.grdAudiobook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAudiobook.Size = new System.Drawing.Size(529, 462);
            this.grdAudiobook.TabIndex = 2;
            // 
            // ofDialog
            // 
            this.ofDialog.FileName = "openFileDialog1";
            // 
            // file_renamer_log_id
            // 
            this.file_renamer_log_id.HeaderText = "file_renamer_log_id";
            this.file_renamer_log_id.MinimumWidth = 15;
            this.file_renamer_log_id.Name = "file_renamer_log_id";
            this.file_renamer_log_id.ReadOnly = true;
            this.file_renamer_log_id.Visible = false;
            this.file_renamer_log_id.Width = 300;
            // 
            // title
            // 
            this.title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.title.HeaderText = "Title";
            this.title.MinimumWidth = 150;
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // date
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "d";
            dataGridViewCellStyle9.NullValue = null;
            this.date.DefaultCellStyle = dataGridViewCellStyle9;
            this.date.HeaderText = "Date";
            this.date.MinimumWidth = 15;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 75;
            // 
            // Current
            // 
            this.Current.FalseValue = "False";
            this.Current.HeaderText = "Current";
            this.Current.IndeterminateValue = "False";
            this.Current.MinimumWidth = 15;
            this.Current.Name = "Current";
            this.Current.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Current.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Current.TrueValue = "True";
            this.Current.Width = 45;
            // 
            // is_read
            // 
            this.is_read.FalseValue = "False";
            this.is_read.HeaderText = "Read";
            this.is_read.IndeterminateValue = "False";
            this.is_read.MinimumWidth = 15;
            this.is_read.Name = "is_read";
            this.is_read.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.is_read.TrueValue = "True";
            this.is_read.Width = 45;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(119)))), ((int)(((byte)(99)))));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(505, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(24, 19);
            this.btnExit.TabIndex = 106;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(119)))), ((int)(((byte)(99)))));
            this.ClientSize = new System.Drawing.Size(548, 603);
            this.Controls.Add(this.tabMain);
            this.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.Text = "File Renamer";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
            this.tabFiles.ResumeLayout(false);
            this.tabFiles.PerformLayout();
            this.spltFiles.Panel1.ResumeLayout(false);
            this.spltFiles.Panel1.PerformLayout();
            this.spltFiles.Panel2.ResumeLayout(false);
            this.spltFiles.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltFiles)).EndInit();
            this.spltFiles.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            this.tabData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAudiobook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox lstRenamedFiles;
        private System.Windows.Forms.Label lblRenamedFiles;
        private System.Windows.Forms.ListBox lstSourceFiles;
        private System.Windows.Forms.Label lblSourceFiles;
        private System.Windows.Forms.TabPage tabFiles;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ProgressBar pgbRename;
        private System.Windows.Forms.Label lblAudiobook;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtAudiobook;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblGenerateName;
        private System.Windows.Forms.Button btnGenerateName;
        private System.Windows.Forms.TextBox txtRename;
        private System.Windows.Forms.SplitContainer spltFiles;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label lblSelectAuthor;
        private System.Windows.Forms.ComboBox cboAuthor;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.Label lblRowcount;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.LinkLabel llRefresh;
        private System.Windows.Forms.DataGridView grdAudiobook;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.OpenFileDialog ofDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_renamer_log_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Current;
        private System.Windows.Forms.DataGridViewCheckBoxColumn is_read;
    }
}

