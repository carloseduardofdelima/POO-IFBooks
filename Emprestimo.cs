using System;

class Emprestimo {
  public int Id { get; set; }
  public int CodigoExemplar { get; set; }
  public int MatAluno { get; set; }
  public int MatBibliotecario { get; set; }
  public DateTime DataEmprestimo { get; set; }
  public DateTime DataDevolucao { get; set; }

  public override string ToString() {
    return $"Id: {Id} - Codigo do exemplar: {CodigoExemplar} - Aluno: {MatAluno} - Data prevista de devolucao: {DataDevolucao}";
  }
}