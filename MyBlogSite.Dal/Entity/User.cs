﻿using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Core.Enums;
using MyBlogSite.Dal.Entity.Abstract;

namespace MyBlogSite.Dal.Entity;

public class User : BaseEntity
{
    [Column("name", TypeName = "varchar(100)")]
    public required string Name { get; set; }
    
    [Column("surname", TypeName = "varchar(100)")]
    public required string Surname { get; set; }
    
    [Column("username", TypeName = "varchar(100)")]
    public required string Username { get; set; }

    [Column("email", TypeName = "varchar(200)")] 
    public required string Email { get; set; }

    [Column("password", TypeName = "varchar(300)")]
    public required string Password { get; set; }

    [Column("is_banned")] 
    public required bool IsBanned { get; set; }
    
    [Column("is_active")] 
    public required bool IsActive { get; set; }

    [Column("role")]
    public RoleEnum Role { get; set; }
    
    [ForeignKey("blog_id")]
    [Column("blog_id")]
    public required Guid? BlogId { get; set; }

    public Blog? Blog { get; set; }
}
