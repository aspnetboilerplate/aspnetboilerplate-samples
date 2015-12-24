using System.Collections.Generic;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

namespace OrganizationUnitsDemo.Products
{
    public class ProductManager : IDomainService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductManager(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProductsInOu(long organizationUnitId)
        {
            return _productRepository.GetAllList(p => p.OrganizationUnitId == organizationUnitId);
        }
    }
}