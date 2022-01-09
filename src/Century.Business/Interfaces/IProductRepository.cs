using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Century.Business.Models;

namespace Century.Business.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierid);
        Task<IEnumerable<Product>> GetProductsAndSuppliers(); //Lista de produtos e fornecedores desse produto
        Task<Product> GetProductSupplier(Guid id); //Obter 1 produto de 1 fornecedor
       
    }
}
