﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBlogSite.Data;

#nullable disable

namespace MyBlogSite.Migrations
{
    [DbContext(typeof(ContextDb))]
    [Migration("20240610124242_mig_1")]
    partial class mig_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyBlogSite.Entity.Blog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("title");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("type_id");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("blogs");
                });

            modelBuilder.Entity("MyBlogSite.Entity.BlogComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("BlogId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("blog_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("full_name");

                    b.Property<bool>("IsItApproved")
                        .HasColumnType("bit")
                        .HasColumnName("is_it_approved");

                    b.Property<Guid?>("RepliedCommentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("replied_comment_id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("text");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("blog_comments");
                });

            modelBuilder.Entity("MyBlogSite.Entity.BlogLike", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("BlogId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("blog_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("email");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("blog_likes");
                });

            modelBuilder.Entity("MyBlogSite.Entity.BlogProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("BlogId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("blog_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<int>("NumberOfViews")
                        .HasColumnType("int")
                        .HasColumnName("number_of_views");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("blog_properties");
                });

            modelBuilder.Entity("MyBlogSite.Entity.BlogType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("type_name");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.ToTable("blog_types");
                });

            modelBuilder.Entity("MyBlogSite.Entity.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid?>("BlogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("TicketName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("ticket_name");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("tickets");
                });

            modelBuilder.Entity("MyBlogSite.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("password");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_date");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("MyBlogSite.Entity.Blog", b =>
                {
                    b.HasOne("MyBlogSite.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyBlogSite.Entity.BlogComment", b =>
                {
                    b.HasOne("MyBlogSite.Entity.Blog", "Blog")
                        .WithMany("BlogComments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("MyBlogSite.Entity.BlogLike", b =>
                {
                    b.HasOne("MyBlogSite.Entity.Blog", "Blog")
                        .WithMany("BlogLikes")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("MyBlogSite.Entity.BlogProperty", b =>
                {
                    b.HasOne("MyBlogSite.Entity.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("MyBlogSite.Entity.Ticket", b =>
                {
                    b.HasOne("MyBlogSite.Entity.Blog", null)
                        .WithMany("Tickets")
                        .HasForeignKey("BlogId");
                });

            modelBuilder.Entity("MyBlogSite.Entity.Blog", b =>
                {
                    b.Navigation("BlogComments");

                    b.Navigation("BlogLikes");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}