using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Entity;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class JobController : Controller
    {
        JobManager _jobManager = new JobManager(new JobDal());
        public IActionResult Index()
        {
            var values = _jobManager.TGetList();
            return View(values);

        }

        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddJob(Job p)
        {
            _jobManager.TInsert(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteJob(int id)
        {
            var value = _jobManager.TGetById(id);
            _jobManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateJob(int id)
        {
            var value = _jobManager.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateJob(Job p)
        {
            _jobManager.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
