using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Classes
{
    public class Author
    {
        private string au_id;
        private string au_lname;
        private string au_fname;
        private string phone;
        private string address;
        private string city;
        private string state;
        private string zip;
        private bool contract;

        public Author(string au_lname, string au_fname, string phone, string address, string city, string state, string zip, bool contract)
        {
            this.au_lname = au_lname;
            this.au_fname = au_fname;
            this.phone = phone;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.contract = contract;
        }

        public string AuId
        {
            get { return au_id; }
            set { au_id = value; }
        }

        public string AuLname
        {
            get { return au_lname; }
            set { au_lname = value; }
        }

        public string AuFname
        {
            get { return au_fname; }
            set { au_fname = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
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

        public bool Contract
        {
            get { return contract; }
            set { contract = value; }
        }
    }
}
