using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreWeb1.Modules.Score
{
    [Route("api/[controller]")]
    public class ScoreController : Controller
    {
        //Ref to our DB proxy
        protected ScoreContext Context = new ScoreContext();
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Context.Dispose();
        }

        // GET api/Score
        [HttpGet]
        public IEnumerable<ScoreModel> Get()
        {
            // PROTUP filter these results using http paramaters or something like ODATA 
            // ODATA exposes full lambda searches to the client, ala Facebook parse.
            return Context.Scores.OrderByDescending(o => o.Points);
        }

        // GET api/Score/5
        [HttpGet("{id}")]
        public Task<ScoreModel> Get(string id)
        {
            return Context.Scores.FirstOrDefaultAsync(o => o.UserName == id);
        }

        // POST api/Score
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ScoreModel model)
        {
            //Sanity
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad Username or something");
            }

            //Check for new or update
            var old = await Context.Scores.FirstOrDefaultAsync(o => o.UserName == model.UserName);

            if (old == null)
            {
                //New
                Context.Scores.Add(model);
                await Context.SaveChangesAsync();

                return Ok(model);
            }
            else
            {
                //UPDATE
                old.Points = model.Points;
                await Context.SaveChangesAsync();
                return Ok(model);
            }
        }

        // DELETE api/Score/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            //Check for new or update
            var old = await Context.Scores.FirstOrDefaultAsync(o => o.UserName == id);
            if (old != null)
            {
                Context.Scores.Remove(old);
                await Context.SaveChangesAsync();
            }
        }
    }
}
