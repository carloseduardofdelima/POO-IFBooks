using System;
using System.Collections.Generic;
using System.Linq;

static class NAluno {
  private static List<Aluno> alunos = new List<Aluno>();
  public static void Inserir(Aluno a) {
    if(alunos.Count == 0) {
      a.Id = 1;
    }
    else {
      int x = alunos.Select(a => a.Id).Max();
      x++;
      a.Id = x;
    }
    alunos.Add(a);
  }
  
  public static List<Aluno> Listar() {
    var x = alunos.OrderBy(a => a.Id).ToList();
    return x;
  }
  
  public static Aluno Listar(int mat) {
    foreach(Aluno obj in alunos)
      if (obj.IdUsuario == mat) return obj;
    return null;
  }  
}