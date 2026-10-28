using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using cdn_api;


namespace WystawianieDokumentuFSE
{

    public class WprowadzPola : Form
    {




        private IContainer components = (IContainer)null;

        public SqlConnection sqlConnection;
        private XLDokumentNagInfo_20210 DokNagInfo;
        private XLDokumentElemInfo_20210 DokElemInfo;
        private XLZamkniecieDokumentuInfo_20210 ZamkDokInfo;

        private Button btnExecute;
        private Button btnCancel;
        private Panel pnBottom;
        private Label MMyyyy;
        private Button btnWybierzMiesiac;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private RadioButton rButton1;
        private RadioButton rButton2;
        private RadioButton rButton3;
        private Label label5;
        private int IDDokumentu;
        private int sesja = -1;

        Wypelnione Pola = new Wypelnione();
        string GL_McRokPod2="";


        private string XLDatabase = "";                                                     //tu jakies zmienne podeklarowane
        private string XLUser = "";
        private string XLPass = "";
        private string XLSQLServer;
        private string XLSQLDatabase;
        public string connection_string = "";
        private int XLWersjaAPI = 20210;
        private int XLTrybWsadowy = 1;
        private int XLWinieta;
        private int XLUtworzWlasnaSesje;
        public string indexPrzed = "";
        private Konfig cnf;
        private int Trn_GIDFirma;
        private int Trn_GIDNumer;
        private Label label1;
        private int Trn_GIDTyp;
        private string Atr_AtkID;

        public WprowadzPola()
        {
            InitializeComponent();

            Pola.GL_TypProduktu = "";
            if (GetConfig())
            {
                GetConnectionString();
                try
                {
                    XLLogin();
                    ComboBoxActivate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd XLLogin " + ex.Message, "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else MessageBox.Show("Nie pykło z konfigiem");
        }

        //GL_TypProduktu
        void GetRButtonValue(RadioButton radioButton)
        {
            if (radioButton.Checked)
            {
                Pola.GL_TypProduktu = radioButton.Text;
            }
        }

        //GL_McRokPod
        void ButtonMiesiac_Click(object sender, EventArgs e)
        {

            WybierzMiesiac wybierzMiesiac = new WybierzMiesiac();
            wybierzMiesiac.ShowDialog();

            GL_McRokPod2 = WybierzMiesiac.wybranyMiesiac.Remove(2, 1); ;
            //MessageBox.Show(GL_McRokPod2);

            MMyyyy.Text = WybierzMiesiac.wybranyMiesiac;
        }
        
        //GL_Produkt_w_czasie
        string GetTextBox(object sender, EventArgs e)
        {

            return textBox1.Text;
        }

        //inicjowanie ComboBox do GL_MPK
        List<string> comboLista = new List<string>();

        public List<string> ComboLista { get => comboLista; set => comboLista = value; }
        public string comboString = "";
        void ComboBoxActivate()
        {
            comboLista = SelectDoListy("select Twr_Kod from CDN.TwrKarty where " +
                "Twr_GIDTyp = 16 " +
                "and Twr_Typ = 4 " +
                "and(Twr_Kod like '[0-9][0-9] ZI%' and left(TwR_Kod, 2) >= '18') " +
                "or (Twr_Kod like '[0-9][0-9] LA%' and left(TwR_Kod, 2) > '18')",
                    "Twr_Kod", "CDN.TwrKarty");

            foreach (string kartotekaUslugowa in comboLista)
            {
                comboBox1.Items.Add(kartotekaUslugowa);
            }
        }

        //Get GL_MPK
        string GetComboBox(object sender, EventArgs e)
        {
            string tempstr = comboBox1.Text;

            return comboBox1.Text;
        }

        private void BrnCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnExecuteClick(object sender, EventArgs e)
        {
    

            Pola.GL_McRokPod = GL_McRokPod2;
            Pola.GL_MPK = GetComboBox(comboBox1, e);
            Pola.GL_Produkt_w_czasie = GetTextBox(textBox1, e);
            GetRButtonValue(rButton1);
            GetRButtonValue(rButton2);
            GetRButtonValue(rButton3);

            //sprawdza, czy pola wypełnione
            if (Pola.GL_McRokPod !="" && Pola.GL_MPK !="" && Pola.GL_Produkt_w_czasie != "" && Pola.GL_TypProduktu != "")
            {
                label1.Visible = false;

                if (GetConfig())
                {
                    Cursor.Current = Cursors.WaitCursor;
                    GetConnectionString();

                    XLLogin();
                    //Hide();
                    DokNagInfo = new XLDokumentNagInfo_20210
                    {
                        Seria = "DREZ",
                        Wersja = 20210,
                        Tryb = 1,
                        Typ = 2037
                    };
                    try
                    {
                        cdn_api.cdn_api.XLNowyDokument(sesja, ref IDDokumentu, DokNagInfo);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd XLNowyDokument " + ex.Message, "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    DokElemInfo = new XLDokumentElemInfo_20210
                    {
                        Wersja = 20210,
                        TowarKod = "PROWIZJA",
                        Ilosc = "1"
                    };
                    try
                    {
                        cdn_api.cdn_api.XLDodajPozycje(IDDokumentu, DokElemInfo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd XLDodajPozycje " + ex.Message, "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    Trn_GIDFirma = DokNagInfo.GIDFirma;
                    Trn_GIDNumer = DokNagInfo.GIDNumer;
                    Trn_GIDTyp = DokNagInfo.GIDTyp;

                    //tu dodaje atrybuty 4,bo 4 wypełnione pola
                    Atr_AtkID = Select("select Atk_ID from cdn.AtrybutyKlasy where AtK_Nazwa='GL_McRokPod'", "Atk_ID", "cdn.AtrybutyKlasy");
                    //MessageBox.Show(Atr_AtkID);
                    var komunikatDelete1 = DeleteFrom("DELETE FROM cdn.Atrybuty WHERE Atr_ObiTyp = " + Trn_GIDTyp + " and Atr_ObiFirma = " + Trn_GIDFirma + " and Atr_ObiNumer = " + Trn_GIDNumer + " and Atr_AtkId =" + Atr_AtkID);
                    var komunikatInsert1 = InsertInto("INSERT INTO cdn.Atrybuty(Atr_ObiTyp, Atr_ObiFirma, Atr_ObiNumer, Atr_ObiLp, Atr_ObiSubLp, Atr_AtkId, Atr_Wartosc, AtR_AtrTyp, Atr_AtrFirma, Atr_AtrLp, Atr_AtrSubLp, Atr_OptimaId, Atr_Grupujacy) " +
                                                      "VALUES(" + Trn_GIDTyp + ", " + Trn_GIDFirma + ", " + Trn_GIDNumer + ", 1, 0, '" + Atr_AtkID + "', '" + Pola.GL_McRokPod + "', 2037, 758274, 0, 0, 0, 0)");

                    Atr_AtkID = Select("select Atk_ID from cdn.AtrybutyKlasy where AtK_Nazwa='GL_MPK'", "Atk_ID", "cdn.AtrybutyKlasy");

                    var komunikatDelete2 = DeleteFrom("DELETE FROM cdn.Atrybuty WHERE Atr_ObiTyp = " + Trn_GIDTyp + " and Atr_ObiFirma = " + Trn_GIDFirma + " and Atr_ObiNumer = " + Trn_GIDNumer + " and Atr_AtkId =" + Atr_AtkID);
                    var komunikatInsert2 = InsertInto("INSERT INTO cdn.Atrybuty(Atr_ObiTyp, Atr_ObiFirma, Atr_ObiNumer, Atr_ObiLp, Atr_ObiSubLp, Atr_AtkId, Atr_Wartosc, AtR_AtrTyp, Atr_AtrFirma, Atr_AtrLp, Atr_AtrSubLp, Atr_OptimaId, Atr_Grupujacy) " +
                                                      "VALUES(" + Trn_GIDTyp + ", " + Trn_GIDFirma + ", " + Trn_GIDNumer + ", 1, 0, '" + Atr_AtkID + "', '" + Pola.GL_MPK + "', 2037, 758274, 0, 0, 0, 0)");

                    Atr_AtkID = Select("select Atk_ID from cdn.AtrybutyKlasy where AtK_Nazwa='GL_Produkt_w_czasie'", "Atk_ID", "cdn.AtrybutyKlasy");

                    var komunikatDelete3 = DeleteFrom("DELETE FROM cdn.Atrybuty WHERE Atr_ObiTyp = " + Trn_GIDTyp + " and Atr_ObiFirma = " + Trn_GIDFirma + " and Atr_ObiNumer = " + Trn_GIDNumer + " and Atr_AtkId =" + Atr_AtkID);
                    var komunikatInsert3 = InsertInto("INSERT INTO cdn.Atrybuty(Atr_ObiTyp, Atr_ObiFirma, Atr_ObiNumer, Atr_ObiLp, Atr_ObiSubLp, Atr_AtkId, Atr_Wartosc, AtR_AtrTyp, Atr_AtrFirma, Atr_AtrLp, Atr_AtrSubLp, Atr_OptimaId, Atr_Grupujacy) " +
                                                      "VALUES(" + Trn_GIDTyp + ", " + Trn_GIDFirma + ", " + Trn_GIDNumer + ", 1, 0, '" + Atr_AtkID + "', '" + Pola.GL_Produkt_w_czasie + "', 2037, 758274, 0, 0, 0, 0)");

                    Atr_AtkID = Select("select Atk_ID from cdn.AtrybutyKlasy where AtK_Nazwa='GL_TypProduktu'", "Atk_ID", "cdn.AtrybutyKlasy");

                    var komunikatDelete4 = DeleteFrom("DELETE FROM cdn.Atrybuty WHERE Atr_ObiTyp = " + Trn_GIDTyp + " and Atr_ObiFirma = " + Trn_GIDFirma + " and Atr_ObiNumer = " + Trn_GIDNumer + " and Atr_AtkId =" + Atr_AtkID);
                    var komunikatInsert4 = InsertInto("INSERT INTO cdn.Atrybuty(Atr_ObiTyp, Atr_ObiFirma, Atr_ObiNumer, Atr_ObiLp, Atr_ObiSubLp, Atr_AtkId, Atr_Wartosc, AtR_AtrTyp, Atr_AtrFirma, Atr_AtrLp, Atr_AtrSubLp, Atr_OptimaId, Atr_Grupujacy) " +
                                                      "VALUES(" + Trn_GIDTyp + ", " + Trn_GIDFirma + ", " + Trn_GIDNumer + ", 1, 0, '" + Atr_AtkID + "', '" + Pola.GL_TypProduktu + "', 2037, 758274, 0, 0, 0, 0)");


                    Cursor.Current = Cursors.Default;
                    ZamkDokInfo = new XLZamkniecieDokumentuInfo_20210
                    {
                        Wersja = 20210,
                        Tryb = 1,

                    };
                    try
                    {
                        cdn_api.cdn_api.XLZamknijDokument(IDDokumentu, ZamkDokInfo);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd XLZamknijDokument " + ex.Message, "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    btnCancel.Text = "Zamknij";

                    Logout();
                    Close();
                }
                else
                {
                    MessageBox.Show("Błąd przy wczytywaniu konfiguracji.");
                }
            }
            else
            {
                label1.Visible = true;
            }
        }

        private string Update(int TrP_GIDTyp, int TrP_GIDNumer, string wartosc)
        {
            string str = "OK";
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "\r\nUPDATE CDN.Atrybuty SET\r\nAtr_Wartosc = '" + wartosc + "' \r\nWHERE \r\nAtr_ObiTyp = " + TrP_GIDTyp + " AND Atr_ObiNumer = " + TrP_GIDNumer + " AND Atr_AtkId = 6; UPDATE CDN.Atrybuty SET Atr_Wartosc = '" + wartosc + "' WHERE Atr_ObiTyp = 12300 AND Atr_ObiNumer = " + TrP_GIDNumer + " AND Atr_AtkId = 6 and 7684 = " + TrP_GIDTyp + " ";
            try
            {
                if (this.sqlConnection.State == ConnectionState.Closed)
                    this.sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                str = "Błąd SQL. " + ex.Message;
            }
            finally
            {
                this.sqlConnection.Close();
            }
            return str;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        public bool GetConfig()
        {
            bool flaga = false;
            cnf = KonfigPobierz.GetData();
            XLUser = cnf.XLLogin_OpeIdent;
            XLDatabase = cnf.XLLogin_Baza;
            XLPass = cnf.XLLogin_OpeHaslo;

            XLWersjaAPI = 20210;
            XLTrybWsadowy = 1;
            XLWinieta = -1;
            XLUtworzWlasnaSesje = 1;

            XLSQLServer = cnf.XLServer;

            XLSQLDatabase = cnf.XLDatabase;

            if (XLUser != "" && XLDatabase != "" && XLPass != "") ;                                                              //tu nie ma żadnej funkcjonalności
            flaga = true;

            return flaga;

        }

        public int XLLogin()
        {
            return cdn_api.cdn_api.XLLogin(new XLLoginInfo_20210()
            {
                Wersja = XLWersjaAPI,
                ProgramID = "Dodatek wystawiający dokumenty FSE z serią DREZ",
                //PlikLog = (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\api.log"),
                PlikLog = (AppDomain.CurrentDomain.BaseDirectory + "api.log"),
                Baza = XLDatabase,                                                        //do zaminy
                OpeIdent = XLUser,
                OpeHaslo = XLPass,
                TrybWsadowy = XLTrybWsadowy,
                // TrybNaprawy = 0,
                UtworzWlasnaSesje = XLUtworzWlasnaSesje,
                Winieta = XLWinieta,
            }, ref sesja);
        }

        public void Logout()
        {
            cdn_api.cdn_api.XLLogout(sesja);
        }

        public string GetConnectionString()
        {
            connection_string = "Server=" + XLSQLServer + ";Database=" + XLSQLDatabase + ";User Id=onesupport_dod; Password=43gQdfs31.so3;";

            //connection_string = "Server=" + XLSQLServer + ";Database=" + XLSQLDatabase + ";Integrated Security = SSPI; ";
            //connection_string = "Server=" + "localhost"/*XLSQLServer*/ + ";Integrated Security = SSPI; " + ";Database=" + "BeeFree;"; //*XLSQLDatabase*/ + ";User Id=Bartek" +/*onesupport*/"; Password=;";//g54q@8w#v$Y.Df_8f4hg;";        //tu bd inaczej


            return connection_string;
        }

        string query()
        {
            string str="SELECT /**/ from "+/*dadada+*/"i tam dalej w zależności od tego co bd w bazie.";
            return str;
        }

        public string InsertInto(string sql)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    connection.Open();
                    adapter.InsertCommand = new SqlCommand(sql, connection);
                    adapter.InsertCommand.ExecuteNonQuery();
                    //MessageBox.Show("Row inserted !! ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return sql;
        }

        public string DeleteFrom(string sql)       //Użycie delete i inserta nie jest optymalne, ale w niektórych przypadkach pozycje nie miały atrybutu. Po testach zmienić na update
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    connection.Open();
                    adapter.DeleteCommand = new SqlCommand(sql, connection);
                    adapter.DeleteCommand.ExecuteNonQuery();
                    //MessageBox.Show("Row deleted!! ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return sql;
        }

        public List<string> SelectDoListy(string query, string szukana, string srcTableName)
        {
            List<string> comboLista1 = new List<string>();
            try
            {
                
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(query, connection);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, srcTableName);
                    foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[0].Rows)
                        comboLista1.Add(row[szukana].ToString());  

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd z listą w selectdolisty"+ ex);
            }
            return comboLista1;
        }

        public string Select(string query, string szukana, string srcTableName)
        {
            string str = "";
            try
            {

                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(query, connection);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, srcTableName);
                    foreach (DataRow row in (InternalDataCollectionBase)dataSet.Tables[0].Rows)
                        str += row[szukana].ToString();

                }
            }
            catch (Exception ex)
            {
                str = str + "Bład SQL:" + ex.ToString() + "\n";
            }
            return str;
        }

        private void InitializeComponent()
        {
            this.pnBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.MMyyyy = new System.Windows.Forms.Label();
            this.btnWybierzMiesiac = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rButton1 = new System.Windows.Forms.RadioButton();
            this.rButton2 = new System.Windows.Forms.RadioButton();
            this.rButton3 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.label1);
            this.pnBottom.Controls.Add(this.btnCancel);
            this.pnBottom.Controls.Add(this.btnExecute);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 180);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(337, 27);
            this.pnBottom.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(262, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BrnCancelClick);
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExecute.Location = new System.Drawing.Point(0, 0);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 27);
            this.btnExecute.TabIndex = 0;
            this.btnExecute.Text = "Wykonaj";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.BtnExecuteClick);
            // 
            // MMyyyy
            // 
            this.MMyyyy.AutoSize = true;
            this.MMyyyy.Location = new System.Drawing.Point(169, 28);
            this.MMyyyy.Name = "MMyyyy";
            this.MMyyyy.Size = new System.Drawing.Size(56, 13);
            this.MMyyyy.TabIndex = 2;
            this.MMyyyy.Text = "MM-YYYY";
            // 
            // btnWybierzMiesiac
            // 
            this.btnWybierzMiesiac.Location = new System.Drawing.Point(250, 23);
            this.btnWybierzMiesiac.Name = "btnWybierzMiesiac";
            this.btnWybierzMiesiac.Size = new System.Drawing.Size(75, 23);
            this.btnWybierzMiesiac.TabIndex = 3;
            this.btnWybierzMiesiac.Text = "Zmień date";
            this.btnWybierzMiesiac.UseVisualStyleBackColor = true;
            this.btnWybierzMiesiac.Click += new System.EventHandler(this.ButtonMiesiac_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "GL_McRokPod ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(171, 52);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "GL_MPK ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(171, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 20);
            this.textBox1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "GL_Produkt_w_czasie ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "GL_TypProduktu ";
            // 
            // rButton1
            // 
            this.rButton1.AutoSize = true;
            this.rButton1.Location = new System.Drawing.Point(171, 108);
            this.rButton1.Name = "rButton1";
            this.rButton1.Size = new System.Drawing.Size(31, 17);
            this.rButton1.TabIndex = 10;
            this.rButton1.TabStop = true;
            this.rButton1.Text = "1";
            this.rButton1.UseVisualStyleBackColor = true;
            // 
            // rButton2
            // 
            this.rButton2.AutoSize = true;
            this.rButton2.Location = new System.Drawing.Point(232, 108);
            this.rButton2.Name = "rButton2";
            this.rButton2.Size = new System.Drawing.Size(31, 17);
            this.rButton2.TabIndex = 10;
            this.rButton2.TabStop = true;
            this.rButton2.Text = "2";
            this.rButton2.UseVisualStyleBackColor = true;
            // 
            // rButton3
            // 
            this.rButton3.AutoSize = true;
            this.rButton3.Location = new System.Drawing.Point(293, 108);
            this.rButton3.Name = "rButton3";
            this.rButton3.Size = new System.Drawing.Size(31, 17);
            this.rButton3.TabIndex = 10;
            this.rButton3.TabStop = true;
            this.rButton3.Text = "3";
            this.rButton3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(81, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Proszę wypełnic wszystkie pozycje.";
            this.label1.Visible = false;
            // 
            // WprowadzPola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 207);
            this.Controls.Add(this.rButton3);
            this.Controls.Add(this.rButton2);
            this.Controls.Add(this.rButton1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnWybierzMiesiac);
            this.Controls.Add(this.MMyyyy);
            this.Controls.Add(this.pnBottom);
            this.Name = "WprowadzPola";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wprowadź dane";
            this.pnBottom.ResumeLayout(false);
            this.pnBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }

}
