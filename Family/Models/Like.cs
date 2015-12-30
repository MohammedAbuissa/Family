namespace Family.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Like
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int User_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Post_Id { get; set; }

        [ForeignKey("LikeOwner")]
        public int Like_Owner_Id { get; set; }

        public virtual Post Post { get; set; }

        public virtual User LikeOwner { get; set; }
    }
}
