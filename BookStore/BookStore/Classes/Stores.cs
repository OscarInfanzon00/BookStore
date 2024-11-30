using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace BookStore
{
    public class Stores
    {
        private string stor_id;
        private string stor_name;
        private string stor_address;
        private string city;
        private string state;
        private short zip;

        // Constructor
        public Stores(string stor_id, DateTime ord_date, short qty, string payterms, string title_id)
        {
            this.stor_id = stor_id;
            this.stor_name = stor_name;
            this.stor_address = stor_address;
            this.city = city;
            this.state = state;
	    this.zip = zip;
        }

        // Getters and Setters
        public string Storid
        {
            get { return stor_id; }
            set { stor_id = value; }
        }

        public string Stor_name
        {
            get { return stor_name; }
            set { stor_name = value; }
        }

        public string Stor_address
        {
            get { return stor_address; }
            set { stor_address = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public short Zip
        {
            get { return zip; }
            set { zip = value; }
        }
    }
}