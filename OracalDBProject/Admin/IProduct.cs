using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracalDBProject.Admin
{
    public interface IProduct
    {
        void InsertId(string id);
        void InsetName(string name);
        void InsertAmount(int amount);
        void ExecuteToDatabase();
    }
}
