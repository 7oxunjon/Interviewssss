using DATA.Model;

namespace Interviewssss.Repostory.Interface
{
    public interface IOluvchiRepo
    {
        Task<SuhbatOluvchi> Insert(SuhbatOluvchi suhbatOluvchi);

        Task<IEnumerable<SuhbatOluvchi>> GetAll();

        Task<SuhbatOluvchi> Update(int id, SuhbatOluvchi suhbatOluvchi);

        Task<SuhbatOluvchi> GetId(int id);

        Task<SuhbatOluvchi> Delete(int id);
    }
}
