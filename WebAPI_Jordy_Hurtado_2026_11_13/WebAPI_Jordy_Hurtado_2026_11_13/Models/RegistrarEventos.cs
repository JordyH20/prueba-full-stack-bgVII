using Microsoft.AspNetCore.Http.HttpResults;

namespace WebAPI_Jordy_Hurtado_2026_11_13.Models
{
    public class RegistrarEventos
    {
        public int RegistrationId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public string Estado { get; set; } = "Pendiente";
    }
}

