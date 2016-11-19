using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiometricsManager
{
    public static class digitsProcessor
    {
        public static List<int> getRandomDigits()
        {
            int length = 5;

            var result = new List<int>();

            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Add(rnd.Next(10));
            }

            return result;
        }

        public static List<string> digitHumanizer(List<int> digits)
        {
            var result = new List<string>();

            foreach(var digit in digits)
            {
                switch(digit)
                {
                    case 0:
                        result.Add("ноль");
                        break;
                    case 1:
                        result.Add("один");
                        break;
                    case 2:
                        result.Add("два");
                        break;
                    case 3:
                        result.Add("три");
                        break;
                    case 4:
                        result.Add("четыре");
                        break;
                    case 5:
                        result.Add("пять");
                        break;
                    case 6:
                        result.Add("шесть");
                        break;
                    case 7:
                        result.Add("семь");
                        break;
                    case 8:
                        result.Add("восемь");
                        break;
                    case 9:
                        result.Add("девять");
                        break;
                }
            }

            return result;
        }
    }
}
