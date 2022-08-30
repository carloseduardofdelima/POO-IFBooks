using System;

class Aluno {
  public int Id { get; set; }
  public string Nome { get; set; }
  public int IdUsuario { get; set; }

  public override string ToString() {
    return $"Id do aluno: {Id} - Nome: {Nome} - Matricula: {IdUsuario}";
  }
}