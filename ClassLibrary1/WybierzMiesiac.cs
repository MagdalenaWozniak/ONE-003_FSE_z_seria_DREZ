using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WystawianieDokumentuFSE
{
    public partial class WybierzMiesiac : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Button button37;
        int numBtn = 0;

        public static string GenMMyyyy(int m)
        {
            string str;
            str = DateTime.Now.AddMonths(m).ToString("MM/yyyy");
            return str;
        }

        public static string wybranyMiesiac="";

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

        }


        public WybierzMiesiac()
        {
            InitializeComponent();
            numBtn = -17;
            foreach (var btn in this.Controls)
            {
                Button tmpbtn;
                try
                {
                    tmpbtn = (Button)btn;
                    tmpbtn.Text = GenMMyyyy(numBtn);
                    numBtn++;
                }
                catch (InvalidCastException e)
                {
                    
                }
            }

        }
        
        public void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            wybranyMiesiac = btn.Text;


            Close();
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button37 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "MM - YYYY";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(12, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "MM - YYYY";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(12, 92);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "MM - YYYY";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(12, 121);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "MM - YYYY";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(12, 150);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "MM - YYYY";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button_Click);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button6.Location = new System.Drawing.Point(12, 179);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(120, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "MM - YYYY";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button_Click);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(12, 208);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(120, 23);
            this.button7.TabIndex = 0;
            this.button7.Text = "MM - YYYY";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button_Click);
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(12, 237);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(120, 23);
            this.button8.TabIndex = 0;
            this.button8.Text = "MM - YYYY";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button_Click);
            // 
            // button9
            // 
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(12, 266);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(120, 23);
            this.button9.TabIndex = 0;
            this.button9.Text = "MM - YYYY";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Button_Click);
            // 
            // button10
            // 
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(12, 295);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(120, 23);
            this.button10.TabIndex = 0;
            this.button10.Text = "MM - YYYY";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Button_Click);
            // 
            // button11
            // 
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Location = new System.Drawing.Point(12, 324);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(120, 23);
            this.button11.TabIndex = 0;
            this.button11.Text = "MM - YYYY";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Button_Click);
            // 
            // button12
            // 
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Location = new System.Drawing.Point(12, 353);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(120, 23);
            this.button12.TabIndex = 0;
            this.button12.Text = "MM - YYYY";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.Button_Click);
            // 
            // button13
            // 
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Location = new System.Drawing.Point(148, 34);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(120, 23);
            this.button13.TabIndex = 0;
            this.button13.Text = "MM - YYYY";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.Button_Click);
            // 
            // button14
            // 
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Location = new System.Drawing.Point(148, 63);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(120, 23);
            this.button14.TabIndex = 0;
            this.button14.Text = "MM - YYYY";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.Button_Click);
            // 
            // button15
            // 
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Location = new System.Drawing.Point(148, 92);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(120, 23);
            this.button15.TabIndex = 0;
            this.button15.Text = "MM - YYYY";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.Button_Click);
            // 
            // button16
            // 
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Location = new System.Drawing.Point(148, 121);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(120, 23);
            this.button16.TabIndex = 0;
            this.button16.Text = "MM - YYYY";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.Button_Click);
            // 
            // button17
            // 
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Location = new System.Drawing.Point(148, 150);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(120, 23);
            this.button17.TabIndex = 0;
            this.button17.Text = "MM - YYYY";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.Button_Click);
            // 
            // button18
            // 
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button18.Location = new System.Drawing.Point(148, 179);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(120, 23);
            this.button18.TabIndex = 0;
            this.button18.Text = "MM - YYYY";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.Button_Click);
            // 
            // button19
            // 
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Location = new System.Drawing.Point(148, 208);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(120, 23);
            this.button19.TabIndex = 0;
            this.button19.Text = "MM - YYYY";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.Button_Click);
            // 
            // button20
            // 
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Location = new System.Drawing.Point(148, 237);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(120, 23);
            this.button20.TabIndex = 0;
            this.button20.Text = "MM - YYYY";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.Button_Click);
            // 
            // button21
            // 
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Location = new System.Drawing.Point(148, 266);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(120, 23);
            this.button21.TabIndex = 0;
            this.button21.Text = "MM -YYYY";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.Button_Click);
            // 
            // button22
            // 
            this.button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button22.Location = new System.Drawing.Point(148, 295);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(120, 23);
            this.button22.TabIndex = 0;
            this.button22.Text = "MM - YYYY";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.Button_Click);
            // 
            // button23
            // 
            this.button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button23.Location = new System.Drawing.Point(148, 324);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(120, 23);
            this.button23.TabIndex = 0;
            this.button23.Text = "MM - YYYY";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.Button_Click);
            // 
            // button24
            // 
            this.button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button24.Location = new System.Drawing.Point(148, 353);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(120, 23);
            this.button24.TabIndex = 0;
            this.button24.Text = "MM -YYYY";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.Button_Click);
            // 
            // button25
            // 
            this.button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button25.Location = new System.Drawing.Point(284, 34);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(120, 23);
            this.button25.TabIndex = 0;
            this.button25.Text = "MM - YYYY";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.Button_Click);
            // 
            // button26
            // 
            this.button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button26.Location = new System.Drawing.Point(284, 63);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(120, 23);
            this.button26.TabIndex = 0;
            this.button26.Text = "MM - YYYY";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.Button_Click);
            // 
            // button27
            // 
            this.button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button27.Location = new System.Drawing.Point(284, 92);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(120, 23);
            this.button27.TabIndex = 0;
            this.button27.Text = "MM - YYYY";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.Button_Click);
            // 
            // button28
            // 
            this.button28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button28.Location = new System.Drawing.Point(284, 121);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(120, 23);
            this.button28.TabIndex = 0;
            this.button28.Text = "MM - YYYY";
            this.button28.UseVisualStyleBackColor = true;
            this.button28.Click += new System.EventHandler(this.Button_Click);
            // 
            // button29
            // 
            this.button29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button29.Location = new System.Drawing.Point(284, 150);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(120, 23);
            this.button29.TabIndex = 0;
            this.button29.Text = "MM - YYYY";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.Button_Click);
            // 
            // button30
            // 
            this.button30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button30.Location = new System.Drawing.Point(284, 179);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(120, 23);
            this.button30.TabIndex = 0;
            this.button30.Text = "MM - YYYY";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.Button_Click);
            // 
            // button31
            // 
            this.button31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button31.Location = new System.Drawing.Point(284, 208);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(120, 23);
            this.button31.TabIndex = 0;
            this.button31.Text = "MM - YYYY";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.Button_Click);
            // 
            // button32
            // 
            this.button32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button32.Location = new System.Drawing.Point(284, 237);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(120, 23);
            this.button32.TabIndex = 0;
            this.button32.Text = "MM - YYYY";
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.Button_Click);
            // 
            // button33
            // 
            this.button33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button33.Location = new System.Drawing.Point(284, 266);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(120, 23);
            this.button33.TabIndex = 0;
            this.button33.Text = "MM - YYYY";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.Button_Click);
            // 
            // button34
            // 
            this.button34.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button34.Location = new System.Drawing.Point(284, 295);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(120, 23);
            this.button34.TabIndex = 0;
            this.button34.Text = "MM - YYYY";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.Button_Click);
            // 
            // button35
            // 
            this.button35.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button35.Location = new System.Drawing.Point(284, 324);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(120, 23);
            this.button35.TabIndex = 0;
            this.button35.Text = "MM - YYYY";
            this.button35.UseVisualStyleBackColor = true;
            this.button35.Click += new System.EventHandler(this.Button_Click);
            // 
            // button36
            // 
            this.button36.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button36.Location = new System.Drawing.Point(284, 353);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(120, 23);
            this.button36.TabIndex = 0;
            this.button36.Text = "MM - YYYY";
            this.button36.UseVisualStyleBackColor = true;
            this.button36.Click += new System.EventHandler(this.Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(137, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wybierz Miesiąc";
            // 
            // button37
            // 
            this.button37.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button37.Location = new System.Drawing.Point(148, 353);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(120, 23);
            this.button37.TabIndex = 0;
            this.button37.Text = "MM -YYYY";
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Click += new System.EventHandler(this.Button_Click);
            // 
            // WybierzMiesiac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 388);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button37);
            this.Controls.Add(this.button24);
            this.Controls.Add(this.button25);
            this.Controls.Add(this.button26);
            this.Controls.Add(this.button27);
            this.Controls.Add(this.button28);
            this.Controls.Add(this.button29);
            this.Controls.Add(this.button30);
            this.Controls.Add(this.button31);
            this.Controls.Add(this.button32);
            this.Controls.Add(this.button33);
            this.Controls.Add(this.button34);
            this.Controls.Add(this.button35);
            this.Controls.Add(this.button36);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WybierzMiesiac";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.Label label1;

    }
}
