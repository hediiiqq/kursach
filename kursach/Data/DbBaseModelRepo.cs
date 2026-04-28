using kursach.Interface;
using kursach.Models;
using Microsoft.EntityFrameworkCore;

namespace kursach.Data;

public class DbBaseModelRepo : IRepository<BaseModel>
{
    private AppDbContext context;

    public DbBaseModelRepo(AppDbContext context)
    {
        this.context = context;
    }

    public IEnumerable<BaseModel> GetAllList()
    {
        return context.BaseModels;
    }

    public BaseModel GetById(int id)
    {
        return context.BaseModels.Find(id);
    }

    public void Create(BaseModel item)
    {
        context.BaseModels.Add(item);
    }

    public void Update(BaseModel item)
    {
        context.Entry(item).State = EntityState.Modified;
    }

    public void Delete(BaseModel item)
    {
        BaseModel baseModel = context.BaseModels.Find(item.Id);
        if (baseModel != null)
        {
            context.BaseModels.Remove(baseModel);
        }
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }

    private bool disposed = false;

    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
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