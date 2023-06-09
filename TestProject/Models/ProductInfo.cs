namespace TestProject.Models
{
    public class ProductInfo
    {
        public int Product_Id { get; set; }
        public int ProductStatus { get; set; }
        public int Category_Id { get; set; }
        public String ProductTitle { get; set; }
        public String ProductDescription { get; set; }
        public String ProductImages { get; set; }
        public Decimal ProductPrice { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
