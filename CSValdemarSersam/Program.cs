using CSValdemarSersam;
// CsvFile file = new();

// lambda??
// List<string> postfields = posts.Select(line => line.Split(",").ToList()).ToList();

DataManager d = new();

var db = new BlogContext();

// db.Database.ExecuteSqlRaw("delete from users");

d.Upload(Entity.user);


//Thread.Sleep(100);
//d.Upload(Entity.blog);

//Thread.Sleep(100);
//d.Upload(Entity.post);

//Thread.Sleep(100);

