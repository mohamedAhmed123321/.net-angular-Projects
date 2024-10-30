using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBl.Bl;
namespace StoreProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string sOption = string.Empty;
            while (sOption!="0")
            {
                UiHelper.MainOptions();
                sOption = Console.ReadLine();
                switch(sOption)
                {
                    case "1":
                        Console.Clear();
                        UiHelper.StoreOptions();
                        break;
                    case "2":
                        Console.Clear();
                        UiHelper.ItemOptions();
                        break;
                    case "3":
                        Console.Clear();
                        UiHelper.OrderOptions();
                        break;
                    case "4":
                        break;
                }
                Console.Clear();
            }

            Console.ReadKey();
        }
    }
}
