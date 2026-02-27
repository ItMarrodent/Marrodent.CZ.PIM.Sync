using Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Data;
using Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Sql;
using Marrodent.CZ.PIM.Sync.Models.Data;

namespace Marrodent.CZ.PIM.Sync.Infrastructure.Controllers.Data
{
    public sealed class ProductsCategoriesDataController : IProductsCategoriesDataController
    {
        //Private
        private readonly ISqlController<ProductCategory> _sqlController;

        //CTOR
        public ProductsCategoriesDataController(ISqlController<ProductCategory> sqlController)
        {
            _sqlController = sqlController;
        }

        //Public
        public async Task<ICollection<ProductCategory>> GetCategories()
        {
            return await _sqlController.List(GetDataQuery());
        }

        //Private
        private string GetDataQuery()
        {
            return @"SELECT Dictionary.ID, Dictionary.Value as 'Name', Dictionary.Parent as 'ParentCategoryId', (SELECT STRING_AGG(temp.ID, ';') FROM Dictionary as temp WHERE temp.Category = 'F.CZ_NOVYSTROM6' and temp.Parent = Dictionary.ID) as 'ChildrenCategoriesIds' 
                   FROM Dictionary
                   WHERE Category = 'F.CZ_NOVYSTROM6'";
        }
    }
}
