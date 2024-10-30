using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Enumorations;
namespace Bl.InterFaces
{
    public interface ViewInterFace<T>
    {
        public List<T> GetAll();
        public T GetById(int Id);

    }
}
