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

[assembly: CallbackAssemblyDescription(Name: "ONE-003 - Dokument FSE z serią DREZ",
                                           Description: "Wystawienie dokumentu FSE z serią DREZ",
                                           Author: "OneSupport",
                                           Version: "1.0",
                                           SystemVersion: "2021.0.0",
                                           Created: "15-08-2019")]


namespace WystawianieDokumentuFSE
{
    [SubscribeProcedure(Procedures.ListaDokumentow, "Wystawienie dokumentu FSE z serią DREZ")]
    public class FSEDokument : Callback
    {
        ClaWindow zakladkaEksport;
        ClaWindow FSEButton;
        ClaWindow eksportBtn;
        public static bool dodatekAktywny=false;




        public override void Init()
        {
            AddSubscription(true, 0, Events.OpenWindow, new TakeEventDelegate(OnOpenwindow));
            AddSubscription(true, 0, Events.ResizeWindow, new TakeEventDelegate(Resize));
        }

        bool OnOpenwindow(Procedures ProcId, int ControlId, Events Event)
        {
            ClaWindow Parent = GetWindow();

            Rectangle WndBnd = GetWindow().Bounds;
            zakladkaEksport = GetWindow().AllChildren["?TabEksport"];//["?TabEksport"];
            FSEButton = zakladkaEksport.Children.Add(ControlTypes.button);
            FSEButton.Visible = true;
            FSEButton.ToolTipRaw = "Wystawienie dokumentu FSE z serią DREZ";
            FSEButton.TextRaw = "FSE";

            //pobiera współrzędne przycisku gotówka
            eksportBtn = GetWindow().AllChildren["?EksportFSE:Button"]; //[" ? EksportButton"];
            FSEButton.Bounds = new Rectangle(eksportBtn.Bounds.X-18, eksportBtn.Bounds.Y, 17, 15);


            //naduszenie przycisku
            FSEButton.OnAfterAccepted += new TakeEventDelegate(FSEBtnOnClick);

            return true;

        }

        private bool Resize (Procedures ProcId, int ControlId, Events Event) {

            eksportBtn = GetWindow().AllChildren["?EksportFSE:Button"]; //[" ? EksportButton"];
            FSEButton.Bounds = new Rectangle(eksportBtn.Bounds.X-18, eksportBtn.Bounds.Y, 17, 15);

            return true;
        }

        //przeniesienie z pow
        public bool FSEBtnOnClick(Procedures ProcId, int ControlId, Events Event)
        {

            dodatekAktywny = true;
            WprowadzPola wprowadzPola = new WprowadzPola();
            
            wprowadzPola.sqlConnection = Runtime.ActiveRuntime.Repository.Connection;
            int num1 = (int)wprowadzPola.ShowDialog();
            dodatekAktywny = false;

            Runtime.WindowController.PostEvent(0, Events.FullRefresh);
            return true;
        }

        public override void Cleanup()
        { }

    }

  
}
