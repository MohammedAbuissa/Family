namespace Family.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Posts = new HashSet<Post>();
            Users1 = new HashSet<User>();
            Users = new HashSet<User>();
        }

        [Key]
        public int User_Id { get; set; }

        [Required]
        [StringLength(15)]
        public string First_Name { get; set; }

        [Required]
        [StringLength(15)]
        public string Last_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string E_Mail { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        public DateTime? Profile_Picture { get; set; }

        [StringLength(20)]
        public string Phone_Number { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        public byte Marital_Status { get; set; }

        [Column(TypeName = "text")]
        public string About_me { get; set; }

        [StringLength(50)]
        public string HomeTown { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
