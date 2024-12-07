using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business
{
    public class TitleBusinessLogic
    {
        public TitleDataAccess titleDataAccess = new TitleDataAccess();

        public bool ValidateNumericField(string inputText, string fieldName, StringBuilder errorMessage)
        {
            if (string.IsNullOrWhiteSpace(inputText) || !decimal.TryParse(inputText, out decimal result) || result < 0)
            {
                errorMessage.AppendLine($"{fieldName} must be a valid positive number.");
                return false;
            }
            return true;
        }


    }
}
