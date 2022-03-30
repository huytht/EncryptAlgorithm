using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptAlgorithm.model
{
    class Vigener
    {
        #region property 
        public string key { get; set; }
        public string plainText { get; set; }
        public string cipherText { get; set; }
        #endregion 

        public Vigener(string s)
        {
            key = s.ToUpper();
        }

        string stringForEncrypt = "AĂÂBCDĐEÊGHIKLMNOÔƠPQRSTUƯVXY @#$%?!;=.,ÁÀẢẠÃẮẰẲẴẶẤẦẨẪẬÉÈẺẼẸẾỀỂỄỆÍÌỈĨỊÓÒÕỎỌỐỒỖỔỘỚỜỠỞỢÚÙỦŨỤỨỪỮỬỰÝỲỸỶỴaăâbcdđeêghiklmnoôơpqrstuưvxyáàảạãắằẳẵặấầẩẫậéèẻẽẹếềểễệíìỉĩịóòõỏọốồỗổộớờỡởợúùủũụứừữửựýỳỹỷỵ";

        public int[] getArrayOfIndexFromString(string s)
        {
            int[] arrayOfIndex = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
                arrayOfIndex[i] = stringForEncrypt.IndexOf(s[i]);

            return arrayOfIndex;
        }

        public string getStringFromArrayOfIndex(int[] arrayOfIndex)
        {
            string s = String.Empty;
            for (int i = 0; i < arrayOfIndex.Length; i++)
                s += stringForEncrypt[arrayOfIndex[i]];

            return s;
        } 

        public String encryptVietnamese()
        {
            plainText = plainText.ToUpper();
            int[] p = getArrayOfIndexFromString(plainText);
            int[] k = getArrayOfIndexFromString(key);

            int[] result = new int[plainText.Length];
            // Encrypt
            for (int i = 0, j = 0; i < plainText.Length; ++i)
            {
                result[i] = (p[i] + k[j]) % stringForEncrypt.Length;
                if (result[i] < 0)
                    result[i] = (p[i] + k[j] + stringForEncrypt.Length) % stringForEncrypt.Length;
                j = ++j % k.Length;
            }

            cipherText = getStringFromArrayOfIndex(result);

            return cipherText;
        }

        public String decryptVietnamese()
        {
            int[] c = getArrayOfIndexFromString(cipherText);
            int[] k = getArrayOfIndexFromString(key);

            int[] result = new int[cipherText.Length];

            // Encrypt
            for (int i = 0, j = 0; i < cipherText.Length; ++i)
            {
                result[i] = (c[i] - k[j]) % stringForEncrypt.Length;
                if (result[i] < 0)
                    result[i] = (c[i] + stringForEncrypt.Length - k[j]) % stringForEncrypt.Length;

                j = ++j % k.Length;
            }

            plainText = getStringFromArrayOfIndex(result);

            return plainText;
        }
    }
}
