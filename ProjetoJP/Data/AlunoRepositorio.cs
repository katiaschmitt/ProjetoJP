using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJP.Data
{
    public class AlunoRepositorio
    {
        private SqlConnection _conn;
        public AlunoRepositorio(SqlConnection conn)
        {
            _conn = conn;
        }
        public string InserirAluno(Aluno aluno)
        {
            try
            {
                string sql = $"INSERT INTO Aluno (Nome, Idade, Cpf) VALUES('{aluno.Nome}', {aluno.Idade}, '{aluno.Cpf}')";
                SqlCommand comando = new SqlCommand(sql, _conn);

                comando.ExecuteNonQuery();

                return "Aluno inserido com sucesso!";
            }
            catch (Exception e)
            {

                return "Erro ao inserir Aluno";
            }
        }

        public List<Aluno> BuscarAlunos()
        {
            try
            {
                string sql = "select Nome, Idade, Cpf from Aluno";
                SqlCommand comando = new SqlCommand(sql, _conn);

                List<Aluno> alunos = new List<Aluno>();

                using (var reader = comando.ExecuteReader())
                {
                    //cria um leitor do ADO.net

                    while (reader.Read())
                    {///vai lendo cada item do resultado do select
                     ///retorna cada item encontrado
                        var nomeDb = reader.GetString(reader.GetOrdinal("Nome"));
                        var idadeDb = reader.GetInt32(reader.GetOrdinal("Idade"));
                        var cpfDb = reader.GetString(reader.GetOrdinal("Cpf"));

                        alunos.Add(new Aluno()
                        {
                            Nome = nomeDb,
                            Idade = idadeDb,
                            Cpf = cpfDb
                        });

                    }
                    return alunos;
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public string EditarAluno(Aluno aluno)
        {
            try
            {
                string sql = @"Update Aluno
                    SET Nome = @Nome, Idade = @Idade, Cpf = @Cpf
                    Where Id = @Id";

                using (SqlCommand comando = new SqlCommand(sql, _conn))
                {
                    comando.Parameters.AddWithValue("@Nome", aluno.Nome);
                    comando.Parameters.AddWithValue("@Idade", aluno.Idade);
                    comando.Parameters.AddWithValue("@Cpf", aluno.Cpf);
                    comando.Parameters.AddWithValue("@Id", aluno.Id);

                    comando.ExecuteNonQuery();

                    return "Aluno editado com sucesso";
                }
            }
            catch (Exception e)
            {

                return "Erro ao editar Aluno";
            }
        }

        public string ExcluirAluno(int id)
        {
            try
            {
                string sql = @"delete from Aluno Where Id = @Id";

                using (SqlCommand comando = new SqlCommand(sql, _conn))
                {
                    comando.Parameters.AddWithValue("@Id", id);

                    comando.ExecuteNonQuery();

                    return "Aluno Excluído com sucesso";
                }
            }
            catch (Exception e)
            {

                return "Erro ao excluir Aluno";
            }
        }

    }
}
