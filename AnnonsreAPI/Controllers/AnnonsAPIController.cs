using AnnonsreAPI.Data;
using AnnonsreAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnnonsreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnonsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AnnonsAPIController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Annons>>> GetAll()
        {
            return Ok(await _dbContext.Annonser.ToListAsync());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Annons>> GetOne(int id)
        {
            var hero = _dbContext.Annonser.Find(id);

            if (hero == null)
            {
                return BadRequest("Annonsen not found");
            }
            return Ok(hero);
        }
        [HttpPost]
        public async Task<ActionResult<Annons>> PostHero(Annons hero)
        {
            _dbContext.Annonser.Add(hero);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Annonser.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<Annons>> UpdateHero(Annons hero)
        {
            // OBS: PUT Uppdaterar HELA SuperHero (ALLA properties)
            var heroToUpdate = await _dbContext.Annonser.FindAsync(hero.AnnonsId);

            if (heroToUpdate == null)
            {
                return BadRequest("Annonsen not found");
            }

            heroToUpdate.Name = hero.Name;
            heroToUpdate.FirstName = hero.FirstName;
            heroToUpdate.SurName = hero.SurName;
            heroToUpdate.City = hero.City;

            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.Annonser.ToListAsync());
        }
        [HttpDelete]
        public async Task<ActionResult<Annons>> Delete(int id)
        {
            var hero = await _dbContext.Annonser.FindAsync(id);

            if (hero == null)
            {
                return BadRequest("Superhero not found");
            }

            _dbContext.Annonser.Remove(hero);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Annonser.ToListAsync());
        }



    }
}
