using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace BookStore
{
    public class Titles
    {
        private string title_id;
        private string title;
        private string type;
        private char pub_id;
        private int price;
        private int advance;
        private int royalty;
        private int ytd_sales;
        private string notes;
        private DateTime pubdate;


        
    public Titles(string title_id, string title, string type, char pub_id, int price, int advance, int royalty, int ytd_sales, string notes, DateTime pubdate)
        {
            this.title_id = title_id;
            this.title = title;
            this.type = type;
            this.pub_id = pub_id;
            this.price = price;
            this.advance = advance;
            this.royalty = royalty;
            this.ytd_sales = ytd_sales;
            this.notes = notes;
	    this.pubdate = pubdate;
        }

        // Getters and Setters
        public string Title_id
        {
            get { return title_id; }
            set { title_id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = type; }
        }
        public char Pub_id
        {
            get { return pub_id; }
            set { pub_id = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Advance
        {
            get { return advance; }
            set { advance = value; }
        }
        public int Royalty
        {
            get { return royalty; }
            set { royalty = value; }
        }
        public int Ytd_sales
        {
            get { return ytd_sales; }
            set { ytd_sales = value; }
        }
	public string Notes
        {
            get{ return notes; }
	    set{ notes = value; }
        }
	public DateTime Pubdate
        {
             get{ return pubdate; }
	     set{ pubdate = value; }
        }
    }
}