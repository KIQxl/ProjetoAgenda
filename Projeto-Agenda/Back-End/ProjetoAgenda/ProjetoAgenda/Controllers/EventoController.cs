using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjetoAgenda.Models;
using ProjetoAgenda.Repositorio.Interfaces;

namespace ProjetoAgenda.Controllers;

[ApiController]
[Route("[controller]")]
public class EventoController:ControllerBase
{
	private readonly IEvento _evento;

	public EventoController(IEvento evento)
	{
		_evento= evento;
	}

	[HttpGet]
	public async Task<ActionResult<List<EventosModel>>> BuscaEventos()
	{
		List<EventosModel> eventos = await _evento.GetEventos();

		return Ok(eventos);
	}


    [HttpGet("{id}")]
    public async Task<ActionResult<EventosModel>> BuscaEventoId(int id)
    {
        EventosModel evento = await _evento.GetEventoId(id);

        return Ok(evento);
    }

    [HttpPost]
    public async Task<ActionResult<EventosModel>> CadastraEvento([FromBody]EventosModel eventoModel)
	{
		EventosModel evento = await _evento.PostEvento(eventoModel);
		return Ok(evento);
	}

	[HttpPut("{id}")]
    public async Task<ActionResult<EventosModel>> AlteraEvento([FromBody]EventosModel eventoModel, int id)
	{
		EventosModel evento = await _evento.PutEvento(eventoModel, id);
		return Ok(evento);
	}

	[HttpDelete("{id}")]
    public async Task<ActionResult<EventosModel>> RemoveEvento(int id)
    {
        bool evento = await _evento.DeleteEvento(id);
        return Ok(evento);
    }
}
