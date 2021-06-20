using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.DTO
{
    public class Currency
    {
        double USADollar = 23000;
        double Russian = 315.94;
        double chinese = 3564.18;
        double Korean = 20.26;
        double bath = 731.46;
        double japanese = 208.65;
        private static Currency instance;

        public static Currency Instance {
            get
            {
                if (instance == null) instance = new Currency();
                return Currency.instance;
            }
            private set { Currency.instance = value; }
        }
        public string CurrencyConvert(string type, double amount)
        {
            double result = 0;
            switch (type)
            {
                case "USA":
                    {
                        result = amount / USADollar;
                        break;
                    }
                case "Russian":
                    {
                        result = amount / Russian;
                        break;
                    }
                case "Chinese":
                    {
                        result = amount / chinese;
                        break;
                    }
                case "Thailand":
                    {
                        result = amount / bath;
                        break;
                    }
                case "Japanese":
                    {
                        result = amount / japanese;
                        break;
                    }
                case "Korean":
                    {
                        result = amount / Korean;
                        break;
                    }
                default:
                    break;
            }
            return result.ToString();
        }
    }
}
