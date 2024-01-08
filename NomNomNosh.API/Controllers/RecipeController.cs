using Microsoft.AspNetCore.Mvc;
using NomNomNosh.Application.DTOs;

namespace NomNomNosh.API.Controllers
{
    [Route("[controller]")]
    public class Recipe : Controller
    {
        [HttpGet]
        public async Task<ActionResult<RecipeDto>> CreateRecipe(Guid member_id)
        {
            throw new NotImplementedException();
        }
    }
}