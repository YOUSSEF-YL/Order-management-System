using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Gestion_des_command
{
   public class Client
    {


        public int Code { get; set; }

        public string Nom { get; set; }

        public string Adresse { get; set; }

        public string Tel { get; set; }

        public string Mail { get; set; }

       
        public Client(int code, string nom, string adresse, string tel, string mail)
        {
            Code = code;
            Nom = nom;
            Adresse = adresse;
            Tel = tel;
            Mail = mail;
        }
       
       
        public static void Enregistre(string chemin, List<Client> ls)
        {

            XmlSerializer serialiser = new XmlSerializer(typeof(List<Client>));

            StreamWriter strw = new StreamWriter(chemin);

            serialiser.Serialize(strw, ls);

            strw.Close();

        }
        
        public static List<Client> Charger(string chemin)
        {

            XmlSerializer serialiser = new XmlSerializer(typeof(List<Client>));

            StreamReader strr = new StreamReader(chemin);

           List<Client> lsc = (List<Client>)serialiser.Deserialize(strr);

            strr.Close();

            return lsc;

        }
        public Client()
        {

        }
        
    }
}
