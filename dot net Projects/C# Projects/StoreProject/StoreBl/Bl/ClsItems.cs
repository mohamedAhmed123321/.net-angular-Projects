using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBl.Dal;
using StoreBl.Models;

namespace StoreBl.Bl
{
    public class ClsItems : IBusinessLayer<ItemModel>
    {
        public bool Add(ItemModel table)
        {
            List<ItemModel> lstItems = GetAll();
            int nItemId = 0;
            if (lstItems.Count == 0)
                nItemId = 1;
            else
            {
                nItemId = lstItems.Max(a => a.ItemId) + 1;
            }
            string itemData = string.Format("-{0}#{1}#{2}", nItemId, table.ItemName,table.ItemPrice);
            IDataAccess myDataAccess = DataAccessHelper.CreateObject();
            myDataAccess.Insert(FileNames.items.ToString() + ".txt", itemData);
            return true;
        }

        public bool Delete(int id)
        {
            List<ItemModel> lstItems = GetAll();
            ItemModel model = lstItems.Where(x => x.ItemId == id).FirstOrDefault();
            if (model == null)
                return false;
            else
            {
                lstItems.Remove(model);
                string sFileData = string.Empty;
                int nCount = 0;
                foreach (var item in lstItems)
                {
                    if (nCount == 0)
                        sFileData += string.Format("{0}#{1}#{2}", item.ItemId, item.ItemName,item.ItemPrice);
                    else
                        sFileData += string.Format("-{0}#{1}#{2}", item.ItemId, item.ItemName, item.ItemPrice);
                    nCount++;
                }
                IDataAccess myDataAccess = DataAccessHelper.CreateObject();
                myDataAccess.Delete(FileNames.items.ToString() + ".txt", sFileData);
                return true;
            }
        }

        public List<ItemModel> GetAll()
        {
            IDataAccess myDataAccess = DataAccessHelper.CreateObject();
            string itemList = myDataAccess.GetAll(FileNames.items.ToString() + ".txt");
            string[] Items = itemList.Split('-');
            List<ItemModel> listItems = new List<ItemModel>();
            ItemModel oItemModel;
            foreach (string myItem in Items)
            {
                if (string.IsNullOrEmpty(myItem))
                    continue;

                string[] ItemFileds = myItem.Split('#');
                oItemModel = new ItemModel();
                oItemModel.ItemId = Convert.ToInt32(ItemFileds[0]);
                oItemModel.ItemName = ItemFileds[1];
                oItemModel.ItemPrice= Convert.ToDecimal(ItemFileds[2]);
                listItems.Add(oItemModel);
            }
            return listItems;
        }
    }
}
