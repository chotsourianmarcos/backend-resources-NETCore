using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IProductLogic
    {
        List<ProductItem> GetAllProducts();
        List<ProductItem> GetProductsByCriteria(ProductFilter productFilter);
        void InsertProductItem(ProductItem productItem);
    }
}
