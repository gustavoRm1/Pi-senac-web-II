using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
using mvc.Models;

namespace mvc.Models
{
    public class UsuarioBD
    {
        private static string DadosCN = "Database=sistemfullstack ;Data Source=localhost; User Id=root; ";
        public static Usuario ValidarLogin(Usuario u) {
            MySqlConnection conexao = new MySqlConnection(DadosCN);
            conexao.Open();
            string query = "SELECT * FROM usuario WHERE login=@login AND senha=@senha";
            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@login", u.login);
            comando.Parameters.AddWithValue("@senha", u.senha);
            MySqlDataReader dados = comando.ExecuteReader();

            Usuario usuarioEncontrado = null;
            if (dados.Read())
            {
                usuarioEncontrado = new Usuario();
                if(!dados.IsDBNull(dados.GetOrdinal("id")))
                    usuarioEncontrado.id = dados.GetInt32("id");
                if(!dados.IsDBNull(dados.GetOrdinal("nome")))
                    usuarioEncontrado.nome = dados.GetString("nome"); 
                if(!dados.IsDBNull(dados.GetOrdinal("tel")))
                    usuarioEncontrado.tel = dados.GetString("tel"); 
                if(!dados.IsDBNull(dados.GetOrdinal("email")))
                    usuarioEncontrado.email = dados.GetString("email");
                if(!dados.IsDBNull(dados.GetOrdinal("login")))
                    usuarioEncontrado.login = dados.GetString("login");
                if(!dados.IsDBNull(dados.GetOrdinal("senha")))
                    usuarioEncontrado.senha = dados.GetString("senha");
                if(!dados.IsDBNull(dados.GetOrdinal("tipo")))
                    usuarioEncontrado.tipo = dados.GetInt32("tipo");
            }
            conexao.Close();
            return usuarioEncontrado;

    


        
            


         
        }
            
    }
}