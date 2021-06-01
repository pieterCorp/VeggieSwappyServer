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
        private readonly ITradeService _tradeService;

        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }


        [HttpGet("{userId1}/{userId2}")]
        public async Task<ActionResult<TradeDto>> GetTradeAsync(int userId1, int userId2)
        {
            var test = await _tradeService.GetTradeDto(userId1, userId2);

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

        [HttpGet("{tradeId}")]
        public async Task<ActionResult<TradeHistoryDto>> GetTradeHistoryAsync(int tradeId)
        {            
            var test = await _tradeService.GetTradeHistory(tradeId);
            return Ok(test);
        }

        [HttpGet("Cancel/{id}")]
        public async Task<ActionResult<bool>> CancelTrade(int id)
        {
            bool succes = await _tradeService.CancelTrade(id);
            return Ok(succes);
        }

        [HttpGet("Accept/{id}")]
        public async Task<ActionResult<bool>> AcceptTrade(int id)
        {
            bool succes = await _tradeService.AcceptTrade(id);
            return Ok(succes);
        }
    }
}
