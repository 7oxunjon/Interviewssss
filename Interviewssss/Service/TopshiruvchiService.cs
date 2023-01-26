using AutoMapper;
using DATA.DTO;
using DATA.Model;
using Interviewssss.Repostory.Interface;
using Interviewssss.Service.Interface;

namespace Interviewssss.Service
{
    public class TopshiruvchiService : IToshiruvchiService
    {
        protected readonly ITopshiruvchiRepo repo;
        protected readonly IMapper mapper;

        public TopshiruvchiService(ITopshiruvchiRepo repo, IMapper mapper)
        {
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SuhbatTopshiruvchi> Delete(int id)
        {
            await repo.GetId(id);
            return mapper.Map<SuhbatTopshiruvchi>(await repo.Delete(id));
        }


        public async Task<IEnumerable<SuhbatTopshiruvchi>> GetAll()
        {
            return await repo.GetAll();
        }

        public async Task<SuhbatTopshiruvchi> GetId(int id)
        {
            return await repo.GetId(id);
        }

        public async Task<SuhbatTopshirivchiDTO> Insert(SuhbatTopshirivchiDTO suhbatTopshirivchiDTO)
        {
            var con = mapper.Map<SuhbatTopshiruvchi>(suhbatTopshirivchiDTO);
            return mapper.Map<SuhbatTopshirivchiDTO>(await repo.Insert(con));
        }

        public async Task<SuhbatTopshirivchiDTO> Update(int id, SuhbatTopshirivchiDTO suhbatTopshirivchiDTO)
        {
            SuhbatTopshiruvchi suhbat = mapper.Map<SuhbatTopshiruvchi>(suhbatTopshirivchiDTO);
            suhbat.Id = id;
            return mapper.Map<SuhbatTopshirivchiDTO>(await repo.Update(id, suhbat));

        }
    }
}
