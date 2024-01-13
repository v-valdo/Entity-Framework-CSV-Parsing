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
                    if (Exists(UserPath))
                    {
                        Console.WriteLine("user.csv exists");
                    }
                    else { Console.WriteLine("user file doesnt exist"); }
                    break;

                case Entity.post:
                    if (Exists(PostPath))
                    {
                        Console.WriteLine("post.csv exists");
                    }
                    else { Console.WriteLine("post file doesnt exist"); }
                    break;

                case Entity.blog:
                    if (Exists(BlogPath))
                    {
                        Console.WriteLine("blog.csv exists");
                    }
                    else { Console.WriteLine("blog file doesnt exist"); }
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
}

public enum Entity
{
    user = 1,
    post,
    blog
}
