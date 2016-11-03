using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EFlib;
using EFlib.BLL;

namespace ConsoleGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Initializer.InitializeDatabase();
        }
    }
}
