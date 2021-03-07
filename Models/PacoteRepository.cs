
using System.Collections.Generic;
using System.Data;
using MySqlConnector;

namespace klturismo.Models
{
    public class PacoteRepository
    {

        private const string DadosConexao = "Database=klturismo; Data Source=localhost; User Id=root;";
        public List<PacoteTuristico> Listar(){

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "SELECT * FROM pacotes;";

            MySqlCommand ComandoQuery = new MySqlCommand(Query, Conexao);
            MySqlDataReader DadosEncontrados = ComandoQuery.ExecuteReader();

            List<PacoteTuristico> lista = new List<PacoteTuristico>();

            while(DadosEncontrados.Read()){

                PacoteTuristico PacoteEncontrado = new PacoteTuristico();
                PacoteEncontrado.Id = DadosEncontrados.GetInt32("Id");

                if(!DadosEncontrados.IsDBNull(DadosEncontrados.GetOrdinal("Nome")))
                PacoteEncontrado.Nome =  DadosEncontrados.GetString("Nome");

                if(!DadosEncontrados.IsDBNull(DadosEncontrados.GetOrdinal("Origem")))
                PacoteEncontrado.Origem =  DadosEncontrados.GetString("Origem");

                if(!DadosEncontrados.IsDBNull(DadosEncontrados.GetOrdinal("Destino")))
                PacoteEncontrado.Destino =  DadosEncontrados.GetString("Destino");

                if(!DadosEncontrados.IsDBNull(DadosEncontrados.GetOrdinal("Atrativo")))
                PacoteEncontrado.Atrativo =  DadosEncontrados.GetString("Atrativo");

                 if(!DadosEncontrados.IsDBNull(DadosEncontrados.GetOrdinal("Saida")))
                PacoteEncontrado.Saida =  DadosEncontrados.GetDateTime("Saida");

                 if(!DadosEncontrados.IsDBNull(DadosEncontrados.GetOrdinal("Retorno")))
                PacoteEncontrado.Retorno =  DadosEncontrados.GetDateTime("Retorno"); 

                lista.Add(PacoteEncontrado);
            }
            Conexao.Close();
            return lista;
            
        }

        public void Inserir(PacoteTuristico pacote){

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "INSERT INTO pacotes(nome, origem, destino, atrativo, saida, retorno, usuario) VALUES (@Nome, @Origem, @Destino, @Atrativo, @Saida, @Retorno, @Usuario);";

            MySqlCommand ComandoQuery = new MySqlCommand(Query, Conexao);

            ComandoQuery.Parameters.AddWithValue("@Nome", pacote.Nome);
            ComandoQuery.Parameters.AddWithValue("@Origem", pacote.Origem);
            ComandoQuery.Parameters.AddWithValue("@Destino", pacote.Destino);
            ComandoQuery.Parameters.AddWithValue("@Atrativo", pacote.Atrativo);
            ComandoQuery.Parameters.AddWithValue("@Saida", pacote.Saida);
            ComandoQuery.Parameters.AddWithValue("@Retorno", pacote.Retorno);
            ComandoQuery.Parameters.AddWithValue("@Usuario", pacote.Usuario);

            ComandoQuery.ExecuteNonQuery();
            Conexao.Close();
        }
    
        
        public void Editar(PacoteTuristico pacote){

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "UPDATE pacotes SET nome=@Nome, origem=@Origem, destino=@Destino, saida=@Saida, retorno=@Retorno, usuario=@Usuario WHERE id=@Id;";

            MySqlCommand ComandoQuery = new MySqlCommand(Query, Conexao);

            ComandoQuery.Parameters.AddWithValue("@Nome", pacote.Nome);
            ComandoQuery.Parameters.AddWithValue("@Origem", pacote.Origem);
            ComandoQuery.Parameters.AddWithValue("@destino", pacote.Destino);
            ComandoQuery.Parameters.AddWithValue("@atrativo", pacote.Atrativo);
            ComandoQuery.Parameters.AddWithValue("@saida", pacote.Saida);
            ComandoQuery.Parameters.AddWithValue("@retorno", pacote.Retorno);
            ComandoQuery.Parameters.AddWithValue("@usuario", pacote.Usuario);
            ComandoQuery.Parameters.AddWithValue("@Id", pacote.Id);

            ComandoQuery.ExecuteNonQuery();
            Conexao.Close();
        }


        public void Remover(int Id){

            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "DELET FROM pacotes WHERE id=@Id;";

            MySqlCommand ComandoQuery = new MySqlCommand(Query, Conexao);
            ComandoQuery.Parameters.AddWithValue("@Id", Id);

            ComandoQuery.ExecuteNonQuery();
            Conexao.Close();

        }
    
    }
}