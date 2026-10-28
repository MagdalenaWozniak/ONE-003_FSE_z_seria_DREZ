using Hydra;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cdn_api;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Data;
using System.Data.Odbc;





namespace WystawianieDokumentuFSE
{
    [SubscribeProcedure(Procedures.TrN_FSE, "Wgystawienie dokumentu FSE z serią DREZ")]
    public class ComboBoxalSeria : Callback
    {
        ClaWindow zakladkaFSE;

        ClaWindow seriaComboBox;



        public override void Init()
        {
            AddSubscription(true, 0, Events.OpenWindow, new TakeEventDelegate(OnOpenwindow));

        }

        bool OnOpenwindow(Procedures ProcId, int ControlId, Events Event)
        {
            ClaWindow Parent = GetWindow();

            zakladkaFSE = GetWindow().AllChildren["?TabNaglowek"];//["?TabEksport"];
            seriaComboBox = GetWindow().AllChildren["?TrN:TrNSeria"]; //[" ? EksportButton"];
            if (FSEDokument.dodatekAktywny==true)
            {
                seriaComboBox.Enabled = false;
            }
            else
            {
                seriaComboBox.Enabled = true;
            }



            return true;
        }

        public override void Cleanup()
        { }

    }

  
}
