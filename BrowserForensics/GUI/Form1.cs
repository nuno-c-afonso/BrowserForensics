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
        private Controller.Controller c;
        public Form1() {
            InitializeComponent();
            c = new Controller.Controller();
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
    }
}
