using CSValdemarSersam;
using System.Data.Common;
using var db = new BlogContext();

string UserPath = "../../../csv/user.csv";
string BlogPath = "../../csv/user.csv";
string PostPath = "../../../csv/user.csv";
// ---- pseudo-pseudo ----
// Via csvfile klassen:
// paths & listor --> users, posts,blogs (addrange?)
// Id = CsvFile.GetId(users)? etc..
// Query db
// Streamreader --> visa "träd"

// ---- pseudo ----
// encapsulate med enum? ->
// CsvFile.Upload(users)
// CsvFile.Upload(blogs)
// CsvFile.Upload(posts)
// 

new CsvFile().Load("user");

