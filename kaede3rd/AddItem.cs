using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;
using AmazonProductAdvtApi;

namespace kaede3rd
{
    public partial class AddItem : Form
    {
        int receipt_id;
        int item_id = 0;
        string isbn;
        string comment = "";
        bool supplement = false;
        public AddItem()
        {
            InitializeComponent();
            SetConfig();
        }

        public AddItem(int receiptid)
        {
            receipt_id = receiptid;
            InitializeComponent();
            SetConfig();
        }

        private void SetConfig()
        {
            if (Globals.Config.itemname_iemon)
            {
                this.text_itemname.ImeMode = ImeMode.On;
            }
            else
            {
                this.text_itemname.ImeMode = ImeMode.Off;
            }
        }
        private bool Button_next_Enable()
        {
            if (text_itemname.Text.Length > 0 && text_price.Text.Length > 0 && toolStripStatusLabel1.Text != "ISBN/JAN検索中" &&
                text_price.BackColor == Color.White && text_volume.BackColor == Color.White && text_num.BackColor == Color.White)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void text_itemname_TextChanged(object sender, EventArgs e)
        {
            this.ConvBarcode(text_itemname);
            button_next.Enabled = Button_next_Enable();
        }

        private void text_itemname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl((Control)sender, true, true, true, false);
                e.SuppressKeyPress = true;
            }
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (button_next.Enabled)
            {
                DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
                if (item_id > 0)
                {
                    var list = from n in context.item
                               where n.item_id == item_id
                               select n;
                    foreach (item q in list)
                    {
                        q.item_name = text_itemname.Text;
                        q.item_tagprice = int.Parse(text_price.Text);
                        q.item_return = check_return.Checked;
                        if (comment != null && comment.Length > 0)
                        {
                            q.item_comment = comment;
                        }
                        if (groupBox_volume.Enabled && text_num.Text.Length > 0)
                        {
                            q.item_number = int.Parse(text_num.Text);
                            if (text_volume.Text != "")
                            {
                                q.item_volumes = int.Parse(text_volume.Text);
                            }
                        }
                        else
                        {
                            q.item_number = 1;
                        }
                        q.item_supplement = supplement;
                    }
                }
                else
                {
                    item newitem = new item
                    {
                        item_name = text_itemname.Text,
                        item_tagprice = int.Parse(text_price.Text),
                        item_return = check_return.Checked,
                        item_receipt_id = receipt_id,
                        item_receipt_time = DateTime.Now,
                        item_isbn = isbn
                    };
                    if (comment != null && comment.Length > 0)
                    {
                        newitem.item_comment = comment;
                    }
                    if (groupBox_volume.Enabled && text_num.Text.Length > 0)
                    {
                        newitem.item_number = int.Parse(text_num.Text);
                        if (text_volume.Text != "")
                        {
                            newitem.item_volumes = int.Parse(text_volume.Text);
                        }
                    }
                    else
                    {
                        newitem.item_number = 1;
                    }
                    newitem.item_supplement = supplement;
                    context.item.InsertOnSubmit(newitem);
                }
                try
                {
                    context.SubmitChanges();
                    try
                    {
                        if (item_id == 0) throw new Exception("新規登録");
                        var list = (from n in context.item
                                    where n.item_receipt_id == receipt_id
                                    orderby n.item_id ascending
                                    where n.item_id > item_id
                                    select n).First();
                        item_id = list.item_id;
                        isbn = "";
                        this.text_itemid.Text = item_id.ToString();
                        this.text_itemname.Text = list.item_name;
                        this.text_price.Text = list.item_tagprice.ToString();
                        this.check_return.Checked = list.item_return;
                        comment = list.item_comment;
                        if (list.item_number > 1)
                        {
                            this.groupBox_volume.Enabled = true;
                            this.text_num.Text = list.item_number.ToString();
                            this.text_volume.Text = list.item_volumes.ToString();
                        }
                        else
                        {
                            this.groupBox_volume.Enabled = false;
                            this.text_num.Text = "";
                            this.text_volume.Text = "";
                        }
                        this.supplement = list.item_supplement;
                        this.label_supplement.Visible = list.item_supplement;
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "新規登録" || ex.Message == "シーケンスに要素が含まれていません")
                        {
                            item_id = 0;
                            isbn = "";
                            comment = "";
                            this.text_itemid.Text = "";
                            this.text_itemname.Text = "";
                            this.text_price.Text = "";
                            this.check_return.Checked = false;
                            groupBox_volume.Enabled = false;
                            this.text_num.Text = "";
                            this.text_volume.Text = "";
                        }
                        else
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    finally
                    {
                        text_itemname.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button_pre_Click(object sender, EventArgs e)
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            item list;
            text_price.BackColor = Color.White;
            text_volume.BackColor = Color.White;
            text_num.BackColor = Color.White;
            try
            {
                try
                {
                    if (text_itemid.Text == "")
                    {
                        list = (from n in context.item
                                where n.item_receipt_id == receipt_id
                                orderby n.item_id descending
                                select n).First();
                    }
                    else
                    {
                        list = (from n in context.item
                                where n.item_receipt_id == receipt_id
                                orderby n.item_id descending
                                where n.item_id < item_id
                                select n).First();
                    }
                }
                catch
                {
                    throw new Exception("最後の商品です");
                }
                if (list != null)
                {
                    text_itemid.Text = list.item_id.ToString();
                    item_id = list.item_id;
                    text_itemname.Text = list.item_name;
                    text_price.Text = list.item_tagprice.ToString();
                    check_return.Checked = list.item_return;
                    comment = list.item_comment;
                    if (list.item_number > 1)
                    {
                        this.groupBox_volume.Enabled = true;
                        this.text_num.Text = list.item_number.ToString();
                        if (text_volume.Text != "")
                        {
                            this.text_volume.Text = list.item_volumes.ToString();
                        }
                    }
                    else
                    {
                        this.groupBox_volume.Enabled = false;
                        this.text_num.Text = "";
                        this.text_volume.Text = "";
                    }
                    this.supplement = list.item_supplement;
                    this.label_supplement.Visible = list.item_supplement;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void text_price_TextChanged(object sender, EventArgs e)
        {
            button_next.Enabled = Button_next_Enable();
        }

        private void check_return_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !groupBox_volume.Enabled)
            {
                button_next_Click(sender, null);
            }
            else
            {
                SelectNextControl((Control)sender, true, true, true, false);
                e.SuppressKeyPress = true;
            }
        }

        private void AddItem_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers & Keys.Control) == Keys.Control && e.KeyCode == Keys.S && text_itemname.Text.Length > 0)
            {

                if (!groupBox_volume.Enabled)
                {
                    if (text_itemname.Text.Length > 0)
                    {
                        string result;
                        string result2;
                        TitleSplitForm.Show_Dialog(text_itemname.Text, out result);
                        if (InputBox.Show_Dialog("「" + result + "」の巻数を入力してください", "セット商品支援", "", out result2, ImeMode.Off, HorizontalAlignment.Left)
                            == DialogResult.OK && result2.Length > 0)
                        {
                            text_itemname.Text = result + " [" + result2 + "]";
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                groupBox_volume.Enabled = !groupBox_volume.Enabled;

            }
            else if ((e.Modifiers & Keys.Control) == Keys.Control && e.KeyCode == Keys.C && text_itemname.Text.Length > 0)
            {
                string result;
                if (InputBox.Show_Dialog("コメントを入力してください", "コメント入力", "", out result, ImeMode.On, HorizontalAlignment.Left)
                    == DialogResult.OK && result.Length > 0)
                {
                    comment = result;
                }
            }
            else if ((e.Modifiers & Keys.Control) == Keys.Control && e.KeyCode == Keys.R)
            {
                supplement = !supplement;
                this.label_supplement.Visible = supplement;
            }
        }


        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            textbox.SelectAll();
        }

        private void Num_Validate(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            string text = textbox.Text;
            int num;
            if ((TextBox)sender == text_volume && text == "")
            {
                textbox.BackColor = Color.White;
                button_next.Enabled = true;
            }
            else
            {

                if (!int.TryParse(text, out num))
                {
                    textbox.BackColor = Color.LightPink;
                    button_next.Enabled = false;
                }
                else
                {
                    textbox.BackColor = Color.White;
                    button_next.Enabled = true;
                }

            }
        }

        private void text_itemid_KeyDown(object sender, KeyEventArgs e)
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
            if (e.KeyCode == Keys.Enter)
            {
                item list;
                int itemid;
                text_price.BackColor = Color.White;
                text_volume.BackColor = Color.White;
                text_num.BackColor = Color.White;
                if (int.TryParse(text_itemid.Text, out itemid))
                {
                    try
                    {
                        list = (from n in context.item
                                where n.item_id == itemid
                                select n).First();
                        if (list != null)
                        {
                            receipt_id = list.item_receipt_id;
                            text_itemid.Text = list.item_id.ToString();
                            item_id = list.item_id;
                            text_itemname.Text = list.item_name;
                            text_price.Text = list.item_tagprice.ToString();
                            check_return.Checked = list.item_return;
                            if (list.item_number > 1)
                            {
                                this.groupBox_volume.Enabled = true;
                                this.text_num.Text = list.item_number.ToString();
                                if (text_volume.Text != "")
                                {
                                    this.text_volume.Text = list.item_volumes.ToString();
                                }
                            }
                            else
                            {
                                this.groupBox_volume.Enabled = false;
                                this.text_num.Text = "";
                                this.text_volume.Text = "";
                            }
                            this.supplement = list.item_supplement;
                            this.label_supplement.Visible = list.item_supplement;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                }
            }
        }

        #region Amazon関連

        public enum BarcodeType
        {
            Isbn, Jan
        }

        protected void ConvBarcode(TextBox textbox)
        {
            string val = textbox.Text;
            if (string.IsNullOrEmpty(val)) { return; }

            if (val.Length == 13)
            {
                val = Microsoft.VisualBasic.Strings.StrConv(val, Microsoft.VisualBasic.VbStrConv.Narrow, 0);

                if (System.Text.RegularExpressions.Regex.IsMatch(val, @"^\d{13}$"))
                {
                    if (val.StartsWith("978") || val.StartsWith("979"))
                    {
                        System.Threading.Thread t = new System.Threading.Thread(this.setTitleConvIsbnThread);
                        t.Start(textbox);
                    }
                    else
                        if (val.StartsWith("45") || val.StartsWith("49"))
                        {
                            System.Threading.Thread t = new System.Threading.Thread(this.setTitleConvJanThread);
                            t.Start(textbox);
                        }
                }
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(val, @"^4\d{9}$"))
            {
                System.Threading.Thread t = new System.Threading.Thread(this.setTitleConvIsbnThread);
                t.Start(textbox);
            }
        }


        protected readonly string tooltip_BarcodeSearching = "ISBN/JAN検索中";
        //別スレッド
        protected void setTitleConvIsbnThread(object obj) { this.setTitleConvBarcodeThread(obj, BarcodeType.Isbn); }
        protected void setTitleConvJanThread(object obj) { this.setTitleConvBarcodeThread(obj, BarcodeType.Jan); }

        protected void setTitleConvBarcodeThread(object obj, BarcodeType type)
        {
            TextBox textbox = (TextBox)obj;

            if (toolStripStatusLabel1.Text == this.tooltip_BarcodeSearching) { return; }

            bool f = false;
            try
            {
                ControlUtil.SafelyOperated(this, (MethodInvoker)delegate()
                {
                    toolStripStatusLabel1.Text = this.tooltip_BarcodeSearching;
                    isbn = textbox.Text;
                    button_next.Enabled = Button_next_Enable();
                });
                f = this.setTitleConvIsbn_Impl(textbox, type);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ISBN/JAN検索");
            }
            finally
            {
                if (f == false)
                {
                    //書名をセットしなかった
                }

                ControlUtil.SafelyOperated(this, (MethodInvoker)delegate()
                {
                    toolStripStatusLabel1.Text = null;
                    button_next.Enabled = Button_next_Enable();
                });
            }
        }


        //別スレッド
        protected bool setTitleConvIsbn_Impl(TextBox textbox, BarcodeType type)
        {
            string code = textbox.Text;

            SignedRequestHelper helper = new SignedRequestHelper("test", "test", "ecs.amazonaws.jp");


            IDictionary<string, string> requestParams = new Dictionary<string, String>();
            requestParams["Service"] = "AWSECommerceService";
            requestParams["Version"] = "2009-11-01";
            requestParams["Operation"] = "ItemLookup";
            requestParams["ItemId"] = code;

            if (type == BarcodeType.Isbn)
            {
                requestParams["IdType"] = "ISBN";
            }
            //else if (type == BarcodeType.Jan)
            else
            {
                requestParams["IdType"] = "EAN";
            }
            requestParams["SearchIndex"] = "All";

            string url = helper.Sign(requestParams);
            System.Diagnostics.Debug.WriteLine(url);

            System.Net.WebClient webc = new System.Net.WebClient();

            using (Stream st = webc.OpenRead(url))
            {
                if (st == null) { return false; }
                using (StreamReader sr = new StreamReader(st, Encoding.UTF8))
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(sr);

                    XmlNodeList xlist = xdoc.GetElementsByTagName("Title", @"http://webservices.amazon.com/AWSECommerceService/2009-11-01");

                    if (xlist.Count > 0)
                    {
                        XmlNode xtitle = xlist.Item(0);
                        ControlUtil.SafelyOperated(this, (MethodInvoker)delegate()
                        {
                            textbox.Text = xtitle.InnerText;
                        });
                        return true;
                    }
                }
            }

            ControlUtil.SafelyOperated(this, (MethodInvoker)delegate()
            {
                // cell.DataGridView[ColumnName.isbn, cell.RowIndex].Value = null;
            });

            return false;
        }

        #endregion








    }
}
