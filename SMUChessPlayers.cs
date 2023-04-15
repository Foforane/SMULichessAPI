using System.ComponentModel.DataAnnotations;

namespace LichessAPI
{
    public class SMUChessPlayers
    {
        [Key]
        public string username { get; set; }
        public string surname { get; set; }
        public string name { get; set; }

        public string phoneNumber { get; set; }
        public string gender { get; set; }
    }
}
