using System;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Firebase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "lVE5xwYYR6693QYet0L3XAteKwAObA2Y4hS6W6lv",
            BasePath = "https://chatapplimayrac-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient fclient;
        private void Form1_Load(object sender, EventArgs e)
        {
            try 
            {
                fclient = new FireSharp.FirebaseClient(fcon);
            }
            catch
            {
                MessageBox.Show("il y a eu un problème avec internet");
            }
        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            Messages msg = new Messages()
            {
                MessageTxt = messagebox.Text,
                UserName = usernamebox.Text,
                DateMsg = DateTime.Now.ToString("MM/dd/yyyy HH:mm"),
            };

            var setter = fclient.Set("Messages/" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace('/','-'), msg);
        }

        private void selectbtn_Click(object sender, EventArgs e)
        {
            FirebaseResponse res = fclient.Get("Messages/");
            Dictionary<string, Messages> data = JsonConvert.DeserializeObject<Dictionary<string, Messages>>(res.Body.ToString());
            //Console.WriteLine(res.Body.ToString());
            GetMsgToString(data);
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            var setter = fclient.Delete("Messages/channel1/" + usernamebox.Text);
        }

        private void GetMsgToString(Dictionary<string, Messages> record)
        {
            displaymsgbox.Clear();
            foreach (var item in record)
            {
                displaymsgbox.Text += item.Value.DateMsg + "    ";
                displaymsgbox.Text += item.Value.UserName + " : ";
                displaymsgbox.Text += item.Value.MessageTxt + " ";
                displaymsgbox.Text += "\n";
            }
        }
    }
}
