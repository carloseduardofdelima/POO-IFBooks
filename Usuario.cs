using System;

class Usuario {
  public int Matricula { get; set; }
  public string Email { get; set; }
  public string Senha { get; set; }
  public bool Bibliotecario { get; set; }
 
  public override string ToString() {
    return $"{Matricula} - {Email}";
  }
}