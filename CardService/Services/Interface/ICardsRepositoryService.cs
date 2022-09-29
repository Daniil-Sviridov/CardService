using CardStorageService.Data;

namespace CardService.Services
{
    public interface ICardsRepositoryService : IRepository<Cards, string>
    {
        IList<Cards> GetByClientId(string id);
    }
}
