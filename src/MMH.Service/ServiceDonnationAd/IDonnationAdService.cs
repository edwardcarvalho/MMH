using MMH.Model.Models;
using System.Web.ModelBinding;

namespace MMH.Service.ServiceDonnationAd
{
    public interface IDonnationAdService
    {
        bool ValidateDonnationAd(DonnationAd entity, ref ModelStateDictionary modelState);
        bool Save(DonnationAd entity);
        bool Update(DonnationAd entity);
        bool Delete(DonnationAd entity);
    }
}