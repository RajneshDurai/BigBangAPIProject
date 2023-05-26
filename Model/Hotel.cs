using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProjectBigBang.Model
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HotelId { get; set; }
        public string HotelName { get; set; }=string.Empty;
        public string Location { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public string RoomsAvailable { get; set; } = string.Empty;
        public ICollection<Room> Rooms { get; set; }
    }
}
