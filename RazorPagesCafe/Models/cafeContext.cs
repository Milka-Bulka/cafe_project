using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RazorPagesCafe.Models
{
    public partial class cafeContext : DbContext
    {
        public cafeContext()
        {
        }

        public cafeContext(DbContextOptions<cafeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContentsOfDish> ContentsOfDishes { get; set; }
        public virtual DbSet<ContentsOfOrder> ContentsOfOrders { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Orderr> Orderrs { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=cafe;Username=milka;Password=8982kekes;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum(null, "place", new[] { "В зале", "С собой" })
                .HasPostgresEnum(null, "status", new[] { "Готовится", "Готово", "Ошибка" })
                .HasPostgresEnum(null, "stop_list", new[] { "Есть в наличии", "Нет в наличии" })
                .HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<ContentsOfDish>().ToTable("ContentsOfDish");
            modelBuilder.Entity<ContentsOfDish>(entity =>
            {
                entity.HasKey(e => new { e.IdIngredient, e.IdPosition })
                    .HasName("contents_of_dish_pkey");

                entity.ToTable("contents_of_dish");

                entity.Property(e => e.IdIngredient).HasColumnName("id_ingredient");

                entity.Property(e => e.IdPosition).HasColumnName("id_position");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdIngredientNavigation)
                    .WithMany(p => p.ContentsOfDishes)
                    .HasForeignKey(d => d.IdIngredient)
                    .HasConstraintName("contents_of_dish_id_ingredient_fkey");

                entity.HasOne(d => d.IdPositionNavigation)
                    .WithMany(p => p.ContentsOfDishes)
                    .HasForeignKey(d => d.IdPosition)
                    .HasConstraintName("contents_of_dish_id_position_fkey");
            });

            modelBuilder.Entity<ContentsOfOrder>().ToTable("ContentsOfOrder");
            modelBuilder.Entity<ContentsOfOrder>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("contents_of_order_pkey");

                entity.ToTable("contents_of_order");

                entity.Property(e => e.IdOrder)
                    .ValueGeneratedNever()
                    .HasColumnName("id_order");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment");

                entity.Property(e => e.IdPosition).HasColumnName("id_position");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithOne(p => p.ContentsOfOrder)
                    .HasForeignKey<ContentsOfOrder>(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contents_of_order_id_order_fkey");

                entity.HasOne(d => d.IdPositionNavigation)
                    .WithMany(p => p.ContentsOfOrders)
                    .HasForeignKey(d => d.IdPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contents_of_order_id_position_fkey");
            });

            modelBuilder.Entity<Dish>().ToTable("Dish");
            modelBuilder.Entity<Dish>(entity =>
            {
                entity.HasKey(e => e.IdPosition)
                    .HasName("dish_pkey");

                entity.ToTable("dish");

                entity.Property(e => e.IdPosition).HasColumnName("id_position");

                entity.Property(e => e.Amount)
                    .HasPrecision(8, 2)
                    .HasColumnName("amount");

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.CookingCourse).HasColumnName("cooking_course");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.MenuView)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("menu_view");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.QuantityInOrder).HasColumnName("quantity_in_order");

                entity.HasOne(d => d.MenuViewNavigation)
                    .WithMany(p => p.Dishes)
                    .HasForeignKey(d => d.MenuView)
                    .HasConstraintName("dish_menu_view_fkey");
            });

            modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.IdIngredient)
                    .HasName("ingredient_pkey");

                entity.ToTable("ingredient");

                entity.Property(e => e.IdIngredient).HasColumnName("id_ingredient");

                entity.Property(e => e.Calories)
                    .HasPrecision(6, 2)
                    .HasColumnName("calories");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("name");

                entity.Property(e => e.Remainder).HasColumnName("remainder");

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("unit");
            });

            modelBuilder.Entity<Menu>().ToTable("Menu");
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.MenuView)
                    .HasName("menu_pkey");

                entity.ToTable("menu");

                entity.Property(e => e.MenuView)
                    .HasMaxLength(20)
                    .HasColumnName("menu_view");

                entity.Property(e => e.TimeOfAction).HasColumnName("time_of_action");
            });

            modelBuilder.Entity<Orderr>().ToTable("Orderr");
            modelBuilder.Entity<Orderr>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("orderr_pkey");

                entity.ToTable("orderr");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdTable)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_table");

                entity.Property(e => e.IdVisitor).HasColumnName("id_visitor");

                entity.Property(e => e.NumberOfVisitor).HasColumnName("number_of_visitor");

                entity.Property(e => e.OrderTime).HasColumnName("order_time");

                entity.Property(e => e.TotalAmount)
                    .HasPrecision(8, 2)
                    .HasColumnName("total_amount");

                entity.HasOne(d => d.IdVisitorNavigation)
                    .WithMany(p => p.Orderrs)
                    .HasForeignKey(d => d.IdVisitor)
                    .HasConstraintName("orderr_id_visitor_fkey");
            });

            modelBuilder.Entity<Visitor>().ToTable("Visitor");
            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.HasKey(e => e.IdVisitor)
                    .HasName("visitor_pkey");

                entity.ToTable("visitor");

                entity.HasIndex(e => e.Telephone, "unique_telephone")
                    .IsUnique();

                entity.Property(e => e.IdVisitor).HasColumnName("id_visitor");

                entity.Property(e => e.Bonuses).HasColumnName("bonuses");

                entity.Property(e => e.DOfB)
                    .HasColumnType("date")
                    .HasColumnName("d_of_b");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("name");

                entity.Property(e => e.Telephone)
                    .HasPrecision(11)
                    .HasColumnName("telephone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
