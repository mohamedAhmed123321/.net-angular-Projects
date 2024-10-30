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
    public interface SalesInvoiceItemInterFace
    {
        public List<TbSalesInvoiceItem> GetSalesInvoiceId(int id);

        public bool Save(IList<TbSalesInvoiceItem> Items, int salesInvoiceId, bool isNew);

    }
}
