using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDomain.Interfaces
{
    public interface IService
    {
        int Id { get; }
        string RegistrationNumber { get; }
        DateTime ServiceDate { get; }
        string Description { get;  }
        bool IsCompleted { get;}
        void Update(DateTime servicedate, string dercription, bool Iscompleted);



    }
}
