using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3
{
    class Program
    {
       

        public static void Main(string[] args)
        {
            TuDien dic = new TuDien();
            
            Application.Run(dic);
            Console.ReadKey();

        }
    }
}
