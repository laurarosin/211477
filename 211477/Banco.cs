using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace _211477
{
    internal class Banco
    {
        public static MySqlConnection Conexao;

        public static MySqlCommand Comando;

        public static MySqlDataAdapter Adaptador;

        public static DataTable datTabela;

        public static void AbriConexao()
        {
            try
            {
                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");

                Conexao.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);    
            }
        }

        public static void FecharConexao()
        {
            try
            {
                Conexao.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message,"Erro", MessageBoxButtons.OK,MessageBoxIcon.Error);   
            }
        }

        public static void CriarBanco()
        {
            try
            {
                AbriConexao();

                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas, USE vendas", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Cidades" + "(id integer auto_increment primary key, " + "nome char (40)," + "uf char (02))", Conexao);
                Comando.ExecuteNonQuery();


                FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
    }
}
