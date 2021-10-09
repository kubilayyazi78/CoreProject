using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        EfCategoryRepository _categoryRepository;
        //to do DependencyInjection
        public CategoryManager()
        {
            _categoryRepository = new EfCategoryRepository();
        }
        public void Add(Category category)
        {
            _categoryRepository.Insert(category);
        }

        public void Delete(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public List<Category> GetList()
        {
            return _categoryRepository.GetListAll();
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
