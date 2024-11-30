using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace BookStore
{
    public class Employees
    {
        private string emp_id;
        private string fname;
        private string minit;
        private string lname;
        private short job_id;
        private short job_lvl;
        private char pub_Id;
        private DateTime hire_date;


        // Constructor
    public Employees(string emp_id, string fname, string minit, string lname, short job_id, short job_lvl, char pub_Id, DateTime hire_date)
        {
            this.emp_id = emp_id;
            this.fname = fname;
            this.minit = minit;
            this.lname = lname;
            this.job_id = job_id;
            this.job_lvl = job_lvl;
            this.pub_Id = pub_Id;
            this.hire_date = hire_date;
        }

        // Getters and Setters
        public string Emp_id
        {
            get { return emp_id; }
            set { emp_id = value; }
        }
        public string Fname
        {
            get { return fname; }
            set { fname = value; }
        }
        public string Minit
        {
            get { return minit; }
            set { minit = value; }
        }
        public string Lname
        {
            get { return lname; }
            set { lname = value; }
        }
        public short Job_id
        {
            get { return job_id; }
            set { job_id = value; }
        }
        public short Job_lvl
        {
            get { return job_lvl; }
            set { job_lvl = value; }
        }
        public char Pub_Id
        {
            get { return pub_Id; }
            set { pub_Id = value; }
        }
        public DateTime Hire_date
        {
            get { return hire_date; }
            set { hire_date = value; }
        }
    }
}
