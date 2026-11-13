using Dapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Jordy_Hurtado_2026_11_13.Data;
using WebAPI_Jordy_Hurtado_2026_11_13.Dtos.Request;
using WebAPI_Jordy_Hurtado_2026_11_13.Models;

namespace WebAPI_Jordy_Hurtado_2026_11_13.Services
{
    public class EventosService
    {
        private readonly DataDapper _dataDapper;

        public EventosService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }


        public async Task<IEnumerable<Eventos>> GetAllEventosAsync()
        {
            using var connection = _dataDapper.GetConnection();
            var query = "SELECT * FROM DB_Eventos";
            var eventos = await connection.QueryAsync<Eventos>(query);
            return eventos;
        }


        public async Task<Eventos?> GetEventoByIdAsync(int eventId)
        {
            using var connection = _dataDapper.GetConnection();
            var query = "SELECT * FROM DB_Eventos WHERE EventId = @EventId";
            var evento = await connection.QuerySingleOrDefaultAsync<Eventos>(query, new { EventId = eventId });
            return evento;
        }



        public async Task<Eventos> CreateEventos ([FromBody] EventosRequest dto)
        {
            using var connection = _dataDapper.GetConnection();
            var query = @"INSERT INTO DB_Eventos (Titulo, Descrpcion, FechaInicio, FechaFin, Location, OrganizerId)
                          VALUES (@Titulo, @Descrpcion, @FechaInicio, @FechaFin, @Location, @OrganizerId);
                          SELECT CAST(SCOPE_IDENTITY() as int);";
            var parameters = new
            {
                dto.Titulo,
                dto.Descrpcion,
                dto.FechaInicio,
                dto.FechaFin,
                dto.Location,
                dto.OrganizerId
            };
            var eventId = await connection.QuerySingleAsync<int>(query, parameters);
            return new Eventos
            {
                EventId = eventId,
                Titulo = dto.Titulo,
                Descrpcion = dto.Descrpcion,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Location = dto.Location,
                OrganizerId = dto.OrganizerId
            };
        }
    }


}
