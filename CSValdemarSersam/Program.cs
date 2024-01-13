using CSValdemarSersam;
using System.Data.Common;

using var db = new BlogContext();

string users = new CsvFile().Path(Entity.user);
Console.WriteLine(users);

new CsvFile().Load("user");
new CsvFile().Load("post");
new CsvFile().Load("blog");


