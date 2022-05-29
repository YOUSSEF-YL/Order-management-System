using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Gestion_des_command
{
  public  class Users
    {
        public static List<Users> lsuser = new List<Users>();

        public string Username { get; set; }
        public string password { get; set; }

        public Users(string Username , string password)
        {
            this.Username = Username;
            this.password = password;
        }
        public static List<Users> load(string path)
        {

            XmlSerializer serialiser = new XmlSerializer(typeof(List<Users>));

            StreamReader strr = new StreamReader(path);

            List<Users> lsus = (List<Users>)serialiser.Deserialize(strr);

            strr.Close();

            return lsus;

        }

        public static void save(string path, List<Users> ls)
        {

            XmlSerializer serialiser = new XmlSerializer(typeof(List<Users>));

            StreamWriter strw = new StreamWriter(path);

            serialiser.Serialize(strw, ls);

            strw.Close();

        }

        public Users()
        {

        }
    }
}
