using System;
using System.ComponentModel.DataAnnotations;

namespace ProductAdminAPI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The product name can not be empty")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Product Name field must have minimum 6 and maximum 150 character!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The product category can not be empty")]
        [Range(1, 5)]
        public int CategoryId { get; set; }
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The product name can not be empty")]
        [StringLength(300, MinimumLength = 5, ErrorMessage = "Product Description field must have minimum 16 and maximum 300 character!")]
        public string Description { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The product base-weight can not be empty")]
        [Range(1, 1000)]
        public Int16 BaseWeight { get; set; }
        [Required(ErrorMessage = "The product category can not be empty")]
        [Range(1, 5)]
        public int MeasurementId { get; set; }
        [Required(ErrorMessage = "Is Available field can not be empty")]
        public bool IsAvailable { get; set; }
        [Required(ErrorMessage = "The amount per unit field can not be empty")]
        [Range(1, 99999)]
        public Int16 AmountPerUnit { get; set; }
        [Required(ErrorMessage = "Is Active field can not be empty")]
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DataType(DataType.Text)]
        public string CreatedBy { get; set; }
        [DataType(DataType.Text)]
        public string ModifiedBy { get; set; }
    }
}