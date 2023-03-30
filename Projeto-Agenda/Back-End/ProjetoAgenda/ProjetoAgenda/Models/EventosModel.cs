using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAgenda.Models;

public class EventosModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Data é obrigatório")]
    public DateOnly Data { get; set; }

    [Required(ErrorMessage = "O campo Título é obrigatório")]
    [MaxLength(50, ErrorMessage = "Limite de caractéres excedido")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O campo Descrição é obrigatório")]
    [MaxLength(600, ErrorMessage = "Limite de caractéres excedido")]
    public string Descrição { get; set; }
}
