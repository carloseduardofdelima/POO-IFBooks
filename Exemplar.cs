using System;

class Exemplar {
  public int Codigo { get; set; }
  public bool Disponivel { get; set; }
  public int IsbnLivro { get; set; }

  public override string ToString() {
    return $"Codigo: {Codigo} - Isbn do livro: {IsbnLivro} - Disponível: {Disponivel}";
  }
}