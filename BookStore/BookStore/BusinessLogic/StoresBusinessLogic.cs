using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic
{
    public class StoresBusinessLogic
    {
        public StoresDataAccess storesDataAccess = new StoresDataAccess();

        public bool IsValidZipCode(string zipCode)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(zipCode, @"^\d{5}(-\d{4})?$");
        }

    }
}
