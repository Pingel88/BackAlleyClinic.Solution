using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BackAlleyClinic.Models;

namespace BackAlleyClinic.Controllers
{
  public class DoctorsController : Controller
  {
    private readonly BackAlleyClinicContext _db;
    public DoctorsController(BackAlleyClinicContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Doctor> model = _db.Doctors.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Doctor doctor)
    {
      _db.Doctors.Add(doctor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Doctor thisDoctor = _db.Doctors
        .Include(doctor => doctor.JoinEntities)
        .ThenInclude(join => join.Patient)
        .FirstOrDefault(doctor => doctor.DoctorId == id);
      return View(thisDoctor);
    }

    public ActionResult Edit(int id)
    {
      Doctor thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
      return View(thisDoctor);
    }

    [HttpPost]
    public ActionResult Edit(Doctor doctor)
    {
      _db.Entry(doctor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Doctor thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
      return View(thisDoctor);
    }
    
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Doctor thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
      _db.Doctors.Remove(thisDoctor);
      _db.SaveChanges();
      return DedirectToAction("Index");
    }
  }
}