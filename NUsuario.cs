using System;
using System.Collections.Generic;
using System.Linq;

static class NUsuario {
  private static List<Usuario> usuarios = new List<Usuario>();
  public static Usuario Autenticar(int mat, string senha) {
    var x = usuarios.Where(u => u.Matricula == mat && u.Senha == senha).ToList();
    return x.First();
  }
  public static void Inserir(Usuario u) {
    usuarios.Add(u);
  }
  
}