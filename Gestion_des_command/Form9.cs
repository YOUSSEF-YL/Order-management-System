using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Gestion_des_command
{
    public partial class Form9 : Form
    {
		//public static string PasswordHash { get; private set; }
		//public static char[] VIKey { get; private set; }
		//public static char[] SaltKey { get; private set; }
		static readonly string PasswordHash = "P@@Sw0rd";
		static readonly string SaltKey = "S@LT&KEY";
		static readonly string VIKey = "@1B2c3D4e5F6g7H8";

		

		public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            try
            {
				Users.lsuser = Users.Charger("E:\\list-users.xml");
			}
            catch (Exception)
            {
				//

			}
		}

		public static string Encrypt(string plainText)
		{
			byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

			byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
			var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
			var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

			byte[] cipherTextBytes;

			using (var memoryStream = new MemoryStream())
			{
				using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
				{
					cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
					cryptoStream.FlushFinalBlock();
					cipherTextBytes = memoryStream.ToArray();
					cryptoStream.Close();
				}
				memoryStream.Close();
			}
			return Convert.ToBase64String(cipherTextBytes);
		}

		public static string Decrypt(string encryptedText)
		{
			byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
			byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
			var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

			var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
			var memoryStream = new MemoryStream(cipherTextBytes);
			var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
			byte[] plainTextBytes = new byte[cipherTextBytes.Length];

			int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
			memoryStream.Close();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string username;
			string password;
			username = textBox1.Text;
			password = textBox2.Text;

			

			foreach (Users us in Users.lsuser)
			{
				if (username == us.Username && password == Decrypt(us.password))
				{
					Form1 f1 = new Form1();
					this.Hide();
					f1.Show();
				}
			}

		}

		private void button2_Click(object sender, EventArgs e)
		{
			string password;
			string pass;
			string username;
			username = textBox1.Text;
			password = textBox2.Text;
			pass =  Encrypt(password);
			Users usr = new Users(username, pass);
			Users.lsuser.Add(usr);

			Users.Enregistre("E:\\list-users.xml",Users.lsuser);
		}
	}
}
