using System;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data.SQLite;

namespace Firebase
{
    public partial class Form1 : Form
    {
        //SQL MESSAGES
        public string queryinsertmsg = "INSERT INTO MESSAGES ('DATE','USER_M','TEXT_M') VALUES (@date, @user_m, @text_m)";
        public string queryselectmsgspe = "SELECT * FROM MESSAGES WHERE DATE = @date AND USER_M = @user_m";
        public string queryselectmsg = "SELECT * FROM MESSAGES";
        public string querydeletemsg = "DELETE FROM MESSAGES WHERE DATE = @date AND USER_M = @user_m";

        //SQL USERS
        public string queryinsertuser = "INSERT INTO USER ('USERNAME','PASSWORD') VALUES (@username, @password)";
        public string queryselectuser = "SELECT * FROM USER";
        public string queryselectuserspe = "SELECT * FROM USER WHERE USERNAME = @username";
        public string querydeleteuser = "DELETE FROM USER";

        //Username pour l'app
        public string username = "pierre";
        //Dernier msg date
        public string lastdate = "18/06/2022 16:50:35";

        //Init SQLite
        Database bdsqlite3 = new Database();
        //Init Firebase
        IFirebaseClient fclient;

        public Form1()
        {
            try
            {
                fclient = new FireSharp.FirebaseClient(fcon);
            }
            catch
            {
                MessageBox.Show("il y a eu un problème avec internet");
            }
            InitializeComponent();
            GetUserFromFirebase();
            GetMsgToSQLite();
            GetMsgSQLiteToString();
            plan1();
        }

        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "lVE5xwYYR6693QYet0L3XAteKwAObA2Y4hS6W6lv",
            BasePath = "https://chatapplimayrac-default-rtdb.firebaseio.com/"
        };
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            Messages msg = new Messages()
            {
                MessageTxt = messagebox.Text,
                UserName = username,
                DateMsg = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
            };

            var setter = fclient.Set("Messages/" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss").Replace('/','-'), msg);
            lastdate = msg.DateMsg;
        }

        private void selectbtn_Click(object sender, EventArgs e)
        {
            GetMsgToSQLite();
            GetMsgSQLiteToString();
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            SQLiteCommand SMSG = new SQLiteCommand(queryselectmsgspe, bdsqlite3.connexion);
            bdsqlite3.OpenConnection();
            SMSG.Parameters.AddWithValue("@date", lastdate);
            SMSG.Parameters.AddWithValue("@user_m", username);
            SQLiteDataReader result = SMSG.ExecuteReader();
            if (result.HasRows)
            {
                result.Read();
                SQLiteCommand DMSG = new SQLiteCommand(querydeletemsg, bdsqlite3.connexion);
                DMSG.Parameters.AddWithValue("@date", lastdate);
                DMSG.Parameters.AddWithValue("user_m", username);
                DMSG.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Pas de message à supprimer","Erreur");
            }
            bdsqlite3.CloseConnection();
            GetMsgSQLiteToString();
        //var setter = fclient.Delete("Messages/channel1/" + usernamebox.Text);
        }
        private void plan1()
        {
            //Plan1
            UsernameCon.Visible = true;
            PasswordCon.Visible = true;
            UsernametxtCon.Visible = true;
            PasswordtxtCon.Visible = true;
            ConnexionBTN.Visible = true;
            InscriptionBTN.Visible = true;
            //Plan 2
            displaymsgbox.Visible = false; 
            messagebox.Visible = false; 
            selectbtn.Visible = false; 
            insertbtn.Visible = false; 
        }
        private void plan2 ()
        {
            //Plan 1
            UsernameCon.Visible = false;
            PasswordCon.Visible = false;
            UsernametxtCon.Visible = false;
            PasswordtxtCon.Visible = false;
            ConnexionBTN.Visible = false;
            InscriptionBTN.Visible = false;
            //Plan 2
            displaymsgbox.Visible = true;
            messagebox.Visible = true;
            selectbtn.Visible = true;
            insertbtn.Visible = true;
        }

        private void GetMsgToSQLite()
        {
            FirebaseResponse res = fclient.Get("Messages/");
            Dictionary<string, Messages> data = JsonConvert.DeserializeObject<Dictionary<string, Messages>>(res.Body.ToString());
            bdsqlite3.OpenConnection();
            foreach (var item in data)
            {
                SQLiteCommand SMSG = new SQLiteCommand(queryselectmsgspe, bdsqlite3.connexion);
                SMSG.Parameters.AddWithValue("@date", item.Value.DateMsg);
                SMSG.Parameters.AddWithValue("@user_m", item.Value.UserName);
                SQLiteDataReader result = SMSG.ExecuteReader();
                if (result.HasRows)
                {

                }
                else
                {
                    SQLiteCommand IMSG = new SQLiteCommand(queryinsertmsg, bdsqlite3.connexion);
                    IMSG.Parameters.AddWithValue("@date", item.Value.DateMsg);
                    MessageBox.Show("date");
                    IMSG.Parameters.AddWithValue("@user_m", item.Value.UserName);
                    MessageBox.Show("user_m");
                    IMSG.Parameters.AddWithValue("@text_m", item.Value.MessageTxt);
                    MessageBox.Show("text_m");
                    IMSG.ExecuteNonQuery();
                }
            }
            bdsqlite3.CloseConnection();
        }
        private void GetMsgSQLiteToString ()
        {
            displaymsgbox.Clear();
            SQLiteCommand myCommand = new SQLiteCommand(queryselectmsg, bdsqlite3.connexion);
            bdsqlite3.OpenConnection();
            SQLiteDataReader result = myCommand.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    displaymsgbox.Text += result["DATE"] + "    " + result["USER_M"] + " : " + result["TEXT_M"] + "\n";
                }
            }
            bdsqlite3.CloseConnection();
        }
        private void GetUserFromFirebase ()
        {
            FirebaseResponse res = fclient.Get("Users/");
            Dictionary<string, Users> data = JsonConvert.DeserializeObject<Dictionary<string, Users>>(res.Body.ToString());
            bdsqlite3.OpenConnection();
            foreach (var item in data)
            {
                SQLiteCommand SUSER = new SQLiteCommand(queryselectuserspe, bdsqlite3.connexion);
                SUSER.Parameters.AddWithValue("@username", item.Value.UserName);
                SQLiteDataReader result = SUSER.ExecuteReader();
                if (result.HasRows)
                {

                }
                else
                {
                    SQLiteCommand CUSER = new SQLiteCommand(queryinsertuser, bdsqlite3.connexion);
                    CUSER.Parameters.AddWithValue("@username", item.Value.UserName);
                    CUSER.Parameters.AddWithValue("@password", item.Value.PassWord);
                    CUSER.ExecuteNonQuery();
                }
            }
            bdsqlite3.CloseConnection();
        }
        private void CheckUserFromSQLite ()
        {
            if (UsernametxtCon.Text != "" && PasswordtxtCon.Text != "")
            {
                SQLiteCommand SUSER = new SQLiteCommand(queryselectuserspe, bdsqlite3.connexion);
                bdsqlite3.OpenConnection();
                SUSER.Parameters.AddWithValue("@username", UsernametxtCon.Text);
                SQLiteDataReader result = SUSER.ExecuteReader();
                if (result.HasRows)
                {
                    result.Read();
                    if (result["PASSWORD"].ToString() == PasswordtxtCon.Text)
                    {
                        username = UsernametxtCon.Text;
                        plan2();
                    }
                    else
                    {
                        MessageBox.Show("Mot de passe incorrect","Erreur");
                        PasswordtxtCon.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Utilisateur inexistant", "Erreur");
                    PasswordtxtCon.Text = "";
                    UsernametxtCon.Text = "";
                }
                bdsqlite3.CloseConnection();
            }
        }

        private void PutUserOnFirebase()
        {
            if (UsernametxtCon.Text != "" && PasswordtxtCon.Text != "")
            {
                SQLiteCommand SUSER = new SQLiteCommand(queryselectuserspe, bdsqlite3.connexion);
                bdsqlite3.OpenConnection();
                SUSER.Parameters.AddWithValue("@username", UsernametxtCon.Text);
                SQLiteDataReader result = SUSER.ExecuteReader();
                if (result.HasRows)
                {
                    MessageBox.Show("Utilisateur déjà existant", "Erreur");
                }
                else
                {
                    Users user = new Users()
                    {
                        UserName = UsernametxtCon.Text,
                        PassWord = PasswordtxtCon.Text
                    };

                    var setter = fclient.Set("Users/" + UsernametxtCon.Text, user);
                    MessageBox.Show("Utilisateur créé", "Information");
                    PasswordtxtCon.Text = "";
                    UsernametxtCon.Text = "";
                }
                bdsqlite3.CloseConnection();
            }
        }
        private void ConnexionBTN_Click(object sender, EventArgs e)
        {
            CheckUserFromSQLite();
        }

        private void InscriptionBTN_Click(object sender, EventArgs e)
        {
            GetUserFromFirebase();
            PutUserOnFirebase();
        }
    }
}
