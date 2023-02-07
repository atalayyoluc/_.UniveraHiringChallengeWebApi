using _.UniveraHiringChallengeBusines.Services.Abstractions;
using _.UniveraHiringChallengeEntity.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _.UniveraHiringChallengeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry([FromBody] CountryDTO country)
        {
            await countryService.AddCountry(country);
            return Ok("Ekleme Başarılı");
        }
        [HttpGet]
        public async Task<IActionResult> ListCountry()
        {
           var country= await countryService.ListCountry();
            return Ok(country);
        }
    }
}
