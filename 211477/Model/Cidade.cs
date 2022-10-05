using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;


namespace _211477.Model
{
   public class Cidade
    {
        public int ID { get; set; } 

        public string Nome { get; set; }

        public string uf { get; set; }  


        public void Incluir()
        {
            try
            {
                Banco.AbriConexao();
                Banco.Comando = new MySqlCommand("INSERT INTO cidade ( nome, uf) VALUES (@nome,@uf)", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@nome", Nome);
                Banco.Comando.Parameters.AddWithValue("@uf", uf);

                Banco.Comando.ExecuteNonQuery();

                Banco.FecharConexao();
            }catch(Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

     
    }
}
