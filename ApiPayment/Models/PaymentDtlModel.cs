using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPayment.Models
{
    public class PaymentDtlModel
    {
        [Key]
        public int PaymentId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CardOwnerName { get; set; } = "";

        [Column(TypeName = "nvarchar(16)")]
        public string CardNumber { get; set; } = "";

        //mm/yy
        [Column(TypeName = "nvarchar(5)")]
        public string ExpireDate { get; set; } = "";

        [Column(TypeName = "nvarchar(3)")]
        public string SecurityCode { get; set; } = "";
    }
}
