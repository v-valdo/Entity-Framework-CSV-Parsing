using CSValdemarSersam;
using CSValdemarSersam.Migrations;
using Microsoft.EntityFrameworkCore;

using var db = new BlogContext();

DataManager data = new(db);

//// Clear & Upload

// DeleteTables();
//data.Upload(Entity.user);
//data.Upload(Entity.blog);
//data.Upload(Entity.post);

ShowTree(db);

void ShowTree(BlogContext db)
{
    // eagerly loading
    // https://learn.microsoft.com/en-us/ef/ef6/querying/related-data

    var blogs1 = db.Blogs.Include(b => b.Posts).ToList();
    var users1 = db.Users.Include(u => u.Posts).ToList();

    Console.Clear();
    foreach (var user in db.Users)
    {
        Console.WriteLine($"user: {user.Username}");
        foreach (var post in user.Posts)
        {
            Console.WriteLine($"  post: {post.Title}");
            Console.WriteLine($"    blog: {post.Blog.Name}");
        }
        Console.WriteLine();
    }
}

void DeleteTables()
{
    db.Blogs.RemoveRange(db.Blogs.ToList());
    db.Users.RemoveRange(db.Users.ToList());
    db.Posts.RemoveRange(db.Posts.ToList());
    db.SaveChanges();
    Console.WriteLine("tables cleared");
    Console.ReadKey();
}