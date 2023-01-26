using DATA.DTO;
using DATA.Model;

namespace Interviewssss.Service.Interface
{
    public interface IToshiruvchiService
    {
        Task<SuhbatTopshirivchiDTO> Insert(SuhbatTopshirivchiDTO suhbatTopshirivchiDTO);

        Task<IEnumerable<SuhbatTopshiruvchi>> GetAll();

        Task<SuhbatTopshirivchiDTO> Update(int id, SuhbatTopshirivchiDTO suhbatTopshirivchiDTO);

        Task<SuhbatTopshiruvchi> GetId(int id);

        Task<SuhbatTopshiruvchi> Delete(int id);


    }
}
