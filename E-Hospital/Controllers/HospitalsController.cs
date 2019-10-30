using E_Hospital.Data.Entity;
using E_Hospital.Data.Repositories;
using E_Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Hospital.Controllers
{
    public class HospitalsController : Controller
    {
        private IHospitalRepository _hospitalRepo;
        private IDoctorRepository _doctorRepo;
        public HospitalsController(IHospitalRepository hospitalRepo, IDoctorRepository doctorRepo)
        {
            _hospitalRepo = hospitalRepo;
            _doctorRepo = doctorRepo;
        }
        public ActionResult Index()
        {
            var hospitals = _hospitalRepo.GetHospitals();
            var model = new HospitalsPageViewModel
            {
                Hospitals = hospitals,
                Locations = hospitals.Select(h => h.Location).ToList()
            };
            return View(model);
        }

        public ActionResult Doctors(int hospitalId)
        {
            var model = new DoctorsViewModel
            {
                Hospital = _hospitalRepo.Get(hospitalId),
                Doctors = _doctorRepo.GetDoctors().Where(d => d.HospitalID == hospitalId).ToList()
            };
            return View(model);
        }
    }
}
