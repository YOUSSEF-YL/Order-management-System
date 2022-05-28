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
    public partial class Form4 : Form
    {
        public static List<Commande> lscom = new List<Commande>();
        int Quantite_stock;
        int Quantite_Command;
        public Form4()
        {
            InitializeComponent();
        }
       
        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (Client c in Form2.lscli)
            {
                comboBox1.Items.Add(c.Nom);

            }
            foreach (Produit P in Produit.lsprod)
            {
                comboBox2.Items.Add(P.Reference);

            }
           

        }
        

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            foreach (Produit pr in Produit.lsprod)
            {

                textBox2.Text = pr.Prix.ToString();

                textBox3.Text = pr.Quantite.ToString();
                Quantite_stock = pr.Quantite;
               
            }
           
        }
        Produit prod = null;
        private Produit Getprod()
        {
            
            foreach (Produit Pd in Produit.lsprod)
            {
                if (Pd.Quantite == Quantite_stock)
                {
                    prod = Pd;
                }
            }

            return prod;
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
            Produit prod = Getprod();
            prod.Quantite = Quantite_stock - Quantite_Command;
            ////
            ///
            Quantite_Command = int.Parse(textBox1.Text);
             string clin_Nom = comboBox1.SelectedItem.ToString();
            DateTime DateCommande = DateTime.Now;
            
            try
            {
                if (Quantite_Command < Quantite_stock)
                {
                    
                    Commande com = new Commande(clin_Nom, Quantite_Command, DateCommande);
                    lscom.Add(com);
                    Form1.reg = 0;
                }
                else
                    MessageBox.Show("La Quantite Commande est superieyr a la Quantite de stock", "ERROR"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception)
            {

                MessageBox.Show("Il y a une erreur de saisie", "ERROR"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            foreach (Control c in Controls)
            {
                if (c is ComboBox)
                {
                    c.Text = "";
                }
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            comboBox1.Focus();
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.BackColor = Color.SkyBlue;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
        }
    }



 }

