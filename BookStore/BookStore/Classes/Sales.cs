using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace BookStore
{
    public class Sales
    {
        private string stor_id;
        private string ord_num;
        private DateTime ord_date;
        private short qty;
        private string payterms;
        private string title_id;

        // Constructor
        public Sales(string stor_id, DateTime ord_date, short qty, string payterms, string title_id)
        {
            this.stor_id = stor_id;
            this.ord_date = ord_date;
            this.qty = qty;
            this.payterms = payterms;
            this.title_id = title_id;
        }

        // Getters and Setters
        public string StorId
        {
            get { return stor_id; }
            set { stor_id = value; }
        }

        public string OrdNum
        {
            get { return ord_num; }
            set { ord_num = value; }
        }

        public DateTime OrdDate
        {
            get { return ord_date; }
            set { ord_date = value; }
        }

        public short Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        public string Payterms
        {
            get { return payterms; }
            set { payterms = value; }
        }

        public string TitleId
        {
            get { return title_id; }
            set { title_id = value; }
        }
    }
}
