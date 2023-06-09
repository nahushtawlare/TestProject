namespace TestProject.Models
{
    public class CategoryInfo
    {
        public int Category_Id { get; set; }
        public String CategoryTitle { get; set; }
        public String GroupName { get; set; }
        public DateTime CreationDate { get; set; }
        public int CategoryStatus { get; set; }
        public int TotalRowCount { get; set; }
    }

    public class CategoryInfoModel
    {
       // public CategoryInfo CategoryInfo { get; set; }
       private List<CategoryInfo> _categories = new List<CategoryInfo>();
       public List<CategoryInfo> CategoriesList 
        {
        get { return _categories; }
        set { _categories = value; }
        }
    }
}
