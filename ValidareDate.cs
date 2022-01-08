using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace ARA
{
    public class StringNoEmpty : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str = value.ToString();
            if (str == "")
                return new ValidationResult(false, "Necesita completare !");
            return new ValidationResult(true, null);
        }
    }
    public class MinLen : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string cuv = value.ToString();

            if (cuv.Length < 4)
                return new ValidationResult(false, "Trebuie minim 4 caractere !");
            return new ValidationResult(true, null);
        }
    }
    public class MinCnp : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int cnp = value.GetHashCode();
            if (cnp != 9)
            {
                return new ValidationResult(false, "CNP-ul trebuie sa contina 9 cifre, fiind excluse ultimele 4");
            }
            return new ValidationResult(true, null);    
        }
    }
}
