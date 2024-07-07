using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPayment.Models;

namespace ApiPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDtlController : ControllerBase
    {
        private readonly PaymentDtlContext _context;

        public PaymentDtlController(PaymentDtlContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDtl
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDtlModel>>> GetPaymentDtl()
        {
            return await _context.PaymentDtl.ToListAsync();
        }

        // GET: api/PaymentDtl/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDtlModel>> GetPaymentDtlModel(int id)
        {
            var paymentDtlModel = await _context.PaymentDtl.FindAsync(id);

            if (paymentDtlModel == null)
            {
                return NotFound();
            }

            return paymentDtlModel;
        }

        // PUT: api/PaymentDtl/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDtlModel(int id, PaymentDtlModel paymentDtlModel)
        {
            if (id != paymentDtlModel.PaymentId)
            {
                return BadRequest();
            }

            _context.Entry(paymentDtlModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDtlModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymentDtl
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentDtlModel>> PostPaymentDtlModel(PaymentDtlModel paymentDtlModel)
        {
            _context.PaymentDtl.Add(paymentDtlModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDtlModel", new { id = paymentDtlModel.PaymentId }, paymentDtlModel);
        }

        // DELETE: api/PaymentDtl/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDtlModel(int id)
        {
            var paymentDtlModel = await _context.PaymentDtl.FindAsync(id);
            if (paymentDtlModel == null)
            {
                return NotFound();
            }

            _context.PaymentDtl.Remove(paymentDtlModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
         
        private bool PaymentDtlModelExists(int id)
        {
            return _context.PaymentDtl.Any(e => e.PaymentId == id);
        }
    }
}
