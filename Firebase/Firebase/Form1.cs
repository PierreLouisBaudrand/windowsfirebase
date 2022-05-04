using System;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            Message msg = new Message()
            {
                MessageTxt = messagebox.Text,
                UserName = usernamebox.Text
            };

            var setter = fclient.Set("Messages/channel1/" + usernamebox.Text, msg);
        }

        private void selectbtn_Click(object sender, EventArgs e)
        {
            var result = fclient.Get("Messages/channel1/" + usernamebox.Text);
            Message msg = result.ResultAs<Message>();
            themmessagebox.Text = msg.MessageTxt;
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            var setter = fclient.Delete("Messages/channel1/" + usernamebox.Text);
        }
    }
}
