using System;

namespace MvcClient.Models
{
    public class UpdateServiceListModel
    {

        public int Id { get; set; }

        public DateTime ServiceDate { get; set; }
        public string Description { get; set; }
        public bool Iscompleted { get; set; }
    }
}