using CRUD;

class Program
{
    static void Main(string[] args)
    {
        //CONEXÃO COM O BANCO
        string StringDeConexao = "Coloque aqui sua conexão do banco de dados";
        Banco banco = new Banco(StringDeConexao);
        Processamentos processamentos = new Processamentos(banco);
        
        //METODOS --> CLASSE PROCESSAMENTO
        processamentos.InserirDados();
        processamentos.VerificarDados();
        processamentos.AtualizandoDados();
        processamentos.ExcluindoDados();
        processamentos.Menu();
    }
}