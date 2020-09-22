using System.Threading.Tasks;
using ForSale.ComunDll.Entidades;
using ForSale.WebbApp.Data.Entidades;
using ForSale.WebbApp.Models;

namespace ForSale.WebbApp.Helpers
{
    public interface IConverterHelper
    {
        Category ToCategory(CategoryViewModel model, string imageId, bool isNew);

        CategoryViewModel ToCategoryViewModel(Category category);
        Task<Product> ToProductAsync(ProductViewModel model, bool isNew);

        ProductViewModel ToProductViewModel(Product product);

    }
}
