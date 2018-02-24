using System;
using System.Data;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace kaede3rd
{
    class Globals
    {

        public static IDbConnection ConnectionString;
        public static DbConfig Config;
        public const string seller_EXT = "9090";
        public const string seller_LAGACY = "9001";
        public const string seller_DONATE = "9002";

        public static System.Drawing.Printing.PageSettings pageSettings =
            new System.Drawing.Printing.PageSettings { Color = true };
        public static System.Drawing.Printing.PrinterSettings printerSettings
             = new System.Drawing.Printing.PrinterSettings();

        public static System.Drawing.Printing.PageSettings receipt_pageSettings
            = new System.Drawing.Printing.PageSettings { Color = false };
        public static System.Drawing.Printing.PrinterSettings receipt_printerSettings
            = new System.Drawing.Printing.PrinterSettings();

        public static bool ShowPrintDialog_AtTagPrint = true;

        public static bool isChugaku(string kumi)
        {
            if (kumi == "A" || kumi == "B" || kumi == "C") { return true; }
            return false;
        }

        public static int CalcAllPages(int itemCount, int itemPerPage)
        {
            double d = (double)itemCount / (double)itemPerPage;
            return (int)Math.Ceiling(d);
        }

        public static bool TryParseBarcode(string s, out int itemid)
        {
            if (s.Length == 8 && s.StartsWith(Globals.Config.barcodeplefix.ToString()))
            {
                char check = s[7];

                byte[] di = new byte[7];
                byte cdi;
                try
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (!char.IsDigit(s[i])) { throw new Exception(); }
                        di[i] = byte.Parse(s.Substring(i, 1));
                    }

                    if (!char.IsDigit(check)) { throw new Exception(); }
                    cdi = byte.Parse(check.ToString());

                    //CheckDigit
                    int c1 = (di[0] + di[2] + di[4] + di[6]) * 3 +
                            di[1] + di[3] + di[5];
                    int c2 = (10 - (c1 % 10)) % 10;

                    if (c2.ToString() != check.ToString())
                    {
                        throw new Exception();
                    }

                }
                catch
                {
                    itemid = 0;
                    return false;
                }

                itemid = int.Parse(s.Substring(2, 5));
                return true;
            }
            else
            {
                itemid = 0;
                return false;
            }
        }
        public static string getTimeString(DateTime? dt)
        {
            if (dt.HasValue)
            {
                return dt.Value.ToString("MM/dd HH:mm");
            }
            else
            {
                return "不明";
            }
        }

        public static string getSellerString(string receipt_seller, string receipt_seller_exname)
        {

            switch (receipt_seller)
            {
                case Globals.seller_EXT:
                    {
                        //TODO
                        /*if (this.External != null)
                        {
                            ret = this.External.getSellerString();
                        }
                        else
                        {
                            ret = "不明な外部者";
                        }*/
                        return receipt_seller_exname;
                    }

                case Globals.seller_LAGACY:
                    {
                        return "遺産";
                    }
                case Globals.seller_DONATE:
                    {
                        return "寄付";
                    }
                default:
                    if (receipt_seller.Substring(0, 1) == "9")
                    {
                        return "ERR: 不明";
                    }

                    return receipt_seller.Substring(0, 1) + "年" + receipt_seller.Substring(1, 1) + "組 " +
                        receipt_seller.Substring(2, 2) + "番 " + receipt_seller_exname;
            }

        }

        public static string getSellerSortKey(string receipt_seller, string receipt_seller_exname)
        {
            string sortKey;

            switch (receipt_seller)
            {
                case Globals.seller_EXT:
                    {
                        sortKey = "C" + receipt_seller_exname;
                        break;
                    }
                case Globals.seller_LAGACY:
                    {
                        sortKey = "E";
                        break;
                    }
                case Globals.seller_DONATE:
                    {
                        sortKey = "D";
                        break;
                    }
                default:
                    {
                        if (Globals.isChugaku(receipt_seller.Substring(1, 1)))
                        {
                            sortKey = "A" + receipt_seller;
                        }
                        else
                        {
                            sortKey = "B" + receipt_seller;
                        }
                        break;
                    }
            }

            return sortKey;

        }
    }


    public static class ControlUtil
    {
        public static object SafelyOperated(Control context, Delegate process)
        {
            return ControlUtil.SafelyOperated(context, process, null);
        }

        public static object SafelyOperated(Control context, Delegate process, params object[] args)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (process == null)
            {
                throw new ArgumentNullException("process");
            }

            if (!(context.IsHandleCreated))
            {
                return null;
            }
            if (context.InvokeRequired)
            {
                return context.Invoke(process, args);
            }
            else
            {
                return process.DynamicInvoke(args);
            }
        }
        public static void DGV_ExSelect(DataGridView dgv)
        {
            if (dgv == null) { throw new NullReferenceException(); }

            if (dgv.SelectedRows.Count == 0)
            {
                DataGridViewSelectedCellCollection cells = dgv.SelectedCells;
                for (int i = 0; i < cells.Count; i++)
                {
                    dgv.Rows[cells[i].RowIndex].Selected = true;
                }
            }
        }
    }
    public static class KaedeExMethods
    {
        public static string ToCSVString(this string str)
        {
            if (str == null) { return "\"\""; /* "" */ }
            return "\"" + str.Replace("\"", "\"\"") + "\"";
        }

    }
}

