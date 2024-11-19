using Dapper;
using Microsoft.Data.SqlClient;
using OOP.Models;
using OOP.Repository.Interface;
using System.Data;

namespace OOP.Repository
{
    public class Repository : IRepository
    {
        private readonly IDbConnection _db;
        public Repository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public Clients GetClient(int id)
        {
            var sql = "SELECT * FROM Clients where id =@id";
            return _db.Query<Clients>(sql, new
            {
                @id = id,
            }).Single();
        }
        public List<Clients> GetClients()
        {
            var sql = "SELECT * FROM Clients";
            return _db.Query<Clients>(sql).ToList();
        }
        public Clients TambahClient(Clients client)
        {
            //cara pertama 
            /* var sql = "INSERT INTO Clients(Nama, telepon, email, negara, tanggal ) VALUES(@nama, @telepon, @email, @negara, @tanggal)" +
                 "SELECT CAST(SCOPE_IDENTITY() AS Int)";
             var id = _db.Query<int>(sql, new
             {
                 client.Nama,
                 client.telepon,
                 client.email,
                 client.negara,
                 client.tanggal,
             }).Single();*/

            //cara kedua
            var sql = "INSERT INTO Clients(Nama, telepon, email, negara, tanggal ) VALUES(@nama, @telepon, @email, @negara, @tanggal)" +
                "SELECT CAST(SCOPE_IDENTITY() AS Int)";
            var id = _db.Query<int>(sql, client).Single();
            client.Id = id;
            return client;
        }
        public Clients UpdateClient(Clients client)
        {
            var sql = "UPDATE Clients SET Nama=@nama, telepon=@telepon, email=@email, negara=@negara, tanggal=@tanggal where id = @id";
            _db.Execute(sql, client);
            return client;
        }
        public void DeleteClient(int id)
        {
            var sql = "Delete FROM Clients where id =@id";
            _db.Execute(sql, new
            {
                @id = id,
            });
           
        }
    }
}
