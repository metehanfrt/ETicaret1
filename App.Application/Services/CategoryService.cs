using App.Application.Dtos;
using App.Infrastructure.Data;
using App.Infrastructure.Data.Entity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }

        public List<CategoryDto> GetCategoriesDtoExample()
        {
            var categories = _db.Categories.Include(e => e.ParentCategory).ToList();

            //var list = new List<CategoryDto>();
            //foreach (var item in categories)
            //{
            //    list.Add(new CategoryDto { Id = item.Id, CategoryName = item.Name, Slug = item.Slug });
            //}

            var list = _mapper.Map<List<CategoryDto>>(categories);

            return list;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _db.Categories.Include(e => e.ParentCategory).FirstOrDefault(e => e.Id == categoryId);
        }
    }
}
