using System.ComponentModel.DataAnnotations;

namespace WebAPI_Jordy_Hurtado_2026_11_13.Dtos.Request
{
    public class EventosRequest
    {

        [Required]
        public string Titulo { get; set; } = null!;

        [Required]
        public string? Descrpcion { get; set; }


        [Required]
        public DateTime FechaInicio { get; set; }


        [Required]
        public DateTime FechaFin { get; set; }


        [Required]
        public string Location { get; set; } = null!;


        [Required]
        public int OrganizerId { get; set; }
    }
}
