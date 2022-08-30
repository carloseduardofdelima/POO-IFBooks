using System;

class Secao {
  public int Id { get; set; }
  public string Descricao { get; set; }

  public override string ToString() {
    return $"Id: {Id} - Descrição: {Descricao}";
  }
}