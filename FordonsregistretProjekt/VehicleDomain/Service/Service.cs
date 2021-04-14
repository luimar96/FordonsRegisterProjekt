using System;
using System.Collections.Generic;
using VehicleDomain.Interfaces;

namespace VehicleDomain.Service
{
    public class Service : IService
    {
        private int id { get; set; }
        private string registrationNumber { get; set; }
        private DateTime serviceDate { get; set; }
        private string description { get; set; }
        private bool isCompleted { get; set; }
        public IList<IService> ServiceHistory { get; set; } = new List<IService>();
        public DateTime ServiceDate => serviceDate;
        public string Description => description;

        public string RegistrationNumber => registrationNumber;

        public bool IsCompleted => isCompleted;

        public int Id => id;

        public Service(string regNum, DateTime serviceDate, string description)
        {
            this.registrationNumber = regNum;
            this.serviceDate = serviceDate;
            this.description = description;

        }

        public Service(int id,string regNum, DateTime serviceDate, string description, bool isCompleted)
        {
            this.id = id;
            this.registrationNumber = regNum;
            this.serviceDate = serviceDate;
            this.description = description;
            this.isCompleted = isCompleted;
        }
        public void Update(DateTime servicedate,string dercription,bool Iscompleted)
        {
            this.serviceDate = servicedate;
            this.description = dercription;
            this.isCompleted = Iscompleted;
                
        }


    }
}
