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
    public partial class BoxItemShow : ItemsShow
    {
        private int boxid;
        public BoxItemShow(int box_id)
            : base(false)
        {
            this.boxid = box_id;
            itemList = RefreshList();
            this.itemsGridView1.Load(RefreshList());
        }

        public override List<item> RefreshList()
        {
            return (from n in new DBClassDataContext(Globals.ConnectionString).item
                    where n.item_box_id == boxid
                    select n).ToList();
        }

    }


}
