using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_RESTful.Models
{
    public class Repositório
    {
        //criando o banco de dados fictio utilizando o modelo Usuario e adicionando 4 usuarios
        private List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario{ Id = 0, Nome = "Lucas Gabriel", Email = "lucas.gabriel@eu.com", Senha="12345"},
            new Usuario{ Id = 1, Nome = "João Vitor", Email = "joao.vitor@eu.com", Senha="12345"},
            new Usuario{ Id = 2, Nome = "Ana Maria", Email = "ana.maria@eu.com", Senha="12345"},
            new Usuario{ Id = 3, Nome = "Isabella Silva", Email = "isabella.silva@eu.com", Senha="12345"},
        };

        //método para adicionar um usuário na lista
        public void Adicionar(Usuario _user)
        {
            usuarios.Add(_user);
        }

        //método para remover um usuário na lista através do Id utilizando LINQ
        public void Remover(int Id)
        {
            usuarios.Remove(usuarios.Where(x => x.Id == Id).ToList()[0]);
        }

        //método para alterar os dados de um usuario
        public void Alterar(Usuario _user)
        {
            //como o id é automatico, caso o id passado seja maior que o id existente 
            //joga uma exceção que é tratada no controller
            if (_user.Id > usuarios.Count)
            {
                throw new Exception();
            }
            else
            {
                //verifica se o nome é nulo ou em branco, se não for ele altera
                if (string.IsNullOrEmpty(_user.Nome) == false || !string.IsNullOrWhiteSpace(_user.Nome) == false)
                {
                    usuarios[_user.Id].Nome = _user.Nome;
                }

                //verifica se a senha é nula ou em branco, se não for ele altera
                if (string.IsNullOrEmpty(_user.Senha) == false || string.IsNullOrWhiteSpace(_user.Senha) == false)
                {
                    usuarios[_user.Id].Senha = _user.Senha;
                }

                //verifica se o email é nulo ou em branco, se não for ele altera
                if (string.IsNullOrEmpty(_user.Email) == false || string.IsNullOrWhiteSpace(_user.Email) == false)
                {
                    usuarios[_user.Id].Email = _user.Email;
                }
            }
        }

        //método para exibir todos os usuarios
        public List<Usuario> ExibirTodos()
        {
            return usuarios;
        }

        //método que busca um usuario através do id e retorna.
        public Usuario ExibirUsuario(int id)
        {
            return usuarios.Where(x => x.Id == id).ToList()[0];
        }
    }
}