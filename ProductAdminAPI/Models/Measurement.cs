using System;

namespace ProductAdminAPI.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}