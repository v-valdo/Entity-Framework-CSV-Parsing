using Microsoft.EntityFrameworkCore;
using System;
using System.Xml.Linq;

public class BlogContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Blog> Blogs { get; set; }

    public string DbPath { get; }

    public BlogContext()
    {
        DbPath = ("valdemarsersam2.db");
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}
public class User
{
    public int UserId { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }

    public List<Post> Posts { get; } = new();
}

public class Blog
{
    public int BlogId { get; set; }
    public string? Url { get; set; }
    public string? Name { get; set; }

    public List<Post> Posts { get; } = new();
}
public class Post
{
    public int PostId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime Published_On { get; set; }

    public Blog? Blog { get; set; }
    public int BlogId { get; set; }

    public User? User { get; set; }
    public int UserId { get; set; }
}