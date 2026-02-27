using Marrodent.CZ.PIM.Sync.Models.Data;

namespace Marrodent.CZ.PIM.Sync.Infrastructure.Interfaces.Data;

public interface IProductsCategoriesDataController
{
    Task<ICollection<ProductCategory>> GetCategories();
}