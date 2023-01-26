using DATA.DTO;
using Interviewssss.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Interviewssss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SuhbatController : ControllerBase
    {
        protected readonly IOluvchiService service;

        public SuhbatController(IOluvchiService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Insert(SuhbatOluvchiDTO suhbatOluvchiDTO)
        {
            return Ok(await service.Insert(suhbatOluvchiDTO));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SuhbatOluvchiDTO dTO)
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
