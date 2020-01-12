using ProductManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repository.Interface
{
    public interface IProductRepository
    {
        IEnumerable<ProductViewModel> GetAll();

        void Add(ProductViewModel entity);

        void Delete(ProductViewModel entity);

        void Update(ProductViewModel products);

        ProductViewModel GetById(int id);

        ProductViewModel GetByCondition(Object obj);

        void SaveChange();
    }
}
