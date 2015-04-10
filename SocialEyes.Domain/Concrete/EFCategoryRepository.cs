using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Abstract;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Concrete
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private EFdbContext context = new EFdbContext();

        public IQueryable<Category> Categories
        {
            get { return context.Categories; }
        }

        //method to create/update category to database
        public void SaveCategory(Category category)
        {
            if (category.CategoryId == 0)
            {
                context.Categories.Add(category);
            }
            else
            {
                Category c = context.Categories.Find(category.CategoryId);
                if (c != null)
                {
                    c.CategoryId = category.CategoryId;
                    c.Name = category.Name;
                    c.CategoryImageURL = category.CategoryImageURL;
                    c.CompanyId = category.CompanyId;
                }
            }
            context.SaveChanges();
        } //ends create/update category method

        //method to delete category from database
        public Category DeleteCategory(int categoryId)
        {
            Category x = context.Categories.Find(categoryId);

            if (x != null)
            {
                context.Categories.Remove(x);
                context.SaveChanges();
            }
            return x;
        } //ends delete method
    }
}
