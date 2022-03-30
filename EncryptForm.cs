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
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void btnEncryptVigener_Click(object sender, EventArgs e)
        {   
            if (txtKeyVigener.Text.Length > 0 && txtKeyVigener.Text.Trim() != "")
            {
                vigener.key = txtKeyVigener.Text;
                if (txtPlainTextVigener.Text.Length > 0 && txtPlainTextVigener.Text.Trim() != "")
                {
                    vigener.plainText = txtPlainTextVigener.Text;
                    txtCipherVigener.Text = vigener.encryptVietnamese();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập chuỗi cần mã hóa");
                }
            } else
            {
                MessageBox.Show("Vui lòng nhập khóa");
            }
        }

        private void btnDecryptVigener_Click(object sender, EventArgs e)
        {
            if (txtKeyVigener.Text.Length > 0 && txtKeyVigener.Text.Trim() != "")
            {
                vigener.key = txtKeyVigener.Text;
                if (txtCipherVigener.Text.Length > 0 && txtCipherVigener.Text.Trim() != "")
                {
                    vigener.cipherText = txtCipherVigener.Text;
                    txtDecryptVigener.Text = vigener.decryptVietnamese();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập chuỗi đã mã hóa");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập khóa");
            }
        }

        #region BienTrungGian
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        byte[] plainTextRSA;
        byte[] cipherTextRSA;
        #endregion

        private void btnEncryptRSA_Click(object sender, EventArgs e)
        {
            if (txtPlainTextRSA.Text.Length > 0 && txtPlainTextRSA.Text.Trim() != "")
            {
                plainTextRSA = Encoding.UTF8.GetBytes(txtPlainTextRSA.Text);
                cipherTextRSA = RSAEncryption.Encrypt(plainTextRSA, rsa.ExportParameters(false), false);
                StringBuilder sbHash = new StringBuilder();
                foreach (byte b in cipherTextRSA)
                    sbHash.Append(String.Format("{0:x2}", b));
                txtCipherTextRSA.Text = sbHash.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập chuỗi cần mã hóa");
            }

        }

        private void btnDecryptRSA_Click(object sender, EventArgs e)
        {
            if (txtCipherTextRSA.Text.Length > 0 && txtCipherTextRSA.Text.Trim() != "")
            {
                byte[] decryptText = RSAEncryption.Decrypt(cipherTextRSA, rsa.ExportParameters(true), false);
                txtDecryptTextRSA.Text = Encoding.UTF8.GetString(decryptText);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập chuỗi đã mã hóa");
            }
        }
    }
}
