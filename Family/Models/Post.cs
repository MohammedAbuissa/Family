namespace Family.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int User_Id { get; set; }

        [Column(TypeName = "text")]
        [StringLength(144)]
        public string Caption { get; set; }

        [Key]
        [Column(Order = 1)]
        [DataType(DataType.Date)]
        public DateTime Time { get; set; }

        public bool? Private_Public { get; set; }

        public bool Has_Picture { get; set; }

        public virtual Like Like { get; set; }

        public virtual User User { get; set; }

        public ICollection<Post> Comments { get; set; }
    }
}
