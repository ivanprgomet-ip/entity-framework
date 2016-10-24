using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ange ett tal: ");
            float f = HelperClass.StringToFloat(Console.ReadLine());
            Console.WriteLine($"{f} * 12 = {f * 12}");
        }
    }
    public static class HelperClass
    {

        public static float StringToFloat(string str)
        {
            float output;
            bool isString = float.TryParse(str, out output);
            if (isString)
                return output;
            else
                return 0;
        }
    }
}
