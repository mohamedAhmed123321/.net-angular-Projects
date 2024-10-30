using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StoreBl.Dal
{
    public class FileDataLayer : IDataAccess
    {
        public void Create(string tableName)
        {
            try
            {
                File.Create(tableName);
            }
            catch
            {

            }
        }

        public void Delete(string tableName, string data)
        {
            try
            {
                File.WriteAllText(tableName, data);
            }
            catch
            {

            }
        }

        public string GetAll(string tableName)
        {
            try
            {
                return File.ReadAllText(tableName);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public void Insert(string tableName, string data)
        {
            try
            {
                File.AppendAllText(tableName, data);
            }
            catch
            {

            }
        }
    }
}
