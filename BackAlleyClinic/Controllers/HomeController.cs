using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BackAlleyClinic.Models;

namespace BackAlleyClinic.Controllers
{
  public class HomeController : Controller
  {
    private readonly BackAlleyClinicContext _db;

    public HomeController(BackAlleyClinicContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Doctor> model = _db.Doctors.ToList();
      return View(model);
    }
  }
}