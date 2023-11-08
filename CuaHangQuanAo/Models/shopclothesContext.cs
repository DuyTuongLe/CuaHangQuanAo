using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CuaHangQuanAo.Models
{
    public partial class shopclothesContext : DbContext
    {
        public shopclothesContext()
        {
        }

        public shopclothesContext(DbContextOptions<shopclothesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=shopclothes;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId).HasColumnName("Cart_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("Created_at");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__Product_ID__5EBF139D");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatogoryId)
                    .HasName("PK__Category__65D7466536C88902");

                entity.ToTable("Category");

                entity.Property(e => e.CatogoryId).HasColumnName("Catogory_ID");

                entity.Property(e => e.NameCate)
                    .HasMaxLength(50)
                    .HasColumnName("Name_Cate");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CusId)
                    .HasName("PK__Customer__0AD16557C5854206");

                entity.ToTable("Customer");

                entity.Property(e => e.CusId).HasColumnName("Cus_ID");

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.CusName)
                    .HasMaxLength(50)
                    .HasColumnName("Cus_Name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__2623598B0579A92F");

                entity.ToTable("Employee");

                entity.Property(e => e.EmpId).HasColumnName("Emp_ID");

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .HasColumnName("Emp_Name");

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.CusId).HasColumnName("Cus_ID");

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.EmpId).HasColumnName("Emp_ID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("Order_Date");

                entity.Property(e => e.PaymentId).HasColumnName("Payment_ID");

                entity.Property(e => e.PaymentMenthod)
                    .HasMaxLength(50)
                    .HasColumnName("Payment_menthod");

                entity.Property(e => e.TotalPrice).HasColumnName("total_Price");

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Cus_ID__619B8048");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Emp_ID__628FA481");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Orders_Payment");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("Order_detail");

                entity.Property(e => e.OrderDetailId).HasColumnName("Order_Detail_ID");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_det__Order__5FB337D6");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_det__Produ__60A75C0F");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("Payment_ID");

                entity.Property(e => e.PaymentName)
                    .HasMaxLength(50)
                    .HasColumnName("Payment_Name");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.PostId).HasColumnName("Post_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("Created_at");

                entity.Property(e => e.EmpId).HasColumnName("Emp_ID");

                entity.Property(e => e.ModifiedAt)
                    .HasColumnType("date")
                    .HasColumnName("modified_at");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Post__Emp_ID__6477ECF3");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.CatogoryId).HasColumnName("Catogory_ID");

                entity.Property(e => e.NameProduct)
                    .HasMaxLength(50)
                    .HasColumnName("Name_Product");

                entity.Property(e => e.QuantityInventory).HasColumnName("Quantity_inventory");

                entity.Property(e => e.SupId).HasColumnName("Sup_ID");

                entity.HasOne(d => d.Catogory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CatogoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__Catogor__656C112C");

                entity.HasOne(d => d.Sup)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupId)
                    .HasConstraintName("FK_Product_Supplier");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("Role_Name");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupId)
                    .HasName("PK__Supplier__8F4CE1217A76553E");

                entity.ToTable("Supplier");

                entity.Property(e => e.SupId).HasColumnName("Sup_ID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.SupName)
                    .HasMaxLength(50)
                    .HasColumnName("Sup_Name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("Create_Date");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("User_Name");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__Role_ID__6754599E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
