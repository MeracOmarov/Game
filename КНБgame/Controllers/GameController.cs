using Abtraction;
using Domen.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace КНБgame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IMoneyTransaction _moneyTransaction;
        private readonly IUserMatchHistory _userMatchHistory;
        private readonly IUserOperations _userOperations;
        private readonly IMatchHistoryOperations _matchHistoryOperations;

        public GameController(IMoneyTransaction moneyTransaction,
                              IUserMatchHistory userMatchHistory,
                              IUserOperations userOperations,
                              IMatchHistoryOperations matchHistoryOperations)
        {
            _moneyTransaction = moneyTransaction;
            _userMatchHistory = userMatchHistory;
            _userOperations = userOperations;
            _matchHistoryOperations = matchHistoryOperations;
        }

        [HttpPost]
        public async Task<IActionResult> GameUserMatchHistory(int selectedUserId)
        {
            var result = await _userMatchHistory.FetchUserMatchHistory(selectedUserId);
            return Ok(result);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> GameUserRegistration(CreateUserDTO createUserDTO)
        {
            await _userOperations.CreateUser(createUserDTO);
            return Ok();
        }

        [HttpPost("NewMatch")]

        public async Task<IActionResult> GameNewMatch(CreateMatchHistoryDTO createMatchHistoryDTO)
        {
            await _matchHistoryOperations.CreateMatchHistory(createMatchHistoryDTO);
            return Ok();
        }


    }
}
