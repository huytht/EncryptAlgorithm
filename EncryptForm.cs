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

        RSAKey rsaKey = new RSAKey(string.Empty, string.Empty);

        private void btnEncryptRSA_Click(object sender, EventArgs e)
        {
            rsaKey = RSAEncryption.GenerateKeys(1024);
            if (txtPlainTextRSA.Text.Length > 0 && txtPlainTextRSA.Text.Trim() != "")
            {
                txtCipherTextRSA.Text = RSAEncryption.Encrypt(rsaKey.publicKey, txtPlainTextRSA.Text);
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
                txtDecryptTextRSA.Text = RSAEncryption.Decrypt(rsaKey.privateKey, txtCipherTextRSA.Text);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập chuỗi đã mã hóa");
            }
        }
    }
}
