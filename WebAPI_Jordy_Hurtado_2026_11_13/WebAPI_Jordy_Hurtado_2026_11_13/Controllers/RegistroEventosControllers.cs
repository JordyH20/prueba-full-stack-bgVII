using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Jordy_Hurtado_2026_11_13.Dtos.Request;
using WebAPI_Jordy_Hurtado_2026_11_13.Services;

namespace WebAPI_Jordy_Hurtado_2026_11_13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroEventosControllers : ControllerBase
    {
        private readonly RegistrarEventosService _registrarEventosService;

        public RegistroEventosControllers(RegistrarEventosService registrarEventosService)
        {
            _registrarEventosService = registrarEventosService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRegistroEventos()
        {
            var registroEventos = await _registrarEventosService.getAllRegistroEventos();
            return Ok(registroEventos);
        }

        [HttpGet("{registrationId}")]
        public async Task<IActionResult> GetRegistroEventoById(int registrationId)
        {
            var registroEvento = await _registrarEventosService.GetRegistroEventoByIdAsync(registrationId);
            if (registroEvento == null)
            {
                return NotFound();
            }
            return Ok(registroEvento);
        }


        [HttpPost]
        public async Task<IActionResult> CreateRegistroEventos( [FromBody] RegistrarEventoRequest dto)
        {
            var createdRegistroEvento =
                await _registrarEventosService.CreateRegistroEventos(dto);

            return CreatedAtAction(
                nameof(GetRegistroEventoById),
                new
                {
                    registrationId = createdRegistroEvento.RegistrationId
                },
                new
                {
                    mensaje = "Registro de evento creado correctamente",
                    registroEventoId = createdRegistroEvento.RegistrationId
                }
            );
        }



        [HttpPut ("id")]
        public async Task <IActionResult> UpdateRegistroEventos (int id, RegistrarEventoRequest dto)
        {
            var updateRegistro = await _registrarEventosService.GetRegistroEventoByIdAsync(id);
            if (updateRegistro == null)
            {
                return NoContent();
            }

            await _registrarEventosService.UpdateRegistroEventoAsync(id, dto);
            return NoContent();
        }


    }
}