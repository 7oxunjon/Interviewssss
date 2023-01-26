using DATA.Model;
using Interviewssss.Context;
using Interviewssss.Repostory.Interface;
using Microsoft.EntityFrameworkCore;

namespace Interviewssss.Repostory
{
    public class TopshiruvchiRepo : ITopshiruvchiRepo
    {
        protected readonly AppDbContext dbContext;

        public TopshiruvchiRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<SuhbatTopshiruvchi> Delete(int id)
        {
            var con = await dbContext.topshiruvchi.FirstOrDefaultAsync(p => p.Id == id);
            if (con != null)
            {
                dbContext.topshiruvchi.Remove(con);
                await dbContext.SaveChangesAsync();
                return con;
            }
            return null;
        }

        public async Task<IEnumerable<SuhbatTopshiruvchi>> GetAll()
        {
            return await dbContext.topshiruvchi./*Include(p => p.suhbatOluvchi).*/ToListAsync();
        }

        public async Task<SuhbatTopshiruvchi> GetId(int id)
        {
            return await dbContext.topshiruvchi.FirstAsync(p => p.Id == id);
        }

        public async Task<SuhbatTopshiruvchi> Insert(SuhbatTopshiruvchi suhbatTopshiruvchi)
        {
            await dbContext.topshiruvchi.AddAsync(suhbatTopshiruvchi);
            await dbContext.SaveChangesAsync();
            return suhbatTopshiruvchi;
        }

        public async Task<SuhbatTopshiruvchi> Update(int id, SuhbatTopshiruvchi suhbatTopshiruvchi)
        {
            var con = await dbContext.topshiruvchi.FindAsync(id);
            if (con == null) await dbContext.topshiruvchi.AddAsync(suhbatTopshiruvchi);
            else dbContext.Entry(con).CurrentValues.SetValues(suhbatTopshiruvchi);
            await dbContext.SaveChangesAsync();
            return suhbatTopshiruvchi;
        }
    }
}
