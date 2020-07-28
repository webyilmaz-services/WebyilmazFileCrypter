using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WebyilmazFileCrypter
{
    public class File
    {
        ///<summary>WebyilmazFileCrypter</summary>
        ///<returns>if succes return 1, if error return 0</returns>
        /// Decrypt Always Return 0
        public int Encrypt(string inputFile, string outputFile)
        {

            try
            {
                string pwd = @"crtKey60";
                
                UnicodeEncoding UE = new UnicodeEncoding();
                
                byte[] key = UE.GetBytes(pwd);

                string cryptFile = outputFile;
                
                FileStream fCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged Crypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fCrypt,
                    
                    Crypto.CreateEncryptor(key, key),
                    
                    CryptoStreamMode.Write);

                FileStream fin = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fin.ReadByte()) != -1)
                    cs.WriteByte((byte)data);

        
                fin.Close();
                
                cs.Close();
                
                fCrypt.Close();
                
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Decrypt(string inputFile, string outputFile)
        {

            {
                string pwd = @"crtKey60";

                UnicodeEncoding UE = new UnicodeEncoding();
                
                byte[] key = UE.GetBytes(pwd);

                FileStream fCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged Crypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fCrypt,
                    
                    Crypto.CreateDecryptor(key, key),
                    
                    CryptoStreamMode.Read);

                FileStream fout = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    
                    fout.WriteByte((byte)data);
                
                fout.Close();
                
                cs.Close();
                
                fCrypt.Close();
                
                return 1;

            }
        }
    }
}