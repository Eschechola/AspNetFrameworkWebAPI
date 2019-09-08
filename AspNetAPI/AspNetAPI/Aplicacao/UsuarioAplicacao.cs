using AspNetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetAPI.Aplicacao
{
    public class UsuarioAplicacao
    {
        //criando o banco de dados fictio utilizando o modelo Usuario e adicionando 4 usuarios
        private List<Usuarios> usuarios = new List<Usuarios>
        {
            new Usuarios{ Id = 0, Nome = "Lucas Gabriel", Email = "lucas.gabriel@eu.com", Senha="12345"},
            new Usuarios{ Id = 1, Nome = "João Vitor", Email = "joao.vitor@eu.com", Senha="12345"},
            new Usuarios{ Id = 2, Nome = "Ana Maria", Email = "ana.maria@eu.com", Senha="12345"},
            new Usuarios{ Id = 3, Nome = "Isabella Silva", Email = "isabella.silva@eu.com", Senha="12345"},
        };

        //método para adicionar um usuário na lista
        public bool Adicionar(Usuarios usuarioRecebido)
        {
            //atribui os dados a uma nova variavel
            var usuarioInserir = usuarioRecebido;
            //pega o valor do ultimo id cadastrado precisa do -1 pois começa em zero
            var ultimoIdCadastrado = usuarios[usuarios.Count - 1].Id;
            //adiciona +1 pois o id nao pode ser igual ao anterior
            usuarioInserir.Id = ultimoIdCadastrado + 1;

            try
            {
                usuarios.Add(usuarioInserir);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //método para remover um usuário na lista através do Id utilizando LINQ
        public bool Remover(int Id)
        {
            try
            {
                usuarios.Remove(usuarios.Where(x => x.Id == Id).ToList()[0]);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //método para alterar os dados de um usuario
        public bool Alterar(Usuarios usuarioRecebido)
        {
            //como o id é automatico, caso o id passado não exista
            //joga uma exceção que é tratada no controller
            try
            {
                usuarios[usuarioRecebido.Id].Nome = usuarioRecebido.Nome;
                usuarios[usuarioRecebido.Id].Senha = usuarioRecebido.Senha;
                usuarios[usuarioRecebido.Id].Email = usuarioRecebido.Email;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //método para exibir todos os usuarios
        public List<Usuarios> ExibirTodos()
        {
            return usuarios;
        }

        //método que busca um usuario através do id e retorna.
        public Usuarios ExibirUsuario(int id)
        {
            try
            {
                return usuarios.Where(x => x.Id == id).ToList()[0];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}