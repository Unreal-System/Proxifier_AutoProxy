using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proxifier_AutoProxy.Function;
using System.IO;

namespace Proxifier_AutoProxy.Forms
{

    public partial class MainForm : Form
    {

        private delegate void SetCallBack(object Object, object RequirtData);
        public static int progressbar_int = 0;
        public static string tip = "";

        public MainForm()
        {
            InitializeComponent();
        }
        //Begin Start
        private void btn_Get_Click(object sender, EventArgs e)
        {
            btn_Get.Enabled = false;
            btn_save.Enabled = false;
            Task.Factory.StartNew(delegate { FormCallBack.GetCallBack(this, null); });
        }
        private void tim_Update_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressbar_int;
            lab_log.Text = tip;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Proxifier Config (*.ppx)|*.ppx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate);
                string ppt = Encoding.UTF8.GetString(System.Convert.FromBase64String(Function.GetMain.def_ppt_base64));
                ppt = ppt.Replace("*proxy-dns-host*", System.Environment.NewLine + Function.GetMain.dns_proxy + System.Environment.NewLine);
                ppt = ppt.Replace("<Targets>China-IP", "<Targets> " + System.Environment.NewLine + Function.GetMain.ipresult) + " "+ System.Environment.NewLine;
                ppt = ppt.Replace("<Targets>China-Host", "<Targets> " + System.Environment.NewLine + Function.GetMain.dns_direct) + " "+ System.Environment.NewLine;
                ppt = ppt.Replace("<Targets>Proexy-Host", "<Targets> "+ System.Environment.NewLine + Function.GetMain.dns_proxy) + " "+ System.Environment.NewLine;
                fs.Write(Encoding.Default.GetBytes(ppt), 0, Encoding.Default.GetBytes(ppt).Count());
                fs.Close();
            }
        }

        #region asy
        public static class FormCallBack
        {

            public static void GetCallBack(Object frm, object rdata)
            {

                Forms.MainForm Form = (Forms.MainForm)frm;
                if (Form.InvokeRequired)
                {
                    //AsyGet
                    //getip
                    GetMain.Get_IP(Form.textBox1.Text, Form.textBox2.Text);
                    GetMain.GetDns_Whitelist(Form.textBox3.Text);
                    string result = GetMain.ipresult;
                    //getpac_dns_whitelist
                    SetCallBack scb = new SetCallBack(GetCallBack);
                    if (Form.IsHandleCreated)
                    {
                        Form.Invoke(scb, new object[] { Form, null });
                    }
                }
                else
                {
                    Form.btn_Get.Enabled = true;
                    Form.btn_save.Enabled = true;
                }

            }

        }


        #endregion

    }

}
