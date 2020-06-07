using Newtonsoft.Json;
using OIDt.Models;
using OIDt.Models.DB;
using Syncfusion.EJ2.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OIDt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private string testJson = "[{\"udid\": \"guid\", \"date\": \"date\",\"event_id\": 1, \"parameters\": {\"key1\": \"val1\",\"key2\": \"val2\"}}]";

        private static int count;
        private static Users user = new Users { UserId = "-1" };

        private static List<GameStarts> GameStarts = new List<GameStarts>();
        private static List<Users> Users = new List<Users>();
        private static List<UserData> UserData = new List<UserData>();
        private static List<StartStages> StartStages = new List<StartStages>();
        private static List<EndStages> EndStages = new List<EndStages>();
        private static List<ItemPurchases> ItemPurchases = new List<ItemPurchases>();
        private static List<CreditsPurchase> CreditsPurchase = new List<CreditsPurchase>();

        private int predictionCount = 6;

        public async Task<ActionResult> Index()
        {
            //DirectoryInfo d = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "json\\"));//Assuming Test is your Folder
            //FileInfo[] Files = d.GetFiles("*.json"); //Getting Text files
            //string str;
            ////List of files
            //for (int i = 226; i < Files.Length; i++)
            //{
            //    //Selected file
            //    //int i = 1;
            //    using (StreamReader sr = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "json\\", Files[i].Name)))
            //    {
            //        str = sr.ReadToEnd();
            //    }
            //    await JsonLoader(str);
            //}

            //DateTime day = new DateTime(2018, 01, 07);
            ////DAU
            //int change = (13865 + 24446 + 24717 + 24798 + 24750 + 49563 + 49610) / 7 * 30;
            //int y = 49610;
            //List<ChartData> chartData = new List<ChartData>
            //{
            //    new ChartData { x= "01.01.2018", y= 13865 },
            //    new ChartData { x= "01.01.2018", y= 24446 },
            //    new ChartData { x= "01.01.2018", y= 24717 },
            //    new ChartData { x= "01.01.2018", y= 24798 },
            //    new ChartData { x= "01.01.2018", y= 24750 },
            //    new ChartData { x= "01.01.2018", y= 49563 },
            //    new ChartData { x= "01.01.2018", y= 49610 }
            //};
            ////Users
            //int change = (13865 + 26241 + 24717 + 24798 + 24750 + 49563 + 49610) / 7 * 30;
            //int y = 49610;
            //List<ChartData> chartData = new List<ChartData>
            //{
            //    new ChartData { x= "01.01.2018", y= 13865 },
            //    new ChartData { x= "01.01.2018", y= 26241 },
            //    new ChartData { x= "01.01.2018", y= 24717 },
            //    new ChartData { x= "01.01.2018", y= 24798 },
            //    new ChartData { x= "01.01.2018", y= 24750 },
            //    new ChartData { x= "01.01.2018", y= 49563 },
            //    new ChartData { x= "01.01.2018", y= 49610 }
            //};
            ////Revenue
            //int change = (20255 + 36740 + 34723 + 37188 + 38502 + 74142 + 74982) / 7 * 30;
            //int y = 74982;
            //List<ChartData> chartData = new List<ChartData>
            //{
            //    new ChartData { x= "01.01.2018", y= 20255 },
            //    new ChartData { x= "01.01.2018", y= 36740 },
            //    new ChartData { x= "01.01.2018", y= 34723 },
            //    new ChartData { x= "01.01.2018", y= 37188 },
            //    new ChartData { x= "01.01.2018", y= 38502 },
            //    new ChartData { x= "01.01.2018", y= 74142 },
            //    new ChartData { x= "01.01.2018", y= 74982 }
            //};
            ////Count saled items
            //int change = (3356 + 6061 + 6247 + 6434 + 6522 + 13615 + 13631) / 7 * 30;
            //int y = 13631;
            //List<ChartData> chartData = new List<ChartData>
            //{
            //    new ChartData { x= "01.01.2018", y= 3356 },
            //    new ChartData { x= "01.01.2018", y= 6061 },
            //    new ChartData { x= "01.01.2018", y= 6247 },
            //    new ChartData { x= "01.01.2018", y= 6434 },
            //    new ChartData { x= "01.01.2018", y= 6522 },
            //    new ChartData { x= "01.01.2018", y= 13615 },
            //    new ChartData { x= "01.01.2018", y= 13631 }
            //};
            ////Count saled items
            //int change = (99706 + 178202 + 177811 + 178573 + 178045 + 362479 + 356644) / 7 * 30;
            //int y = 356644;
            //List<ChartData> chartData = new List<ChartData>
            //{
            //    new ChartData { x= "01.01.2018", y= 99706 },
            //    new ChartData { x= "01.01.2018", y= 178202 },
            //    new ChartData { x= "01.01.2018", y= 177811 },
            //    new ChartData { x= "01.01.2018", y= 178573 },
            //    new ChartData { x= "01.01.2018", y= 178045 },
            //    new ChartData { x= "01.01.2018", y= 362479 },
            //    new ChartData { x= "01.01.2018", y= 356644 }
            //};
            //for (int i = 0; i < predictionCount; i++)
            //{
            //    y += change;
            //    day = day.AddMonths(1);
            //    chartData.Add(new ChartData { x = day.ToShortDateString(), y = y });
            //}
            //ViewBag.dataSource = chartData;

            ////Group by Gender
            //ViewBag.dataSource = db.UserDatas.GroupBy(x => new { x.EventDate, x.Gender }).Select(x => new { x.Key.EventDate, x.Key.Gender, Count = x.Count() }).OrderBy(x => new { x.EventDate, x.Gender }).ToList();

            ////Group by Age
            //ViewBag.dataSource = db.UserDatas.GroupBy(x => new { x.EventDate, x.Age }).Select(x => new { x.Key.EventDate, x.Key.Age, Count = x.Count() }).OrderBy(x => new { x.EventDate, x.Age }).ToList();

            ////Group by Country
            //ViewBag.dataSource = db.UserDatas.GroupBy(x => new { x.EventDate, x.Country }).Select(x => new { x.Key.EventDate, x.Key.Country, Count = x.Count() }).OrderBy(x => x.EventDate).ToList();

            ////Group by user pay
            //string s = db.CreditsPurchases.ToList().LastOrDefault().EventDate;
            //var list = db.CreditsPurchases.Where(x => x.EventDate == s).GroupBy(x => x.UserId).Select(x => new UserPrice { User = x.Key, Price = x.Sum(v => v.Price) }).ToList();
            //var userList = db.GameStarts.Where(x => x.EventDate == s).GroupBy(x => x.UserId).Select(x => x.Key).ToList();
            //for (int i = 0; i < userList.Count; i++)
            //{
            //    if (list.FirstOrDefault(x => x.User == userList[i]) == null)
            //    {
            //        list.Add(new UserPrice { User = userList[i], Price = 0 });
            //    }
            //}
            //for (int i = 0; i < list.Count; i++)
            //{
            //    list[i].Tear = GetTear(list[i].Price);
            //}
            //ViewBag.dataSource = list.GroupBy(x => x.Tear).Select(x => new { Tear = x.Key, Count = x.Count() }).ToList();

            ////Find users who violated the rules of the economy
            //ViewBag.dataSource = db.Userss.Where(x => db.ItemPurchases.GroupBy(y => new { y.UserId, y.Price }).Where(y => y.Key.UserId == x.UserId).Sum(y => y.Key.Price) > db.EndStages.GroupBy(y => new { y.UserId, y.Income }).Where(y => y.Key.UserId == x.UserId).Sum(y => y.Key.Income)).Select(x => new { User = x.UserId }).ToList();

            return View();
        }

        private static readonly int[] tears = new int[] { 0, 5, 10, 20 };

        private string GetTear(float price)
        {
            for (int i = 0; i < tears.Length; i++)
            {
                if (price <= tears[i])
                {
                    return "Tear " + i;
                }
            }
            return "Tear " + (tears.Length - 1);
        }

        private class UserPrice
        {
            public string User;
            public float Price;
            public string Tear;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task JsonLoader(string json)
        {
            List<LoadData> data = JsonConvert.DeserializeObject<List<LoadData>>(json).OrderBy(x => x.udid).ToList();
            for (int i = 0; i < data.Count; i++)
            {
                LoadGroups(data[i]);
                count++;
                if (count >= 10000 || i == data.Count - 1)
                {
                    count = 0;
                    db.GameStarts.AddRange(GameStarts);
                    db.Userss.AddRange(Users);
                    db.UserDatas.AddRange(UserData);
                    db.StartStages.AddRange(StartStages);
                    db.EndStages.AddRange(EndStages);
                    db.ItemPurchases.AddRange(ItemPurchases);
                    db.CreditsPurchases.AddRange(CreditsPurchase);
                    await db.SaveChangesAsync();
                    GameStarts.Clear();
                    Users.Clear();
                    UserData.Clear();
                    StartStages.Clear();
                    EndStages.Clear();
                    ItemPurchases.Clear();
                    CreditsPurchase.Clear();
                    GC.Collect(50, GCCollectionMode.Optimized, false);
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        public async Task Load(LoadData loadData)
        {
            switch (loadData.event_id)
            {
                case 1:
                    db.GameStarts.Add(new GameStarts { EventDate = loadData.date, UserId = loadData.udid, User = db.Userss.FirstOrDefault(x => x.UserId == loadData.udid) });
                    break;
                case 2:
                    if (db.Userss.FirstOrDefault(x => x.UserId == loadData.udid) == null)
                        db.Userss.Add(new Users { UserId = loadData.udid });
                    db.UserDatas.Add(new UserData { EventDate = loadData.date, UserId = loadData.udid, User = db.Userss.FirstOrDefault(x => x.UserId == loadData.udid), Gender = loadData.parameters["gender"], Age = int.Parse(loadData.parameters["age"]), Country = loadData.parameters["country"] });
                    break;
                case 3:
                    db.StartStages.Add(new StartStages { EventDate = loadData.date, UserId = loadData.udid, User = db.Userss.FirstOrDefault(x => x.UserId == loadData.udid), Stage = int.Parse(loadData.parameters["stage"]) });
                    break;
                case 4:
                    db.EndStages.Add(new EndStages { EventDate = loadData.date, UserId = loadData.udid, User = db.Userss.FirstOrDefault(x => x.UserId == loadData.udid), Stage = int.Parse(loadData.parameters["stage"]), Win = bool.Parse(loadData.parameters["win"]), Time = int.Parse(loadData.parameters["time"]), Income = int.Parse(loadData.parameters["income"]) });
                    break;
                case 5:
                    db.ItemPurchases.Add(new ItemPurchases { EventDate = loadData.date, UserId = loadData.udid, User = db.Userss.FirstOrDefault(x => x.UserId == loadData.udid), Item = loadData.parameters["item"], Price = float.Parse(loadData.parameters["price"], CultureInfo.InvariantCulture) });
                    break;
                case 6:
                    db.CreditsPurchases.Add(new CreditsPurchase { EventDate = loadData.date, UserId = loadData.udid, User = db.Userss.FirstOrDefault(x => x.UserId == loadData.udid), Name = loadData.parameters["name"], Price = float.Parse(loadData.parameters["price"], CultureInfo.InvariantCulture), Income = int.Parse(loadData.parameters["income"]) });
                    break;
            }
            count++;
            if (count >= 300)
            {
                count = 0;
                await db.SaveChangesAsync();
            }
        }

        public void LoadGroups(LoadData loadData)
        {
            switch (loadData.event_id)
            {
                case 1:
                    GameStarts.Add(new GameStarts { EventDate = loadData.date, UserId = loadData.udid, User = user });
                    break;
                case 2:
                    if (db.Userss.FirstOrDefault(x => x.UserId == loadData.udid) == null)
                    {
                        user = new Users { UserId = loadData.udid };
                        Users.Add(user);
                    }
                    UserData.Add(new UserData { EventDate = loadData.date, UserId = loadData.udid, User = user, Gender = loadData.parameters["gender"], Age = int.Parse(loadData.parameters["age"]), Country = loadData.parameters["country"] });
                    break;
                case 3:
                    StartStages.Add(new StartStages { EventDate = loadData.date, UserId = loadData.udid, User = user, Stage = int.Parse(loadData.parameters["stage"]) });
                    break;
                case 4:
                    EndStages.Add(new EndStages { EventDate = loadData.date, UserId = loadData.udid, User = user, Stage = int.Parse(loadData.parameters["stage"]), Win = bool.Parse(loadData.parameters["win"]), Time = int.Parse(loadData.parameters["time"]), Income = int.Parse(loadData.parameters["income"]) });
                    break;
                case 5:
                    ItemPurchases.Add(new ItemPurchases { EventDate = loadData.date, UserId = loadData.udid, User = user, Item = loadData.parameters["item"], Price = float.Parse(loadData.parameters["price"], CultureInfo.InvariantCulture) });
                    break;
                case 6:
                    CreditsPurchase.Add(new CreditsPurchase { EventDate = loadData.date, UserId = loadData.udid, User = user, Name = loadData.parameters["name"], Price = float.Parse(loadData.parameters["price"], CultureInfo.InvariantCulture), Income = int.Parse(loadData.parameters["income"]) });
                    break;
            }
        }
    }
    public class ChartData
    {
        public string x;
        public double y;
    }
}