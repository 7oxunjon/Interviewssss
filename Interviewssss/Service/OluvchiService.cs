using AutoMapper;
using DATA.DTO;
using DATA.Model;
using Interviewssss.Repostory.Interface;
using Interviewssss.Service.Interface;

namespace Interviewssss.Service
{
    public class OluvchiService : IOluvchiService
    {
        protected readonly IOluvchiRepo repo;
        protected readonly IMapper mapper;

        public OluvchiService(IOluvchiRepo repo, IMapper mapper)
        {
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SuhbatOluvchi> Delete(int id)
        {
            await repo.GetId(id);
            return mapper.Map<SuhbatOluvchi>(await repo.Delete(id));
        }

        public async Task<SuhbatOluvchi> GetId(int id)
        {
            return await repo.GetId(id);
        }

        public async Task<IEnumerable<SuhbatOluvchi>> GetAll()
        {
            return await repo.GetAll();
        }

        public async Task<SuhbatOluvchiDTO> Insert(SuhbatOluvchiDTO suhbatOluvchiDTO)
        {
            var con = mapper.Map<SuhbatOluvchi>(suhbatOluvchiDTO);
            return mapper.Map<SuhbatOluvchiDTO>(await repo.Insert(con));
        }

        public async Task<SuhbatOluvchiDTO> Update(int id, SuhbatOluvchiDTO suhbatOluvchiDTO)
        {
            SuhbatOluvchi suhbat = mapper.Map<SuhbatOluvchi>(suhbatOluvchiDTO);
            suhbat.Id = id;
            return mapper.Map<SuhbatOluvchiDTO>(await repo.Update(id, suhbat));
        }
    }
}
