namespace CSValdemarSersam;

public class DataManager
{
    private CsvFile file;
    private BlogContext Db;

    public DataManager(BlogContext db)
    {
        file = new CsvFile();
        Db = db;
    }

    public void Upload(Entity e)
    {
        if (file.Exists(file.Path(e)))
        {
            string[] all = file.Load($"{e}");

            string[] columnData = file.Filter(e, all);

            Add(e, columnData);

            Console.Clear();
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
                            UserId = Convert.ToInt32(data[i]),
                            Username = data[i + 1],
                            Password = data[i + 2],
                        };
                        Db.Users.Add(u);
                    }
                    Db.SaveChanges();
                    return "Users successfully added";
                }

            case Entity.post:
                {
                    for (int i = 0; i < data.Length; i += 6)
                    {
                        Post p = new Post
                        {
                            PostId = Convert.ToInt32(data[i]),
                            Title = data[i + 1],
                            Content = data[i + 2],
                            Published_On = DateTime.TryParse(data[i + 3], out DateTime n) ? n : DateTime.Now,
                            BlogId = Convert.ToInt32(data[i + 4]),
                            UserId = Convert.ToInt32(data[i + 5])
                        };
                        Db.Posts.Add(p);
                    }
                    Db.SaveChanges();
                }
                return "Posts successfully added";

            case Entity.blog:
                {
                    for (int i = 0; i < data.Length; i += 3)
                    {
                        Blog b = new Blog
                        {
                            BlogId = Convert.ToInt32(data[i]),
                            Url = data[i + 1],
                            Name = data[i + 2],
                        };
                        Db.Blogs.Add(b);
                    }
                    Db.SaveChanges();
                }
                return "Blogs successfully added";
        }
        return "Failed";
    }
}