using UnlockCells.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace UnlockCells.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			List<DataPoint> dataPoints = new List<DataPoint>();

			dataPoints.Add(new DataPoint("User1", 25));   // momentan sunt hard codate, dar le vom modifica in asa fel incat sa ia userii din baza de date
			dataPoints.Add(new DataPoint("User2", 13));
			dataPoints.Add(new DataPoint("User3", 8));
			dataPoints.Add(new DataPoint("User4", 7));
			dataPoints.Add(new DataPoint("User5", 6.8));
			dataPoints.Add(new DataPoint("User6", 40.2));

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

			return View();
		}
	}
}