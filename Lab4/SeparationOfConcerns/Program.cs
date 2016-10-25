using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeparationOfConcerns
{
    class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();

            while(app.isRunning)
            {
                app.Run();
            }
        }
    }
}
