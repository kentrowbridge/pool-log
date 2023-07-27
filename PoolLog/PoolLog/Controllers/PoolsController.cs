using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoolLog.Models;

namespace PoolLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoolsController : ControllerBase
    {
        private readonly PoolContext context;

        public PoolsController(PoolContext context)
        {
            this.context = context;
        }

        /// <summary>
        ///     Gets the set of all known pools
        /// </summary>
        /// <returns>The set of all pools.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pool>>> GetPools()
        {
            if (this.context.Pools == null)
            {
                return this.NotFound();
            }

            return await this.context.Pools.ToListAsync();
        }

        /// <summary>
        ///     Gets a specific pool by ID.
        /// </summary>
        /// <param name="id">The pool ID.</param>
        /// <returns>The desired pool, if present.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Pool>> GetPool(int id)
        {
            if (this.context.Pools == null)
            {
                return this.NotFound();
            }

            var pool = await this.context.Pools.FindAsync(id);

            if (pool == null)
            {
                return this.NotFound();
            }

            return pool;
        }

        // PUT: api/Pools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPool(int id, Pool pool)
        {
            if (id != pool.Id)
            {
                return this.BadRequest();
            }

            this.context.Entry(pool).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this.PoolExists(id) is false)
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.NoContent();
        }

        // POST: api/Pools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pool>> PostPool(Pool pool)
        {
            if (this.context.Pools == null)
            {
                return this.Problem("Entity set 'PoolContext.Pools'  is null.");
            }

            this.context.Pools.Add(pool);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(this.GetPool), new { id = pool.Id }, pool);
        }

        // DELETE: api/Pools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePool(int id)
        {
            if (this.context.Pools == null)
            {
                return this.NotFound();
            }
            
            var pool = await this.context.Pools.FindAsync(id);

            if (pool == null)
            {
                return this.NotFound();
            }

            this.context.Pools.Remove(pool);
            await this.context.SaveChangesAsync();

            return this.NoContent();
        }

        private bool PoolExists(int id)
        {
            return (this.context.Pools?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
