using DATA.Model;
using Interviewssss.Context;
using Interviewssss.Repostory.Interface;
using Microsoft.EntityFrameworkCore;

namespace Interviewssss.Repostory
{
    public class OluvchiRepo : IOluvchiRepo
    {
        protected readonly AppDbContext dbContext;

        public OluvchiRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<SuhbatOluvchi> Delete(int id)
        {
            var con = await dbContext.suhbatOluvchis.FirstOrDefaultAsync(p => p.Id == id);
            if (con != null)
            {
                dbContext.suhbatOluvchis.Remove(con);
                await dbContext.SaveChangesAsync();
                return con;
            }
            return null;
        }

        public async Task<IEnumerable<SuhbatOluvchi>> GetAll()
        {
            return await dbContext.suhbatOluvchis.Include(p => p.suhbatTopshiruvchis).ToListAsync();
        }

        public async Task<SuhbatOluvchi> GetId(int id)
        {
            return await dbContext.suhbatOluvchis.FirstAsync(p => p.Id == id);
        }

        public async Task<SuhbatOluvchi> Insert(SuhbatOluvchi suhbatOluvchi)
        {
            await dbContext.suhbatOluvchis.AddAsync(suhbatOluvchi);
            await dbContext.SaveChangesAsync();
            return suhbatOluvchi;
        }

        public async Task<SuhbatOluvchi> Update(int id, SuhbatOluvchi suhbatOluvchi)
        {
            var con = await dbContext.suhbatOluvchis.FindAsync(id);
            if (con == null) await dbContext.suhbatOluvchis.AddAsync(suhbatOluvchi);
            else dbContext.Entry(con).CurrentValues.SetValues(suhbatOluvchi);
            await dbContext.SaveChangesAsync();
            return suhbatOluvchi;
        }
    }
}
