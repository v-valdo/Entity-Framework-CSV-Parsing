using CSValdemarSersam;


using var db = new BlogContext();
CsvFile file = new();

// List<string> postfields = posts.Select(line => line.Split(",").ToList()).ToList();

// --------------- UPLOAD POSTS --------------------

if (file.Exists(file.Path(Entity.user)))
{
    string[] posts = file.Load("post");

    Console.WriteLine("uploading posts");

    int filesUploaded = 1;

    foreach (string post in posts)
    {
        Console.WriteLine(filesUploaded);

        Thread.Sleep(150);

        filesUploaded++;

        string[] parts = post.Split(",");

        Post p = new Post
        {
            Id = Convert.ToInt32(parts[0]),
            Title = parts[1],
            Content = parts[2],
            Published_On = DateTime.TryParse(parts[3], out DateTime n) ? n : DateTime.Now,
            BlogId = Convert.ToInt32(parts[4]),
            UserId = Convert.ToInt32(parts[5])
        };

        db.Posts.Add(p);
    }

    db.SaveChanges();

    Console.WriteLine($"successfully uploaded {filesUploaded - 1} posts");
}

