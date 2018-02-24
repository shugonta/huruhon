using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kaede3rd
{
    public partial class ConfigForm : Form
    {
        private DBClassDataContext context;

        public ConfigForm()
        {
            InitializeComponent();

            context = new DBClassDataContext(Globals.ConnectionString);
            var config = GetConfig(context);

            this.textBox_bumon.Text = config.bumonnname;
            this.textBox_company.Text = config.companyname;
            this.pictureBox1.BackColor = config.symbolcolor;
            this.pictureBox2.BackColor = config.bumontextcolor;
            this.textBox_barcode.Text = config.barcodeplefix.ToString();
            this.checkBox_imeon.Checked = config.itemname_iemon;
            this.checkBox_entertotab.Checked = config.entertotab;
            this.textBox_connection.Text = config.connectionstring;
        }

        private DbConfig GetConfig(DBClassDataContext context)
        {
            DbConfig config_data = new DbConfig();
            try
            {
                foreach (var n in context.config)
                {
                    if (n.config_name == "bumonname")
                    {
                        config_data.bumonnname = n.config_value;
                    }
                    else if (n.config_name == "companyname")
                    {
                        config_data.companyname = n.config_value;
                    }
                    else if (n.config_name == "symbolcolor_argb")
                    {
                        config_data.symbolcolor = Color.FromArgb(int.Parse(n.config_value));
                    }
                    else if (n.config_name == "bumontextcolor_argb")
                    {
                        config_data.bumontextcolor = Color.FromArgb(int.Parse(n.config_value));
                    }
                    else if (n.config_name == "barcodeprefix")
                    {
                        config_data.barcodeplefix = int.Parse(n.config_value);
                    }
                    else if (n.config_name == "itemname_imeon")
                    {
                        config_data.itemname_iemon = bool.Parse(n.config_value);
                    }
                    else if (n.config_name == "entertotab")
                    {
                        config_data.entertotab = bool.Parse(n.config_value);
                    }
                    else if (n.config_name == "connection_string")
                    {
                        config_data.connectionstring = n.config_value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return config_data;
        }

        private void SetConfig(DbConfig config_data, DBClassDataContext context)
        {
            List<config> config_list = new List<config>();
            config_list.Add(new config
           {
               config_name = "bumonname",
               config_value = config_data.bumonnname
           });
            config_list.Add(new config
            {
                config_name = "companyname",
                config_value = config_data.companyname
            });
            config_list.Add(new config
            {
                config_name = "symbolcolor_argb",
                config_value = config_data.symbolcolor.ToArgb().ToString()
            });
            config_list.Add(new config
            {
                config_name = "bumontextcolor_argb",
                config_value = config_data.bumontextcolor.ToArgb().ToString()
            });
            config_list.Add(new config
            {
                config_name = "barcodeprefix",
                config_value = config_data.barcodeplefix.ToString()
            });
            config_list.Add(new config
            {
                config_name = "itemname_imeon",
                config_value = config_data.itemname_iemon.ToString()
            });
            config_list.Add(new config
            {
                config_name = "entertotab",
                config_value = config_data.entertotab.ToString()
            });
            config_list.Add(new config
            {
                config_name = "connection_string",
                config_value = config_data.connectionstring
            });

            //データベース処理
            try
            {
                context.config.DeleteAllOnSubmit(context.config);
                foreach (config data in config_list)
                {
                    context.config.InsertOnSubmit(data);
                }
                context.SubmitChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void show_colorDialog(PictureBox pictBox)
        {
            ColorDialog cdia = new ColorDialog();
            cdia.Color = pictBox.BackColor;
            cdia.FullOpen = true;
            cdia.AnyColor = true;

            if (cdia.ShowDialog() == DialogResult.OK)
            {
                pictBox.BackColor = cdia.Color;
            }

            cdia.Dispose();
        }

        private void button_color_Click(object sender, EventArgs e)
        {
            this.show_colorDialog(this.pictureBox1);
        }

        private void button_color2_Click(object sender, EventArgs e)
        {
            this.show_colorDialog(this.pictureBox2);
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            DbConfig config_data = new DbConfig
            {
                bumonnname = textBox_bumon.Text,
                companyname = textBox_company.Text,
                symbolcolor = pictureBox1.BackColor,
                bumontextcolor = pictureBox2.BackColor,
                barcodeplefix = int.Parse(textBox_barcode.Text),
                itemname_iemon = checkBox_imeon.Checked,
                entertotab = checkBox_entertotab.Checked,
                connectionstring = textBox_connection.Text
            };
            Globals.Config = config_data;
            SetConfig(config_data, context);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_editgenre_Click(object sender, EventArgs e)
        {
            GenreEdit form = new GenreEdit();
            form.ShowDialog();
        }
    }
}
