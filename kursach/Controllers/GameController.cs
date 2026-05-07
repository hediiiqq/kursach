using kursach.Data;
using kursach.Interface;
using kursach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kursach.Controllers;

public class GameController : Controller
{
    private readonly IRepository<GameModel> db;

    public GameController(IRepository<GameModel> db)
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
    public ActionResult Create(GameModel gameModel)
    {
        if (ModelState.IsValid)
        {
            db.Create(gameModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(gameModel);
    }

    public ActionResult Edit(int id)
    {
        GameModel? baseModel = db.GetById(id);
        if (baseModel == null)
        {
            return NotFound();
        }

        return View(baseModel);
    }

    [HttpPost]
    public ActionResult Edit(GameModel gameModel)
    {
        if (ModelState.IsValid)
        {
            db.Update(gameModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(gameModel);
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
        GameModel? baseModel = db.GetById(id);
        if (baseModel == null)
        {
            return NotFound();
        }

        return View(baseModel);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        GameModel? baseModel = db.GetById(id);
        if (baseModel == null)
        {
            return NotFound();
        }

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