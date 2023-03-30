using Microsoft.EntityFrameworkCore;
using ProjetoAgenda.Models;

namespace ProjetoAgenda.Context;

public class AgendaContext:DbContext
{
	public AgendaContext(DbContextOptions<AgendaContext> opts):base(opts)
	{

	}

	public DbSet<EventosModel> Eventos { get; set; }
}
