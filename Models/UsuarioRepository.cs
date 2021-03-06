using System;
using MySqlConnector;

namespace klturismo.Models
{
    public class UsuarioRepository
    {
        private const string DadosConexao = "Database=klturismo; Data Source=localhost; User Id=root;";

        public static void TestarConexao(){

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            
                Conexao.Open();
                Console.Write("BANCO DE DADOS FUNCIONANDO!!!!");
                Conexao.Close();
            
           
        }


        public Usuario FazerLogin(Usuario user){
            
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "SELECT * FROM usuario WHERE login=@Login And senha=@Senha;";

            MySqlCommand ComandoQuery = new MySqlCommand(Query, Conexao);
            ComandoQuery.Parameters.AddWithValue("@Login", user.Login);
            ComandoQuery.Parameters.AddWithValue("@Senha", user.Senha);
            MySqlDataReader DadosEncontrados = ComandoQuery.ExecuteReader();

            Usuario UsuarioEncontrado = null;

            if(DadosEncontrados.Read()){

                UsuarioEncontrado = new Usuario();
                UsuarioEncontrado.Id = DadosEncontrados.GetInt32("Id");


                if(!DadosEncontrados.IsDBNull(DadosEncontrados.GetOrdinal("Nome")))
                UsuarioEncontrado.Nome =  DadosEncontrados.GetString("Nome");

                if(!DadosEncontrados.IsDBNull(DadosEncontrados.GetOrdinal("Login")))
                UsuarioEncontrado.Nome =  DadosEncontrados.GetString("Login");
            }
            Conexao.Close();
            
            return UsuarioEncontrado;
        }

        public void CadastrarUsuario(Usuario user){

             MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "INSERT INTO usuario(nome, login, senha, dataNascimento) VALUES (@Nome, @Login, @Senha, @DataNascimento);";

            MySqlCommand ComandoQuery = new MySqlCommand(Query, Conexao);

            ComandoQuery.Parameters.AddWithValue("@Login", user.Login);
            ComandoQuery.Parameters.AddWithValue("@Nome", user.Nome);
            ComandoQuery.Parameters.AddWithValue("@Senha", user.Senha);
            ComandoQuery.Parameters.AddWithValue("@DataNascimento", user.DataNascimento);
          
            ComandoQuery.ExecuteNonQuery();
            Conexao.Close();
        }
        


    }

}