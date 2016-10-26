using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud
{
    /// <summary>
    /// why was the Authors in the AuthorsContext null?
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
           
            UI ui = new UI();
            while (ui.Run())
            {
                ui.Run();
            }
        }
    }

}
