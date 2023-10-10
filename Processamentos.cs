namespace CRUD
{
    internal class Processamentos
    {
        private Banco banco;

        public Processamentos(Banco banco)
        {
            this.banco = banco;
        }

        public void InserirDados()
        {
            Console.WriteLine("Deseja inserir dados no banco? (sim/não)");
            string resposta = Console.ReadLine();


            if (resposta.ToLower() == "sim")
            {
                Console.Write("Digite o nome: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o email: ");
                string email = Console.ReadLine();

                Console.Write("Digite a senha: ");
                string senha = Console.ReadLine();

                //METODO
                banco.InserirInformacoesDeLogin(nome, email, senha);

                Console.WriteLine("Informações de login inseridas no banco de dados com sucesso.");
            }
        }

        public void VerificarDados()
        {

            Console.WriteLine("Deseja verificar os dados inseridos? (sim/não)");
            string resposta2 = Console.ReadLine();


            if (resposta2.ToLower() == "sim")
            {
                //METODO
                List<Login> usuarios = banco.LerUsuarios();

                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"ID: {usuario.Id}, Nome: {usuario.Nome}, Email: {usuario.Email}, Senha: {usuario.Senha}, Cadastro: {usuario.Cadastro}");
                }
            }
        }

        public void AtualizandoDados()
        {
            Console.WriteLine("Deseja atualizar os dados no banco? (sim/não)");
            string resposta3 = Console.ReadLine();


            if (resposta3.ToLower() == "sim")
            {

                List<Login> usuarios = banco.LerUsuarios();

                if (usuarios != null && usuarios.Count > 0)
                {
                    Console.WriteLine("Usuários existentes:");
                    foreach (var usuario in usuarios)
                    {
                        Console.WriteLine($"ID: {usuario.Id}, Nome: {usuario.Nome}");
                    }

                    Console.Write("Digite o ID do usuário que deseja atualizar: ");
                    if (int.TryParse(Console.ReadLine(), out int userId))
                    {
                        // Localizando o usuário com base na ID   //obj //id do obj // id
                        Login usuarioParaAtualizar = usuarios.Find(u => u.Id == userId);

                        if (usuarioParaAtualizar != null)
                        {
                            Console.Write("Digite o novo nome: ");
                            string novoNome = Console.ReadLine();

                            Console.Write("Digite o novo email: ");
                            string novoEmail = Console.ReadLine();

                            Console.Write("Digite a nova senha: ");
                            string novaSenha = Console.ReadLine();

                            // Atualizando
                            usuarioParaAtualizar.Nome = novoNome;
                            usuarioParaAtualizar.Email = novoEmail;
                            usuarioParaAtualizar.Senha = novaSenha;

                            // METODO
                            banco.AtualizarUsuario(usuarioParaAtualizar);

                            Console.WriteLine("Usuário atualizado com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("ID de usuário inválido.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Não há usuários para atualizar.");
                }
            }
        }
        public void ExcluindoDados()
        {

            Console.Write("Deseja deletar um registro? (sim/não)");
            string resposta4 = Console.ReadLine();

            if (resposta4.ToLower() == "sim")
            {
                List<Login> usuarios = banco.LerUsuarios();

                if (usuarios != null && usuarios.Count > 0)
                {
                    Console.WriteLine("Registros existentes:");

                    // Listar os registros com seus IDs
                    for (int i = 0; i < usuarios.Count; i++)
                    {
                        Console.WriteLine($"ID: {i + 1}, Nome: {usuarios[i].Nome}");
                    }

                    Console.Write("Digite o número do registro que deseja excluir: ");
                    if (int.TryParse(Console.ReadLine(), out int registroIndex) && registroIndex >= 1 && registroIndex <= usuarios.Count)
                    {
                        // Obtem o registro com base no índice escolhido pelo usuário
                        Login registroParaExcluir = usuarios[registroIndex - 1];

                        //METODO
                        banco.ExcluirUsuario(registroParaExcluir.Id);

                        Console.WriteLine("Registro excluído com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Número de registro inválido.");
                    }
                }
                else
                {
                    Console.WriteLine("Não há registros para excluir.");
                }
            }

            Console.WriteLine("CRUD realizado com sucesso");
        }
        //Looping do menu de funções
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("Quais das opções deseja fazer novamente ?");
                Console.WriteLine("1. Inserir dados");
                Console.WriteLine("2. Verificar dados");
                Console.WriteLine("3. Atualizar dados");
                Console.WriteLine("4. Excluir registro");
                Console.WriteLine("5. Sair");

                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        InserirDados();
                        break;

                    case "2":
                        VerificarDados();
                        break;

                    case "3":
                        AtualizandoDados();
                        break;

                    case "4":
                        ExcluindoDados();
                        break;

                    case "5":
                        Console.WriteLine("Saindo do programa.");
                        return;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
