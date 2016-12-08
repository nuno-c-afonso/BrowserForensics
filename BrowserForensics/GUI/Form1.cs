using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI {
    public partial class Form1 : Form {
        private Controller.Controller first;
        private Controller.Controller c;
        public Form1() {
            InitializeComponent();
            first = new Controller.Controller();
            c = first;

            locationLabel.Text = "";
        }

        private void button1_Click(object sender, EventArgs e) {
            Output.Text = c.getDownloads();
        }

        private void passwords_Button_Click(object sender, EventArgs e) {
            Output.Text = c.getPasswords();
        }

        private void cookies_Button_Click(object sender, EventArgs e) {
            Output.Text = c.getCookies();
        }

        private void searches_Button_Click(object sender, EventArgs e) {
            Output.Text = c.getSearches();
        }

        private void browsing_Button_Click(object sender, EventArgs e) {
            Output.Text = c.getHistory();
        }

        private void autofills_Button_Click(object sender, EventArgs e) {
            Output.Text = c.getAutofills();
        }

        private void all_Button_Click(object sender, EventArgs e) {
            Output.Text = c.getAllInfo();
        }

        private void timelineButton_Click(object sender, EventArgs e) {
            Output.Text = c.getTimeline();
        }

        private void incoherenciesButton_Click(object sender, EventArgs e) {
            Output.Text = c.detectIncoherencies();
        }
        private void domainButton_Click(object sender, EventArgs e) {
            Output.Text = c.getAllDomains();
        }

        private void chooseLocationButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                locationLabel.Text = "Custom Location: " + folderBrowserDialog1.SelectedPath;
                c = new Controller.Controller(folderBrowserDialog1.SelectedPath);
                if (locationLabel.Right > this.Width)
                    locationLabel.Left = this.Width - locationLabel.Width - 20;
            }
             

        }

        private void resetLocationButton_Click(object sender, EventArgs e)
        {
            locationLabel.Text = "";
            c = first;
        }
    }
}
