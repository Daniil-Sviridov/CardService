using CardStorageService.Data;
using CardService.Models;
using Microsoft.Extensions.Options;

namespace CardService.Services
{
    public class CardsRepository : ICardsRepositoryService
    {

        private readonly SampleServiceDbContext _context;
        private readonly ILogger<CardsRepository> _logger;
        private readonly IOptions<DatabaseOptions> _databaseOptions;

        public CardsRepository(IOptions<DatabaseOptions> databaseOptions, SampleServiceDbContext context, ILogger<CardsRepository> logger)
        {
            _databaseOptions = databaseOptions;
            _context = context;
            _logger = logger;
        }

        public string Create(Cards data)
        {
            var client = _context.Clients.FirstOrDefault(client => client.ClientId == data.ClientId);
            if (client == null)
                throw new Exception("Client not found.");

            _context.Cards.Add(data);

            _context.SaveChanges();

            return data.CardId.ToString();
        }

        public IList<Cards> GetByClientId(string id)
        {
            return _context.Cards.Where(c => c.ClientId.ToString() == id).ToList();
        }

        public int Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Cards> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Update(Cards data)
        {
            throw new NotImplementedException();
        }

        public Cards GetById(string id)
        {
            throw new NotImplementedException();
        }

        

    }
}
