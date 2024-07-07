using Microsoft.EntityFrameworkCore;

namespace ApiPayment.Models
{
    public class PaymentDtlContext : DbContext
    {
        public PaymentDtlContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PaymentDtlModel> PaymentDtl {  get; set; }
    }
}
