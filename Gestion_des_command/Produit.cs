using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Gestion_des_command
{
   public class Produit
    {

        public static List<Produit> lsprod = new List<Produit>();

        public int Reference { get; set; }

        public String Designation { get; set; }

        public double Prix { get; set; }

        public int Quantite { get; set; }

        public Produit(int reference, string designation, double prix, int quantite)
        {

            Reference = reference;
            Designation = designation;
            Prix = prix;
            Quantite = quantite;
        }
       
        public static void Enregistre(string chemin, List<Produit> ls)
        {

            XmlSerializer serialiser = new XmlSerializer(typeof(List<Produit>));

            StreamWriter strw = new StreamWriter(chemin);

            serialiser.Serialize(strw, ls);

            strw.Close();

        }

        public static List<Produit> Charger(string path)
        {

            XmlSerializer serialiser = new XmlSerializer(typeof(List<Produit>));

            StreamReader strr = new StreamReader(path);

            List<Produit> lsp = (List<Produit>)serialiser.Deserialize(strr);

            strr.Close();

            return lsp;

        }

        public Produit()
        {

        }



    }
}
