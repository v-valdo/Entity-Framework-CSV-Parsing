using CSValdemarSersam;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
// CsvFile file = new();

// lambda??
// List<string> postfields = posts.Select(line => line.Split(",").ToList()).ToList();

DataManager d = new();
var db = new BlogContext();
string qDeleteAll = "delete from users; delete from blogs; delete from posts;";
db.Database.ExecuteSqlRaw(qDeleteAll);
Console.ReadKey();
Console.Clear();

// Upload Users
d.Upload(Entity.user);
Console.ReadKey();
Console.Clear();

// Upload Blogs
d.Upload(Entity.blog);
Console.ReadKey();
Console.Clear();

// Upload Posts
d.Upload(Entity.post);
Console.ReadKey();
Console.Clear();

var blogs = db.Blogs;
var users = db.Users;
var posts = db.Posts;

foreach (var b in blogs)
{
    Console.WriteLine($"Id: {b.Id}, Url: {b.Url}, Name: {b.Name}");
}
Console.ReadKey();
Console.Clear();

foreach (var p in posts)
{
    Console.WriteLine($"Id: {p.Id}, Title: {p.Title}, Contents: {p.Content}, Published: {p.Published_On}, User ID: {p.UserId}, Blog ID: {p.BlogId}");
}
Console.ReadKey();
Console.Clear();

foreach (var u in users)
{
    Console.WriteLine($"Id: {u.Id}, Name: {u.Username}, Password: {u.Password}");
}





//Thread.Sleep(100);
//d.Upload(Entity.blog);

//Thread.Sleep(100);
//d.Upload(Entity.post);

//Thread.Sleep(100);

