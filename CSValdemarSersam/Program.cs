using CSValdemarSersam;
using CSValdemarSersam.Migrations;
using Microsoft.EntityFrameworkCore;


using var db = new BlogContext();

DataManager data = new(db);

//// clear tables
//db.Blogs.RemoveRange(db.Blogs.ToList());
//db.Users.RemoveRange(db.Users.ToList());
//db.Posts.RemoveRange(db.Posts.ToList());
//db.SaveChanges();
//Console.WriteLine("tables cleared");
//Console.ReadKey();

//// Upload Users
//data.Upload(Entity.user);
//Console.ReadKey();
//Console.Clear();

//// Upload Blogs
//data.Upload(Entity.blog);
//Console.ReadKey();
//Console.Clear();

//// Upload Posts
//data.Upload(Entity.post);
//Console.ReadKey();
//Console.Clear();

ShowTree(db);

void ShowTree(BlogContext db)
{
    db.Users.ToArray();
    var bt = db.Blogs.ToList();
    db.Posts.ToList();
    // ^ ToList laddar dem tydligen korrekt

    Console.WriteLine("THE TRÄD:");

    foreach (var user in db.Users)
    {
        Console.WriteLine($"User: {user.Username}");
        foreach (var post in user.Posts)
        {
            Console.WriteLine($" Post Title: {post.Title}");
            Console.WriteLine($"    Blog Name: {post.Blog.Name}");
        }
    }
}


//foreach (var b in blogs)
//{
//    Console.WriteLine($"Id: {b.Id}, Url: {b.Url}, Name: {b.Name}");
//    Console.WriteLine($"{b.Posts}");
//}
//Console.ReadKey();
//Console.Clear();

//foreach (var p in posts)
//{
//    Console.WriteLine($"Id: {p.Id}, Title: {p.Title}, Contents: {p.Content}, Published: {p.Published_On}, User ID: {p.UserId}, Blog ID: {p.BlogId}");
//}
//Console.ReadKey();
//Console.Clear();

//foreach (var u in users)
//{
//    Console.WriteLine($"Id: {u.Id}, Name: {u.Username}, Password: {u.Password}");
//}