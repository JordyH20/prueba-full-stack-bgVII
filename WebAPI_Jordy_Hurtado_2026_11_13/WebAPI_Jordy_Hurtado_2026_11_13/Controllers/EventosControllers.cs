using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Jordy_Hurtado_2026_11_13.Dtos.Request;
using WebAPI_Jordy_Hurtado_2026_11_13.Services;

namespace WebAPI_Jordy_Hurtado_2026_11_13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosControllers : ControllerBase
    {
        private readonly EventosService _eventosService;

        public EventosControllers(EventosService eventosService)
        {
            _eventosService = eventosService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEventos()
        {
            var eventos = await _eventosService.GetAllEventosAsync();
            return Ok(eventos);
        }


        [HttpGet("id")]
        public async Task<IActionResult> GetEventoById(int eventId)
        {
            var evento = await _eventosService.GetEventoByIdAsync(eventId);
            if (evento == null)
            {
                return NotFound(new
                {
                    mensaje = $"No existe un evento con el ID {eventId}"
                });
            }
            return Ok(evento);
        }


        [HttpPost]
        public async Task<IActionResult> CreateEventos(EventosRequest dto)
        {
            var createdEvento = await _eventosService.CreateEventos(dto);
            return CreatedAtAction(nameof(GetEventoById), new { eventId = createdEvento.EventId }, createdEvento);
        }
    }
}
