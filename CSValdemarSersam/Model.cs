using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class BlogContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Blog> Blogs { get; set; }

    public string DbPath { get; }

    public BlogContext()
    {
        DbPath = $"{Environment.CurrentDirectory}valdemarsersam.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={DbPath}");
}

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Published_On { get; set; }

    public Blog Blog { get; set; }
    public int BlogId { get; set; }

    public User User { get; set; }
    public int UserId { get; set; }

}

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }

    public List<Post>? Posts { get; }
}

public class Blog
{
    public int Id { get; set; }
    public string? Url { get; set; }
    public string? Name { get; set; }

    public List<Post>? Posts { get; set; }
}
