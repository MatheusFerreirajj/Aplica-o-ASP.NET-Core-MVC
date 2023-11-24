using ProjetoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Repositorio.Interfaces;
using System.Collections.Generic;

namespace ProjetoMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contato = _contatoRepository.ObterTodosOsContatos();

            return View(contato);
        }

        public IActionResult Cadastro()
        {
            return View("_Cadastro");
        }

        [HttpPost]
        public IActionResult CadastrarContato(ContatoModel contato)
        {
            ContatoModel contatoAdd =_contatoRepository.Adicionar(contato);
            if (contatoAdd == null)
                return BadRequest();
            return Ok();
        }

        [HttpGet]
        public IActionResult RemoverContato(int id)
        {
            bool Apagado = _contatoRepository.Apagar(id);
            if(!Apagado)
                return BadRequest();
            return Ok();
        }
        
        public IActionResult CarregaContato(int id)
        {
            ContatoModel contatoUpd = _contatoRepository.BuscarPorId(id);
            if(contatoUpd == null)
                return BadRequest();

            return View("_Editar",contatoUpd);
        }

        [HttpPut]
        public IActionResult EditarContato(ContatoModel contato,int id)
        {
            ContatoModel cont =_contatoRepository.Editar(contato, id);
            if(cont == null)
                return BadRequest();

            return Ok();
        }
    }
}
