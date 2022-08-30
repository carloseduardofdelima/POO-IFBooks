using System;
using System.Collections.Generic;
using System.Linq;

static class NLivro {
  private static List<Livro> livros = new List<Livro>();
  public static void Inserir(Livro l) {
    livros.Add(l);
  }
  public static List<Livro> Listar() {
    var x = livros.OrderBy(l => l.Titulo).ToList();
    return x;
  }
  public static Livro Listar(int isbn) {
    foreach(Livro obj in livros)
      if (obj.Isbn == isbn) return obj;
    return null;
  }
  
  public static void Atualizar(Livro l, int isbnAntigo) {
    Livro atual = Listar(isbnAntigo);
    if (atual != null) 
      atual.Isbn = l.Isbn;
      atual.Titulo = l.Titulo;
      atual.Autor = l.Autor;
      atual.Genero = l.Genero;
      atual.Editora = l.Editora;
      atual.AnoLancamento = l.AnoLancamento;
      atual.IdSecao = l.IdSecao;
  }
  
  public static void Excluir(Livro l) {
    Livro atual = Listar(l.Isbn);
    if (atual != null) 
      livros.Remove(atual);
  }
}