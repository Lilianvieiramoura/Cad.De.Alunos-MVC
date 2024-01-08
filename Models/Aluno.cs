using System.ComponentModel.DataAnnotations;

namespace mvc.Models;

public class Aluno
{
  public int Id { get; set; }
  [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
  public string? Nome { get; set; }

  [Required(ErrorMessage = "O campo 'Email' é obrigatório")]
  [EmailAddress(ErrorMessage = "Digite um endereço de e-mail válido.")]
  public string? Email { get; set; }

  [DataType(DataType.Date)]
  public DateTime DataCadastro { get; set; }
  public bool Ativo { get; set; }
}