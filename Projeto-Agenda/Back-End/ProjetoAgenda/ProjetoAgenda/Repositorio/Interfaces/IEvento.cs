using ProjetoAgenda.Models;

namespace ProjetoAgenda.Repositorio.Interfaces;

public interface IEvento
{
    Task<List<EventosModel>> GetEventos();
    Task<EventosModel> GetEventoId(int id);
    Task<EventosModel> PostEvento(EventosModel evento);
    Task<EventosModel> PutEvento(EventosModel evento, int id);
    Task<bool> DeleteEvento(int id);

}
