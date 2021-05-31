using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VeggieSwappyServer.Business.Dto;
using VeggieSwappyServer.Business.Services;

namespace VeggieSwappyServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class TradeController : ControllerBase
    {
        private ITradeService _tradeService;

        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }


        [HttpGet("{id1}/{id2}")]
        public async Task<ActionResult<TradeDto>> GetTradeAsync(int id1, int id2)
        {
            var test = await _tradeService.GetTradeDto(id1, id2);

            if (test == null)
            {
                return NoContent();
            }

            return Ok(test);
        }

        [HttpPost]
        public async Task<ActionResult> PostTradeAsync(TradeDto tradeDTO)
        {
            var test = await _tradeService.SaveTradeDto(tradeDTO);

            return Ok(test);
        }
    }
}
