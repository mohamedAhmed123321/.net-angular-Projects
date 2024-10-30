using CoursesProject.Migrations;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public interface Interface1<t>
    {
        public List<t> GettAll();
        public t GetById(int ColumId);
        public void Delete(int id);
        public void Save(t colum);
        public List<Details> GettAllWithData();
    }
}
