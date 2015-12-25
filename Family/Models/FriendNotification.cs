using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Family.Models
{
    public class FriendNotification
    {
        [Key]
        [Column(Order =0)]
        [ForeignKey("Users")]
        public int User_ID { get; set; }

        [Key]
        [Column(Order =1)]
        [Required]
        public DateTime Time { get; set; }

        [ForeignKey("Friends")]
        public int Friend_ID { get; set; }

        [Required]
        public bool? Read { get; set; }

        public virtual List<User> Users { get; set; }
        public virtual List<User> Friends { get; set; }
    }
}
