using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
using mvc.Models;

namespace mvc.Models
{
    public class ContatosBD
    {
        private static string DadosCN = "Database=sistemfullstack ;Data Source=localhost; User Id=root;";

        public static String TestarConexao(){
            MySqlConnection conexao = new MySqlConnection(DadosCN);
            
            conexao.Open();
            conexao.Close();
            string mensagem = "Conectado com sucesso";
            return mensagem;
        }
        public static void Inserir (Contatos contato){
            MySqlConnection conexao = new MySqlConnection(DadosCN);
            conexao.Open();
            string query = "INSERT INTO contatos (nome, numero, email, msg) VALUES (@nome, @numero, @email, @msg) ";
            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@nome", contato.nome);
            comando.Parameters.AddWithValue("@numero", contato.numero);
            comando.Parameters.AddWithValue("@email", contato.email);
            comando.Parameters.AddWithValue("@msg", contato.msg);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        public static List<Contatos> Listar(){
            MySqlConnection conexao = new MySqlConnection(DadosCN);
            conexao.Open();
            string query = "SELECT * FROM contatos;";
            MySqlCommand comando = new MySqlCommand(query, conexao);
            MySqlDataReader leitor = comando.ExecuteReader();
            
            List<Contatos> lista = new  List<Contatos> ();
            while (leitor.Read())
            {
                Contatos contato = new Contatos();
                if (!leitor.IsDBNull(leitor.GetOrdinal("nome")))
                    contato.nome = leitor.GetString("nome");
                if (!leitor.IsDBNull(leitor.GetOrdinal("email")))
                    contato.email = leitor.GetString("email");
                if (!leitor.IsDBNull(leitor.GetOrdinal("numero")))
                    contato.numero = leitor.GetString("numero");
                if (!leitor.IsDBNull(leitor.GetOrdinal("msg")))
                    contato.msg = leitor.GetString("msg");

                    lista.Add(contato);
            }
            conexao.Close();
            return lista;
        }
    }
}