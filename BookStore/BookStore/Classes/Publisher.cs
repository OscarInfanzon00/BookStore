using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Classes
{
    public class Publisher
    {
        private string pub_id;
        private string pub_name;
        private string city;
        private string state;
        private string country;

        public Publisher(string pub_name, string city, string state, string country)
        {
            this.pub_name = pub_name;
            this.city = city;
            this.state = state;
            this.country = country;
        }

        public string PubId
        {
            get { return pub_id; }
            set { pub_id = value; }
        }

        public string PubName
        {
            get { return pub_name; }
            set { pub_name = value; }
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

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
    }
}
