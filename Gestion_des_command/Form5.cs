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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            

            foreach (Client c in Form2.lscli)
            {
                string Code = c.Code.ToString();
                string Nom = c.Nom;
                string Tel = c.Tel;
                string Mail = c.Mail;
                string Adresse = c.Adresse;
                dataGridView1.Rows.Add(Code, Nom,Adresse ,Tel, Mail);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            button2.Enabled = true;
            button2.BackColor = Color.SkyBlue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Client cli in Form2.lscli)
            {
                
                if (int.Parse(textBox1.Text) == cli.Code)
                {
                    dataGridView1.Rows.Add(cli.Code,cli.Nom ,cli.Adresse,cli.Tel ,cli.Mail);
                }
            }
           
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
            Form2.lscli.RemoveAt(index);
            Form1.reg = 0;
        }
    }
}
