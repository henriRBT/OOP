using OOP.Models;

namespace OOP.Repository.Interface
{
    public interface IRepository
    {
        Clients GetClient(int id);
        List<Clients> GetClients();
        Clients TambahClient(Clients client);
        Clients UpdateClient(Clients client);
        void DeleteClient(int id);
    }
}
