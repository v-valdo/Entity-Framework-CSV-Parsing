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

            Console.WriteLine($"uploading {e}");

            List<string> parts = new();

            foreach (var line in all)
            {
                string[] split = line.Split(",");
                parts.AddRange(split);
            }

            // string[] filteredTable = CsvFile.Filter(parts.ToArray());

            CsvFile.Filter(parts.ToArray());

            // Add(e, filteredTable);

            Console.WriteLine($"successfully uploaded files of type {e}");
        }
    }

    public string Add(Entity e, string[] data)
    {
        switch (e)
        {
            case Entity.user:
                {
                    for (int i = 0; i < data.Length; i += 4)
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
                    Post p = new Post
                    {
                        Id = Convert.ToInt32(data[0]),
                        Title = data[1],
                        Content = data[2],
                        Published_On = DateTime.TryParse(data[3], out DateTime n) ? n : DateTime.Now,
                        BlogId = Convert.ToInt32(data[4]),
                        UserId = Convert.ToInt32(data[5])
                    };
                    db.Posts.Add(p);
                    db.SaveChanges();
                    return "Posts successfully added";
                }
        }
        return "Failed";
    }
}
