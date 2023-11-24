using ProjetoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC.Repositorio.Interfaces
{
    public interface IContatoRepository
    {
        ContatoModel BuscarPorId(int id);
        ContatoModel Adicionar(ContatoModel contato);
        List<ContatoModel> ObterTodosOsContatos();
        bool Apagar(int id);
        ContatoModel Editar(ContatoModel conato,int id);
    }
}
