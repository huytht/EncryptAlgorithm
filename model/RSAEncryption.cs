using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptAlgorithm.model
{
    class RSAEncryption
    {
        #region Function_Encrypt_Decrypt
        public static byte[] Encrypt(byte[] data, RSAParameters RSAKey, bool doOAEF)
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(RSAKey);
                return rsa.Encrypt(data, doOAEF);
            }
            catch (CryptographicException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static byte[] Decrypt(byte[] data, RSAParameters RSAKey, bool doOAEF)
        {
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(RSAKey);
                return rsa.Decrypt(data, doOAEF);
            }
            catch (CryptographicException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        #endregion
    }
}
