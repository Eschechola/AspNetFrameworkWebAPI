using API_RESTful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_RESTful.Controllers
{
    public class MinhaAPIController : ApiController
    {
        static readonly Repositório repositório = new Repositório();

        [HttpGet]
        public List<Usuario> VerTodosUsuarios()
        {
            //http://localhost:57114/api/MinhaAPI/VerTodosUsuarios
            return repositório.ExibirTodos();
        }

        [HttpGet]
        public Usuario VerUmUsuario(string _id)
        {
            //http://localhost:57114/api/MinhaAPI/VerUmUsuario/?_id=2
            return repositório.ExibirUsuario(Int32.Parse(_id));
        }

        [HttpPost]
        public string InserirUsuario([FromUri]string _nome, [FromUri]string _email, [FromUri]string _senha)
        {
            //http://localhost:57114/api/MinhaAPI/InserirUsuario/?_nome=Alguem&_email=Alguem.eu@eu.com&_senha=1234
            try
            {
                repositório.Adicionar(new Usuario { Id = repositório.ExibirTodos().Count, Nome = _nome, Senha = _senha, Email = _email });
            }
            catch
            {
                return "Ocorreu algum erro, tente novamente mais tarde.";
            }
            return "Usuario inserido com sucesso!";
        }

        [HttpPut]
        public string AlterarUsuario([FromUri]string _id, [FromUri]string _nome, [FromUri]string _email, [FromUri]string _senha)
        {
            if (string.IsNullOrEmpty(_id)||string.IsNullOrWhiteSpace(_id))
            {
                return "O Id não pode ser nulo!";
            }

            //http://localhost:57114/api/MinhaAPI/AlterarUsuario/?_id=0&_nome=PauloCesar&_email=paulo.cesar@eu.com&_senha=12345
            Usuario _user = new Usuario();
            _user.Id = Int32.Parse(_id);
            _user.Nome = _nome;
            _user.Email = _email;
            _user.Senha = _senha;
            try
            {
                repositório.Alterar(_user);
            }
            catch
            {
                return "Ocorreu algum erro, tente novamente mais tarde.";
            }
            return "Usuario alterado com sucesso!";
        }

        [HttpDelete]
        public string DeletarUsuario([FromUri]string _id)
        {
            //http://localhost:57114/api/MinhaAPI/DeletarUsuario/?_id=0
            if (string.IsNullOrEmpty(_id) || string.IsNullOrWhiteSpace(_id))
            {
                return "O Id não pode ser nulo!";
            }

            try
            {
                repositório.Remover(Int32.Parse(_id));
                return "Usuario deletado com sucesso!";
            }
            catch
            {
                return "Ocorreu algum erro, tente novamente mais tarde.";
            }
            
        }
    }
}
