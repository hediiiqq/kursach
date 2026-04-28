using kursach.Data;
using kursach.Interface;
using kursach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kursach.Controllers;

public class BaseController : Controller
{
    private readonly IRepository<BaseModel> db;

    public BaseController(IRepository<BaseModel> db)
    {
        this.db = db;
    }

    public ActionResult Index()
    {
        return View(db.GetAllList());
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(BaseModel baseModel)
    {
        if (ModelState.IsValid)
        {
            db.Create(baseModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(baseModel);
    }

    public ActionResult Edit(int id)
    {
        BaseModel baseModel = db.GetById(id);
        return View(baseModel);
    }

    [HttpPost]
    public ActionResult Edit(BaseModel baseModel)
    {
        if (ModelState.IsValid)
        {
            db.Update(baseModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(baseModel);
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
        BaseModel baseModel = db.GetById(id);
        return View(baseModel);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        BaseModel baseModel = db.GetById(id);
        db.Delete(baseModel);
        db.SaveChanges();

        return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
        db.Dispose();
        base.Dispose(disposing);
    }
}