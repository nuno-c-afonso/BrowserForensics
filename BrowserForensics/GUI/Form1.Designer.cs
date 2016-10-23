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
            this.Output = new System.Windows.Forms.TextBox();
            this.downloads_Button = new System.Windows.Forms.Button();
            this.passwords_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Output
            // 
            this.Output.Location = new System.Drawing.Point(13, 13);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Output.Size = new System.Drawing.Size(420, 228);
            this.Output.TabIndex = 0;
            // 
            // downloads_Button
            // 
            this.downloads_Button.Location = new System.Drawing.Point(440, 13);
            this.downloads_Button.Name = "downloads_Button";
            this.downloads_Button.Size = new System.Drawing.Size(137, 23);
            this.downloads_Button.TabIndex = 1;
            this.downloads_Button.Text = "Show downloads";
            this.downloads_Button.UseVisualStyleBackColor = true;
            this.downloads_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // passwords_Button
            // 
            this.passwords_Button.Location = new System.Drawing.Point(440, 42);
            this.passwords_Button.Name = "passwords_Button";
            this.passwords_Button.Size = new System.Drawing.Size(137, 23);
            this.passwords_Button.TabIndex = 2;
            this.passwords_Button.Text = "Show passwords";
            this.passwords_Button.UseVisualStyleBackColor = true;
            this.passwords_Button.Click += new System.EventHandler(this.passwords_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 253);
            this.Controls.Add(this.passwords_Button);
            this.Controls.Add(this.downloads_Button);
            this.Controls.Add(this.Output);
            this.Name = "Form1";
            this.Text = "BrowserForensics";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.Button downloads_Button;
        private System.Windows.Forms.Button passwords_Button;
    }
}

