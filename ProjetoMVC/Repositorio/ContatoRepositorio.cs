using ProjetoMVC.Data;
using ProjetoMVC.Models;
using ProjetoMVC.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoMVC.Repositorio
{
    public class ContatoRepositorio : IContatoRepository
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoEncontrado = BuscarPorId(id);

            _bancoContext.Contatos.Remove(contatoEncontrado);
            _bancoContext.SaveChanges();

            return true;
        }

        public ContatoModel BuscarPorId(int id)
        {
            return _bancoContext.Contatos.Where(x => x.Id == id).FirstOrDefault();
        }

        public ContatoModel Editar(ContatoModel contact,int id)
        {
            ContatoModel contato = BuscarPorId(id);

            contato.Id = id;
            contato.Nome = contact.Nome;
            contato.CPF = contact.CPF;
            contato.Email = contact.Email;
            contato.Celular = contact.Celular;

            _bancoContext.Update(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public List<ContatoModel> ObterTodosOsContatos()
        {
            return _bancoContext.Contatos.ToList();
        }
    }
}
