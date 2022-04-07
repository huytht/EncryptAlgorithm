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
            EnabledInput(false);
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

        //RSAKey rsaKey = new RSAKey(string.Empty, string.Empty);

        //private void btnEncryptRSA_Click(object sender, EventArgs e)
        //{
        //    rsaKey = RSAEncryption.GenerateKeys(1024);
        //    if (txtPlainTextRSA.Text.Length > 0 && txtPlainTextRSA.Text.Trim() != "")
        //    {
        //        txtCipherTextRSA.Text = RSAEncryption.Encrypt(rsaKey.publicKey, txtPlainTextRSA.Text);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Vui lòng nhập chuỗi cần mã hóa");
        //    }

        //}

        //private void btnDecryptRSA_Click(object sender, EventArgs e)
        //{
        //    if (txtCipherTextRSA.Text.Length > 0 && txtCipherTextRSA.Text.Trim() != "")
        //    {
        //        txtDecryptTextRSA.Text = RSAEncryption.Decrypt(rsaKey.privateKey, txtCipherTextRSA.Text);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Vui lòng nhập chuỗi đã mã hóa");
        //    }
        //}

        RSAEncryption rsa = new RSAEncryption();
        private void btnEncryptRSA_Click(object sender, EventArgs e)
        {
            if (!rsa.existKey)
            { MessageBox.Show("Bạn chưa tạo khóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            else
            {
                if (txtPlainTextRSA.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập bản rõ để mã hóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    // thực hiện mã hóa
                    try
                    {
                        txtCipherTextRSA.Text = rsa.Encrypt(txtPlainTextRSA.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDecryptRSA_Click(object sender, EventArgs e)
        {
            if (!rsa.existKey)
                MessageBox.Show("Bạn chưa tạo khóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                try
                {
                    txtDecryptTextRSA.Text = rsa.Decrypt(txtCipherTextRSA.Text);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Bản mã không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void ResetRSA()
        {
            txtRSANumberP.Text = txtRSANumberQ.Text = txtRSAPhiNumberN.Text = txtRSANumberN.Text = txtRSANumberE.Text = txtRSANumberD.Text = string.Empty;
            rsa.existKey = false;
        }

        private void EnabledInput(bool enabled)
        {
            txtRSANumberP.Enabled = txtRSANumberQ.Enabled = txtRSAPhiNumberN.Enabled = txtRSANumberN.Enabled = txtRSANumberE.Enabled = txtRSANumberD.Enabled = enabled;
        }

        private void btnCreateKey_Click(object sender, EventArgs e)
        {
            if (rbRandom.Checked == true && rbOptinal.Checked == false)
            {
                rsa.numberP = rsa.numberQ = 0;
                do
                {
                    rsa.numberP = rsa.RandomNumber();
                    rsa.numberQ = rsa.RandomNumber();
                }
                while (rsa.numberP == rsa.numberQ || !rsa.checkSNT(rsa.numberP) || !rsa.checkSNT(rsa.numberQ));
                
                txtRSANumberP.Text = rsa.numberP.ToString();
                txtRSANumberQ.Text = rsa.numberQ.ToString();
                rsa.GenerateKey();
                txtRSAPhiNumberN.Text = rsa.phiNumberN.ToString();
                txtRSANumberN.Text = rsa.numberN.ToString();
                txtRSANumberE.Text = rsa.numberE.ToString();
                txtRSANumberD.Text = rsa.numberD.ToString();
                rsa.existKey = true;
            }
            else
            {
                if (rbRandom.Checked == false && rbOptinal.Checked == true)
                {
                    if (txtRSANumberP.Text == "" || txtRSANumberQ.Text == "")
                        MessageBox.Show("Phải nhập đủ 2 số p và q", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        rsa.numberP = int.Parse(txtRSANumberP.Text);
                        rsa.numberQ = int.Parse(txtRSANumberQ.Text);
                        if (rsa.numberP == rsa.numberQ)
                        {
                            MessageBox.Show("Nhập 2 số nguyên tố khác nhau ", " Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtRSANumberQ.Focus();
                        }
                        else
                        {
                            if (!rsa.checkSNT(rsa.numberP) || rsa.numberP < 10)
                            {
                                MessageBox.Show("Phải nhập số nguyên tố p lớn hơn 10 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtRSANumberP.Focus();
                            }
                            else
                            {
                                if (!rsa.checkSNT(rsa.numberQ) || rsa.numberQ < 10)
                                {
                                    MessageBox.Show("Phải nhập số nguyên tố q lớn hơn 10 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtRSANumberQ.Focus();
                                }
                                else
                                {
                                    //rsa.numberP = int.Parse(txtRSANumberP.Text);
                                    //rsa.numberQ = int.Parse(txtRSANumberQ.Text);
                                    rsa.GenerateKey();
                                    txtRSAPhiNumberN.Text = rsa.phiNumberN.ToString();
                                    txtRSANumberN.Text = rsa.numberN.ToString();
                                    txtRSANumberE.Text = rsa.numberE.ToString();
                                    txtRSANumberD.Text = rsa.numberD.ToString();
                                    rsa.existKey = true;
                                }
                            }
                        }
                    }

                }
            }
        }

        private void rbRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRandom.Checked)
            {
                btnCreateKey.Text = "Tạo khóa ngẫu nhiên";
                EnabledInput(false);
            }
            else
            {
                btnCreateKey.Text = "Tạo khóa tùy chọn";
                EnabledInput(true);
            }
            ResetRSA();
        }
    }
}
