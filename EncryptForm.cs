using EncryptAlgorithm.helpers;
using EncryptAlgorithm.model;
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

namespace EncryptAlgorithm
{
    public partial class EncryptForm : Form
    {
        Vigener vigener = new Vigener(String.Empty);
        static string signFileName = @"D:\C-Sharp\EncryptAlgorithm\files\MyResultSign.txt";

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
            txtRSANumberPSign.Text = txtRSANumberQSign.Text = txtRSANumberPhiNSign.Text = txtRSANumberNSign.Text = txtRSANumberESign.Text = txtRSANumberDSign.Text = string.Empty;
            rsa.existKey = false;
        }

        private void EnabledInput(bool enabled)
        {
            txtRSANumberP.Enabled = txtRSANumberQ.Enabled = txtRSAPhiNumberN.Enabled = txtRSANumberN.Enabled = txtRSANumberE.Enabled = txtRSANumberD.Enabled = enabled;
            txtRSANumberPSign.Enabled = txtRSANumberQSign.Enabled = txtRSANumberPhiNSign.Enabled = txtRSANumberNSign.Enabled = txtRSANumberESign.Enabled = txtRSANumberDSign.Enabled = enabled;
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

        private void rbRandomSign_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRandomSign.Checked)
            {
                btnCreateKeySign.Text = "Tạo khóa ngẫu nhiên";
                EnabledInput(false);
            }
            else
            {
                btnCreateKeySign.Text = "Tạo khóa tùy chọn";
                EnabledInput(true);
            }
            ResetRSA();
        }

        private void btnChooseFileSign_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            txtFileSign.Text = TextFile.OpenFile(openFileDialog1.FileName);
        }

        private void btnCreateKeySign_Click(object sender, EventArgs e)
        {
            if (rbRandomSign.Checked == true && rbOptinalSign.Checked == false)
            {
                rsa.numberP = rsa.numberQ = 0;
                do
                {
                    rsa.numberP = rsa.RandomNumber();
                    rsa.numberQ = rsa.RandomNumber();
                }
                while (rsa.numberP == rsa.numberQ || !rsa.checkSNT(rsa.numberP) || !rsa.checkSNT(rsa.numberQ));

                txtRSANumberPSign.Text = rsa.numberP.ToString();
                txtRSANumberQSign.Text = rsa.numberQ.ToString();
                rsa.GenerateKey();
                txtRSANumberPhiNSign.Text = rsa.phiNumberN.ToString();
                txtRSANumberNSign.Text = rsa.numberN.ToString();
                txtRSANumberESign.Text = rsa.numberE.ToString();
                txtRSANumberDSign.Text = rsa.numberD.ToString();
                rsa.existKey = true;
            }
            else
            {
                if (rbRandomSign.Checked == false && rbOptinalSign.Checked == true)
                {
                    if (txtRSANumberPSign.Text == "" || txtRSANumberQSign.Text == "")
                        MessageBox.Show("Phải nhập đủ 2 số p và q", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        rsa.numberP = int.Parse(txtRSANumberPSign.Text);
                        rsa.numberQ = int.Parse(txtRSANumberQSign.Text);
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
                                    rsa.GenerateKey();
                                    txtRSANumberPhiNSign.Text = rsa.phiNumberN.ToString();
                                    txtRSANumberNSign.Text = rsa.numberN.ToString();
                                    txtRSANumberESign.Text = rsa.numberE.ToString();
                                    txtRSANumberDSign.Text = rsa.numberD.ToString();
                                    rsa.existKey = true;
                                }
                            }
                        }
                    }

                }
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            txtResultFileSign.Text = rsa.Sign(txtFileSign.Text);
        }

        private void btnCreateTextSign_Click(object sender, EventArgs e)
        {
            TextFile.CreateFile(txtResultFileSign.Text, signFileName);
        }

        private void btnChooseFileVerify_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            txtFileVerify.Text = TextFile.OpenFile(openFileDialog1.FileName);
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (rsa.Verify(txtFileSign.Text, txtFileVerify.Text))
            {
                MessageBox.Show("Xác thực thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtResultFileVerify.Text = txtFileSign.Text;
            }
            else
                MessageBox.Show("Xác thực thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
