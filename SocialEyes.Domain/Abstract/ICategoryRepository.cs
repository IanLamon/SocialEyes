using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialEyes.Domain.Entities;

namespace SocialEyes.Domain.Abstract
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }

        //code to save category to database
        void SaveCategory(Category category);

        //code to delete category from database
        Category DeleteCategory(int categoryId);
    }
}
