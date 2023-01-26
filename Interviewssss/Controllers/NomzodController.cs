using DATA.DTO;
using Interviewssss.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Interviewssss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NomzodController : ControllerBase
    {
        protected readonly IToshiruvchiService service;

        public NomzodController(IToshiruvchiService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Insert(SuhbatTopshirivchiDTO suhbatTopshirivchiDTO)
        {
            return Ok(await service.Insert(suhbatTopshirivchiDTO));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SuhbatTopshirivchiDTO dTO)
        {
            return Ok(await service.Update(id, dTO));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            return Ok(await service.GetId(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.Delete(id));
        }
    }
}
