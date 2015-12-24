using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization.Users;
using Abp.Organizations;
using Abp.Runtime.Session;
using OrganizationUnitsDemo.EntityFramework;
using OrganizationUnitsDemo.Products;
using Shouldly;
using Xunit;

namespace OrganizationUnitsDemo.Tests.Products
{
    public class ProductManager_Tests : OrganizationUnitsDemoTestBase
    {
        private readonly ProductManager _productManager;
        private readonly OrganizationUnitManager _organizationUnitManager;

        public ProductManager_Tests()
        {
            CreateTestData();

            _productManager = Resolve<ProductManager>();
            _organizationUnitManager = Resolve<OrganizationUnitManager>();
        }

        [Fact]
        public void Test_GetProductsInOu()
        {
            var productsInOu1 = _productManager.GetProductsInOu(GetOu("OU1").Id);
            productsInOu1.Count.ShouldBe(1);
            productsInOu1.Any(p => p.Name == "Product A").ShouldBeTrue();

            var productsInOu12 = _productManager.GetProductsInOu(GetOu("OU12").Id);
            productsInOu12.Count.ShouldBe(1);
            productsInOu12.Any(p => p.Name == "Product C").ShouldBeTrue();
        }

        [Fact]
        public void Test_GetProductsInOuIncludingChildren()
        {
            var productsInOu1 = _productManager.GetProductsInOuIncludingChildren(GetOu("OU1").Id);
            productsInOu1.Count.ShouldBe(3);
            productsInOu1.Any(p => p.Name == "Product D").ShouldBeFalse();
        }

        [Fact]
        public async Task Test_GetProductsForUser()
        {
            var productsOfUser = await _productManager.GetProductsForUserAsync(AbpSession.GetUserId());
            productsOfUser.Count.ShouldBe(2);
            productsOfUser.Any(p => p.Name == "Product B").ShouldBeTrue();
            productsOfUser.Any(p => p.Name == "Product D").ShouldBeTrue();
        }

        private OrganizationUnit GetOu(string displayName)
        {
            return UsingDbContext(context => context.OrganizationUnits.Single(ou => ou.DisplayName == displayName));
        }

        private void CreateTestData()
        {
            UsingDbContext(context =>
            {
                /*** Organization Tree ***********
                 * - OU1
                 *   - OU11
                 *   - OU12
                 * - OU2
                 */

                var ou1 = CreateOu(context, "OU1", "00001");
                var ou11 = CreateOu(context, "OU11", "00001.00001", ou1.Id);
                var ou12 = CreateOu(context, "OU12", "00001.00002", ou1.Id);
                var ou2 = CreateOu(context, "OU2", "00002");

                /*** Products **********
                 * - Product A (in OU1)
                 * - Product B (in OU11)
                 * - Product C (in OU12)
                 * - Product D (in OU2)
                 */
                
                CreateProduct(context, "Product A", ou1.Id);
                CreateProduct(context, "Product B", ou11.Id);
                CreateProduct(context, "Product C", ou12.Id);
                CreateProduct(context, "Product D", ou2.Id);

                /* Assign admin to OU11 and OU2.
                 */
                AssignUserToOu(context, AbpSession.GetUserId(), ou11.Id);
                AssignUserToOu(context, AbpSession.GetUserId(), ou2.Id);
            });
        }

        private OrganizationUnit CreateOu(OrganizationUnitsDemoDbContext context, string displayName, string code, long? parentId = null)
        {
            var ou = new OrganizationUnit(AbpSession.GetTenantId(), displayName, parentId) {Code = code};
            context.OrganizationUnits.Add(ou);
            context.SaveChanges();
            return ou;
        }

        private Product CreateProduct(OrganizationUnitsDemoDbContext context, string displayName, long organizationUnitId)
        {
            var product = new Product(AbpSession.GetTenantId(), organizationUnitId, displayName, 99.9f);
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        private void AssignUserToOu(OrganizationUnitsDemoDbContext context, long userId, long organizationUnitId)
        {
            var uou = new UserOrganizationUnit(AbpSession.GetTenantId(), userId, organizationUnitId);
            context.UserOrganizationUnits.Add(uou);
            context.SaveChanges();
        }
    }
}
