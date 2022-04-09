using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptAlgorithm.helpers
{
    class TextFile
    {
        public static void CreateFile(string message, string myFileName)
        {
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(myFileName))
                {
                    File.Delete(myFileName);
                }

                // Create a new file     
                using (FileStream fs = File.Create(myFileName))
                {
                    // Add some text to file    
                    Byte[] title = new UTF8Encoding(true).GetBytes(message);
                    fs.Write(title, 0, title.Length);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        public static string OpenFile(string myFileName)
        {
            try
            {
                // Open the stream and read it back.    
                using (StreamReader sr = File.OpenText(myFileName))
                {
                    string s = "";
                    while ((s = sr.ReadToEnd()) != null)
                    {
                        return s;
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            return null;
        }
    }
}
