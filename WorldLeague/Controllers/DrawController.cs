using Microsoft.AspNetCore.Mvc;
using WorldLeague.Constants;
using WorldLeague.Entities;
using WorldLeague.Services;

namespace WorldLeague.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DrawController : ControllerBase
    {
        private readonly IDrawService _drawService;

        public DrawController(IDrawService drawService)
        {
            _drawService = drawService;
        }

        [HttpPost]
        public async Task<ActionResult<List<Group>>> Post(string draverName, int numberOfGroups)
        {
            if (numberOfGroups.Equals(8) || numberOfGroups.Equals(4))
            {
                return await _drawService.CreateDraw(draverName, numberOfGroups);
             }
            else
                return BadRequest(Messages.NumberOfGroupsIsNotValid);
        }

    }
}

