using DATA.DTO;
using DATA.Model;

namespace Interviewssss.Service.Interface
{
    public interface IOluvchiService
    {
        Task<SuhbatOluvchiDTO> Insert(SuhbatOluvchiDTO suhbatOluvchiDTO);

        Task<IEnumerable<SuhbatOluvchi>> GetAll();

        Task<SuhbatOluvchiDTO> Update(int id, SuhbatOluvchiDTO suhbatOluvchiDTO);

        Task<SuhbatOluvchi> Delete(int id);

        Task<SuhbatOluvchi> GetId(int id);
    }
}
