using System.ComponentModel.DataAnnotations;

namespace OOP.Models
{
    public class Clients
    {
        [Key]
        public int Id { get; set; }
        public string Nama { get; set; }
        public string telepon { get; set; }
        public string email { get; set; }
        public string negara { get; set; }
        public DateTime tanggal { get; set; }

    }
}
