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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

            foreach (Produit P in Produit.lsprod)
            {

                int Reference = P.Reference;
                String Designation = P.Designation;
                double Prix = P.Prix;
                int Quantite = P.Quantite;

                    dataGridView1.Rows.Add(Reference, Designation, Prix ,Quantite);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Produit pd in Produit.lsprod)
            {
                if (textBox1.Text == pd.Reference.ToString())
                {
                    dataGridView1.Rows.Add(pd.Reference,pd.Designation, pd.Prix,pd.Quantite);
                }
            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button2.BackColor = Color.SkyBlue;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
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
            Produit.lsprod.RemoveAt(index);
            Form1.reg = 0;
        }
        
    }

}


