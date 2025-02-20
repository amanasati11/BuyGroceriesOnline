﻿using Microsoft.EntityFrameworkCore;

namespace BuyGroceriesOnline.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Category> AllCategories => _appDbContext.Categories.Include(c=>c.Products);

        public Category DeleteCategory(int categoryId)
        {
            var category = _appDbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            var entry = _appDbContext.Categories.Remove(category);
            _appDbContext.SaveChanges();
            return entry.Entity;
        }

        public Category InsertCategory(Category category)
        {
            var entry = _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();
            return entry.Entity;
        }

        public Category UpdateCategory(Category category)
        {
            var entry = this._appDbContext.Categories.Update(category);
            this._appDbContext.SaveChanges();
            return entry.Entity;
        }
    }
}
