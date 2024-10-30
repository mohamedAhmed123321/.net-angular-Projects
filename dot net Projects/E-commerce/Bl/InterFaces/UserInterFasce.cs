using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Enumorations;
namespace Bl.InterFaces
{
    public interface UserInterFasce<T>
    {
        public List<T> GetAll();
        public  Task<T> GetById(string Id);
        public Task<bool> Save(T Item);
        public Task<bool> ChangeState(string Id, EntityStateEnum EntityState);

    }
}
