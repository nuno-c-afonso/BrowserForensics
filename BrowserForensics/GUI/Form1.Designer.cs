namespace GUI {
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
            this.components = new System.ComponentModel.Container();
            this.Output = new System.Windows.Forms.TextBox();
            this.downloads_Button = new System.Windows.Forms.Button();
            this.passwords_Button = new System.Windows.Forms.Button();
            this.cookies_Button = new System.Windows.Forms.Button();
            this.searches_Button = new System.Windows.Forms.Button();
            this.browsing_Button = new System.Windows.Forms.Button();
            this.autofills_Button = new System.Windows.Forms.Button();
            this.all_Button = new System.Windows.Forms.Button();
            this.timelineButton = new System.Windows.Forms.Button();
            this.IncoherenciesButton = new System.Windows.Forms.Button();
            this.domainsButton = new System.Windows.Forms.Button();
            this.chooseLocationButton = new System.Windows.Forms.Button();
            this.resetLocationButton = new System.Windows.Forms.Button();
            this.locationLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelFound = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Output
            // 
            this.Output.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Output.Location = new System.Drawing.Point(12, 10);
            this.Output.Margin = new System.Windows.Forms.Padding(2);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Output.Size = new System.Drawing.Size(878, 315);
            this.Output.TabIndex = 0;
            // 
            // downloads_Button
            // 
            this.downloads_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downloads_Button.Location = new System.Drawing.Point(891, 10);
            this.downloads_Button.Margin = new System.Windows.Forms.Padding(2);
            this.downloads_Button.Name = "downloads_Button";
            this.downloads_Button.Size = new System.Drawing.Size(103, 19);
            this.downloads_Button.TabIndex = 1;
            this.downloads_Button.Text = "Show downloads";
            this.downloads_Button.UseVisualStyleBackColor = true;
            this.downloads_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // passwords_Button
            // 
            this.passwords_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.passwords_Button.Location = new System.Drawing.Point(891, 33);
            this.passwords_Button.Margin = new System.Windows.Forms.Padding(2);
            this.passwords_Button.Name = "passwords_Button";
            this.passwords_Button.Size = new System.Drawing.Size(103, 21);
            this.passwords_Button.TabIndex = 2;
            this.passwords_Button.Text = "Show passwords";
            this.passwords_Button.UseVisualStyleBackColor = true;
            this.passwords_Button.Click += new System.EventHandler(this.passwords_Button_Click);
            // 
            // cookies_Button
            // 
            this.cookies_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cookies_Button.Location = new System.Drawing.Point(891, 59);
            this.cookies_Button.Margin = new System.Windows.Forms.Padding(2);
            this.cookies_Button.Name = "cookies_Button";
            this.cookies_Button.Size = new System.Drawing.Size(103, 19);
            this.cookies_Button.TabIndex = 3;
            this.cookies_Button.Text = "Show cookies";
            this.cookies_Button.UseVisualStyleBackColor = true;
            this.cookies_Button.Click += new System.EventHandler(this.cookies_Button_Click);
            // 
            // searches_Button
            // 
            this.searches_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searches_Button.Location = new System.Drawing.Point(891, 83);
            this.searches_Button.Margin = new System.Windows.Forms.Padding(2);
            this.searches_Button.Name = "searches_Button";
            this.searches_Button.Size = new System.Drawing.Size(103, 19);
            this.searches_Button.TabIndex = 4;
            this.searches_Button.Text = "Show searches";
            this.searches_Button.UseVisualStyleBackColor = true;
            this.searches_Button.Click += new System.EventHandler(this.searches_Button_Click);
            // 
            // browsing_Button
            // 
            this.browsing_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browsing_Button.Location = new System.Drawing.Point(891, 107);
            this.browsing_Button.Margin = new System.Windows.Forms.Padding(2);
            this.browsing_Button.Name = "browsing_Button";
            this.browsing_Button.Size = new System.Drawing.Size(103, 21);
            this.browsing_Button.TabIndex = 5;
            this.browsing_Button.Text = "Show browsing";
            this.browsing_Button.UseVisualStyleBackColor = true;
            this.browsing_Button.Click += new System.EventHandler(this.browsing_Button_Click);
            // 
            // autofills_Button
            // 
            this.autofills_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autofills_Button.Location = new System.Drawing.Point(891, 134);
            this.autofills_Button.Margin = new System.Windows.Forms.Padding(2);
            this.autofills_Button.Name = "autofills_Button";
            this.autofills_Button.Size = new System.Drawing.Size(103, 19);
            this.autofills_Button.TabIndex = 6;
            this.autofills_Button.Text = "Show autofills";
            this.autofills_Button.UseVisualStyleBackColor = true;
            this.autofills_Button.Click += new System.EventHandler(this.autofills_Button_Click);
            // 
            // all_Button
            // 
            this.all_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.all_Button.Location = new System.Drawing.Point(892, 157);
            this.all_Button.Margin = new System.Windows.Forms.Padding(2);
            this.all_Button.Name = "all_Button";
            this.all_Button.Size = new System.Drawing.Size(103, 38);
            this.all_Button.TabIndex = 7;
            this.all_Button.Text = "Run all";
            this.all_Button.UseVisualStyleBackColor = true;
            this.all_Button.Click += new System.EventHandler(this.all_Button_Click);
            // 
            // timelineButton
            // 
            this.timelineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timelineButton.Location = new System.Drawing.Point(891, 203);
            this.timelineButton.Margin = new System.Windows.Forms.Padding(2);
            this.timelineButton.Name = "timelineButton";
            this.timelineButton.Size = new System.Drawing.Size(103, 38);
            this.timelineButton.TabIndex = 8;
            this.timelineButton.Text = "Show timeline";
            this.timelineButton.UseVisualStyleBackColor = true;
            this.timelineButton.Click += new System.EventHandler(this.timelineButton_Click);
            // 
            // IncoherenciesButton
            // 
            this.IncoherenciesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IncoherenciesButton.Location = new System.Drawing.Point(892, 245);
            this.IncoherenciesButton.Margin = new System.Windows.Forms.Padding(2);
            this.IncoherenciesButton.Name = "IncoherenciesButton";
            this.IncoherenciesButton.Size = new System.Drawing.Size(103, 38);
            this.IncoherenciesButton.TabIndex = 9;
            this.IncoherenciesButton.Text = "Incoherencies";
            this.IncoherenciesButton.UseVisualStyleBackColor = true;
            this.IncoherenciesButton.Click += new System.EventHandler(this.incoherenciesButton_Click);
            // 
            // domainsButton
            // 
            this.domainsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.domainsButton.Location = new System.Drawing.Point(892, 287);
            this.domainsButton.Margin = new System.Windows.Forms.Padding(2);
            this.domainsButton.Name = "domainsButton";
            this.domainsButton.Size = new System.Drawing.Size(103, 38);
            this.domainsButton.TabIndex = 10;
            this.domainsButton.Text = "All domains found";
            this.domainsButton.UseVisualStyleBackColor = true;
            this.domainsButton.Click += new System.EventHandler(this.domainButton_Click);
            // 
            // chooseLocationButton
            // 
            this.chooseLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseLocationButton.Location = new System.Drawing.Point(896, 515);
            this.chooseLocationButton.Name = "chooseLocationButton";
            this.chooseLocationButton.Size = new System.Drawing.Size(99, 28);
            this.chooseLocationButton.TabIndex = 11;
            this.chooseLocationButton.Text = "Other Location...";
            this.chooseLocationButton.UseVisualStyleBackColor = true;
            this.chooseLocationButton.Click += new System.EventHandler(this.chooseLocationButton_Click);
            // 
            // resetLocationButton
            // 
            this.resetLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetLocationButton.Location = new System.Drawing.Point(897, 549);
            this.resetLocationButton.Name = "resetLocationButton";
            this.resetLocationButton.Size = new System.Drawing.Size(98, 30);
            this.resetLocationButton.TabIndex = 12;
            this.resetLocationButton.Text = "Reset Location";
            this.resetLocationButton.UseVisualStyleBackColor = true;
            this.resetLocationButton.Click += new System.EventHandler(this.resetLocationButton_Click);
            // 
            // locationLabel
            // 
            this.locationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(924, 581);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.locationLabel.Size = new System.Drawing.Size(44, 13);
            this.locationLabel.TabIndex = 13;
            this.locationLabel.Text = "location";
            this.locationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(12, 330);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(878, 249);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // searchDTOBindingSource
            // 
            this.searchDTOBindingSource.DataSource = typeof(DTO.SearchDTO);
            // 
            // labelFound
            // 
            this.labelFound.AutoSize = true;
            this.labelFound.Location = new System.Drawing.Point(12, 581);
            this.labelFound.Name = "labelFound";
            this.labelFound.Size = new System.Drawing.Size(59, 13);
            this.labelFound.TabIndex = 15;
            this.labelFound.Text = "labelFound";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 598);
            this.Controls.Add(this.labelFound);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.resetLocationButton);
            this.Controls.Add(this.chooseLocationButton);
            this.Controls.Add(this.domainsButton);
            this.Controls.Add(this.IncoherenciesButton);
            this.Controls.Add(this.timelineButton);
            this.Controls.Add(this.all_Button);
            this.Controls.Add(this.autofills_Button);
            this.Controls.Add(this.browsing_Button);
            this.Controls.Add(this.searches_Button);
            this.Controls.Add(this.cookies_Button);
            this.Controls.Add(this.passwords_Button);
            this.Controls.Add(this.downloads_Button);
            this.Controls.Add(this.Output);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "BrowserForensics";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.Button downloads_Button;
        private System.Windows.Forms.Button passwords_Button;
        private System.Windows.Forms.Button cookies_Button;
        private System.Windows.Forms.Button searches_Button;
        private System.Windows.Forms.Button browsing_Button;
        private System.Windows.Forms.Button autofills_Button;
        private System.Windows.Forms.Button all_Button;
        private System.Windows.Forms.Button timelineButton;
        private System.Windows.Forms.Button IncoherenciesButton;
        private System.Windows.Forms.Button domainsButton;
        private System.Windows.Forms.Button chooseLocationButton;
        private System.Windows.Forms.Button resetLocationButton;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource searchDTOBindingSource;
        private System.Windows.Forms.Label labelFound;
    }
}

