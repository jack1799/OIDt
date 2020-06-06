using Newtonsoft.Json;
using OIDt.Models;
using OIDt.Models.DB;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OIDt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            JsonLoader("[{\"udid\": \"guid\", \"date\": \"date\",\"event_id\": 1, \"parameters\": {\"key1\": \"val1\",\"key2\": \"val2\"}}]");
            return View();
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

        public void JsonLoader(string json)
        {
            List<LoadData> data = JsonConvert.DeserializeObject<List<LoadData>>(json);
            for (int i = 0; i < data.Count; i++)
            {
                switch (data[i].event_id)
                {
                    case 1:
                        db.GameStarts.Add(new GameStarts { EventDate = data[i].date, UserId = data[i].udid, User = db.Userss.FirstOrDefault(x => x.UserId == data[i].udid) });
                        break;
                    case 2:
                        db.Userss.Add(new Users { UserId = data[i].udid });
                        db.UserDatas.Add(new UserData { EventDate = data[i].date, UserId = data[i].udid, User = db.Userss.FirstOrDefault(x => x.UserId == data[i].udid), Gender = data[i].parameters["gender"], Age = int.Parse(data[i].parameters["age"]), Country = data[i].parameters["country"] });
                        break;
                    case 3:
                        db.StartStages.Add(new StartStages { EventDate = data[i].date, UserId = data[i].udid, User = db.Userss.FirstOrDefault(x => x.UserId == data[i].udid), Stage = int.Parse(data[i].parameters["stage"]) });
                        break;
                    case 4:
                        db.EndStages.Add(new EndStages { EventDate = data[i].date, UserId = data[i].udid, User = db.Userss.FirstOrDefault(x => x.UserId == data[i].udid), Stage = int.Parse(data[i].parameters["stage"]), Win = bool.Parse(data[i].parameters["win"]), Time = int.Parse(data[i].parameters["time"]), Income = int.Parse(data[i].parameters["income"]) });
                        break;
                    case 5:
                        db.ItemPurchases.Add(new ItemPurchases { EventDate = data[i].date, UserId = data[i].udid, User = db.Userss.FirstOrDefault(x => x.UserId == data[i].udid), Item = data[i].parameters["item"], Price = int.Parse(data[i].parameters["price"]) });
                        break;
                    case 6:
                        db.CreditsPurchases.Add(new CreditsPurchase { EventDate = data[i].date, UserId = data[i].udid, User = db.Userss.FirstOrDefault(x => x.UserId == data[i].udid), Name = data[i].parameters["name"], Price = int.Parse(data[i].parameters["price"]), Income = int.Parse(data[i].parameters["income"]) });
                        break;
                }
            }
            db.SaveChanges();
        }
    }
}