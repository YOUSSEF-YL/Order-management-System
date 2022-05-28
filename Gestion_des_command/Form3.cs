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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
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
                int reference = int.Parse(textBox1.Text);
                string designation = textBox2.Text;
                double prix = double.Parse(textBox3.Text);
                int quantite = int.Parse(textBox4.Text);
                Produit prod = new Produit(reference, designation, prix
                    , quantite);
                Produit.lsprod.Add(prod);
                Form1.reg = 0;
            }
            catch (Exception)
            {

                MessageBox.Show("Il y a une erreur de saisie", "ERROR"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Focus();

            foreach (Control c in Controls)
            {
                if (c is TextBox)
                    c.Text = "";
                button1.Enabled = false;
                button1.BackColor = Color.White;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
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

       

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
        }
    }
}
