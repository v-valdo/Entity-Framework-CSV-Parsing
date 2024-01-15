namespace CSValdemarSersam;

public class DataManager
{
    private CsvFile file;
    public BlogContext db;

    public DataManager()
    {
        file = new CsvFile();
        db = new BlogContext();
    }

    public void Upload(Entity e)
    {
        if (file.Exists(file.Path(e)))
        {
            string[] all = file.Load($"{e}");

            Console.WriteLine($"uploading {e}s");

            string[] columnData = file.Filter(e, all);

            foreach (var line in columnData)
            {
                Console.WriteLine(line);
            }

            // string[] filteredTable = CsvFile.Filter(parts.ToArray());

            Add(e, columnData);

            Console.WriteLine($"successfully uploaded files of type {e}");
        }
    }

    public string Add(Entity e, string[] data)
    {
        switch (e)
        {
            case Entity.user:
                {
                    for (int i = 0; i < data.Length; i += 3)
                    {
                        User u = new User
                        {
                            Id = Convert.ToInt32(data[i]),
                            Username = data[i + 1],
                            Password = data[i + 2],
                        };
                        db.Users.Add(u);
                    }
                    db.SaveChanges();
                    return "Users successfully added";
                }
            case Entity.post:
                {
                    for (int i = 0; i < data.Length; i += 6)
                    {
                        Post p = new Post
                        {
                            Id = Convert.ToInt32(data[i]),
                            Title = data[i + 1],
                            Content = data[i + 2],
                            Published_On = DateTime.TryParse(data[i + 3], out DateTime n) ? n : DateTime.Now,
                            BlogId = Convert.ToInt32(data[i + 4]),
                            UserId = Convert.ToInt32(data[i + 5])
                        };
                        db.Posts.Add(p);
                    }
                }
                db.SaveChanges();
                return "Posts successfully added";

            case Entity.blog:
                {
                    for (int i = 0; i < data.Length; i += 3)
                    {
                        Blog b = new Blog
                        {
                            Id = Convert.ToInt32(data[i]),
                            Url = data[i + 1],
                            Name = data[i + 2],
                        };
                        db.Blogs.Add(b);
                    }
                }
                db.SaveChanges();
                return "Blogs successfully added";
        }
        return "Failed";
    }
}
