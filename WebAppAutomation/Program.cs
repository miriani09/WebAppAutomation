using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace WebAppAutomation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TheInternet internet = new TheInternet();
            internet.startBrowser();
            internet.openBrowser();
            Console.WriteLine("browser started");

            //Task1
            internet.fileUpload();

            //Task2



            internet.closeBrowser();
        }
    }
}
