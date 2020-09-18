using ForSale.ComunDll.Responses;
using System.Threading.Tasks;


namespace ForSale.ComunDll.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);

    }
}
