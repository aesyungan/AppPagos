using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppCobros.Models
{
    public class User
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string genero { get; set; }
        [Required]
        public int edad { get; set; }
        public ICollection<PaymentDetail> paymentDetails { get; set; }
    }
}
