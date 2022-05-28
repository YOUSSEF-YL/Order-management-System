using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace Gestion_des_command
{
    public partial class Form1 : Form
    {
        public static int reg = 0;
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Produit.lsprod= Produit.Charger("E:\\lsProduit.xml");
           //  Form2.lscli = Client.Charger("E:\\lsClient.xml");
          //   Form4.lscom =  Commande.Charger("E:\\lsCommande.xml");
            panel2.Visible = false;
            panel3.Visible = false;
            int totalpd = Totalitem();

           
            for (int i = 0; i < Produit.lsprod.Count; i++)
            {
                if (i == 0)
                {
                    label7.Visible = true;
                    label7.Text = Produit.lsprod[i].Designation.ToUpper();
                    // panel10.Width = Produit.lsprod[i].Quantite;
                    panel10.Width = Produit.lsprod[i].Quantite / 362;
                     panel5.Visible = true;
                    label11.Text = label7.Text + ":" + Produit.lsprod[i].Quantite;
                    label11.Visible = true;
                }
                if (i == 1)
                {
                    label8.Visible = true;
                    label8.Text = Produit.lsprod[i].Designation.ToUpper();
                    panel11.Width = Produit.lsprod[i].Quantite / 362;
                    panel6.Visible = true;
                    label12.Text = label8.Text + ":" + Produit.lsprod[i].Quantite;
                    label12.Visible = true;
                }
                if (i == 2)
                {
                    label9.Visible = true;
                    label9.Text = Produit.lsprod[i].Designation.ToUpper();
                    panel12.Width = Produit.lsprod[i].Quantite / 362;
                    panel7.Visible = true;
                    label13.Text = label9.Text + ":" + Produit.lsprod[i].Quantite;
                    label13.Visible = true;
                }
                if (i == 3)
                {
                    label10.Visible = true;
                    label10.Text = Produit.lsprod[i].Designation.ToUpper();
                    panel9.Width = Produit.lsprod[i].Quantite / 362;
                    panel8.Visible = true;
                    label14.Text = label10.Text + ":" + Produit.lsprod[i].Quantite;
                    label14.Visible = true;
                }
                //362 bar lenght
                //362 bar lenght
                Totalitem();
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (reg == 1)
            {
                Application.Exit();
            }
            else
                MessageBox.Show("Sauvegarder vos donnees", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public int aj = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (aj == 0)
            {
                button5.Location = new Point(4, 134);
                panel2.Visible = true;
                panel2.Location = new Point(3, 36);
                aj = 1;
            }
            else if (aj == 1)
            {
                button5.Location = new Point(1, 36);
                panel2.Visible = false;
                panel2.Location = new Point(3, 72);
                aj = 0;
            }
            if (re == 1)
            {
                panel3.Visible = false;
            }

        }
        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.DeepSkyBlue;
        }
        public int re = 0;
        private void button5_Click(object sender, EventArgs e)
        {

            if (aj == 0)
            {

                if (re == 0)
                {
                    panel3.Location = new Point(3, 65);
                    panel3.Visible = true;
                    re = 1;
                }
                else if (re == 1)
                {
                    panel3.Visible = false;
                    re = 0;
                }
            }
            else if (aj == 1)
            {
                if (re == 0)
                {
                    panel3.Location = new Point(3, 165);
                    panel3.Visible = true;
                    re = 1;
                }
                else if (re == 1)
                {
                    panel3.Visible = false;
                    re = 0;

                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Produit.Enregistre("D:\\lsProduit.xml", Produit.lsprod);
            Client.Enregistre("D:\\lsClient.xml", Form2.lscli);
            Commande.Enregistre("D:\\lsCommande.xml", Form4.lscom);

            reg = 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 frm4 = new Form4();
            frm4.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 frm5 = new Form5();
            frm5.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 frm6 = new Form6();
            frm6.Show();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.DeepSkyBlue;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = Color.DeepSkyBlue;
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            label6.ForeColor = Color.DeepSkyBlue;
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.ForeColor = Color.DeepSkyBlue;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.MidnightBlue;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.MidnightBlue;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.MidnightBlue;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.MidnightBlue;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.MidnightBlue;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.DeepSkyBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.RoyalBlue;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.DeepSkyBlue;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.RoyalBlue;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.DeepSkyBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.RoyalBlue;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 frm7 = new Form7();
            frm7.Show();
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.ForeColor = Color.DeepSkyBlue;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.MidnightBlue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f9 = new Form9();
            f9.Show();
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.ForeColor = Color.DeepSkyBlue;
        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.MidnightBlue;
        }
        int items = 0;
        public int Totalitem()
        {
          
            foreach (Produit pd in Produit.lsprod)
            {
                items += pd.Quantite;
            }
            return items;
        }
    }
}
