using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcClient.Models
{
    public class ViewServicesModel
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}