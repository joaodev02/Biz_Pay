using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X500;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using PIM.Database;
using System.Diagnostics;

namespace PIM
{
    public partial class Login : Form
    {
        private MySqlConnection _connection;
        public Login()
        {
            InitializeComponent();
            Utils.ContextLogin.Login = this;
        }


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLogin = new System.Windows.Forms.PictureBox();
            this.eyeLock = new System.Windows.Forms.PictureBox();
            this.eye = new System.Windows.Forms.PictureBox();
            this.inputLoginPass = new System.Windows.Forms.TextBox();
            this.inputLoginUser = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyeLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1325, 740);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.eyeLock);
            this.panel1.Controls.Add(this.eye);
            this.panel1.Controls.Add(this.inputLoginPass);
            this.panel1.Controls.Add(this.inputLoginUser);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(16, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1292, 705);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(48)))), ((int)(((byte)(218)))));
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Location = new System.Drawing.Point(637, 415);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(464, 128);
            this.panel2.TabIndex = 26;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(48)))), ((int)(((byte)(218)))));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.30024F));
            this.tableLayoutPanel2.Controls.Add(this.buttonLogin, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(458, 122);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(48)))), ((int)(((byte)(218)))));
            this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogin.Image = ((System.Drawing.Image)(resources.GetObject("buttonLogin.Image")));
            this.buttonLogin.Location = new System.Drawing.Point(132, 28);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(194, 66);
            this.buttonLogin.TabIndex = 6;
            this.buttonLogin.TabStop = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // eyeLock
            // 
            this.eyeLock.BackColor = System.Drawing.Color.White;
            this.eyeLock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eyeLock.Image = ((System.Drawing.Image)(resources.GetObject("eyeLock.Image")));
            this.eyeLock.Location = new System.Drawing.Point(977, 377);
            this.eyeLock.Name = "eyeLock";
            this.eyeLock.Size = new System.Drawing.Size(29, 23);
            this.eyeLock.TabIndex = 25;
            this.eyeLock.TabStop = false;
            this.eyeLock.Click += new System.EventHandler(this.eyeLock_Click);
            // 
            // eye
            // 
            this.eye.BackColor = System.Drawing.Color.White;
            this.eye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eye.Image = ((System.Drawing.Image)(resources.GetObject("eye.Image")));
            this.eye.Location = new System.Drawing.Point(977, 377);
            this.eye.Name = "eye";
            this.eye.Size = new System.Drawing.Size(27, 23);
            this.eye.TabIndex = 24;
            this.eye.TabStop = false;
            this.eye.Click += new System.EventHandler(this.eye_Click);
            // 
            // inputLoginPass
            // 
            this.inputLoginPass.BackColor = System.Drawing.Color.White;
            this.inputLoginPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputLoginPass.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.inputLoginPass.Location = new System.Drawing.Point(775, 373);
            this.inputLoginPass.Margin = new System.Windows.Forms.Padding(0);
            this.inputLoginPass.Name = "inputLoginPass";
            this.inputLoginPass.Size = new System.Drawing.Size(199, 27);
            this.inputLoginPass.TabIndex = 23;
            // 
            // inputLoginUser
            // 
            this.inputLoginUser.BackColor = System.Drawing.Color.White;
            this.inputLoginUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputLoginUser.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.inputLoginUser.Location = new System.Drawing.Point(775, 288);
            this.inputLoginUser.Margin = new System.Windows.Forms.Padding(0);
            this.inputLoginUser.Name = "inputLoginUser";
            this.inputLoginUser.Size = new System.Drawing.Size(210, 27);
            this.inputLoginUser.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(166, 84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(960, 536);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1333, 750);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eyeLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void checkLogin()
        {
            try
            {

                string commandSql = $"SELECT f.*, c.nome cargo, p.nome permissao FROM funcionario f INNER JOIN cargo c ON f.idCargo = c.id INNER JOIN permissao p on f.idPermissao = p.id WHERE email = '{inputLoginUser.Text}';";
                MySqlDataReader reader = PIM.Database.Connection.connectDB(commandSql);

                DataTable dt = new DataTable();

                dt.Load(reader);

                if (dt.Rows.Count > 0)
                {
                    int id = default;
                    string name = default;
                    string email = default;
                    string phone = default;
                    string cpf = default;
                    string password = default;
                    string status = default;
                    string nameRole = default;
                    string permition = default;


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        id = int.Parse(dt.Rows[i]["id"].ToString());
                        name = dt.Rows[i]["nome"].ToString();
                        email = dt.Rows[i]["email"].ToString();
                        phone = dt.Rows[i]["celular"].ToString();
                        cpf = dt.Rows[i]["cpf"].ToString();
                        password = dt.Rows[i]["senha"].ToString();
                        status = dt.Rows[i]["situacao"].ToString();
                        nameRole = dt.Rows[i]["cargo"].ToString();
                        permition = dt.Rows[i]["permissao"].ToString();
                    }

                    if (status != "Inativo")
                    {
                        if (password == inputLoginPass.Text)
                        {

                            PIM.Database.User.Id = id;
                            PIM.Database.User.Name = name;
                            PIM.Database.User.Email = email;
                            PIM.Database.User.Phone = phone;
                            PIM.Database.User.Cpf = cpf;
                            PIM.Database.User.Password = password;
                            PIM.Database.User.Status = status;
                            PIM.Database.User.NameRole = nameRole;
                            PIM.Database.User.Permition = permition;

                           PIM.Utils.ContextHome._Home = new PIM.Home();

                            Utils.ContextLogin.Login.Hide();
                            PIM.Utils.ContextHome._Home.Show();
                        
                        } else
                        {
                            MessageBox.Show("Senha incorreta!","Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    } else
                    {
                        MessageBox.Show("Usuário Inativo!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                } else
                {
                    MessageBox.Show("Usuário não encontrado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro " + ex.Number + " ocorreu: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { 
                PIM.Database.Connection.closeConnetionDB(); 
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            eye.Visible = false;
            checkVisiblePass();
        }

        private void eye_Click(object sender, EventArgs e)
        {
            eye.Visible = false;
            eyeLock.Visible = true;
            checkVisiblePass();
        }

        private void eyeLock_Click(object sender, EventArgs e)
        {
            eyeLock.Visible = false;
            eye.Visible = true;
            checkVisiblePass();
        }

        private void checkVisiblePass()
        {
            if (eye.Visible == false)
            {
                inputLoginPass.PasswordChar = '*';
            } else
            {
                inputLoginPass.PasswordChar = '\0';
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            checkLogin();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            string programName = Process.GetCurrentProcess().ProcessName;

            foreach (Process process in Process.GetProcessesByName(programName))
            {
                process.Kill();
            }
        }
    }
}
