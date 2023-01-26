using DATA.Model;

namespace Interviewssss.Repostory.Interface
{
    public interface ITopshiruvchiRepo
    {
        Task<SuhbatTopshiruvchi> Insert(SuhbatTopshiruvchi suhbatTopshiruvchi);

        Task<IEnumerable<SuhbatTopshiruvchi>> GetAll();

        Task<SuhbatTopshiruvchi> Update(int id, SuhbatTopshiruvchi suhbatTopshiruvchi);

        Task<SuhbatTopshiruvchi> GetId(int id);

        Task<SuhbatTopshiruvchi> Delete(int id);
    }
}
