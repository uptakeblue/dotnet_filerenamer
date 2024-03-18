namespace FileRenamer.Forms {
    partial class FrmAudiobook {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if( disposing && ( components != null ) ) {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( ) {
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblYearSeries = new System.Windows.Forms.Label();
            this.txtYearSeries = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.lblReadDate = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.Author = new System.Windows.Forms.Label();
            this.txtCreated = new System.Windows.Forms.TextBox();
            this.txtRead = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(144, 96);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(53, 20);
            this.txtNumber.TabIndex = 21;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNumber.Location = new System.Drawing.Point(141, 77);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(47, 13);
            this.lblNumber.TabIndex = 20;
            this.lblNumber.Text = "Number:";
            // 
            // lblYearSeries
            // 
            this.lblYearSeries.AutoSize = true;
            this.lblYearSeries.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblYearSeries.Location = new System.Drawing.Point(18, 77);
            this.lblYearSeries.Name = "lblYearSeries";
            this.lblYearSeries.Size = new System.Drawing.Size(76, 13);
            this.lblYearSeries.TabIndex = 18;
            this.lblYearSeries.Text = "Series or Year:";
            // 
            // txtYearSeries
            // 
            this.txtYearSeries.Location = new System.Drawing.Point(21, 96);
            this.txtYearSeries.Name = "txtYearSeries";
            this.txtYearSeries.Size = new System.Drawing.Size(102, 20);
            this.txtYearSeries.TabIndex = 19;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(102, 304);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOkay
            // 
            this.btnOkay.Location = new System.Drawing.Point(21, 304);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 29;
            this.btnOkay.Text = "Okay";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // lblReadDate
            // 
            this.lblReadDate.AutoSize = true;
            this.lblReadDate.Location = new System.Drawing.Point(21, 243);
            this.lblReadDate.Name = "lblReadDate";
            this.lblReadDate.Size = new System.Drawing.Size(36, 13);
            this.lblReadDate.TabIndex = 27;
            this.lblReadDate.Text = "Read:";
            this.lblReadDate.Visible = false;
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Location = new System.Drawing.Point(21, 190);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(47, 13);
            this.lblCreatedDate.TabIndex = 24;
            this.lblCreatedDate.Text = "Created:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitle.Location = new System.Drawing.Point(18, 137);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 22;
            this.lblTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(21, 156);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(360, 20);
            this.txtTitle.TabIndex = 23;
            // 
            // Author
            // 
            this.Author.AutoSize = true;
            this.Author.Location = new System.Drawing.Point(18, 20);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(38, 13);
            this.Author.TabIndex = 16;
            this.Author.Text = "Author";
            // 
            // txtCreated
            // 
            this.txtCreated.BackColor = System.Drawing.SystemColors.Window;
            this.txtCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreated.Enabled = false;
            this.txtCreated.Location = new System.Drawing.Point(21, 208);
            this.txtCreated.Name = "txtCreated";
            this.txtCreated.ReadOnly = true;
            this.txtCreated.Size = new System.Drawing.Size(176, 20);
            this.txtCreated.TabIndex = 31;
            // 
            // txtRead
            // 
            this.txtRead.BackColor = System.Drawing.SystemColors.Window;
            this.txtRead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRead.Enabled = false;
            this.txtRead.Location = new System.Drawing.Point(21, 259);
            this.txtRead.Name = "txtRead";
            this.txtRead.ReadOnly = true;
            this.txtRead.Size = new System.Drawing.Size(176, 20);
            this.txtRead.TabIndex = 32;
            this.txtRead.Visible = false;
            // 
            // txtAuthor
            // 
            this.txtAuthor.BackColor = System.Drawing.SystemColors.Window;
            this.txtAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAuthor.Enabled = false;
            this.txtAuthor.Location = new System.Drawing.Point(21, 36);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(176, 20);
            this.txtAuthor.TabIndex = 33;
            // 
            // FrmAudiobook
            // 
            this.AcceptButton = this.btnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(401, 348);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtRead);
            this.Controls.Add(this.txtCreated);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblYearSeries);
            this.Controls.Add(this.txtYearSeries);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.lblReadDate);
            this.Controls.Add(this.lblCreatedDate);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.Author);
            this.Name = "FrmAudiobook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmAudiobook";
            this.Load += new System.EventHandler(this.FrmAudiobook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblYearSeries;
        private System.Windows.Forms.TextBox txtYearSeries;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Label lblReadDate;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label Author;
        private System.Windows.Forms.TextBox txtCreated;
        private System.Windows.Forms.TextBox txtRead;
        private System.Windows.Forms.TextBox txtAuthor;
    }
}