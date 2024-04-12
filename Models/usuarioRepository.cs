using MySqlConnector;
using System;
using System.Collections.Generic;
namespace ATV3__PROJETO_INTEGRADOR.Models
{
    public class usuarioRepository
    {
        private const string DadosConexao = "Database = projetointegrador; Data Source = localhost; User Id=root";

        public void testeConexao()
        {
              MySqlConnection conexao = new MySqlConnection(DadosConexao);

            conexao.Open();

            Console.WriteLine("Conectado com sucesso!");

            conexao.Close();
        }

        public void inserir(usuario u)
        {
            MySqlConnection conexao = new MySqlConnection(DadosConexao);

            conexao.Open();

            string query = "INSERT INTO usuario (nome, email, senha) VALUES (@nome, @email, @senha)";

            MySqlCommand comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@nome", u.nome);
            comando.Parameters.AddWithValue("@email", u.email);
            comando.Parameters.AddWithValue("@senha", u.senha);


            comando.ExecuteNonQuery();

            conexao.Close();
        }
        public usuario validarLogin(usuario u)
        {
            MySqlConnection conexao = new MySqlConnection(DadosConexao);
            conexao.Open();

            string query = "SELECT * FROM usuario WHERE email = @email AND senha = @senha";

            MySqlCommand comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@email", u.email);
            comando.Parameters.AddWithValue("@senha", u.senha);


            MySqlDataReader reader = comando.ExecuteReader();

            usuario loginUsuario = null;

            while (reader.Read())
            {
                loginUsuario = new usuario();

                loginUsuario.idUsuario = reader.GetInt32("idUsuario");


                if (!reader.IsDBNull(reader.GetOrdinal("email")))
                    loginUsuario.email = reader.GetString("email");

                if (!reader.IsDBNull(reader.GetOrdinal("senha")))
                    loginUsuario.senha = reader.GetString("senha");


            }

            conexao.Close();
            return loginUsuario;
        }
        public List<usuario> listar()
        {
            List<usuario> lista = new List<usuario>();

            MySqlConnection conexao = new MySqlConnection(DadosConexao);
            conexao.Open();

            string query = "SELECT * FROM usuario";
            MySqlCommand comando = new MySqlCommand(query, conexao);

            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                usuario novoUsuario = new usuario();

                novoUsuario.idUsuario = reader.GetInt32("idUsuario");

                if (!reader.IsDBNull(reader.GetOrdinal("nome")))
                    novoUsuario.nome = reader.GetString("nome");

                if (!reader.IsDBNull(reader.GetOrdinal("email")))
                    novoUsuario.email = reader.GetString("email");

                if (!reader.IsDBNull(reader.GetOrdinal("senha")))
                    novoUsuario.senha = reader.GetString("senha");

                lista.Add(novoUsuario);


            }


            conexao.Close();


            return lista;
        }
        public void editar(usuario u)
        {

            MySqlConnection conexao = new MySqlConnection(DadosConexao);
            conexao.Open();
            string query = "UPDATE SET nome =@nome, email = @email, senha= @senha WHERE  idUsuario = @idUsuario";
            MySqlCommand comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@nome", u.nome);
            comando.Parameters.AddWithValue("@email", u.email);
            comando.Parameters.AddWithValue("@senha", u.senha);
            comando.Parameters.AddWithValue("@idUsuario", u.idUsuario);

            comando.ExecuteNonQuery();

            conexao.Close();

        }
        public void deletar(int idUsuario)
        {

            MySqlConnection conexao = new MySqlConnection(DadosConexao);
            conexao.Open();
            string query = "DELETE FROM usuario WHERE  idUsuario = @idUsuario";
            MySqlCommand comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@idUsuario", idUsuario);

            comando.ExecuteNonQuery();



            conexao.Close();

        }

    }






}