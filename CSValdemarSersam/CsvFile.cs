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
    private string BlogPath = "../../csv/user.csv";
    private string PostPath = "../../../csv/user.csv";

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
                    else { Console.WriteLine("nope"); }
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
}

public enum Entity
{
    user = 1,
    post,
    blog
}
