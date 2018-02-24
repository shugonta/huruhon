using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kaede3rd
{
    public partial class Login : Form
    {
        private List<AppConfig.Connection> connectList;
        private SqlConnection connection;
        public Login()
        {
            InitializeComponent();
            this.connectList = Program.config.ConnectList;
            if (this.connectList == null) { this.connectList = new List<AppConfig.Connection>(); }
            if (this.connectList.Count == 0)
            {
                this.connectList.Add(new AppConfig.Connection
                {
                    cfgname = "テスト部門",
                    host = "localhost",
                    port = "3306",
                    user = "username",
                    pass = "password",
                    dbname = "database_name",
                });
            }

            foreach (var c in this.connectList)
            {
                this.comboBox1.Items.Add(c.cfgname);
            }
            this.comboBox1.SelectedIndex = 0;
            this.setTextbox(0);
        }

        public static DialogResult DialogOpen(string title, out SqlConnection connect)
        {
            Login f = new Login();
            f.Text = title;
            f.connection = new SqlConnection();
            var drt= f.ShowDialog();
            connect = f.connection;
            return drt;
        }

        private void checkBox_showpass_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                textBox_pass.UseSystemPasswordChar = !checkBox_showpass.Checked;
            }
            catch
            {
            }
        }
        private void button_open_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("SQL Server Express Edition以外を使用している場合自動的にデタッチされません。使用後かならずデタッチするようにしてください",
                "注意", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Cancel) return;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter =
                "MDFファイル(*.mdf)|*.mdf";
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                string con;
                con = MakeConnectionStringFile(textBox_host.Text, textBox_port.Text, ofd.FileName, textBox_user.Text, textBox_pass.Text);
                try
                {
                    if (connection == null)
                    {
                        Globals.ConnectionString = new SqlConnection(con);
                        Globals.ConnectionString.Open();
                    }
                    else
                    {
                        connection = new SqlConnection(con);
                        connection.Open();
                    }
                    FormOpen();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button_connect_Click(object sender, EventArgs e)
        {
            string con;
            con = MakeConnectionString(textBox_host.Text, textBox_port.Text, textBox_db.Text, textBox_user.Text, textBox_pass.Text);
            try
            {
                if (connection == null)
                {
                    Globals.ConnectionString = new SqlConnection(con);
                    Globals.ConnectionString.Open();
                }
                else
                {
                    connection = new SqlConnection(con);
                    connection.Open();
                }
                FormOpen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormOpen()
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            //Config確認
            try
            {
                DbConfig config = new DbConfig();
                foreach (var n in context.config)
                {
                    if (n.config_name == "bumonname")
                    {
                        config.bumonnname = n.config_value;
                    }
                    else if (n.config_name == "companyname")
                    {
                        config.companyname = n.config_value;
                    }
                    else if (n.config_name == "symbolcolor_argb")
                    {
                        config.symbolcolor = Color.FromArgb(int.Parse(n.config_value));
                    }
                    else if (n.config_name == "bumontextcolor_argb")
                    {
                        config.bumontextcolor = Color.FromArgb(int.Parse(n.config_value));
                    }
                    else if (n.config_name == "barcodeprefix")
                    {
                        config.barcodeplefix = int.Parse(n.config_value);
                    }
                    else if (n.config_name == "itemname_imeon")
                    {
                        config.itemname_iemon = bool.Parse(n.config_value);
                    }
                    else if (n.config_name == "entertotab")
                    {
                        config.entertotab = bool.Parse(n.config_value);
                    }
                    else if (n.config_name == "connection_string")
                    {
                        config.connectionstring = n.config_value;
                    }
                }
                if (config.bumonnname == null)
                {
                    ConfigForm configform = new ConfigForm();
                    if (configform.ShowDialog() == DialogResult.OK)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                else
                {
                    Globals.Config = config;
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            this.Dispose();
        }
        private string MakeConnectionString(string host, string port, string db, string user, string pass)
        {
            string connection;
            if (port.Length > 0)
            {
                host = host + "," + port;
            }
            if (user == "SSPI")
            {
                connection = "Integrated Security=SSPI;Server=" + host + ";Initial Catalog=" + db;
            }
            else
            {
                connection = "User ID=" + user + ";Password='" + pass + "';Server=" + host + ";Initial Catalog=" + db;
            }
            return connection;
        }

        private string MakeConnectionStringFile(string host, string port, string filename, string user, string pass)
        {
            string connection;
            if (port.Length > 0)
            {
                host = host + "," + port;
            }
            if (user == "SSPI")
            {
                connection = "Integrated Security=SSPI;Data Source=" + host + ";AttachDbFilename=" + filename;
            }
            else
            {
                connection = "User ID=" + user + ";Password='" + pass + "';Server=" + host + ";AttachDbFilename=" + filename;
            }
            return connection;
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void setTextbox(int index)
        {
            AppConfig.Connection c = this.connectList[index];
            this.textBox_host.Text = c.host;
            this.textBox_port.Text = c.port;
            this.textBox_user.Text = c.user;
            this.textBox_pass.Text = c.pass;
            this.textBox_db.Text = c.dbname;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setTextbox(comboBox1.SelectedIndex);
        }
    }
}
