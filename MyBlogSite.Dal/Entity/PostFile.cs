﻿using System.ComponentModel.DataAnnotations.Schema;
using MyBlogSite.Dal.Entity.Abstract;

namespace MyBlogSite.Dal.Entity;

public class PostFile : BaseEntity
{
    [ForeignKey("post_id")]
    [Column("post_id")]
    public required Guid PostId { get; set; }
    
    public Post? Post { get; set; }
    
    [Column("file_name", TypeName = "varchar(4000)")]
    public required string FileName { get; set; }
    
    [Column("file_type", TypeName = "varchar(4000)")]
    public required string FileType { get; set; }
    
    [Column("file_url", TypeName = "varchar(4000)")]
    public required string FileUrl { get; set; }
    
    [Column("file_directory", TypeName = "varchar(4000)")]
    public required string FileDirectory { get; set; }
    
    [Column("is_main_file")]
    public required bool IsMainFile { get; set; }
}