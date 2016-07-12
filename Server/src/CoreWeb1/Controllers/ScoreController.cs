using System.Linq;
using System.Threading.Tasks;
using CoreWeb1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreWeb1.Controllers
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
        public async Task<ScoreModelContainer> Get()
        {
            // PROTIP : filter these results using http paramaters or something like ODATA 
            // ODATA exposes full lambda searches to the client
           
            return new ScoreModelContainer
            {
                Scores = await Queryable.OrderByDescending<ScoreModel, int>(Context.Scores, o => o.Points).ToArrayAsync()
            };
        }

        // GET api/Score/5
        [HttpGet("{id}")]
        public Task<ScoreModel> Get(string id)
        {
            return Context.Scores.FirstOrDefaultAsync<ScoreModel>(o => o.UserName == id);
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
            var old = await Context.Scores.FirstOrDefaultAsync<ScoreModel>(o => o.UserName == model.UserName);

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
            var old = await Context.Scores.FirstOrDefaultAsync<ScoreModel>(o => o.UserName == id);
            if (old != null)
            {
                Context.Scores.Remove(old);
                await Context.SaveChangesAsync();
            }
        }
    }
}
