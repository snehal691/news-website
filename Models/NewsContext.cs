using Microsoft.EntityFrameworkCore;

namespace News.Models
{
    public partial class NewsContext : DbContext
    {
        public NewsContext()
        {
        }

        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleCategory> ArticleCategory { get; set; }
        public virtual DbSet<ArticleComment> ArticleComment { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<CommentPerson> CommentPerson { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonRole> PersonRole { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=news;User=root;Password=guruojintang;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("article");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasColumnName("author")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("text");

                entity.Property(e => e.PublishDate)
                    .HasColumnName("publish_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<ArticleCategory>(entity =>
            {
                entity.ToTable("article_category");

                entity.HasIndex(e => e.ArticleId)
                    .HasName("category_article_article_id_fk");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("category_article_category_id_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArticleId).HasColumnName("article_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleCategory)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("category_article_article_id_fk");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ArticleCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("category_article_category_id_fk");
            });

            modelBuilder.Entity<ArticleComment>(entity =>
            {
                entity.ToTable("article_comment");

                entity.HasIndex(e => e.ArticleId)
                    .HasName("comment_article_article_id_fk");

                entity.HasIndex(e => e.CommentId)
                    .HasName("comment_article_comment_id_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArticleId).HasColumnName("article_id");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleComment)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comment_article_article_id_fk");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.ArticleComment)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comment_article_comment_id_fk");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("text");

                entity.Property(e => e.PublishDate)
                    .HasColumnName("publish_date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<CommentPerson>(entity =>
            {
                entity.ToTable("comment_person");

                entity.HasIndex(e => e.CommentId)
                    .HasName("comment_person_comment_id_fk");

                entity.HasIndex(e => e.PersonId)
                    .HasName("comment_person_person_id_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentPerson)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comment_person_comment_id_fk");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.CommentPerson)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comment_person_person_id_fk");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.HasIndex(e => e.Email)
                    .HasName("person_email_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Nickname)
                    .HasName("person_nickname_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Nickname)
                    .HasColumnName("nickname")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<PersonRole>(entity =>
            {
                entity.ToTable("person_role");

                entity.HasIndex(e => e.PersonId)
                    .HasName("person_role_person_id_fk");

                entity.HasIndex(e => e.RoleId)
                    .HasName("person_role_role_id_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonRole)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("person_role_person_id_fk");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PersonRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("person_role_role_id_fk");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(20)");
            });
        }
    }
}
