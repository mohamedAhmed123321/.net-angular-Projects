using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.InterFaces
{
    public interface SpFilteredItemInterFace<T>
    {
        public List<T> GetItems(int pageNum, int count, string title, int? ramSize, string categoryName, float? minPrice, float? maxPrice);

    }
}
