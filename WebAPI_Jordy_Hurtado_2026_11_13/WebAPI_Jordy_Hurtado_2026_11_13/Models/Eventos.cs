namespace WebAPI_Jordy_Hurtado_2026_11_13.Models
{
    public class Eventos
    {
        public int EventId { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Descrpcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Location { get; set; } = null!;
        public int OrganizerId { get; set; }

    }
}