using Microsoft.EntityFrameworkCore;
using ProjetoAgenda.Context;
using ProjetoAgenda.Models;
using ProjetoAgenda.Repositorio.Interfaces;

namespace ProjetoAgenda.Repositorio;

public class EventoRepositorio : IEvento
{
    private readonly AgendaContext _context;
    public EventoRepositorio(AgendaContext agendaContext)
    {
        _context = agendaContext;
    }

    public async Task<List<EventosModel>> GetEventos()
    {
        return await _context.Eventos.OrderBy(e => e.Data).ToListAsync();
    }

    public async Task<EventosModel> GetEventoId(int id)
    {
        EventosModel evento = await _context.Eventos.FirstOrDefaultAsync(e => e.Id == id);
        return evento;
    }

    public async Task<EventosModel> PostEvento(EventosModel evento)
    {
        _context.Eventos.AddAsync(evento);
        _context.SaveChanges();

        return evento;
    }

    public async Task<EventosModel> PutEvento(EventosModel evento, int id)
    {
        EventosModel eventoPut = await _context.Eventos.FirstOrDefaultAsync(e => e.Id == id);
        if (eventoPut == null)
        {
            throw new Exception($"Evento não encontrado");
        }

        eventoPut.Titulo = evento.Titulo;
        eventoPut.Data = evento.Data;
        eventoPut.Descrição = evento.Descrição;
        _context.SaveChanges();

        return eventoPut;
    }

    public async Task<bool> DeleteEvento(int id)
    {
        EventosModel eventoRemove = await _context.Eventos.FirstOrDefaultAsync(e => e.Id == id);
        if (eventoRemove == null)
        {
            throw new Exception($"Evento não encontrado");
        }

        _context.Eventos.Remove(eventoRemove);
        _context.SaveChanges();
        
        return true;
    }
}
