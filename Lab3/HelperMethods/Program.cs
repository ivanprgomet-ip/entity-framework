using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperMethods
{
    /// <summary>
    /// 3.1	HelperMethods 
    /// 3.2 ExtensionMethods
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //helper class
            Console.WriteLine("Ange ett tal: ");
            float f = HelperClass.StringToFloat(Console.ReadLine());
            Console.WriteLine($"{f} * 12 = {f * 12}");

            //extension method
            Console.WriteLine("Ange ett tal: ");
            float f2 = Console.ReadLine().ToFloat();
            Console.WriteLine($"{f2} * 12 = {f2 * 12}");

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
    public static class StringExtensions
    {
        public static float ToFloat(this string str)
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
