using EncryptAlgorithm.helpers;
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
	//public class RSAKey
	//{
	//	public string publicKey { get; set; }
	//	public string privateKey { get; set; }

	//	public RSAKey(string privateKey, string publicKey)
	//	{
	//		this.privateKey = privateKey;
	//		this.publicKey = publicKey;
	//	}
	//}
	class RSAEncryption
    {
        public int numberP, numberQ, numberN, numberE, numberD, phiNumberN;
        
        public bool existKey = false;
        public int RandomNumber()
        {
            Random rd = new Random();
            return rd.Next(11, 101);// tốc độ chậm nên chọn số bé
        }
        // Hàm kiểm tra nguyên tố
        public bool checkSNT(int x)
        {
            if (x < 2) return false;

            for (int i = 2; i <= Math.Sqrt(x); ++i)
                if (x % i == 0) return false;

            return true;
        }
        // Hàm kiểm tra hai số nguyên tố cùng nhau
        public bool nguyenToCungNhau(int ai, int bi)
        {
            bool ktx_;
            // giải thuật Euclid;
            int temp;
            while (bi != 0)
            {
                temp = ai % bi;
                ai = bi;
                bi = temp;
            }
            if (ai == 1) { ktx_ = true; }
            else ktx_ = false;
            return ktx_;
        }
        // Hàm lấy mod
        public int RSA_mod(int mx, int ex, int nx)
        {
            //Sử dụng thuật toán "bình phương nhân"
            //Chuyển e sang hệ nhị phân
            int[] a = new int[100];
            int k = 0;
            do
            {
                a[k] = ex % 2;
                k++;
                ex = ex / 2;
            }
            while (ex != 0);
            //Quá trình lấy dư
            int kq = 1;
            for (int i = k - 1; i >= 0; i--)
            {
                kq = (kq * kq) % nx;
                if (a[i] == 1)
                    kq = (kq * mx) % nx;
            }
            return kq;
        }

        public void GenerateKey()
        {
            // n = p * q
            numberN = numberP * numberQ;
            // Phi(n) = (p - 1) * (q - 1)
            phiNumberN = (numberP - 1) * (numberQ - 1);
            // e là một số ngẫu nhiên có giá trị 0 < e < phi(n) và là số nguyên tố cùng nhau với Phi(n)
            do
            {
                Random RSA_rd = new Random();
                numberE = RSA_rd.Next(2, phiNumberN);
            }
            while (!nguyenToCungNhau(numberE, phiNumberN));

            // d là nghịch đảo modular của e
            numberD = 0;
            int i = 2;
            while (((1 + i * phiNumberN) % numberE) != 0 || numberD <= 0)
            {
                i++;
                numberD = (1 + i * phiNumberN) / numberE;
            }
        }
        public string Encrypt(string textToEncrypt)
        {
            // Chuyen xau thanh ma Unicode
            byte[] plainBytes = Encoding.Unicode.GetBytes(textToEncrypt);
            string base64 = Convert.ToBase64String(plainBytes);

            // Chuyen xau thanh ma Unicode
            int[] temp_encrypt = new int[base64.Length];
            for (int i = 0; i < base64.Length; i++)
            {
                temp_encrypt[i] = (int)base64[i];
            }

            // Mảng chứa các kí tự đã mã hóa
            int[] arrayEncrypt = new int[temp_encrypt.Length];
            for (int i = 0; i < temp_encrypt.Length; i++)
            {
                arrayEncrypt[i] = RSA_mod(temp_encrypt[i], numberE, numberN); // mã hóa
            }

            //Chuyển sang kiểu kí tự trong bảng mã Unicode
            string encryptedText = "";
            for (int i = 0; i < arrayEncrypt.Length; i++)
            {
                encryptedText = encryptedText + (char)arrayEncrypt[i];
            }
            byte[] data = Encoding.Unicode.GetBytes(encryptedText);
            return Convert.ToBase64String(data);
        }

        // Hàm giải mã
        public string Decrypt(string encryptedTextBase64)
        {
            byte[] plainBytes = Convert.FromBase64String(encryptedTextBase64);
            string decrypt = Encoding.Unicode.GetString(plainBytes);

            int[] b = new int[decrypt.Length];
            for (int i = 0; i < decrypt.Length; i++)
            {
                b[i] = (int)decrypt[i];
            }
            //Giải mã
            int[] c = new int[b.Length];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = RSA_mod(b[i], numberD, numberN);// giải mã
            }

            string base64String = "";
            for (int i = 0; i < c.Length; i++)
            {
                base64String = base64String + (char)c[i];
            }
            byte[] decryptedText = Convert.FromBase64String(base64String);
            return Encoding.Unicode.GetString(decryptedText);
        }
        public string HashSHA(string textForHash)
        {
            SHA256Managed sha256 = new SHA256Managed();

            byte[] input = Encoding.UTF8.GetBytes(textForHash);
            byte[] result = sha256.ComputeHash(input);
            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in result)
            {
                sbHash.Append(String.Format("{0:x2}", b));
            }
            return sbHash.ToString();
        }   

        public string Sign(string message)
        {
            string textSinged = string.Empty;
            message = HashSHA(message);
            if (!existKey)
                MessageBox.Show("Bạn chưa tạo khóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                try
                {
                    textSinged = Encrypt(message);
                    MessageBox.Show("Ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return textSinged;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            return null;
        }

        public bool Verify(string orginalMessage, string textSigned)
        {
            orginalMessage = HashSHA(orginalMessage);
            if (!existKey)
                MessageBox.Show("Bạn chưa tạo khóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                try
                {
                    return orginalMessage == Decrypt(textSigned);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            return false;
        }
    }
}
