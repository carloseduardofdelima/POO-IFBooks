using System;
using System.Collections.Generic;
using System.Linq;

static class NExemplar {
  private static List<Exemplar> exemplares = new List<Exemplar>();
  public static void Inserir(Exemplar e) {
    exemplares.Add(e);
  }
  public static List<Exemplar> Listar() {
    var x = exemplares.OrderBy(e => e.IsbnLivro).ToList();
    return x;
  }
  public static Exemplar Listar(int codigo) {
    foreach(Exemplar obj in exemplares)
      if (obj.Codigo == codigo) return obj;
    return null;
  }

  public static List<Exemplar> ListarDisponiveis() {
    var x = exemplares.Where(e => e.Disponivel == true).ToList();
    return x;
  }
  
  public static void Atualizar(Exemplar e) {
    Exemplar atual = Listar(e.Codigo);
    if (atual != null) 
      atual.Codigo = e.Codigo;
      atual.Disponivel = e.Disponivel;
      atual.IsbnLivro = e.IsbnLivro;
  }
  
  public static void Excluir(Exemplar e) {
    Exemplar atual = Listar(e.Codigo);
    if (atual != null) 
      exemplares.Remove(atual);
  }
}