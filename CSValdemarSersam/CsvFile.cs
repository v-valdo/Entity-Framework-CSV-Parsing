using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSValdemarSersam;

public class CsvFile
{
    private string UserPath = "../../../csv/user.csv";
    private string BlogPath = "../../../csv/blog.csv";
    private string PostPath = "../../../csv/post.csv";

    public CsvFile()
    {

    }

    public string[] Load(string e)
    {
        if (Enum.TryParse(e, out Entity type))
        {
            switch (type)
            {
                case Entity.user:
                    return File.ReadAllLines(UserPath).Skip(1).ToArray();
                case Entity.post:
                    return File.ReadAllLines(PostPath).Skip(1).ToArray();
                case Entity.blog:
                    return File.ReadAllLines(BlogPath).Skip(1).ToArray();
                default:
                    Console.WriteLine($"Failed to parse CSV file for {e}s");
                    break;
            }
        }
        return null;
    }
    public bool Exists(string path) => File.Exists(path);

    public string Path(Enum entity)
    {
        switch (entity)
        {
            case Entity.user: return UserPath;
            case Entity.post: return PostPath;
            case Entity.blog: return BlogPath;
            default:
                return "NoPath";
        }
    }
}
