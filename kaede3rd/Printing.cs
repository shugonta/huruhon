using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data.Linq;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Linq;

namespace kaede3rd
{

    public class ItemsPrintDocument : PrintUtils.MyPrintDocument
    {

        public static event EventHandler Printed_Tag_Changed;

        public static void PrintItems(List<int> items_id)
        {
            if (items_id == null) { throw new NullReferenceException("items"); }
            if (items_id.Count == 0) { return; }

            PrintDialog prid = new PrintDialog();
            prid.PrinterSettings = Globals.printerSettings;
            prid.UseEXDialog = true;

            if (Globals.ShowPrintDialog_AtTagPrint == true)
            {
                DialogResult pdres = prid.ShowDialog();
                if (pdres != DialogResult.OK) { return; }
            }



            System.Threading.Thread t = new System.Threading.Thread(
                (delegate()
            {
                DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
                List<item> items = new List<item>();
                foreach (int id in items_id)
                {
                    var q = from n in context.item
                            where n.item_id == id
                            select n;
                    foreach (var item in q)
                    {
                        items.Add(item);
                    }
                }
                prid.Document = new ItemsPrintDocument(items, Globals.pageSettings, Globals.printerSettings);
                prid.Document.EndPrint += (sender, e) =>
                {
                    //タグ印刷済みに変更
                    try
                    {
                        foreach (int id in items_id)
                        {
                            var item = context.item.Single(n => n.item_id == id);
                            item.item_tag_printed = true;
                        }

                        context.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (Printed_Tag_Changed != null)
                    {
                        Printed_Tag_Changed(null, null);
                    }
                    return;
                };
                prid.Document.Print();
            }));
            t.Start();


            /*
            PrintPreviewDialog pprediag = new PrintPreviewDialog();
            pprediag.Document = new ItemsPrintDocument(items, GlobalData.Instance.pageSettings, GlobalData.Instance.printerSettings);

            try
            {
                pprediag.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("印刷が実行できませんでした: " + e.ToString());
            }
            */
        }

        static void Document_EndPrint(object sender, PrintEventArgs e)
        {
            throw new NotImplementedException();
        }

        public class PrintItem
        {
            public item item_data;
            public long volumeNum; /* 0...分冊なし 1...分冊あり、1冊目 2以降...分冊あり、n冊目 */

            public PrintItem(item item_data, long volumenum)
            {
                this.item_data = item_data;
                this.volumeNum = volumenum;
            }
        }

        private readonly List<PrintItem> pitems;

        private const int cellwidth = 90; //mm
        private const int cellheight = 36; //mm

        private DotNetBarcode barcode;

        public ItemsPrintDocument(List<item> items, PageSettings pageSettings, PrinterSettings printerSettings)
            : base(pageSettings, printerSettings)
        {

            this.barcode = new DotNetBarcode(DotNetBarcode.Types.Jan8);
            this.barcode.PrintChar = false;
            this.barcode.AddChechDigit = true;

            //this.items = items;
            this.pitems = new List<PrintItem>();
            foreach (item i in items)
            {
                if (i.item_volumes.HasValue && i.item_volumes.Value >= 2)
                {
                    for (long vn = 1; vn <= i.item_volumes.Value; vn++)
                    {
                        this.pitems.Add(new PrintItem(i, vn));
                    }
                }
                else
                {
                    this.pitems.Add(new PrintItem(i, 0));
                }
            }

            this.BeginPrint += new PrintEventHandler(ItemsPrintDocument_BeginPrint);
            this.PrintPage += new PrintPageEventHandler(ItemsPrintDocument_PrintPage);
        }

        private int colpp;
        private int rowpp;

        private int count;

        void ItemsPrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            colpp = (int)((this.printArea.Width) / cellwidth);
            rowpp = (int)((this.printArea.Height) / cellheight);

            double allpages = Math.Ceiling((double)this.pitems.Count / (colpp * rowpp));

            this.DocumentName = Globals.Config.bumonnname + " 全 " + ((int)allpages).ToString() + " ページ";

            this.count = 0;

        }

        void ItemsPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Millimeter;

            Pen cellLine = new Pen(Color.Black, 0.2f);
            //縦線
            for (int i = 1; i <= colpp; i++)
            {
                g.DrawLine(cellLine, new Point(wmargin + cellwidth * i, hmargin + 0), new Point(wmargin + cellwidth * i, hmargin + (int)this.printArea.Height));
            }

            //横線
            for (int i = 1; i <= rowpp; i++)
            {
                g.DrawLine(cellLine, new Point(wmargin + 0, hmargin + cellheight * i), new Point(wmargin + (int)this.printArea.Width, hmargin + cellheight * i));
            }

            for (int tate = 0; tate < rowpp; tate++)
            {
                for (int yoko = 0; yoko < colpp; yoko++)
                {
                    this.DrawItem(this.pitems[count], e, wmargin + cellwidth * yoko, hmargin + cellheight * tate);

                    if (this.pitems.Count - 1 <= count)
                    {
                        e.HasMorePages = false;
                        return;
                    }
                    count++;
                }
            }


            e.HasMorePages = true;
        }


        /* volumeNum: 0...分冊なし 1...分冊あり、1冊目 2以降...分冊あり、n冊目 */
        private void DrawItem(PrintItem printit, PrintPageEventArgs e, int x, int y)
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);

            item it = printit.item_data;

            e.Graphics.Clip = new Region(new Rectangle(x, y, cellwidth, cellheight));
            Font fnt = new Font("MS Gothic", 3.5f, FontStyle.Regular, GraphicsUnit.Millimeter);


            //e.Graphics.DrawString("*-*-*-`-" + it.item_id.ToString("0000"), fnt, Brushes.Black, x + 2, y + 3.5f);
            Rectangle namerect = new Rectangle(x + 2, (int)(y + 3.5f + (5.25f) * 0), cellwidth - 2, 11);

            e.Graphics.DrawString("品名: " + it.item_name, fnt, Brushes.Black, namerect);
            // e.Graphics.DrawString("コメント: " + it.item_comment, fnt, Brushes.Black, x + 2, y + 3.5f + (5.25f) * 1);

            e.Graphics.DrawString("価格: " + it.item_tagprice.ToString("#,##0") + "円",
                fnt, Brushes.Black, x + 2, y + 3.5f + (5.25f) * 2);


            /*
            if (!it.item_tataki.HasValue)
            {
                e.Graphics.DrawString("値引: ？", fnt, new SolidBrush(Color.Cyan), x + 30, y + 3.5f + (5.25f) * 2);
            }
            else */
            if (it.item_return /*FIXME*/ == false)
            {
                e.Graphics.DrawString("値引: ○", fnt, Brushes.Black, x + 30, y + 3.5f + (5.25f) * 2);
            }
            else
            {
                e.Graphics.DrawString("値引: ×", fnt, new SolidBrush(Color.Magenta), x + 30, y + 3.5f + (5.25f) * 2);
            }

            if (it.item_supplement)
            {
                e.Graphics.DrawString("品番: " + it.item_id.ToString("00000"), fnt, new SolidBrush(Color.Magenta), x + 2, y + 3.5f + (5.25f) * 3 + 10.0f);
            }
            else
            {
                e.Graphics.DrawString("品番: " + it.item_id.ToString("00000"), fnt, Brushes.Black, x + 2, y + 3.5f + (5.25f) * 3 + 10.0f);
            }

            string s = "";
            string classname = (from n in context.receipt
                                where n.receipt_id == it.item_receipt_id
                                select n).First().receipt_seller;
            if (classname == Globals.seller_EXT)
            {
                s += "EX";
            }
            else if (classname == Globals.seller_LAGACY)
            {
                s += "LG";
            }
            else if (classname == Globals.seller_DONATE)
            {
                s += "DN";
            }
            else
            {
                string kumi = (from n in context.receipt
                               where n.receipt_id == it.item_receipt_id
                               select n).First().receipt_seller.Substring(1, 1);
                if (Globals.isChugaku(kumi)) { s += "C"; }
                else { s += "K"; }

                s += (from n in context.receipt
                      where n.receipt_id == it.item_receipt_id
                      select n).First().receipt_seller.Substring(0, 1);

            }


            s += it.item_receipt_id.ToString("'-R'0000");


            e.Graphics.DrawString(s, new Font("MS Gothic", 3.0f, FontStyle.Italic, GraphicsUnit.Millimeter),
                Brushes.Black, x + 30, y + 3.5f + (5.25f) * 3 + 10.0f + 0.4f);

            e.Graphics.DrawString(Globals.Config.companyname, new Font("MS Mincho", 2.2f, FontStyle.Regular, GraphicsUnit.Millimeter),
                new SolidBrush(Globals.Config.bumontextcolor), x + 46, y + 3.5f + (5.25f) * 3 + 10.9f);


            if (printit.volumeNum < 2)
            {

                int barcodesize = 0;
                if (printit.volumeNum == 1)
                {
                    e.Graphics.DrawString("分売不可 1 / " + it.item_volumes.ToString(), fnt, Brushes.Red, x + 50, y + 3.5f + (5.25f) * 2);
                    barcodesize = 10;
                }
                else
                {
                    barcodesize = 12;
                }

                //バーコード
                this.barcode.WriteBar(Globals.Config.barcodeplefix + it.item_id.ToString("00000"), x + 50, y + (29 - barcodesize), 25, barcodesize, e.Graphics);


                //販売価格
                Pen nedanPen = new Pen(Color.Black, 0.2f);
                nedanPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                nedanPen.DashOffset = 1.0f;
                e.Graphics.DrawLine(nedanPen, new PointF(x + 3.0f, y + 27.0f), new PointF(x + 35.0f, y + 27.0f));
                e.Graphics.DrawString("円", new Font("MS Gothic", 5.5f, FontStyle.Regular, GraphicsUnit.Millimeter),
                               Brushes.Black, x + 36.0f, y + 21.5f);
                e.Graphics.DrawString("販売価格", new Font("MS Gothic", 2.0f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Black, x + 3, y + 3.5f + (5.25f) * 3);
            }
            else
            {
                e.Graphics.DrawString("分売不可  " + printit.volumeNum.ToString() + " / " + it.item_volumes.ToString(),
                    new Font("MS Gothic", 5.5f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Red, x + 19.0f, y + 20.25f);
            }
        }
    }

    public class BoxTagPrintDocument : PrintUtils.MyPrintDocument
    {
        public static void PrintItems(List<int> box_id)
        {
            if (box_id == null) { throw new NullReferenceException("items"); }
            if (box_id.Count == 0) { return; }

            PrintDialog prid = new PrintDialog();
            prid.PrinterSettings = Globals.printerSettings;
            prid.UseEXDialog = true;

            if (Globals.ShowPrintDialog_AtTagPrint == true)
            {
                DialogResult pdres = prid.ShowDialog();
                if (pdres != DialogResult.OK) { return; }
            }



            System.Threading.Thread t = new System.Threading.Thread(
                (delegate()
                {
                    DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
                    List<box> boxes = new List<box>();
                    foreach (int id in box_id)
                    {
                        var q = from n in context.box
                                where n.box_id == id
                                select n;
                        foreach (var item in q)
                        {
                            boxes.Add(item);
                        }
                    }
                    prid.Document = new BoxTagPrintDocument(boxes, Globals.pageSettings, Globals.printerSettings);
                    prid.Document.Print();
                }));
            t.Start();


            /*
            PrintPreviewDialog pprediag = new PrintPreviewDialog();
            pprediag.Document = new ItemsPrintDocument(items, GlobalData.Instance.pageSettings, GlobalData.Instance.printerSettings);

            try
            {
                pprediag.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("印刷が実行できませんでした: " + e.ToString());
            }
            */
        }

        static void Document_EndPrint(object sender, PrintEventArgs e)
        {
            throw new NotImplementedException();
        }

        public class PrintItem
        {
            public box box_data;

            public PrintItem(box box_data)
            {
                this.box_data = box_data;
            }
        }

        private readonly List<PrintItem> pitems;

        private const int cellwidth = 90; //mm
        private const int cellheight = 36; //mm

        private DotNetBarcode barcode;

        public BoxTagPrintDocument(List<box> boxes, PageSettings pageSettings, PrinterSettings printerSettings)
            : base(pageSettings, printerSettings)
        {

            this.barcode = new DotNetBarcode(DotNetBarcode.Types.Jan8);
            this.barcode.PrintChar = false;
            this.barcode.AddChechDigit = true;

            //this.items = items;
            this.pitems = new List<PrintItem>();
            foreach (box i in boxes)
            {
                this.pitems.Add(new PrintItem(i));
            }

            this.BeginPrint += new PrintEventHandler(ItemsPrintDocument_BeginPrint);
            this.PrintPage += new PrintPageEventHandler(ItemsPrintDocument_PrintPage);
        }

        private int colpp;
        private int rowpp;

        private int count;

        void ItemsPrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            colpp = (int)((this.printArea.Width) / cellwidth);
            rowpp = (int)((this.printArea.Height) / cellheight);

            double allpages = Math.Ceiling((double)this.pitems.Count / (colpp * rowpp));

            this.DocumentName = Globals.Config.bumonnname + " 全 " + ((int)allpages).ToString() + " ページ";

            this.count = 0;

        }

        void ItemsPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Millimeter;

            Pen cellLine = new Pen(Color.Black, 0.2f);
            //縦線
            for (int i = 1; i <= colpp; i++)
            {
                g.DrawLine(cellLine, new Point(wmargin + cellwidth * i, hmargin + 0), new Point(wmargin + cellwidth * i, hmargin + (int)this.printArea.Height));
            }

            //横線
            for (int i = 1; i <= rowpp; i++)
            {
                g.DrawLine(cellLine, new Point(wmargin + 0, hmargin + cellheight * i), new Point(wmargin + (int)this.printArea.Width, hmargin + cellheight * i));
            }

            for (int tate = 0; tate < rowpp; tate++)
            {
                for (int yoko = 0; yoko < colpp; yoko++)
                {
                    this.DrawItem(this.pitems[count], e, wmargin + cellwidth * yoko, hmargin + cellheight * tate);

                    if (this.pitems.Count - 1 <= count)
                    {
                        e.HasMorePages = false;
                        return;
                    }
                    count++;
                }
            }


            e.HasMorePages = true;
        }


        private void DrawItem(PrintItem printit, PrintPageEventArgs e, int x, int y)
        {
            DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);

            box bx = printit.box_data;
            int bxprice = (from n in context.item
                           where n.item_box_id == bx.box_id
                           select n).Sum(m => m.item_sellprice_bag.Value);

            e.Graphics.Clip = new Region(new Rectangle(x, y, cellwidth, cellheight));
            Font fnt = new Font("MS Gothic", 3.5f, FontStyle.Regular, GraphicsUnit.Millimeter);


            //e.Graphics.DrawString("*-*-*-`-" + it.item_id.ToString("0000"), fnt, Brushes.Black, x + 2, y + 3.5f);
            Rectangle namerect = new Rectangle(x + 2, (int)(y + 3.5f + (5.25f) * 0), cellwidth - 2, 11);

            //箱名の[*]部分を抽出
            e.Graphics.DrawString("箱名: " + System.Text.RegularExpressions.Regex.Matches(bx.box_comment, @"\[(.*)\]")[0].Groups[1].Value, fnt, Brushes.Black, namerect);

            e.Graphics.DrawString("価格: " + bxprice.ToString("#,##0") + "円",
                fnt, Brushes.Black, x + 2, y + 3.5f + (5.25f) * 2);


            /*
            if (!it.item_tataki.HasValue)
            {
                e.Graphics.DrawString("値引: ？", fnt, new SolidBrush(Color.Cyan), x + 30, y + 3.5f + (5.25f) * 2);
            }
            else */

            e.Graphics.DrawString("箱番: " + bx.box_id.ToString("00000"), fnt, new SolidBrush(Color.Black), x + 2, y + 3.5f + (5.25f) * 3 + 10.0f);


            e.Graphics.DrawString(Globals.Config.companyname, new Font("MS Mincho", 2.2f, FontStyle.Regular, GraphicsUnit.Millimeter),
                new SolidBrush(Globals.Config.bumontextcolor), x + 46, y + 3.5f + (5.25f) * 3 + 10.9f);

            //バーコード
            int barcodesize = 12;
            this.barcode.WriteBar(Globals.Config.barcodeplefix + "9" + bx.box_id.ToString("0000"), x + 50, y + (29 - barcodesize), 25, barcodesize, e.Graphics);


            //販売価格
            Pen nedanPen = new Pen(Color.Black, 0.2f);
            nedanPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            nedanPen.DashOffset = 1.0f;
            e.Graphics.DrawLine(nedanPen, new PointF(x + 3.0f, y + 27.0f), new PointF(x + 35.0f, y + 27.0f));
            e.Graphics.DrawString("円", new Font("MS Gothic", 5.5f, FontStyle.Regular, GraphicsUnit.Millimeter),
                           Brushes.Black, x + 36.0f, y + 21.5f);
            e.Graphics.DrawString("販売価格", new Font("MS Gothic", 2.0f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Black, x + 3, y + 3.5f + (5.25f) * 3);
        }
    }

    public class ReceiptPrintDocument : PrintUtils.MyPrintDocument
    {
        DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);

        private readonly receipt receipt_data;
        private readonly List<item> items;


        private const int rowheight = 6; //mm
        private const float fontheight = 4f; //mm

        public ReceiptPrintDocument(int receiptid, PageSettings pageSettings, PrinterSettings printerSettings)
            : base(pageSettings, printerSettings)
        {
            receipt_data = (from n in context.receipt
                            where n.receipt_id == receiptid
                            select n).First();
            if (receipt_data == null) { throw new NullReferenceException("receipt"); }

            items = (from m in context.item
                     where m.item_receipt_id == receiptid
                     select m).ToList();

            this.BeginPrint += new PrintEventHandler(ReceiptPrintDocument_BeginPrint);
            this.PrintPage += new PrintPageEventHandler(ReceiptPrintDocument_PrintPage);
        }


        private int itemperpage = 1;
        private int allpages = 1;
        private int count = 0;
        private int pagecount = 1;

        private int tableWidth;

        void ReceiptPrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            if (items.Count() == 0) { e.Cancel = true; }
            itemperpage = (int)((this.printArea.Height - 80) / rowheight);
            allpages = Globals.CalcAllPages(items.Count(), itemperpage);

            tableWidth = ((int)this.printArea.Width - 10) - (wmargin + 30);

            this.DocumentName = Globals.Config.bumonnname + " 全 " + allpages.ToString() + " ページ";

            this.pagecount = 1;
            this.count = 0;
        }

        void ReceiptPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Millimeter;

            g.DrawString("出品票",
                new Font("MS Gothic", 8.0f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Black,
                new PointF(wmargin + 15, 7));

            g.DrawString("(" + Globals.Config.bumonnname + ") " + this.pagecount.ToString() + " / " + allpages.ToString() + " ページ",
                new Font("MS Gothic", 6.0f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Black,
                new PointF(wmargin + 15 + 35, 9));

            Font font = new Font("MS Gothic", fontheight, FontStyle.Regular, GraphicsUnit.Millimeter);

            g.DrawString("出品者: " + this.receipt_data.receipt_seller_exname,
                new Font("MS Gothic", 6.0f, FontStyle.Regular, GraphicsUnit.Millimeter)
                , Brushes.Black, new PointF(wmargin + 20, 20));

            g.DrawString(this.receipt_data.receipt_id.ToString("'R'0000"),
                new Font("MS Gothic", 10.0f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Black,
                new PointF(this.printArea.Width - 40, this.printArea.Height - 25)
            );

            Pen pline = new Pen(Color.Black, 0.1f);

            for (int i = 0; i <= itemperpage; i++)
            {
                int y = hmargin + 40 + rowheight * i;
                g.DrawLine(pline, new Point(wmargin + 30, y), new Point(wmargin + 30 + tableWidth, y));
            }

            Region infClip = g.Clip;

            for (int i = 0; i < itemperpage; i++)
            {
                item it = this.items[count];
                this.count++;

                int x = wmargin + 30;
                int y = hmargin + 40 + rowheight * i + 1;

                g.DrawString(String.Format("{0,2}", count) + ".", font, Brushes.Black, new PointF(x + 2, y));

                g.SetClip(new Rectangle(x + 10, y, tableWidth - 36 - 10, rowheight));
                g.DrawString(it.item_name, font, Brushes.Black, new PointF(x + 10, y));
                g.Clip = infClip;

                g.DrawString(it.item_tagprice.ToString("#,##0").PadLeft(6, ' ') + "円", font, Brushes.Black, new PointF(x + tableWidth - 34, y));
                if (it.item_return == true)
                {
                    g.DrawString("返品", font, Brushes.Black, new PointF(x + tableWidth - 14, y));
                }

                if (this.count >= this.items.Count)
                {
                    e.HasMorePages = false;
                    return;
                }
            }

            this.pagecount++;
            e.HasMorePages = true;
        }

    }

    public class BoxContainer
    {
        public List<item> Item { get; set; }
        public box Box { get; set; }
    }

    public class AllBoxPrintDocument : PrintUtils.MyPrintDocument
    {

        DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);

        private readonly List<BoxContainer> data;
        private readonly string genrename;
        private const int rowheight = 6; //mm
        private const float fontheight = 4f; //mm
        private int last_boxid;

        public AllBoxPrintDocument(int genreid, int id_from, int id_by, DateTime? date_from, DateTime? date_by, string searchtext, PageSettings pageSettings, PrinterSettings printerSettings)
            : base(pageSettings, printerSettings)
        {
            genrename = (from o in context.genre
                         where o.genre_id == genreid
                         select o).First().genre_name;
            List<item> items = new List<item>();
            if (date_from == null)
            {
                items = (from m in context.item
                         where m.item_genre == genreid
                         where m.item_id >= id_from && m.item_id <= id_by
                         orderby m.item_box_id ascending, m.item_name ascending
                         select m).ToList();
            }
            else
            {
                items = (from m in context.item
                         where m.item_genre == genreid
                         where m.item_id >= id_from && m.item_id <= id_by
                         where m.item_receipt_time.Value.Date >= date_from && m.item_receipt_time.Value.Date <= date_by
                         orderby m.item_box_id ascending, m.item_name ascending
                         select m).ToList();
            }


            System.Text.RegularExpressions.Regex searchTerm =
             new System.Text.RegularExpressions.Regex(searchtext, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            if (searchtext.Length > 0)
            {
                items = (from n in items
                         let matches = searchTerm.Matches(n.item_name)
                         where matches.Count > 0
                         select n).ToList();
            }
            //箱ごとに分ける
            int pbox = 0;
            int i = 0;
            data = new List<BoxContainer>();
            foreach (var q in items)
            {
                if (!q.item_box_id.HasValue) { }
                else
                {
                    if (pbox == 0)
                    {
                        var box = context.box.Single(n => n.box_id == q.item_box_id.Value);
                        data.Add(new BoxContainer { Box = box, Item = new List<item> { q } });
                        pbox = q.item_box_id.Value;
                    }
                    else if (pbox == q.item_box_id)
                    {
                        data[i].Item.Add(q);
                    }
                    else
                    {
                        var box = context.box.Single(n => n.box_id == q.item_box_id.Value);
                        data.Add(new BoxContainer { Box = box, Item = new List<item> { q } });
                        pbox = q.item_box_id.Value;
                        i++;
                    }
                }
            }
            last_boxid = pbox;

            this.BeginPrint += new PrintEventHandler(ReceiptPrintDocument_BeginPrint);
            this.PrintPage += new PrintPageEventHandler(ReceiptPrintDocument_PrintPage);

            /*
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            */
        }
        private int itemperpage = 1;
        private int allpages = 0;
        private int count = 0;
        private int pagecount = 1;

        private int tableWidth;
        private int boxcount = 0;
        void ReceiptPrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            if (data.Count() == 0) { e.Cancel = true; }
            itemperpage = (int)((this.printArea.Height - 80) / rowheight);
            foreach (var q in data)
            {
                allpages += Globals.CalcAllPages(q.Item.Count(), itemperpage);
            }
            tableWidth = ((int)this.printArea.Width - 10) - (wmargin + 30);

            this.DocumentName = Globals.Config.bumonnname + " 全 " + allpages.ToString() + " ページ";

            this.pagecount = 1;
            this.count = 0;
        }


        void ReceiptPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Millimeter;

            g.DrawString("箱内商品一覧",
                new Font("MS Gothic", 8.0f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Black,
                new PointF(wmargin + 15, 7));

            g.DrawString("(" + Globals.Config.bumonnname + ") " + this.pagecount.ToString() + " / " + allpages.ToString() + " ページ",
                new Font("MS Gothic", 6.0f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Black,
                new PointF(wmargin + 15 + 50, 9));

            Font font = new Font("MS Gothic", fontheight, FontStyle.Regular, GraphicsUnit.Millimeter);

            g.DrawString("ジャンル:" + this.genrename,
                new Font("MS Gothic", 6.0f, FontStyle.Regular, GraphicsUnit.Millimeter)
                , Brushes.Black, new PointF(wmargin + 20, 20));

            if (this.data[boxcount].Box.box_comment != null && this.data[boxcount].Box.box_comment.Length > 0)
            {
                g.DrawString("コメント:" + this.data[boxcount].Box.box_comment,
                    new Font("MS Gothic", 6.0f, FontStyle.Regular, GraphicsUnit.Millimeter)
                    , Brushes.Black, new PointF(wmargin + 20, 28));
            }
            g.DrawString("箱No." + this.data[boxcount].Box.box_id,
                new Font("MS Gothic", 10.0f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Black,
                new PointF(this.printArea.Width - 40, this.printArea.Height - 25)
            );

            Pen pline = new Pen(Color.Black, 0.1f);

            for (int i = 0; i <= itemperpage; i++)
            {
                int y = hmargin + 40 + rowheight * i;
                g.DrawLine(pline, new Point(wmargin + 30, y), new Point(wmargin + 30 + tableWidth, y));
            }

            Region infClip = g.Clip;

            for (int i = 0; i < Math.Min(this.data[boxcount].Item.Count, itemperpage); i++)
            {
                item it = this.data[boxcount].Item[count];
                this.count++;

                int x = wmargin + 30;
                int y = hmargin + 40 + rowheight * i + 1;

                g.DrawString(String.Format("{0,2}", count) + ".", font, Brushes.Black, new PointF(x + 2, y));

                g.SetClip(new Rectangle(x + 10, y, tableWidth - 36 - 10, rowheight));
                g.DrawString(it.item_name, font, Brushes.Black, new PointF(x + 10, y));
                g.Clip = infClip;

                g.DrawString(it.item_tagprice.ToString("#,##0").PadLeft(6, ' ') + "円", font, Brushes.Black, new PointF(x + tableWidth - 34, y));
                if (it.item_return == true)
                {
                    g.DrawString("返品", font, Brushes.Black, new PointF(x + tableWidth - 14, y));
                }

                if (this.count >= this.data[boxcount].Item.Count)
                {
                    if (this.data[boxcount].Box.box_id == last_boxid)
                    {
                        e.HasMorePages = false;
                        return;
                    }
                }
                if (this.data[boxcount].Item.Count == count)
                {
                    boxcount++;
                    count = 0;
                    break;
                }
            }
            this.pagecount++;
            e.HasMorePages = true;
        }

    }


    public class BoxPrintDocument : PrintUtils.MyPrintDocument
    {
        DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);

        private readonly box box_data;
        private readonly List<item> items;
        private readonly string genrename;

        private const int rowheight = 6; //mm
        private const float fontheight = 4f; //mm

        public BoxPrintDocument(int boxid, PageSettings pageSettings, PrinterSettings printerSettings)
            : base(pageSettings, printerSettings)
        {
            box_data = (from n in context.box
                        where n.box_id == boxid
                        select n).First();
            if (box_data == null) { throw new NullReferenceException("receipt"); }
            genrename = (from o in context.genre
                         where o.genre_id == box_data.box_genre
                         select o).First().genre_name;
            items = (from m in context.item
                     where m.item_box_id == boxid
                     select m).ToList();
            this.BeginPrint += new PrintEventHandler(ReceiptPrintDocument_BeginPrint);
            this.PrintPage += new PrintPageEventHandler(ReceiptPrintDocument_PrintPage);
        }

        private int itemperpage = 1;
        private int allpages = 1;
        private int count = 0;
        private int pagecount = 1;

        private int tableWidth;

        void ReceiptPrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            if (items.Count() == 0) { e.Cancel = true; }
            itemperpage = (int)((this.printArea.Height - 80) / rowheight);
            allpages = Globals.CalcAllPages(items.Count(), itemperpage);

            tableWidth = ((int)this.printArea.Width - 10) - (wmargin + 30);

            this.DocumentName = Globals.Config.bumonnname + " 全 " + allpages.ToString() + " ページ";

            this.pagecount = 1;
            this.count = 0;
        }


        void ReceiptPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Millimeter;

            g.DrawString("箱内商品一覧",
                new Font("MS Gothic", 8.0f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Black,
                new PointF(wmargin + 15, 7));

            g.DrawString("(" + Globals.Config.bumonnname + ") " + this.pagecount.ToString() + " / " + allpages.ToString() + " ページ",
                new Font("MS Gothic", 6.0f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Black,
                new PointF(wmargin + 15 + 50, 9));

            Font font = new Font("MS Gothic", fontheight, FontStyle.Regular, GraphicsUnit.Millimeter);

            g.DrawString("ジャンル:" + this.genrename,
                new Font("MS Gothic", 6.0f, FontStyle.Regular, GraphicsUnit.Millimeter)
                , Brushes.Black, new PointF(wmargin + 20, 20));

            if (this.box_data.box_comment != null && this.box_data.box_comment.Length > 0)
            {
                g.DrawString("コメント:" + this.box_data.box_comment,
                    new Font("MS Gothic", 6.0f, FontStyle.Regular, GraphicsUnit.Millimeter)
                    , Brushes.Black, new PointF(wmargin + 20, 28));
            }
            g.DrawString("箱No." + this.box_data.box_id,
                new Font("MS Gothic", 10.0f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Black,
                new PointF(this.printArea.Width - 40, this.printArea.Height - 25)
            );

            Pen pline = new Pen(Color.Black, 0.1f);

            for (int i = 0; i <= itemperpage; i++)
            {
                int y = hmargin + 40 + rowheight * i;
                g.DrawLine(pline, new Point(wmargin + 30, y), new Point(wmargin + 30 + tableWidth, y));
            }

            Region infClip = g.Clip;

            for (int i = 0; i < itemperpage; i++)
            {
                item it = this.items[count];
                this.count++;

                int x = wmargin + 30;
                int y = hmargin + 40 + rowheight * i + 1;

                g.DrawString(String.Format("{0,2}", count) + ".", font, Brushes.Black, new PointF(x + 2, y));

                g.SetClip(new Rectangle(x + 10, y, tableWidth - 36 - 10, rowheight));
                g.DrawString(it.item_name, font, Brushes.Black, new PointF(x + 10, y));
                g.Clip = infClip;

                g.DrawString(it.item_tagprice.ToString("#,##0").PadLeft(6, ' ') + "円", font, Brushes.Black, new PointF(x + tableWidth - 34, y));
                if (it.item_return == true)
                {
                    g.DrawString("返品", font, Brushes.Black, new PointF(x + tableWidth - 14, y));
                }

                if (this.count >= this.items.Count)
                {
                    e.HasMorePages = false;
                    return;
                }
            }

            this.pagecount++;
            e.HasMorePages = true;
        }

    }

    public class GenrePrintDocument : PrintUtils.MyPrintDocument
    {
        DBClassDataContext context = new DBClassDataContext(Globals.ConnectionString);
        private readonly List<item> items;
        private readonly string genrename;

        private const int rowheight = 6; //mm
        private const float fontheight = 4f; //mm

        public GenrePrintDocument(int genreid, PageSettings pageSettings, PrinterSettings printerSettings)
            : base(pageSettings, printerSettings)
        {
            genrename = (from o in context.genre
                         where o.genre_id == genreid
                         select o).First().genre_name;
            items = (from m in context.item
                     where m.item_genre == genreid
                     orderby m.item_name ascending
                     select m).ToList();
            this.BeginPrint += new PrintEventHandler(ReceiptPrintDocument_BeginPrint);
            this.PrintPage += new PrintPageEventHandler(ReceiptPrintDocument_PrintPage);
        }

        public GenrePrintDocument(int genreid, int id_from, int id_by, DateTime? date_from, DateTime? date_by, string searchtext, PageSettings pageSettings, PrinterSettings printerSettings)
            : base(pageSettings, printerSettings)
        {
            genrename = (from o in context.genre
                         where o.genre_id == genreid
                         select o).First().genre_name;
            if (date_from == null)
            {
                items = (from m in context.item
                         where m.item_genre == genreid
                         where m.item_id >= id_from && m.item_id <= id_by
                         orderby m.item_name ascending
                         select m).ToList();
            }
            else
            {
                items = (from m in context.item
                         where m.item_genre == genreid
                         where m.item_id >= id_from && m.item_id <= id_by
                         where m.item_receipt_time.Value.Date >= date_from && m.item_receipt_time.Value.Date <= date_by
                         orderby m.item_name ascending
                         select m).ToList();
            }

            try
            {
                System.Text.RegularExpressions.Regex searchTerm =
                 new System.Text.RegularExpressions.Regex(searchtext, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                if (searchtext.Length > 0)
                {
                    items = (from n in items
                             let matches = searchTerm.Matches(n.item_name)
                             where matches.Count > 0
                             select n).ToList();
                }

                this.BeginPrint += new PrintEventHandler(ReceiptPrintDocument_BeginPrint);
                this.PrintPage += new PrintPageEventHandler(ReceiptPrintDocument_PrintPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }


        private int itemperpage = 1;
        private int allpages = 1;
        private int count = 0;
        private int pagecount = 1;

        private int tableWidth;

        void ReceiptPrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            if (items.Count() == 0) { e.Cancel = true; }
            itemperpage = (int)((this.printArea.Height - 80) / rowheight);
            allpages = Globals.CalcAllPages(items.Count(), itemperpage);

            tableWidth = ((int)this.printArea.Width - 10) - (wmargin + 30);

            this.DocumentName = Globals.Config.bumonnname + " 全 " + allpages.ToString() + " ページ";

            this.pagecount = 1;
            this.count = 0;
        }

        void ReceiptPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Millimeter;

            g.DrawString("箱内商品一覧",
                new Font("MS Gothic", 8.0f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Black,
                new PointF(wmargin + 15, 7));

            g.DrawString("(" + Globals.Config.bumonnname + ") " + this.pagecount.ToString() + " / " + allpages.ToString() + " ページ",
                new Font("MS Gothic", 6.0f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Black,
                new PointF(wmargin + 15 + 50, 9));

            Font font = new Font("MS Gothic", fontheight, FontStyle.Regular, GraphicsUnit.Millimeter);

            g.DrawString("ジャンル:" + this.genrename,
                new Font("MS Gothic", 6.0f, FontStyle.Regular, GraphicsUnit.Millimeter)
                , Brushes.Black, new PointF(wmargin + 20, 20));

            Pen pline = new Pen(Color.Black, 0.1f);

            for (int i = 0; i <= itemperpage; i++)
            {
                int y = hmargin + 40 + rowheight * i;
                g.DrawLine(pline, new Point(wmargin + 30, y), new Point(wmargin + 30 + tableWidth, y));
            }

            Region infClip = g.Clip;

            for (int i = 0; i < itemperpage; i++)
            {
                item it = this.items[count];
                this.count++;

                int x = wmargin + 30;
                int y = hmargin + 40 + rowheight * i + 1;

                g.DrawString(String.Format("{0,2}", count) + ".", font, Brushes.Black, new PointF(x + 2, y));

                g.SetClip(new Rectangle(x + 10, y, tableWidth - 43 - 10, rowheight));
                g.DrawString(it.item_name, font, Brushes.Black, new PointF(x + 10, y));
                g.Clip = infClip;

                g.DrawString(it.item_tagprice.ToString("#,##0").PadLeft(6, ' ') + "円", font, Brushes.Black, new PointF(x + tableWidth - 42, y));
                g.DrawString("箱" + it.item_box_id.ToString(), font, Brushes.Black, new PointF(x + tableWidth - 23, y));
                if (it.item_return == true)
                {
                    g.DrawString("返品", font, Brushes.Black, new PointF(x + tableWidth - 12, y));
                }

                if (this.count >= this.items.Count)
                {
                    e.HasMorePages = false;
                    return;
                }
            }

            this.pagecount++;
            e.HasMorePages = true;
        }

    }

    
    public class ReturnListPrintDocument : PrintUtils.MyPrintDocument
    {
        public enum PrintType
        {
            Return, Meisai, MeisaiWithoutReturn
        };

        public enum SortType
        {
            None, SellPriceDesc, ItemId
        };

        private List<IGrouping<string, item>> list;

        private const int rowheight = 6; //mm
        private const float fontheight = 4f; //mm

        private readonly PrintType printType;
        private readonly string printTypeStr;
        private readonly SortType sortType;

        public ReturnListPrintDocument(List<IGrouping<string, item>> list, PageSettings pageSettings, PrinterSettings printerSettings,
            PrintType type, SortType sort)
            : base(pageSettings, printerSettings)
        {
            this.printType = type;

            if (list == null) { throw new NullReferenceException("list"); }
            this.list = list;

            if (this.printType == PrintType.Meisai || this.printType == PrintType.MeisaiWithoutReturn)
            {
                this.printTypeStr = "明細書";
            }
            else if (this.printType == PrintType.Return)
            {
                this.printTypeStr = "返品リスト";
            }

            this.sortType = sort;

            this.BeginPrint += new PrintEventHandler(ReturnListPrintDocument_BeginPrint);
            this.PrintPage += new PrintPageEventHandler(ReturnListPrintDocument_PrintPage);
        }


        private List<item> curGrpItems = null;

        private int itemPerPage;
        private int tableWidth;

        private int grpPointer = -1;
        private int itemInGrpPointer;
        private int pageInGrpCount = 1;
        private int allPageCount = 0;


        void ReturnListPrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            if (list.Count == 0) { e.Cancel = true; }
            itemPerPage = (int)((this.printArea.Height - 44) / rowheight);
            tableWidth = ((int)this.printArea.Width - 10) - (wmargin + 10);

            this.DocumentName = Globals.Config.bumonnname + " " + this.printTypeStr;

            this.allPageCount = 0;
            this.grpPointer = -1;
            this.curGrpItems = null;

            if (this.prepareNewPage() == false)
            {
                e.Cancel = true;
            }
        }

        //return: HasMorePage
        bool prepareNewPage()
        {
            if (this.curGrpItems == null)
            {
                this.grpPointer++;
                if (this.grpPointer >= this.list.Count)
                {
                    return false;
                }

                IEnumerable<item> itemEnum;
                if (this.printType == PrintType.Meisai)
                {
                    itemEnum = (from i in this.list[grpPointer] select i).ToList();
                }
                else if (this.printType == PrintType.Return)
                {
                    itemEnum = (from i in this.list[grpPointer] where i.item_sellprice.HasValue == false select i).ToList();
                }
                else if (this.printType == PrintType.MeisaiWithoutReturn)
                {
                    itemEnum = (from i in this.list[grpPointer] where i.item_sellprice.HasValue == true select i).ToList();
                }
                else
                {
                    throw new InvalidOperationException();
                }

                if (this.sortType == SortType.ItemId)
                {
                    this.curGrpItems = itemEnum.OrderBy(it => it.item_id).ToList();
                }
                else if (this.sortType == SortType.SellPriceDesc)
                {
                    this.curGrpItems = itemEnum.OrderByDescending(it => it.item_sellprice).ToList();
                }
                else
                {
                    this.curGrpItems = itemEnum.ToList();
                }


                if (this.curGrpItems.Count == 0)
                {
                    this.curGrpItems = null;
                    return this.prepareNewPage();
                }

                this.itemInGrpPointer = -1;
                this.pageInGrpCount = 1;

            }
            else
            {
                this.pageInGrpCount++;
            }

            this.allPageCount++;
            return true;
        }

        void ReturnListPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Millimeter;

            g.DrawString(this.printTypeStr,
                new Font("MS Gothic", 8.0f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Black,
                new PointF(wmargin + 15, 7));

            g.DrawString("(" + Globals.Config.bumonnname + ") " + this.pageInGrpCount.ToString() + " / " +
                Globals.CalcAllPages(this.curGrpItems.Count, this.itemPerPage).ToString() + " ページ",
                new Font("MS Gothic", 6.0f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Black,
                new PointF(wmargin + 15 + 48, 9));

            Font font = new Font("MS Gothic", fontheight, FontStyle.Regular, GraphicsUnit.Millimeter);

            g.DrawString("出品者: " + this.list[grpPointer].Key,
                new Font("MS Gothic", 6.0f, FontStyle.Regular, GraphicsUnit.Millimeter)
                , Brushes.Black, new PointF(wmargin + 20, 20));

            
            g.DrawString(this.curGrpItems.First().item_receipt_id.ToString("'R'0000"),
                new Font("MS Gothic", 10.0f, FontStyle.Regular, GraphicsUnit.Millimeter), Brushes.Black,
                new PointF(this.printArea.Width - 40, this.printArea.Height - 10)
            );
            

            if (this.printType == PrintType.Meisai || this.printType == PrintType.MeisaiWithoutReturn)
            {
                g.DrawString("売価", font, Brushes.Black, new PointF(wmargin + 18 + tableWidth - 30, hmargin + 25));
            }
            else if (this.printType == PrintType.Return)
            {
                g.DrawString("定価", font, Brushes.Black, new PointF(wmargin + 18 + tableWidth - 30, hmargin + 25));
            }
            Pen pline = new Pen(Color.Black, 0.1f);
            g.DrawLine(pline, new Point(wmargin + 10, hmargin + 30), new Point(wmargin + 10 + tableWidth, hmargin + 30));

            Region infClip = g.Clip;

            int receiptId = 0;
            for (int i = 0; i < this.itemPerPage; i++)
            {
                this.itemInGrpPointer++;
                item it = this.curGrpItems[this.itemInGrpPointer];

                int x = wmargin + 18;
                int y = hmargin + 30 + rowheight * i + 1;

                g.DrawString(String.Format("{0,2}", this.itemInGrpPointer + 1) + ".", font, Brushes.Black, new PointF(x + 1, y));
                if (receiptId != it.item_receipt_id)
                {
                    g.DrawString("R" + it.item_receipt_id.ToString("0000"),
                        new Font("MS Gothic", fontheight, FontStyle.Italic, GraphicsUnit.Millimeter), Brushes.Black, new PointF(x + 10, y));
                }
                g.DrawString(it.item_id.ToString("00000"), font, Brushes.Black, new PointF(x + 25, y));


                g.SetClip(new Rectangle(x + 38, y, tableWidth - 36 - 36, rowheight));
                g.DrawString(it.item_name, font, Brushes.Black, new PointF(x + 38, y));
                g.Clip = infClip;

                if (this.printType == PrintType.Meisai || this.printType == PrintType.MeisaiWithoutReturn)
                {
                    if (it.item_sellprice.HasValue)
                    {
                        g.DrawString(it.item_sellprice.Value.ToString("#,##0").PadLeft(6, ' ') + "円", font, Brushes.Black, new PointF(x + tableWidth - 34, y));
                    }
                    else
                    {
                        g.DrawString("未売", font, Brushes.Black, new PointF(x + tableWidth - 30, y));
                    }
                }
                else if (this.printType == PrintType.Return)
                {
                    g.DrawString(it.item_tagprice.ToString("#,##0").PadLeft(6, ' ') + "円", font, Brushes.Black, new PointF(x + tableWidth - 34, y));
                }

                if (it.item_return == true)
                {
                    g.DrawString("返品", font, Brushes.Black, new PointF(x + tableWidth - 17, y));
                }



                g.DrawLine(pline, new Point(wmargin + 10, y + rowheight - 1), new Point(wmargin + 10 + tableWidth, y + rowheight - 1));

                receiptId = it.item_receipt_id;

                if (this.itemInGrpPointer + 1 >= this.curGrpItems.Count())
                {
                    if (this.printType == PrintType.Meisai || this.printType == PrintType.MeisaiWithoutReturn)
                    {
                        long sum = this.curGrpItems.Sum(_it => (long)(_it.item_sellprice ?? 0));
                        g.DrawString("合計金額 " + sum.ToString("#,##0") + "円", font,
                            Brushes.Black, new PointF(x + 10, hmargin + 30 + rowheight * (i + 1) + 1));
                    }

                    this.curGrpItems = null;
                    break;
                }
            }

            e.HasMorePages = this.prepareNewPage();
        }

    }
}
