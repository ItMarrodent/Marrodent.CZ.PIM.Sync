namespace Marrodent.CZ.PIM.Sync.Models.Data
{
    public sealed class ProductCategory
    {
        //Public - int
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }
        public ICollection<int> ChildrenCategoriesIds { get; set; }

        //Public - string
        public string Name { get; set; }
    }
}
