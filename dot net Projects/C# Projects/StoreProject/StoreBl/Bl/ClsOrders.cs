using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBl.Dal;
using StoreBl.Models;

namespace StoreBl.Bl
{
    public class ClsOrders : IBusinessLayer<OrderModel>
    {
        public bool Add(OrderModel table)
        {
            List<OrderModel> lstOrders = GetAll();
            int nOrderId = 0;
            if (lstOrders.Count == 0)
                nOrderId = 1;
            else
            {
                nOrderId = lstOrders.Max(a => a.OrderId) + 1;
            }
            string itemData = string.Format("-{0}#{1}#{2}#{3}", nOrderId, table.OrderDate, table.OrderItem.ItemId,table.OrderStore.StoreId);
            IDataAccess myDataAccess = DataAccessHelper.CreateObject();
            myDataAccess.Insert(FileNames.orders.ToString() + ".txt", itemData);
            return true;
        }

        public bool Delete(int id)
        {
            List<OrderModel> lstOrders = GetAll();
            OrderModel model = lstOrders.Where(x => x.OrderId == id).FirstOrDefault();
            if (model == null)
                return false;
            else
            {
                lstOrders.Remove(model);
                string sFileData = string.Empty;
                int nCount = 0;
                foreach (var order in lstOrders)
                {
                    if (nCount == 0)
                        sFileData += string.Format("{0}#{1}#{2}#{3}", order.OrderId, order.OrderDate, order.OrderItem.ItemId,order.OrderStore.StoreId);
                    else
                        sFileData += string.Format("-{0}#{1}#{2}#{3}", order.OrderId, order.OrderDate, order.OrderItem.ItemId, order.OrderStore.StoreId);
                    nCount++;
                }
                IDataAccess myDataAccess = DataAccessHelper.CreateObject();
                myDataAccess.Delete(FileNames.orders.ToString() + ".txt", sFileData);
                return true;
            }
        }

        public List<OrderModel> GetAll()
        {
            IDataAccess myDataAccess = DataAccessHelper.CreateObject();
            string orderList = myDataAccess.GetAll(FileNames.orders.ToString() + ".txt");
            string[] Orders = orderList.Split('-');
            List<OrderModel> listOrders = new List<OrderModel>();
            OrderModel oOrderModel;
            foreach (string myOrder in Orders)
            {
                if (string.IsNullOrEmpty(myOrder))
                    continue;

                string[] ItemFileds = myOrder.Split('#');
                oOrderModel = new OrderModel();
                oOrderModel.OrderId = Convert.ToInt32(ItemFileds[0]);
                oOrderModel.OrderDate = Convert.ToDateTime(ItemFileds[1]);
                oOrderModel.OrderItem.ItemId = Convert.ToInt32(ItemFileds[2]);
                oOrderModel.OrderStore.StoreId = Convert.ToInt32(ItemFileds[3]);
                listOrders.Add(oOrderModel);
            }
            return listOrders;
        }
    }
}
