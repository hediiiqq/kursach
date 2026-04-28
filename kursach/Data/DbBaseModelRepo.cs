using kursach.Interface;
using kursach.Models;
using Microsoft.EntityFrameworkCore;

namespace kursach.Data;

public class DbBaseModelRepo : IRepository<BaseModel>
{
    private readonly AppDbContext db;

    public DbBaseModelRepo(AppDbContext db)
    {
        this.db = db;
    }

    public IEnumerable<BaseModel> GetAllList()
    {
        return db.BaseModels;
    }

    public BaseModel GetById(int id)
    {
        return db.BaseModels.Find(id);
    }

    public void Create(BaseModel item)
    {
        db.BaseModels.Add(item);
    }

    public void Update(BaseModel item)
    {
        db.Entry(item).State = EntityState.Modified;
    }

    public void Delete(BaseModel item)
    {
        BaseModel baseModel = db.BaseModels.Find(item.Id);
        if (baseModel != null)
        {
            db.BaseModels.Remove(baseModel);
        }
    }

    public void SaveChanges()
    {
        db.SaveChanges();
    }

    private bool disposed = false;

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
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}