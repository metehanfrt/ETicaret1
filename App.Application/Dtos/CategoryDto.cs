namespace App.Application.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string? Slug { get; set; }
        public string CategoryName { get; set; }

        public string ParentCategoryName { get; set; }
    }
}