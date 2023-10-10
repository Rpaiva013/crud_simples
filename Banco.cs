using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CRUD
{
    public class Banco
    {
        private readonly string connectionString;

        public Banco(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // INSERIR INFORMAÇÕES NO BANCO 
        public void InserirInformacoesDeLogin(string nome, string email, string senha)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sql = "INSERT INTO Usuarios (nome, email, senha, dataCadastro) VALUES (@Nome, @Email, @Senha, @DataCadastro)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", nome);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Senha", senha);
                        command.Parameters.AddWithValue("@DataCadastro", DateTime.Now); //arrumar

                        int rowsAffected = command.ExecuteNonQuery();

                        Console.WriteLine($"Linhas afetadas: {rowsAffected}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao inserir informações de login: {ex.Message}");
                }
            }
        }

        //MOSTRAR OS DADOS INSERIDOS NO BANCO 
        public List<Login> LerUsuarios()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sql = "SELECT * FROM Usuarios";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        List<Login> usuarios = new List<Login>();

                        while (reader.Read())
                        {
                            Login usuario = new Login
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Email = reader.GetString(2),
                                Senha = reader.GetString(3),
                                Cadastro = reader.GetDateTime(4)
                            };

                            usuarios.Add(usuario);
                        }

                        return usuarios;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao ler usuários: {ex.Message}");
                    return null;
                }
            }
        }

        //ATUALIZAR DADOS DE USUARIO
        public void AtualizarUsuario(Login usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sql = "UPDATE Usuarios SET Nome = @Nome, Email = @Email, Senha = @Senha WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", usuario.Nome);
                        command.Parameters.AddWithValue("@Email", usuario.Email);
                        command.Parameters.AddWithValue("@Senha", usuario.Senha);
                        command.Parameters.AddWithValue("@Id", usuario.Id);

                        int rowsAffected = command.ExecuteNonQuery();

                        Console.WriteLine($"Usuário atualizado. Linhas afetadas: {rowsAffected}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao atualizar usuário: {ex.Message}");
                }
            }
        }

        //EXCLUIR DADOS DO BANCO
        public void ExcluirUsuario(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sql = "DELETE FROM Usuarios WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", userId);

                        int rowsAffected = command.ExecuteNonQuery();

                        Console.WriteLine($"Usuário excluído. Linhas afetadas: {rowsAffected}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao excluir usuário: {ex.Message}");
                }
            }
        }

    }
}
