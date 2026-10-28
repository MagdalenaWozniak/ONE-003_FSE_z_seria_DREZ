using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WystawianieDokumentuFSE
{
    public static class KonfigPobierz
    {
        public static Konfig GetData()
        {
            Konfig configuration = new Konfig();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Konfig));
            FileStream fileStream = (FileStream)null;
            try
            {
                                
                fileStream = new FileStream("C:\\onesupport\\ONE-003\\Konfiguracja.XML", FileMode.Open);//tu na sztywno
                configuration = (Konfig)xmlSerializer.Deserialize((Stream)fileStream);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }
            return configuration;
        }
    }
}
