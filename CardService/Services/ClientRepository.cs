using CardStorageService.Data;

namespace CardService.Services
{
    public class ClientRepository : IClientRepositoryService
    {
        
        private readonly SampleServiceDbContext _context;
        private readonly ILogger<ClientRepository> _logger;

        public ClientRepository(SampleServiceDbContext context, ILogger<ClientRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public int Create(Client data)
        {
            _context.Clients.Add(data);
            _context.SaveChanges();
            return data.ClientId;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public Client GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Client data)
        {
            throw new NotImplementedException();
        }

    }
}
