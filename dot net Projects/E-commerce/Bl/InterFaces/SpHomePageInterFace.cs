using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.InterFaces
{
    public interface SpHomePageInterFace<T>
    {
        public List<T> GetContent(int PageNumber,int Count);

    }
}
