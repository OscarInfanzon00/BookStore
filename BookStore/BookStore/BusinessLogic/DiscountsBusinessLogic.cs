using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic
{
    public class DiscountsBusinessLogic
    {
        public DiscountsDataAccess discountsDataAccess = new DiscountsDataAccess();

        public bool IsNumeric(string input)
        {
            return decimal.TryParse(input, out _);
        }
    }
}
