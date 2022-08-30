using System;
using System.Collections.Generic;
using System.Linq;

static class NSecao {
  private static List<Secao> secoes = new List<Secao>();
  public static void Inserir(Secao s) {
    if(secoes.Count() == 0) {
      secoes.Add(s);
    }
    else {
      int id = secoes.Max(s => s.Id);
      id++;
      s.Id = id;
      secoes.Add(s);
    }
  }
  public static List<Secao> Listar() {
    var x = secoes.OrderBy(s => s.Id).ToList();
    return x;
  }
  public static Secao Listar(int id) {
    foreach(Secao obj in secoes)
      if (obj.Id == id) return obj;
    return null;
  }
  
  public static void Atualizar(Secao s) {
    Secao atual = Listar(s.Id);
    if (atual != null) 
      atual.Id = s.Id;
      atual.Descricao = s.Descricao;
  }
  
  public static void Excluir(Secao s) {
    Secao atual = Listar(s.Id);
    if (atual != null) 
      secoes.Remove(atual);
  }
}