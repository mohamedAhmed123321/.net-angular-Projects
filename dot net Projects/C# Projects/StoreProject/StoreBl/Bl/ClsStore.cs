using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBl.Models;
using StoreBl.Dal;

namespace StoreBl.Bl
{
    public class ClsStore : IBusinessLayer<StoreModel>
    {
        public bool Add(StoreModel table)
        {
            List<StoreModel> lstStores = GetAll();
            //foreach(var store in lstStores)
            //{
            //    if(store.StoreId==table.StoreId)
            //    {
            //        return false;
            //    }
            //}
            //List<StoreModel> OldStore= lstStores.Where(x => x.StoreId == table.StoreId).ToList();
            //if (OldStore.Count > 0)
            //    return false;
            int nStoreId = 0;
            if (lstStores.Count == 0)
                nStoreId = 1;
            else
            {
                nStoreId = lstStores.Max(a => a.StoreId) + 1;
            }
            string storeData = string.Format("-{0}#{1}", nStoreId, table.StoreName);
            IDataAccess myDataAccess= DataAccessHelper.CreateObject();
            myDataAccess.Insert(FileNames.stores.ToString()+".txt", storeData);
            return true;
        }

        public bool Delete(int id)
        {
            List<StoreModel> lstStores = GetAll();
            StoreModel model = lstStores.Where(x => x.StoreId == id).FirstOrDefault();
            if (model == null)
                return false;
            else
            {
                lstStores.Remove(model);
                string sFileData = string.Empty;
                int nCount = 0;
                foreach(var store in lstStores)
                {
                    if(nCount==0)
                        sFileData+= string.Format("{0}#{1}", store.StoreId, store.StoreName);
                    else
                        sFileData += string.Format("-{0}#{1}", store.StoreId, store.StoreName);
                    nCount++;
                }
                IDataAccess myDataAccess = DataAccessHelper.CreateObject();
                myDataAccess.Delete(FileNames.stores.ToString() + ".txt", sFileData);
                return true;
            }

        }

        public List<StoreModel> GetAll()
        {
            IDataAccess myDataAccess = DataAccessHelper.CreateObject();
            string storeList= myDataAccess.GetAll(FileNames.stores.ToString() + ".txt");
            string[] Stores = storeList.Split('-');
            List<StoreModel> listStores = new List<StoreModel>();
            StoreModel oStoreModel;
            foreach (string myStore in Stores)
            {
                if (string.IsNullOrEmpty(myStore))
                    continue;

                string[] StoreFileds = myStore.Split('#');
                oStoreModel = new StoreModel();
                oStoreModel.StoreId = Convert.ToInt32( StoreFileds[0]);
                oStoreModel.StoreName = StoreFileds[1];
                listStores.Add(oStoreModel);
            }
            return listStores;
        }
    }
}
