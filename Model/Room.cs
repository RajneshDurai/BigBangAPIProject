using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProjectBigBang.Model
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [ForeignKey("Hotel")]

        public int HotelId { get; set; }
        public string RoomType { get; set; }
        public string RoomAvailableinRoomType { get; set; } 

        public double Price { get; set; }

    }
}
