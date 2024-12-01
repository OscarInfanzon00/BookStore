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
        private string zip;

        public Stores(string stor_name, string stor_address, string city, string state, string zip)
        {
            this.stor_name = stor_name;
            this.stor_address = stor_address;
            this.city = city;
            this.state = state;
            this.zip = zip;
        }
        public string StorId
        {
            get { return stor_id; }
            set { stor_id = value; }
        }

        public string StorName
        {
            get { return stor_name; }
            set { stor_name = value; }
        }

        public string StorAddress
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
        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }
    }
}