using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HowlingWolf
{
    public partial class AddingForm : Form
    {
        public AddingForm()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Static @static = new Static();
            MessageBox.Show(@static .Path );
        }
    }
}
