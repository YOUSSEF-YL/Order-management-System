using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_des_command
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
                panel2.Width += 2;

            
           

            if (panel2.Width > 347)
            {
                Form9 frm9 = new Form9();
                this.Hide();
                frm9.Show();
               // panel2.Width = 0;
                timer1.Stop();
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
