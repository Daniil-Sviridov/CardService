using CardStorageService.Data;

namespace CardService.Services
{
    public class ClientRepository : IClientRepositoryService
    {
        

        private readonly SampleServiceDbContext _context;        

        public ClientRepository(SampleServiceDbContext context)
        {
            _context = context;
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
