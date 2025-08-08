using System.Data.SqlClient;

namespace ProjetoJP.Data
{
    public class Conexao
    {
        //public SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\katit\\Documents\\Teste\\MeuBanco.mdf;Integrated Security=True;TrustServerCertificate=True;");
        public SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BancoJP;Data Source=KATIA\\SQLEXPRESS;");

        public void Conectar()
        {
            conn.Open();
        }

        public void Desconectar()
        {
            conn.Close();
        }
    }
}
