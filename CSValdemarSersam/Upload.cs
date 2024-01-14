using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSValdemarSersam;

public class Upload
{
    private CsvFile file;
    public BlogContext db;
    public Upload()
    {
        file = new CsvFile();
        db = new BlogContext();
    }

    public void File(Entity e)
    {
        if (file.Exists(file.Path(e)))
        {
            string[] all = file.Load($"{e}");

            Console.WriteLine("uploading posts");

            int filesUploaded = 1;

            foreach (string line in all)
            {
                Console.WriteLine(filesUploaded);

                Thread.Sleep(150);

                filesUploaded++;

                string[] parts = line.Split(",");

                switch (e)
                {
                    case Entity.user:
                        {
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
                            break;
                        }
                }

                db.SaveChanges();

                Console.WriteLine($"successfully uploaded {filesUploaded - 1} posts");
            }
        }
    }

    public string Insert(Entity e, string[] data)
    {
        switch (e)
        {
            case Entity.user:
                {
                    User u = new User
                    {
                        Id = Convert.ToInt32(data[0]),
                        Username = data[1],
                        Password = data[2],
                    };
                    db.Users.Add(u);

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

                    return "Posts successfully added";

                }
        }
    }
}
