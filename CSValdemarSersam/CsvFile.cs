using System.Xml;

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

    public string[] Filter(string[] rawFile)
    {
        List<string> uniques = new List<string>();

        for (int i = 0; i < rawFile.Length; i++)
        {
            string[] values = rawFile[i].Split(',');

            if (!uniques.Contains(values[0]))
            {
                uniques.Add(values[0]);
                uniques.Add(values[1]);
                uniques.Add(values[2]);
            }
        }

        return uniques.ToArray();
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
