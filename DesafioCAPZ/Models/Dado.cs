using DesafioCAPZ.Controllers;
using System.ComponentModel.DataAnnotations;

namespace DesafioCAPZ.Models;

public class Dado
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O ID do material não pode ser vazio.")]
    [MinLength(2, ErrorMessage = "É obrigatória a presença de 2 ou mais caracteres")]
    public string MaterialID { get; set; }
    [Required(ErrorMessage = "O nome do material não pode ser vazio.")]
    [MinLength(2, ErrorMessage = "É obrigatória a presença de 2 ou mais caracteres")]
    public string MaterialName { get; set; }
}