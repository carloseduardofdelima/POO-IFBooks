using System;

class Livro{
  public int Isbn { get; set; }
  public string Titulo { get; set; }
  public string Autor { get; set; }
  public string Genero { get; set; }
  public string Editora { get; set; }
  public int AnoLancamento { get; set; }
  public int IdSecao { get; set; }

  public override string ToString() {
    return $"Isbn: {Isbn} - Título: {Titulo} - Autor: {Autor} - Ano de lancamento: {AnoLancamento}";
  }
}