using ProjetoJP;
using ProjetoJP.Data;


Conexao db = new Conexao();

db.Conectar();

AlunoRepositorio alunoRepositorio = new AlunoRepositorio(db.conn);

int opcoes = 0;

while (opcoes != 5)
{
    opcoes = Menu();
    Console.Clear();
    switch (opcoes)
    {
        case 1:
            CadastrarAluno();
            Console.Clear();
            break;
        case 2:
            ConsultarAluno();
            Console.Clear();
            break;
        case 3:
            EditarAluno();
            Console.Clear();
            break;
        case 4:
            ExcluirAluno();
            Console.Clear();
            break;
        case 5:
            Console.WriteLine("ENCERRANDO PROGRAMA....");
            break;
    }
}
Console.ReadKey();
static int Menu()
{
    Console.WriteLine("MENU DE OPÇÕES");
    Console.WriteLine("===================");
    Console.WriteLine("[1] Cadastrar Aluno");
    Console.WriteLine("[2] Consultar Aluno");
    Console.WriteLine("[3] Alterar dados do aluno");
    Console.WriteLine("[4] Excluir Aluno");
    Console.WriteLine("[5] Sair");

    int opcoes = int.Parse(Console.ReadLine());
    return opcoes;
}

void CadastrarAluno()
{
    Aluno aluno = new Aluno();

    Console.WriteLine("Preencha os dados solicitados do Aluno");

    Console.WriteLine("Nome Completo");
    aluno.Nome = Console.ReadLine();

    Console.WriteLine("Idade");
    aluno.Idade = int.Parse(Console.ReadLine());

    Console.WriteLine("Cpf");
    aluno.Cpf = Console.ReadLine();

    Console.WriteLine("Cep");
    aluno.Cep = Console.ReadLine();

    Console.WriteLine("Endereço");
    aluno.Endereco = Console.ReadLine();

    Console.WriteLine("Némero da Casa");
    aluno.Numero = Console.ReadLine();

    Console.WriteLine("Bairro");
    aluno.Bairro = Console.ReadLine();

    Console.WriteLine("Cidade");
    aluno.Cidade = Console.ReadLine();

    Console.WriteLine("Estado (sigla, ex: SC, SP, RJ):\"");
    string estadoDigitado = Console.ReadLine();

    if (Enum.TryParse<EstadosBrasil>(estadoDigitado.ToUpper(), out EstadosBrasil estadoEnum))
    {
        aluno.Estado = estadoEnum.ToString();
    }
    else
    {
        Console.WriteLine("Estado inválido!");
        Console.WriteLine("Estado (sigla, ex: SC, SP, RJ):\"");
        estadoDigitado = Console.ReadLine();
    }
    //aluno.Estado = Console.ReadLine();

    Console.WriteLine("Nota 1");
    aluno.Nota1 = double.Parse(Console.ReadLine());

    Console.WriteLine("Nota 2");
    aluno.Nota2 = double.Parse(Console.ReadLine());

    var retorno = alunoRepositorio.InserirAluno(aluno);

   Console.WriteLine(retorno);
   Console.ReadLine();

}
void ConsultarAluno()
{
    Aluno aluno = new Aluno();

    Console.WriteLine("Informe o nome do aluno que deseja buscar");
    aluno.Nome = Console.ReadLine();

    var alunos = alunoRepositorio.BuscarAlunos();

    aluno = alunos.Where(x => x.Nome.Contains(aluno.Nome)).FirstOrDefault();

    Console.WriteLine($"Dados de {aluno.Nome}");
    Console.WriteLine($"Idade {aluno.Idade}");
    Console.WriteLine($"Cpf {aluno.Cpf}");

    Console.ReadLine();
}
void EditarAluno()
{
    Aluno aluno = new Aluno();

    Console.WriteLine("Informe o nome do aluno que deseja editar as informações");
    aluno.Nome = Console.ReadLine();

    var alunos = alunoRepositorio.BuscarAlunos();

    aluno = alunos.Where(x => x.Nome.Contains(aluno.Nome)).FirstOrDefault();

    Console.WriteLine($"1 - Dados de {aluno.Nome}");
    Console.WriteLine($"2 - Idade {aluno.Idade}");
    Console.WriteLine($"3 - Cpf {aluno.Cpf}");
    Console.WriteLine($"Informe o código do registro que deseja editar:");

    int edicao = int.Parse(Console.ReadLine());

    switch (edicao)
    {
        case 1:
            Console.WriteLine($"Informe o nome do(a) aluno(a)");
            aluno.Nome = Console.ReadLine();
            break;
        case 2:
            Console.WriteLine($"Informe a idade do(a) aluno(a)");
            aluno.Idade = int.Parse(Console.ReadLine());
            break;
        case 3:
            Console.WriteLine($"Informe o cpf do(a) aluna");
            aluno.Cpf = Console.ReadLine();
            break;
    }
    var retorno = alunoRepositorio.EditarAluno(aluno);

    Console.WriteLine(retorno);
    Console.ReadLine();
}
void ExcluirAluno()
{
    Aluno aluno = new Aluno();

    Console.WriteLine("Informe o nome do aluno que deseja buscar");
    aluno.Nome = Console.ReadLine();

    var alunos = alunoRepositorio.BuscarAlunos();

    aluno = alunos.Where(x => x.Nome.Contains(aluno.Nome)).FirstOrDefault();

    Console.WriteLine($"Tem certeza que deseja exluir {aluno.Nome} ?");
    Console.WriteLine("Digite S para Sim e N para Não");

    var opcao = Console.ReadLine(); 

    if(opcao == "S" )
    {
        var retorno = alunoRepositorio.ExcluirAluno(aluno.Id);
        Console.WriteLine(retorno);
    }
    else
        Console.WriteLine("Tecle enter para voltar ao menu principal");


    Console.ReadLine();
}





