using System.ComponentModel.DataAnnotations;

namespace WebAPI_Jordy_Hurtado_2026_11_13.Dtos.Request
{
    public class RegistrarEventoRequest
    {
        [Required]
        public int EventId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        [Required]
        public string Estado { get; set; } = "Pendiente";
    }
}

