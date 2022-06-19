
namespace Firebase
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.messagebox = new System.Windows.Forms.TextBox();
            this.insertbtn = new System.Windows.Forms.Button();
            this.selectbtn = new System.Windows.Forms.Button();
            this.displaymsgbox = new System.Windows.Forms.RichTextBox();
            this.PasswordtxtCon = new System.Windows.Forms.TextBox();
            this.UsernametxtCon = new System.Windows.Forms.TextBox();
            this.UsernameCon = new System.Windows.Forms.Label();
            this.PasswordCon = new System.Windows.Forms.Label();
            this.ConnexionBTN = new System.Windows.Forms.Button();
            this.InscriptionBTN = new System.Windows.Forms.Button();
            this.DeleteBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messagebox
            // 
            this.messagebox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messagebox.Location = new System.Drawing.Point(276, 383);
            this.messagebox.Name = "messagebox";
            this.messagebox.Size = new System.Drawing.Size(251, 26);
            this.messagebox.TabIndex = 0;
            // 
            // insertbtn
            // 
            this.insertbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertbtn.Location = new System.Drawing.Point(533, 383);
            this.insertbtn.Name = "insertbtn";
            this.insertbtn.Size = new System.Drawing.Size(87, 26);
            this.insertbtn.TabIndex = 8;
            this.insertbtn.Text = "Envoyer";
            this.insertbtn.UseVisualStyleBackColor = true;
            this.insertbtn.Click += new System.EventHandler(this.insertbtn_Click);
            // 
            // selectbtn
            // 
            this.selectbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectbtn.Location = new System.Drawing.Point(368, 415);
            this.selectbtn.Name = "selectbtn";
            this.selectbtn.Size = new System.Drawing.Size(80, 29);
            this.selectbtn.TabIndex = 9;
            this.selectbtn.Text = "SELECT";
            this.selectbtn.UseVisualStyleBackColor = true;
            this.selectbtn.Click += new System.EventHandler(this.selectbtn_Click);
            // 
            // displaymsgbox
            // 
            this.displaymsgbox.Location = new System.Drawing.Point(116, 12);
            this.displaymsgbox.Name = "displaymsgbox";
            this.displaymsgbox.Size = new System.Drawing.Size(590, 365);
            this.displaymsgbox.TabIndex = 17;
            this.displaymsgbox.Text = "";
            // 
            // PasswordtxtCon
            // 
            this.PasswordtxtCon.Location = new System.Drawing.Point(330, 192);
            this.PasswordtxtCon.Name = "PasswordtxtCon";
            this.PasswordtxtCon.Size = new System.Drawing.Size(100, 20);
            this.PasswordtxtCon.TabIndex = 18;
            // 
            // UsernametxtCon
            // 
            this.UsernametxtCon.Location = new System.Drawing.Point(330, 160);
            this.UsernametxtCon.Name = "UsernametxtCon";
            this.UsernametxtCon.Size = new System.Drawing.Size(100, 20);
            this.UsernametxtCon.TabIndex = 19;
            // 
            // UsernameCon
            // 
            this.UsernameCon.AutoSize = true;
            this.UsernameCon.Location = new System.Drawing.Point(240, 163);
            this.UsernameCon.Name = "UsernameCon";
            this.UsernameCon.Size = new System.Drawing.Size(84, 13);
            this.UsernameCon.TabIndex = 20;
            this.UsernameCon.Text = "Nom d\'utilisateur";
            // 
            // PasswordCon
            // 
            this.PasswordCon.AutoSize = true;
            this.PasswordCon.Location = new System.Drawing.Point(253, 195);
            this.PasswordCon.Name = "PasswordCon";
            this.PasswordCon.Size = new System.Drawing.Size(71, 13);
            this.PasswordCon.TabIndex = 21;
            this.PasswordCon.Text = "Mot de passe";
            // 
            // ConnexionBTN
            // 
            this.ConnexionBTN.Location = new System.Drawing.Point(452, 158);
            this.ConnexionBTN.Name = "ConnexionBTN";
            this.ConnexionBTN.Size = new System.Drawing.Size(75, 23);
            this.ConnexionBTN.TabIndex = 22;
            this.ConnexionBTN.Text = "Connexion";
            this.ConnexionBTN.UseVisualStyleBackColor = true;
            this.ConnexionBTN.Click += new System.EventHandler(this.ConnexionBTN_Click);
            // 
            // InscriptionBTN
            // 
            this.InscriptionBTN.Location = new System.Drawing.Point(452, 190);
            this.InscriptionBTN.Name = "InscriptionBTN";
            this.InscriptionBTN.Size = new System.Drawing.Size(75, 23);
            this.InscriptionBTN.TabIndex = 23;
            this.InscriptionBTN.Text = "S\'Inscrire";
            this.InscriptionBTN.UseVisualStyleBackColor = true;
            this.InscriptionBTN.Click += new System.EventHandler(this.InscriptionBTN_Click);
            // 
            // DeleteBTN
            // 
            this.DeleteBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBTN.Location = new System.Drawing.Point(172, 383);
            this.DeleteBTN.Name = "DeleteBTN";
            this.DeleteBTN.Size = new System.Drawing.Size(98, 26);
            this.DeleteBTN.TabIndex = 24;
            this.DeleteBTN.Text = "Supprimer";
            this.DeleteBTN.UseVisualStyleBackColor = true;
            this.DeleteBTN.Click += new System.EventHandler(this.DeleteBTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteBTN);
            this.Controls.Add(this.InscriptionBTN);
            this.Controls.Add(this.ConnexionBTN);
            this.Controls.Add(this.PasswordCon);
            this.Controls.Add(this.UsernameCon);
            this.Controls.Add(this.UsernametxtCon);
            this.Controls.Add(this.PasswordtxtCon);
            this.Controls.Add(this.displaymsgbox);
            this.Controls.Add(this.selectbtn);
            this.Controls.Add(this.insertbtn);
            this.Controls.Add(this.messagebox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messagebox;
        private System.Windows.Forms.Button insertbtn;
        private System.Windows.Forms.Button selectbtn;
        private System.Windows.Forms.RichTextBox displaymsgbox;
        private System.Windows.Forms.TextBox PasswordtxtCon;
        private System.Windows.Forms.TextBox UsernametxtCon;
        private System.Windows.Forms.Label UsernameCon;
        private System.Windows.Forms.Label PasswordCon;
        private System.Windows.Forms.Button ConnexionBTN;
        private System.Windows.Forms.Button InscriptionBTN;
        private System.Windows.Forms.Button DeleteBTN;
    }
}

