using Dapper;
using WebAPI_Jordy_Hurtado_2026_11_13.Dtos.Request;
using WebAPI_Jordy_Hurtado_2026_11_13.Models;

namespace WebAPI_Jordy_Hurtado_2026_11_13.Services
{
    public class RegistrarEventosService
    {
        private readonly Data.DataDapper _dataDapper;

        public RegistrarEventosService(Data.DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }


        public async Task<IEnumerable<RegistrarEventos>> getAllRegistroEventos()
        {
            using var connection = _dataDapper.GetConnection();
            var query = "SELECT * FROM RegistrosEventos";
            var registroEventos = await connection.QueryAsync<RegistrarEventos>(query);
            return registroEventos;
        }

        public async Task <RegistrarEventos> CreateRegistroEventos (RegistrarEventoRequest dto)
        {
            using var connection = _dataDapper.GetConnection();
            var query = @"INSERT INTO RegistrosEventos (EventId, UserId, RegistrationDate, Estado)
                          VALUES (@EventId, @UserId, @RegistrationDate, @Estado);
                          SELECT CAST(SCOPE_IDENTITY() as int);";
            var parameters = new
            {
                dto.EventId,
                dto.UserId,
                dto.RegistrationDate,
                dto.Estado
            };
            var registrationId = await connection.QuerySingleAsync<int>(query, parameters);
            return new RegistrarEventos
            {
                RegistrationId = registrationId,
                EventId = dto.EventId,
                UserId = dto.UserId,
                RegistrationDate = dto.RegistrationDate,
                Estado = dto.Estado
            };
        }


        public async Task<RegistrarEventos?> GetRegistroEventoByIdAsync(int registrationId)
        {
            using var connection = _dataDapper.GetConnection();
            var query = "SELECT * FROM RegistrosEventos WHERE RegistrationId = @RegistrationId";
            var registroEvento = await connection.QuerySingleOrDefaultAsync<RegistrarEventos>(query, new { RegistrationId = registrationId });
            return registroEvento;
        }   



        public async Task<bool> UpdateRegistroEventoAsync(int registrationId, RegistrarEventoRequest dto)
        {
            using var connection = _dataDapper.GetConnection();
            var query = @"UPDATE RegistrosEventos
                          SET EventId = @EventId,
                              UserId = @UserId,
                              RegistrationDate = @RegistrationDate,
                              Estado = @Estado
                          WHERE RegistrationId = @RegistrationId";
            var parameters = new
            {
                RegistrationId = registrationId,
                dto.EventId,
                dto.UserId,
                dto.RegistrationDate,
                dto.Estado
            };
            var rowsAffected = await connection.ExecuteAsync(query, parameters);
            return rowsAffected > 0;
        }

    }
}
