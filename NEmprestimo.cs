using System;
using System.Collections.Generic;
using System.Linq;

static class NEmprestimo {
  private static List<Emprestimo> emprestimos = new List<Emprestimo>();
  public static void Inserir(Emprestimo e) {
    if(emprestimos.Count() == 0) {
      emprestimos.Add(e);
    }
    else {
      int id = emprestimos.Max(e => e.Id);
      id++;
      e.Id = id;
      emprestimos.Add(e);
    }
    Exemplar exemplarAtual = NExemplar.Listar(e.CodigoExemplar);
    if(exemplarAtual != null)
      exemplarAtual.Disponivel = false;
  }
  public static List<Emprestimo> Listar() {
    var x = emprestimos.OrderBy(e => e.Id).ToList();
    return x;
  }
  public static Emprestimo Listar(int id) {
    foreach(Emprestimo obj in emprestimos)
      if (obj.Id == id) return obj;
    return null;
  }

  public static List<Emprestimo> ListarAluno(int mat) {
    var x = emprestimos.Where(e => e.MatAluno == mat).ToList();
    return x;
  }


  public static void Atualizar(Emprestimo e) {
    Emprestimo atual = Listar(e.Id);
    if (atual != null) 
      atual.Id = e.Id;
      atual.CodigoExemplar = e.CodigoExemplar;
      atual.MatAluno = e.MatAluno;
      atual.MatBibliotecario = e.MatBibliotecario;
      atual.DataEmprestimo = e.DataEmprestimo;
      atual.DataDevolucao = e.DataDevolucao;
  }

  public static void Devolucao(Emprestimo e) {
    Emprestimo atual = Listar(e.Id);
    if (atual != null) 
      atual.Id = e.Id;
      atual.CodigoExemplar = e.CodigoExemplar;
      atual.MatAluno = e.MatAluno;
      atual.MatBibliotecario = e.MatBibliotecario;
      atual.DataEmprestimo = e.DataEmprestimo;
      atual.DataDevolucao = e.DataDevolucao;
    
    Exemplar exemplarAtual = NExemplar.Listar(e.CodigoExemplar);
    if(exemplarAtual != null)
      exemplarAtual.Disponivel = true;
  }
  
  public static void Excluir(Emprestimo e) {
    Emprestimo atual = Listar(e.Id);
    if (atual != null) 
      emprestimos.Remove(atual);
  }
}