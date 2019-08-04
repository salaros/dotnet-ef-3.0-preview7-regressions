using System.Threading.Tasks;
using DummyModels;
using Microsoft.EntityFrameworkCore;

namespace EmptyDbSet
{
    public class EmptyDbService
    {
        protected EmptyDbSetContext db;

        public EmptyDbService(EmptyDbSetContext db)
        {
            this.db = db;
        }

        public async Task<DummyModel> GetOneById(long id)
        {
            return await db.Set<DummyModel>().SingleOrDefaultAsync(d => id == d.Id);
        }
    }
}
