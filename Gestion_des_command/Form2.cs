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
    public partial class Form2 : Form
    {

        public static List<Client> lscli = new List<Client>();
        public Form2()
        {
            InitializeComponent();
            
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
                if (c is TextBox)
                {
                    if (c.Text == "")
                    {
                        button1.Enabled = false;
                    }
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int code = int.Parse(textBox1.Text);

                string nom = textBox2.Text;

                string adresse = textBox3.Text;

                string tel = maskedTextBox1.Text;

                string mail = textBox5.Text;

                Client cli = new Client(code, nom, adresse, tel, mail);
                lscli.Add(cli);
                Form1.reg = 0;

            }
            catch (Exception)
            {

                MessageBox.Show("Il y a une erreur de saisie", "ERROR"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                    c.Text = "";
                button1.Enabled = false;
                button1.BackColor = Color.White;
            }
            textBox1.Focus();
            maskedTextBox1.Text = "";

        }

       
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            foreach (Control c in Controls)

                if (c is TextBox)
                {
                    if (c.Text != "")
                    {
                        button1.Enabled = true;
                        button1.BackColor = Color.SkyBlue;
                    }

                }
        }

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                    e.Handled = true;
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
        }
    }
}
