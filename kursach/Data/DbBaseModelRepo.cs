using kursach.Interface;
using kursach.Models;
using Microsoft.EntityFrameworkCore;

namespace kursach.Data;

public class DbBaseModelRepo : IRepository<GameModel>
{
    private readonly AppDbContext db;

    private bool disposed = false;

    public DbBaseModelRepo(AppDbContext db)
    {
        this.db = db;
    }

    public IEnumerable<GameModel> GetAllList()
    {
        return db.GamesList;
    }

    public GameModel? GetById(int id)
    {
        return db.GamesList.Find(id);
    }

    public void Create(GameModel item)
    {
        db.GamesList.Add(item);
    }

    public void Update(GameModel item)
    {
        db.Entry(item).State = EntityState.Modified;
    }

    public void Delete(GameModel item)
    {
        GameModel? baseModel = db.GamesList.Find(item.Id);
        if (baseModel != null)
        {
            db.GamesList.Remove(baseModel);
        }
    }

    public void SaveChanges()
    {
        db.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }

        this.disposed = true;
    }
}