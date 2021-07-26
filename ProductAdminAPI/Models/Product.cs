using System;

namespace ProductAdminAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public Int16 BaseWeight { get; set; }
        public int MeasurementId { get; set; }
        public bool IsAvailable { get; set; }
        public Int16 AmountPerUnit { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}