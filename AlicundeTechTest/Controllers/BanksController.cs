using AutoMapper;
using ESettOpenApiInterfaces.Interfaces;
using ESettRepositoriesInterfaces.Interfaces;
using ESettRepositoriesInterfaces.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlicundeTechTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BanksController : ControllerBase
    {
        private readonly ILogger<BanksController> _logger;
        private readonly IeSettDataAccess _ieSettDataAccess;
        private readonly IMapper _mapper;
        private readonly IBankService _bankService;

        public BanksController(ILogger<BanksController> logger, IeSettDataAccess ieSettDataAccess, IMapper mapper, IBankService bankService)
        {
            _logger = logger;
            _ieSettDataAccess = ieSettDataAccess;
            _mapper = mapper;
            _bankService = bankService;
        }

        [HttpGet(Name = "Banks")]
        public async Task<ActionResult<IEnumerable<BankEntity>>> GetBanksAsync()
        {
            var dbBanks = await _ieSettDataAccess.GetBanks();
            var entityBanks = _mapper.Map<IEnumerable<BankEntity>>(dbBanks);

            if (entityBanks == null)
            {
                return NotFound();
            }

            return Ok(entityBanks);
        }

        [HttpGet("{bankBic}", Name = "Bank")]
        public async Task<ActionResult<IEnumerable<BankEntity>>> GetBankAsync(string bankBic)
        {
            var dbBank = await _ieSettDataAccess.GetBank(bankBic);
            var entityBank = _mapper.Map<BankEntity>(dbBank);

            if (entityBank == null)
            {
                return NotFound();
            }

            return Ok(entityBank);
        }

        [HttpPost(Name = "PopulateDb")]
        public async Task<ActionResult> PopulateDb()
        {
            var apiBanks = await _bankService.GetBanks();
            var dboBanks = _mapper.Map<IEnumerable<BankDAO>>(apiBanks);
            await _ieSettDataAccess.InsertBanks(dboBanks);

            return Ok();
        }
    }
}
 