using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptAlgorithm.model
{
	public class RSAKey
	{
		public string publicKey { get; set; }
		public string privateKey { get; set; }

		public RSAKey(string privateKey, string publicKey)
		{
			this.privateKey = privateKey;
			this.publicKey = publicKey;
		}
	}
	class RSAEncryption
    {
        
		public static RSAKey GenerateKeys(int keySize = 4096)
		{
			string publicKey = "";
			string privateKey = "";

			using (var rsaProvider = new RSACryptoServiceProvider(keySize))
			{
				try
				{
					publicKey = rsaProvider.ToXmlString(false);
					privateKey = rsaProvider.ToXmlString(true);
				}
				catch (Exception ex)
				{
				}
				finally
				{
					rsaProvider.PersistKeyInCsp = false;
					rsaProvider.Dispose();
				}
			}

			return new RSAKey(privateKey, publicKey);
		}
		public static string Encrypt(string publicKey, string textToEncrypt)
		{
			byte[] plainBytes = null;
			byte[] encryptedBytes = null;
			string encryptedText = "";

			using (var rsaProvider = new RSACryptoServiceProvider())
			{
				try
				{
					rsaProvider.FromXmlString(publicKey);

					plainBytes = Encoding.UTF8.GetBytes(textToEncrypt);
					encryptedBytes = rsaProvider.Encrypt(plainBytes, false);
					encryptedText = Convert.ToBase64String(encryptedBytes);
				}
				catch (Exception ex)
				{
				}
				finally
				{
					rsaProvider.PersistKeyInCsp = false;
					rsaProvider.Dispose();
				}
			}

			return encryptedText;
		}

		public static string Decrypt(string privateKey, string encryptedTextBase64)
		{
			string decryptedText = "";
			byte[] plainBytes = null;

			using (var rsaProvider = new RSACryptoServiceProvider())
			{
				try
				{
					rsaProvider.FromXmlString(privateKey);

					plainBytes = rsaProvider.Decrypt(Convert.FromBase64String(encryptedTextBase64), false);
					decryptedText = Encoding.UTF8.GetString(plainBytes);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Không thể giải mã bản mã trên");
				}
				finally
				{
					rsaProvider.PersistKeyInCsp = false;
					rsaProvider.Dispose();
				}
			}

			return decryptedText;
		}
	}
}
