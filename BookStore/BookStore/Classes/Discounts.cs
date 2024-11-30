using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace BookStore.Classes
{
    internal class Discounts
    {
        private string discounttype;
        private char stor_id;
        private short lowqty;
        private short highqty;
        private decimal discount;

        // Constructor
        public Discounts(string discounttype, char stor_id, short lowqty, short highqty, decimal discount)
        {
            this.discounttype = discounttype;
            this.stor_id = stor_id;
            this.lowqty = lowqty;
            this.highqty = highqty;
            this.discount = discount;
        }

        // Getters and Setters
        public string Discounttype
        {
            get { return discounttype; }
            set { discounttype = value; }
        }
        public char Stor_id
        {
            get { return stor_id; }
            set { stor_id = value; }
        }
        public short Lowqty
        {
            get { return lowqty; }
            set { lowqty = value; }
        }
        public short Highqty
        {
            get { return highqty; }
            set { highqty = value; }
        }
        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }
    }
}
