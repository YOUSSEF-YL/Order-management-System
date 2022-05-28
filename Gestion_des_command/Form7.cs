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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            {
                foreach (Commande com in Form4.lscom)
                {
                   string Client_Nom = com.Client_Nom;
                    DateTime DateCommande = com.DateCommande;
                  int Numerero_commande =  com.Numerero_commande;
                  int Quantite_Command =  com.Quantite_Command;

                    dataGridView1.Rows.Add(Client_Nom , Quantite_Command, Numerero_commande, DateCommande.ToShortDateString());
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button2.BackColor = Color.SkyBlue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Commande com in Form4.lscom)
            {
                if (textBox1.Text == com.Client_Nom)
                {
                    dataGridView1.Rows.Add(com.Client_Nom, com.Quantite_Command, com.Numerero_commande,
                        com.DateCommande);
                   
                }
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.DeepSkyBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows.RemoveAt(index);
            Form4.lscom.RemoveAt(index);
            Form1.reg = 0;
        }
    }
}