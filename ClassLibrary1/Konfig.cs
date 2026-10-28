using cdn_api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WystawianieDokumentuFSE
{
    public class Konfig
    {
        public int WersjaAPI { set; get; }
        public int Sesja { set; get; }
        public string XLLogin_Baza { set; get; }
        public string XLLogin_OpeIdent { set; get; }
        public string XLLogin_OpeHaslo { set; get; }
        public int XLLogin_TrybWsadowy { set; get; }
        public int XLLogin_Winieta { set; get; }
        public int XLLogin_UtworzWlasnaSesje { set; get; }
        public string XLServer { set; get; }
        public string XLDatabase { set; get; }
        //public string XLLogin_SerwerKlucza { set; get; }
        //public string conStr { set; get; }
        //public string onLineOperator { set; get; }


        public string ErrorDescription(int funkcja, int blad)
        {
            string str = "";
            XLKomunikatInfo_20210 KomunikatInfo20210 = new XLKomunikatInfo_20210();
            KomunikatInfo20210.Wersja = this.WersjaAPI;
            KomunikatInfo20210.Funkcja = funkcja;
            KomunikatInfo20210.Blad = blad;
            cdn_api.cdn_api.XLOpisBledu(KomunikatInfo20210);
            if (KomunikatInfo20210.OpisBledu != null)
                str = (string)KomunikatInfo20210.OpisBledu;
            return (string)KomunikatInfo20210.OpisBledu;
        }
    }
}
