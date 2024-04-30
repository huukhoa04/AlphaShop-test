using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AlphaShop.Data;

public partial class HahaContext : DbContext
{
    public HahaContext()
    {
    }

    public HahaContext(DbContextOptions<HahaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Access> Accesses { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartDetail> CartDetails { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Ord> Ords { get; set; }

    public virtual DbSet<Product> Products { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-V3LDFHK\\RESOLVED;Initial Catalog=haha;User ID=khoa;Password=huukhoa1+2;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Access>(entity =>
        {
            entity.HasKey(e => e.AccId);

            entity.ToTable("ACCESS");

            entity.Property(e => e.AccId)
                .ValueGeneratedNever()
                .HasColumnName("ACC_ID");
            entity.Property(e => e.AccName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ACC_NAME");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK_CART_ID");

            entity.ToTable("CART");

            entity.Property(e => e.CartId)
                .ValueGeneratedNever()
                .HasColumnName("CART_ID");
            entity.Property(e => e.CartQuantity).HasColumnName("CART_QUANTITY");

            entity.HasOne(d => d.CartNavigation).WithOne(p => p.Cart)
                .HasForeignKey<Cart>(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CART__CUSTOMER");
        });

        modelBuilder.Entity<CartDetail>(entity =>
        {
            entity.HasKey(e => new { e.CartId, e.PrdId, e.OptionSize, e.OptionType });

            entity.ToTable("CART_DETAIL");

            entity.Property(e => e.CartId).HasColumnName("CART_ID");
            entity.Property(e => e.PrdId).HasColumnName("PRD_ID");
            entity.Property(e => e.OptionSize).HasColumnName("OPTION_SIZE");
            entity.Property(e => e.OptionType).HasColumnName("OPTION_TYPE");
            entity.Property(e => e.Note)
                .HasColumnType("text")
                .HasColumnName("NOTE");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartDetails)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CART__CART_DETAIL");

            entity.HasOne(d => d.Prd).WithMany(p => p.CartDetails)
                .HasForeignKey(d => d.PrdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCT__CART_DETAIL");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CgrId);

            entity.ToTable("CATEGORY");

            entity.Property(e => e.CgrId)
                .ValueGeneratedNever()
                .HasColumnName("CGR_ID");
            entity.Property(e => e.CgrName)
                .HasMaxLength(40)
                .HasColumnName("CGR_NAME");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("COMMENT");

            entity.Property(e => e.CommentId)
                .ValueGeneratedNever()
                .HasColumnName("COMMENT_ID");
            entity.Property(e => e.CommentText)
                .HasColumnType("text")
                .HasColumnName("COMMENT_TEXT");
            entity.Property(e => e.CtrId).HasColumnName("CTR_ID");
            entity.Property(e => e.PrdId).HasColumnName("PRD_ID");
            entity.Property(e => e.Upvote).HasColumnName("UPVOTE");

            entity.HasOne(d => d.Ctr).WithMany(p => p.Comments)
                .HasForeignKey(d => d.CtrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CUSTOMER__COMMENT");

            entity.HasOne(d => d.Prd).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PrdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCT__COMMENT");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CtrId).HasName("PK_CTR");

            entity.ToTable("CUSTOMER");

            entity.Property(e => e.CtrId)
                .ValueGeneratedNever()
                .HasColumnName("CTR_ID");
            entity.Property(e => e.CtrAccess).HasColumnName("CTR_ACCESS");
            entity.Property(e => e.CtrEmail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CTR_EMAIL");
            entity.Property(e => e.CtrGender).HasColumnName("CTR_GENDER");
            entity.Property(e => e.CtrImage)
                .HasColumnType("text")
                .HasColumnName("CTR_IMAGE");
            entity.Property(e => e.CtrLogusername)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CTR_LOGUSERNAME");
            entity.Property(e => e.CtrPassword)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CTR_PASSWORD");
            entity.Property(e => e.CtrPhonenumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CTR_PHONENUMBER");
            entity.Property(e => e.CtrUsed)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("CTR_USED");
            entity.Property(e => e.CtrUsername)
                .HasMaxLength(40)
                .HasColumnName("CTR_USERNAME");

            entity.HasOne(d => d.CtrAccessNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CtrAccess)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ACCESS__CUSTOMER");
        });

        modelBuilder.Entity<Ord>(entity =>
        {
            entity.ToTable("ORD");

            entity.Property(e => e.OrdId)
                .ValueGeneratedNever()
                .HasColumnName("ORD_ID");
            entity.Property(e => e.CartId).HasColumnName("CART_ID");
            entity.Property(e => e.OrdDate)
                .HasColumnType("datetime")
                .HasColumnName("ORD_DATE");
            entity.Property(e => e.OrdDest)
                .HasMaxLength(50)
                .HasColumnName("ORD_DEST");
            entity.Property(e => e.OrdNote)
                .HasColumnType("text")
                .HasColumnName("ORD_NOTE");
            entity.Property(e => e.OrdPrice)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("ORD_PRICE");
            entity.Property(e => e.OrdStatus).HasColumnName("ORD_STATUS");
            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");

            entity.HasOne(d => d.Cart).WithMany(p => p.Ords)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CART__ORD");

            entity.HasOne(d => d.Staff).WithMany(p => p.Ords)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CUSTOMER__ORD");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.PrdId);

            entity.ToTable("PRODUCT");

            entity.Property(e => e.PrdId)
                .ValueGeneratedNever()
                .HasColumnName("PRD_ID");
            entity.Property(e => e.CgrId).HasColumnName("CGR_ID");
            entity.Property(e => e.PrdDesc)
                .HasColumnType("text")
                .HasColumnName("PRD_DESC");
            entity.Property(e => e.PrdImage)
                .HasColumnType("text")
                .HasColumnName("PRD_IMAGE");
            entity.Property(e => e.PrdName)
                .HasMaxLength(40)
                .HasColumnName("PRD_NAME");
            entity.Property(e => e.PrdPrice)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("PRD_PRICE");
            entity.Property(e => e.PrdStatus).HasColumnName("PRD_STATUS");

            entity.HasOne(d => d.Cgr).WithMany(p => p.Products)
                .HasForeignKey(d => d.CgrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CATEGORY__PRODUCT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
