namespace Family.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FamilyModel : DbContext
    {
        public FamilyModel()
            : base("name=FamilyModel")
        {
        }

        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(e => e.Caption)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .HasOptional(e => e.Like)
                .WithRequired(e => e.Post);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Posts1)
                .WithOptional(e => e.Post1);

            modelBuilder.Entity<User>()
                .Property(e => e.First_Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Last_Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.E_Mail)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone_Number)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.About_me)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.HomeTown)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Users1)
                .WithMany(e => e.Users)
                .Map(m => m.ToTable("Friends").MapLeftKey("Friend_Id").MapRightKey("User_Id"));
        }
    }
}
