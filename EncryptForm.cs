using EncryptAlgorithm.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptAlgorithm
{
    public partial class EncryptForm : Form
    {
        Vigener vigener = new Vigener(String.Empty);
        public EncryptForm()
        {
            InitializeComponent();
        }

        private void btnEncryptVigener_Click(object sender, EventArgs e)
        {
            vigener.key = txtKeyVigener.Text;
            vigener.plainText = txtPlainTextVigener.Text;
            txtCipherVigener.Text = vigener.encryptVietnamese();
        }

        private void btnDecryptVigener_Click(object sender, EventArgs e)
        {
            vigener.key = txtKeyVigener.Text;
            vigener.cipherText = txtCipherVigener.Text;
            txtDecryptVigener.Text = vigener.decryptVietnamese();
        }

        #region BienTrungGian
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        byte[] plainTextRSA;
        byte[] cipherTextRSA;
        #endregion

        private void btnEncryptRSA_Click(object sender, EventArgs e)
        {
            plainTextRSA = Encoding.UTF8.GetBytes(txtPlainTextRSA.Text);
            cipherTextRSA = RSAEncryption.Encrypt(plainTextRSA, rsa.ExportParameters(false), false);
            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in cipherTextRSA)
                sbHash.Append(String.Format("{0:x2}", b));
            txtCipherTextRSA.Text = sbHash.ToString();
        }

        private void btnDecryptRSA_Click(object sender, EventArgs e)
        {
            byte[] decryptText = RSAEncryption.Decrypt(cipherTextRSA, rsa.ExportParameters(true), false);
            txtDecryptTextRSA.Text = Encoding.UTF8.GetString(decryptText);
        }
    }
}
