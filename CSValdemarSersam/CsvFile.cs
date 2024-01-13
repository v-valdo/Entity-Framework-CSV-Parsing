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

    public void Load(string e)
    {
        if (Enum.TryParse(e, out Entity result))
        {
            switch (result)
            {
                case Entity.user:

                    break;

                case Entity.post:

                    break;

                case Entity.blog:

                    break;
                default:
                    Console.WriteLine($"Failed to parse CSV file of type {e}");
                    break;
            }
        }
    }
    public bool Exists(string path)
    {
        if (!File.Exists(path))
        {
            return false;
        }
        else { return true; }
    }

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

public enum Entity
{
    user = 1,
    post,
    blog
}
