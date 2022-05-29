using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Gestion_des_command
{


   public class Commande
    {
        

        public int Numerero_commande { get; set; }
        static int numcom = 1;

        public string Client_Nom { get; set; }

        public DateTime DateCommande { get; set; }

        public int Quantite_Command { get; set; }
        public Commande (string Client_Nom,int Quantite_Command, DateTime DateCommande)
        {
           Numerero_commande = numcom;
            numcom++;
            this.DateCommande = DateCommande;
            this.Client_Nom = Client_Nom;
            this.Quantite_Command = Quantite_Command;

        }
      
        public static void save(string chemin, List<Commande> ls)
        {

            XmlSerializer serialiser = new XmlSerializer(typeof(List<Commande>));

            StreamWriter strw = new StreamWriter(chemin);

            serialiser.Serialize(strw, ls);

            strw.Close();

        }

        public static List<Commande> load(string chemin)
        {

            XmlSerializer serialiser = new XmlSerializer(typeof(List<Commande>));

            StreamReader strr = new StreamReader(chemin);

            List<Commande> lscom = (List<Commande>)serialiser.Deserialize(strr);

            strr.Close();

            return lscom;

        }
        public Commande()
        {

        }
        
    }
}
