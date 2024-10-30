using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Enumorations;
using Domains.Tables;
using Domains.ViewResult;
namespace Bl.InterFaces
{
    public interface SalesInvoiceInterFace
    {
        public List<VwSalesInvoice> GetAll();

        public TbSalesInvoice GetById(int id);

        public bool Save(TbSalesInvoice Item, List<TbSalesInvoiceItem> lstItems, bool isNew);

        public bool Delete(int id);

    }
}
