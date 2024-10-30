using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBl.Bl;
using StoreBl.Models;

namespace StoreProject
{
    public class UiHelper
    {
        /// <summary>
        /// show main option for program
        /// </summary>
        public static void MainOptions()
        {
            //Console.Clear();
            Console.WriteLine("Welcome to our store");
            Console.WriteLine("to manage stores press 1");
            Console.WriteLine("to manage items press 2");
            Console.WriteLine("to manage orders press 3");
            Console.WriteLine("to manage reports press 4");
            Console.WriteLine("to close the application press 0");
        }

        public static void StoreOptions()
        {
            string sStoreOption = string.Empty;
            while (sStoreOption != "0")
            {
                Console.WriteLine("Welcome to manage stores data");
                Console.WriteLine("to add stores press 1");
                Console.WriteLine("to get all stores press 2");
                Console.WriteLine("to delete store press 3");
                Console.WriteLine("to go back press 0");
                sStoreOption = Console.ReadLine();
                ClsStore oClsStore = new ClsStore();
                switch (sStoreOption)
                {
                    case "1":

                        StoreModel oStoreModel = new StoreModel();
                        Console.Clear();
                        //Console.WriteLine("please enter store id");
                        //int nStoreId = 0;
                        //bool bCanConverted = int.TryParse(Console.ReadLine(), out nStoreId);
                        //if (bCanConverted)
                        //    oStoreModel.StoreId = nStoreId;
                        //else
                        //{
                        //    Console.WriteLine("please enter a valid store id");
                        //    break;
                        //}

                        Console.WriteLine("please enter store name");
                        oStoreModel.StoreName = Console.ReadLine();


                        oClsStore.Add(oStoreModel);
                        break;
                    case "2":
                        Console.Clear();
                        List<StoreModel> lstStores = oClsStore.GetAll();

                        Console.WriteLine("*************************************");
                        foreach (var store in lstStores)
                        {
                            Console.WriteLine(string.Format("store id {0} store name {1}", store.StoreId, store.StoreName));
                            Console.WriteLine("-----------------------------------");
                        }
                        Console.WriteLine("*************************************");
                        break;
                    case "3":
                        Console.WriteLine("please enter store id");
                        int nStoreId = 0;
                        bool bCanConverted = int.TryParse(Console.ReadLine(), out nStoreId);
                        if (bCanConverted)
                        {
                            bool isDeleted = oClsStore.Delete(nStoreId);
                            if (!isDeleted)
                            {
                                Console.WriteLine("id not found in the file");
                            }
                        }
                        else
                            Console.WriteLine("please enter valid id");
                        break;
                }
            }

        }

        public static void ItemOptions()
        {
            string sItemOption = string.Empty;
            while (sItemOption != "0")
            {
                Console.WriteLine("Welcome to manage items data");
                Console.WriteLine("to add item press 1");
                Console.WriteLine("to get all items press 2");
                Console.WriteLine("to delete item press 3");
                Console.WriteLine("to go back press 0");
                sItemOption = Console.ReadLine();
                ClsItems oClsItem = new ClsItems();
                switch (sItemOption)
                {
                    case "1":

                        ItemModel oItemModel = new ItemModel();
                        Console.Clear();

                        Console.WriteLine("please enter item name");
                        oItemModel.ItemName = Console.ReadLine();

                        Console.WriteLine("please enter item price");
                        decimal dItemPrice = 0;
                        bool bCanConverted = decimal.TryParse(Console.ReadLine(), out dItemPrice);
                        if (bCanConverted)
                            oItemModel.ItemPrice = dItemPrice;
                        else
                            Console.WriteLine("please enter a valid price");

                        oClsItem.Add(oItemModel);
                        break;
                    case "2":
                        Console.Clear();
                        List<ItemModel> lstItems = oClsItem.GetAll();

                        Console.WriteLine("*************************************");
                        foreach (var item in lstItems)
                        {
                            Console.WriteLine(string.Format("item id {0} item name {1} item Price {2}", item.ItemId, item.ItemName, item.ItemPrice));
                            Console.WriteLine("-----------------------------------");
                        }
                        Console.WriteLine("*************************************");
                        break;
                    case "3":
                        Console.WriteLine("please enter store id");
                        int nItemId = 0;
                        bool bIsConverted = int.TryParse(Console.ReadLine(), out nItemId);
                        if (bIsConverted)
                        {
                            bool isDeleted = oClsItem.Delete(nItemId);
                            if (!isDeleted)
                            {
                                Console.WriteLine("id not found in the file");
                            }
                        }
                        else
                            Console.WriteLine("please enter valid id");
                        break;
                }
            }

        }

        public static void OrderOptions()
        {
            string sItemOption = string.Empty;
            while (sItemOption != "0")
            {
                #region Show Options
                Console.WriteLine("Welcome to manage orders data");
                Console.WriteLine("to add order press 1");
                Console.WriteLine("to get all order press 2");
                Console.WriteLine("to delete order press 3");
                Console.WriteLine("to go back press 0"); 
                #endregion

                sItemOption = Console.ReadLine();
                ClsOrders oClsOrders = new ClsOrders();
                int nOrderId = 0;
                bool bCanConverted = false;
                switch (sItemOption)
                {
                    #region Add
                    case "1":
                        OrderModel oOrderModel = new OrderModel();
                        Console.Clear();

                        Console.WriteLine("please enter item id");
                        bCanConverted = int.TryParse(Console.ReadLine(), out nOrderId);
                        if (bCanConverted)
                            oOrderModel.OrderItem.ItemId = nOrderId;
                        else
                            Console.WriteLine("please enter a valid item id");

                        Console.WriteLine("please enter store id");
                        int nStoreId = 0;
                        bCanConverted = int.TryParse(Console.ReadLine(), out nStoreId);
                        if (bCanConverted)
                            oOrderModel.OrderStore.StoreId = nStoreId;
                        else
                            Console.WriteLine("please enter a valid price");

                        oOrderModel.OrderDate = DateTime.Now;

                        oClsOrders.Add(oOrderModel);
                        break;
                    #endregion

                    #region Get All
                    case "2":
                        Console.Clear();
                        List<OrderModel> lstOrders = oClsOrders.GetAll();

                        Console.WriteLine("*************************************");
                        foreach (var order in lstOrders)
                        {
                            Console.WriteLine(string.Format("order id {0} order date {1} item id {2} store id {3}", order.OrderId, order.OrderDate, order.OrderItem.ItemId, order.OrderStore.StoreId));
                            Console.WriteLine("-----------------------------------");
                        }
                        Console.WriteLine("*************************************");
                        break;
                    #endregion

                    #region Delete
                    case "3":
                        Console.WriteLine("please enter store id");
                        nOrderId = 0;
                        bool bIsConverted = int.TryParse(Console.ReadLine(), out nOrderId);
                        if (bIsConverted)
                        {
                            bool isDeleted = oClsOrders.Delete(nOrderId);
                            if (!isDeleted)
                            {
                                Console.WriteLine("id not found in the file");
                            }
                        }
                        else
                            Console.WriteLine("please enter valid id");
                        break; 
                        #endregion
                }
            }

        }

        public static void ShowAllStores(List<StoreModel> lstStores)
        {
            Console.WriteLine("*************************************");
            foreach (var store in lstStores)
            {
                Console.WriteLine(string.Format("store id {0} store name {1}", store.StoreId, store.StoreName));
                Console.WriteLine("-----------------------------------");
            }
            Console.WriteLine("*************************************");
        }
    }
}
