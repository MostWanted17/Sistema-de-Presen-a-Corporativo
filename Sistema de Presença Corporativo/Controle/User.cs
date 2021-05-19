using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Presença_Corporativo.Controle
{
    public class User
    {
        Conection conn;
        private string username, senha, nome, apelido, endereco, nome_categoria;
        private bool sexo;
        private int telefone;
        private float total_salario;

        public string Username { get => username; set => username = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Apelido { get => apelido; set => apelido = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Nome_categoria { get => nome_categoria; set => nome_categoria = value; }
        public bool Sexo { get => sexo; set => sexo = value; }
        public float Total_salario { get => total_salario; set => total_salario = value; }
        public int Telefone { get => telefone; set => telefone = value; }

        public bool setUsername(string value) {
            conn = new Conection();
            if (conn.setUsername(value, username) == true)
            {
                username = value;
                return true;
            }
            return false;
        }
        public bool setSenha(string value)
        {
            conn = new Conection();
            if (conn.setSenha(value, username) == true)
            {
                senha = value;
                return true;
            }
            return false;
        }
        public bool setNoApEnTe(string setnome, string setapelido,string setendereco,int settelefone)
        {
            conn = new Conection();
            if (conn.setInfo(setnome,setapelido,setendereco,settelefone,username) == true)
            {
                nome = setnome;
                apelido = setapelido;
                endereco = setendereco;
                telefone = settelefone;
                return true;
            }
            return false;
        }
    }
}
