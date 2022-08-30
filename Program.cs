using System;

class Program {
  private static bool BibLogado = false;
  private static Aluno alunoLogado = null;

  public static void InserirBib() {
    Usuario u = new Usuario();
    u.Matricula = 1234;
    u.Senha = "bib";
    u.Bibliotecario = true;
    NUsuario.Inserir(u);
  }
  
  public static void Main() {
    InserirBib();    
    Console.WriteLine("----- Bem-vindo ao IFBooks -----");
    int op = 0;
    do {
      try {
        op = Menu();
        switch (op) {
            // Secao
            case 01 : 
              if (Login()) { 
                if (BibLogado) MainBib();
                else MainAluno();
              }
              else 
                Console.WriteLine("Usuário ou senha inválidos");
              break;
            case 02 : Cadastrarse(); break;
        }
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);      
      }
    } while (op != 99);
  }
    
  public static void MainBib() {
    int op = 0;
    do {
      try {
        op = MenuBib();
        switch (op) {
            // Seção
            case 01 : SecaoInserir(); break;
            case 02 : SecaoListar(); break;
            case 03 : SecaoAtualizar(); break;
            case 04 : SecaoExcluir(); break;
            // Livro
            case 05 : LivroInserir(); break;
            case 06 : LivroListar(); break;
            case 07 : LivroAtualizar(); break;
            case 08 : LivroExcluir(); break;
            // Emprestimo
            case 09 : ExemplarInserir(); break;
            case 10 : ExemplarListar(); break;
            case 11 : ExemplarAtualizar(); break;
            case 12 : ExemplarExcluir(); break;
            // Emprestimo
            case 13 : EmprestimoInserir(); break;
            case 14 : EmprestimoListar(); break;
            case 15 : EmprestimoDevolucao(); break;
            case 16 : EmprestimoExcluir(); break;
          }
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);      
      }
    } while (op != 99);
  }
  public static void MainAluno() {
    int op = 0;
    do {
      try {
        op = MenuAluno();
        switch (op) {
          case 01 : ExemplarListarDisponiveis(); break;
          case 02 : EmprestimoListarAluno(); break;
        }
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);      
      }
    } while (op != 99);
  }  
  
  public static int Menu() {
    Console.WriteLine();
    Console.WriteLine("----- Selecione ------");
    Console.WriteLine("  01 - Login");
    Console.WriteLine("  02 - Cadastrar-se");
    Console.WriteLine("----------------------");
    Console.WriteLine("  99 - Sair");
    Console.WriteLine("----------------------");
    Console.Write("Opção: ");
    return int.Parse(Console.ReadLine());    
  }

  public static int MenuBib() {
    Console.WriteLine();
    Console.WriteLine("----- Seções -----");
    Console.WriteLine("  01 - Inserir");
    Console.WriteLine("  02 - Listar");
    Console.WriteLine("  03 - Atualizar");
    Console.WriteLine("  04 - Excluir");
    Console.WriteLine("\n------ Livros ------");
    Console.WriteLine("  05 - Inserir");
    Console.WriteLine("  06 - Listar");
    Console.WriteLine("  07 - Atualizar");
    Console.WriteLine("  08 - Excluir");
    Console.WriteLine("\n------ Exemplares ------");
    Console.WriteLine("  09 - Inserir");
    Console.WriteLine("  10 - Listar");
    Console.WriteLine("  11 - Atualizar");
    Console.WriteLine("  12 - Excluir");
    Console.WriteLine("\n------ Emprestimos ------");
    Console.WriteLine("  13 - Inserir");
    Console.WriteLine("  14 - Listar");
    Console.WriteLine("  15 - Realizar Devolução");
    Console.WriteLine("  16 - Excluir");
    Console.WriteLine("----------------------");
    Console.WriteLine("  99 - Logout");
    Console.WriteLine("----------------------");
    Console.Write("Opção: ");
    return int.Parse(Console.ReadLine());    
  }
  
  public static int MenuAluno() {
    Console.WriteLine();
    Console.WriteLine($"--- Bem-vindo: {alunoLogado.Nome} ---" );
    Console.WriteLine("----------------------");
    Console.WriteLine("  01 - Listar Livros Disponíveis");
    Console.WriteLine("  02 - Ver empréstimos feitos");
    Console.WriteLine("----------------------");
    Console.WriteLine("  99 - Logout");
    Console.WriteLine("----------------------");
    Console.Write("Opcao: ");
    return int.Parse(Console.ReadLine());    
  }

  public static bool Login() {
    Console.WriteLine("Informe a matricula");
    int matricula = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe a senha");
    string senha = Console.ReadLine();
    Usuario u = NUsuario.Autenticar(matricula, senha);
    if (u != null) {
      // Alguém logou! true -> admin, false -> cliente
      BibLogado = u.Bibliotecario;
      // Cliente logado se estiver no cadastro de clientes
      // o id do usuário informado
      alunoLogado = NAluno.Listar(u.Matricula); 
      return true;
    }
    return false;
  }
  public static void Cadastrarse() {
    Console.WriteLine("Informe a matricula");
    int matricula = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe o email");
    string email = Console.ReadLine();
    Console.WriteLine("Informe a senha");
    string senha = Console.ReadLine();
    Console.WriteLine("Informe seu nome");
    string nome = Console.ReadLine();
    // Usuario
    Usuario u = new Usuario();
    u.Matricula = matricula;
    u.Email = email;
    u.Senha = senha;
    u.Bibliotecario = false;
    NUsuario.Inserir(u);
 
    // Aluno
    Aluno a = new Aluno();
    a.Nome = nome;
    a.IdUsuario = matricula; 
    NAluno.Inserir(a);
    Console.WriteLine("Aluno cadastrado com sucesso");
  }

  
  public static void SecaoInserir() {
    Console.WriteLine("----- Nova Seção -----");

    //Console.WriteLine("Informe o id da categoria");
    //int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe a descrição da seção");
    string desc = Console.ReadLine();

    Secao s = new Secao();
    //c.Id = id;
    s.Descricao = desc;

    NSecao.Inserir(s);

    Console.WriteLine("Seção inserida com sucesso");
  }
  
  public static void SecaoListar() {
    Console.WriteLine("----- Lista de Seções -----");
    foreach(Secao obj in NSecao.Listar())
      Console.WriteLine(obj);
  }
  public static void SecaoAtualizar() {
    Console.WriteLine("----- Atualizar Seção -----");

    foreach(Secao obj in NSecao.Listar())
      Console.WriteLine(obj);
    
    Console.WriteLine("Informe o id da seção a ser atualizada");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe a nova descrição da seção");
    string desc = Console.ReadLine();
    
    Secao s = new Secao();
    s.Id = id;
    s.Descricao = desc;

    NSecao.Atualizar(s);

    Console.WriteLine("Secão atualizada com sucesso");
  }
  public static void SecaoExcluir() {
    Console.WriteLine("----- Excluir Seção -----");
    foreach(Secao obj in NSecao.Listar())
      Console.WriteLine(obj);

    Console.WriteLine("Informe o id da categoria a ser excluída");
    int id = int.Parse(Console.ReadLine());
    
    Secao c = new Secao();
    c.Id = id;

    NSecao.Excluir(c);

    Console.WriteLine("Seção excluída com sucesso");
  }

  public static void LivroInserir() {
    Console.WriteLine("----- Novo Livro -----");

    Console.WriteLine("Informe o isbn do livro");
    int isbn = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe o título do livro");
    string titulo = Console.ReadLine();
    Console.WriteLine("Informe o autor");
    string autor = Console.ReadLine();
    Console.WriteLine("Informe o gênero do livro");
    string genero = Console.ReadLine();
    Console.WriteLine("Informe a editora do livro");
    string editora = Console.ReadLine();
    Console.WriteLine("Informe o ano de lançamento do livro");
    int anoLancamento = int.Parse(Console.ReadLine());

    SecaoListar();
    Console.WriteLine("Informe o id da seção em que o livro pertence");
    int idSecao = int.Parse(Console.ReadLine());
    
    Livro l = new Livro();
    l.Isbn = isbn;
    l.Titulo = titulo;
    l.Autor = autor;
    l.Genero = genero;
    l.Editora = editora;
    l.AnoLancamento = anoLancamento;
    l.IdSecao = idSecao;

    NLivro.Inserir(l);

    Console.WriteLine("Livro inserido com sucesso");
  }
  
  public static void LivroListar() {
    Console.WriteLine("----- Lista de Livros -----");
    foreach(Livro obj in NLivro.Listar())
      Console.WriteLine(obj + " - Secao: " +
        NSecao.Listar(obj.IdSecao).Descricao);
  }
  
  public static void LivroAtualizar() {
    Console.WriteLine("----- Atualizar Livro -----");

    foreach(Livro obj in NLivro.Listar())
      Console.WriteLine(obj);
    
    Console.WriteLine("Informe o isbn do livro a ser atualizado");
    int isbn = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe o novo isbn");
    int isbnNovo = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe o Título");
    string titulo = Console.ReadLine();
    Console.WriteLine("Informe o Autor");
    string autor = Console.ReadLine();
    Console.WriteLine("Informe o genero");
    string genero = Console.ReadLine();
    Console.WriteLine("Informe a editora");
    string editora = Console.ReadLine();
    Console.WriteLine("Informe o ano de lancamento");
    int anoLancamento = int.Parse(Console.ReadLine());
   

    SecaoListar();
    Console.WriteLine("Informe o id da secao em que ele pertence");
    int idSecao = int.Parse(Console.ReadLine());
    
    Livro l = new Livro();
    l.Isbn = isbnNovo;
    l.Titulo = titulo;
    l.Autor = autor;
    l.Genero = genero;
    l.Editora = editora;
    l.AnoLancamento = anoLancamento;
    l.IdSecao = idSecao;

    NLivro.Atualizar(l, isbn);

    Console.WriteLine("Livro atualizado com sucesso");
  }
  public static void LivroExcluir() {
    Console.WriteLine("----- Livro Excluir -----");
    foreach(Livro obj in NLivro.Listar())
      Console.WriteLine(obj);

    Console.WriteLine("Informe o isbn do livro a ser excluído");
    int isbn = int.Parse(Console.ReadLine());
    
    Livro l = new Livro();
    l.Isbn = isbn;

    NLivro.Excluir(l);

    Console.WriteLine("Livro excluído com sucesso");
  }

  public static void ExemplarInserir() {
    Console.WriteLine("----- Novo Exemplar -----");

    Console.WriteLine("Informe o código do exemplar");
    int codigo = int.Parse(Console.ReadLine());

    LivroListar();
    Console.WriteLine("Informe o isbn do livro de referência");
    int isbn = int.Parse(Console.ReadLine());
    
    Exemplar e = new Exemplar();
    e.Codigo = codigo;
    e.Disponivel = true;
    e.IsbnLivro = isbn;

    NExemplar.Inserir(e);

    Console.WriteLine("Exemplar inserido com sucesso");
  }
  public static void ExemplarListar() {
    Console.WriteLine("----- Lista de Exemplares -----");
    foreach(Exemplar obj in NExemplar.Listar())
      Console.WriteLine(obj + " - Livro: " +
        NLivro.Listar(obj.IsbnLivro).Titulo);
  }

  public static void ExemplarListarDisponiveis() {
    Console.WriteLine("----- Lista de Exemplares Disponíveis -----");
    foreach(Exemplar obj in NExemplar.ListarDisponiveis())
      Console.WriteLine(obj + " - Livro: " +
        NLivro.Listar(obj.IsbnLivro).Titulo);
  }
  
  public static void ExemplarAtualizar() {
    Console.WriteLine("----- Atualizar Exemplar -----");

    foreach(Exemplar obj in NExemplar.Listar())
      Console.WriteLine(obj);
    
    Console.WriteLine("Informe o código do exemplar a ser atualizado");
    int codigo = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe o isbn do livro de referência");
    int isbn = int.Parse(Console.ReadLine());
    
    
    Exemplar e = new Exemplar();
    e.Codigo = codigo;
    e.IsbnLivro = isbn;

    NExemplar.Atualizar(e);

    Console.WriteLine("Exemplar atualizado com sucesso");
  }
  public static void ExemplarExcluir() {
    Console.WriteLine("----- Exemplar Excluir -----");
    foreach(Exemplar obj in NExemplar.Listar())
      Console.WriteLine(obj);

    Console.WriteLine("Informe o codigo do exemplar a ser excluído");
    int codigo = int.Parse(Console.ReadLine());
  
    Exemplar e = new Exemplar();
    e.Codigo = codigo;
    
    NExemplar.Excluir(e);

    Console.WriteLine("Exemplar excluído com sucesso");
  }

public static void EmprestimoInserir() {
    Console.WriteLine("----- Novo Empréstimo -----");

    Console.WriteLine("Informe o código do exemplar a ser emprestado");
    int codigoExemplar = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe a matrícula do aluno");
    int matriculaAluno = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe a matricula do bibliotecário");
    int matriculaBibliotecario = int.Parse(Console.ReadLine());
    Console.WriteLine("Informe a data do empréstimo");
    DateTime dataEmprestimo = DateTime.Parse(Console.ReadLine());
    Console.WriteLine("Informe a data prevista de devolução");
    DateTime dataDevolucao = DateTime.Parse(Console.ReadLine());
    
    Emprestimo e = new Emprestimo();
    e.Id = 0;
    e.CodigoExemplar = codigoExemplar;
    e.MatAluno = matriculaAluno;
    e.MatBibliotecario = matriculaBibliotecario;
    e.DataEmprestimo = dataEmprestimo;
    e.DataDevolucao = dataDevolucao;

    NEmprestimo.Inserir(e);

    Console.WriteLine("Emprestimo inserido com sucesso");
  }
  public static void EmprestimoListar() {
    Console.WriteLine("----- Lista de Empréstimos-----");
    foreach(Emprestimo obj in NEmprestimo.Listar())
      Console.WriteLine(obj);
  }
  
  public static void EmprestimoDevolucao() {
    Console.WriteLine("----- Realizar Devolução -----");

    foreach(Exemplar obj in NExemplar.Listar()) {
      if(obj.Disponivel == false) Console.WriteLine(obj);
    }
      
    
    Console.WriteLine("Informe o código do empréstimo a ser devolvido");
    int codigo = int.Parse(Console.ReadLine());
    
    Emprestimo e = new Emprestimo();
    e.CodigoExemplar = codigo;

    NEmprestimo.Devolucao(e);

    Console.WriteLine("Livro devolvido com sucesso");
  }
  public static void EmprestimoExcluir() {
    Console.WriteLine("----- Empréstimo Excluir -----");
    foreach(Emprestimo obj in NEmprestimo.Listar())
      Console.WriteLine(obj);

    Console.WriteLine("Informe o id do empréstimo a ser excluído");
    int id = int.Parse(Console.ReadLine());
    
    Emprestimo e = new Emprestimo();
    e.Id = id;

    NEmprestimo.Excluir(e);

    Console.WriteLine("Empréstimo excluído com sucesso");
  }

  public static void EmprestimoListarAluno() {
    Console.WriteLine("Informe a matrícula do aluno");
    int matriculaAluno = int.Parse(Console.ReadLine());
    Console.WriteLine("----- Empréstimos do aluno -----");
    foreach(Emprestimo obj in NEmprestimo.ListarAluno(matriculaAluno)) {
      Console.WriteLine(obj);
    }
      

  }

}