using System;
using System.Linq;
using System.Web.Mvc;
using GrapeSite.Models;

namespace GrapeSite.Controllers
{
    public class ClienteController : Controller
    {
        private GrapeFazendaContext db = new GrapeFazendaContext();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

            if (!ModelState.IsValid)
            {
               
                var erros = ModelState.Values.SelectMany(v => v.Errors)
                                             .Select(e => e.ErrorMessage)
                                             .ToArray();
                return Json(new { sucesso = false, mensagem = string.Join("<br>", erros) });
            }

            var cliente = db.Clientes.FirstOrDefault(c => c.Email == model.Email && c.Senha == model.Senha);

            if (cliente != null)
            {
                return Json(new { sucesso = true, mensagem = "Tudo certo, cadastro validado. Você já pode acessar o aplicativo mobile com essas credenciais." });
            }
            else
            {
                return Json(new { sucesso = false, mensagem = "Erro: Cadastro não encontrado. Por favor, crie uma conta primeiro." });
            }
        }

        // GET: CriarConta
        public ActionResult CriarConta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarConta(Cliente cliente)
        {
            try
            {
                // esse trecho verifica se o cliente já está cadastrado
                if (db.Clientes.Any(c => c.Email == cliente.Email))
                {
                    return Json(new { sucesso = false, mensagem = "Erro: Já existe uma conta com esse e-mail." });
                }

                if (ModelState.IsValid)
                {
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    return Json(new { sucesso = true, mensagem = "Cadastrado com sucesso!" });
                }
                else
                {

                    var erros = ModelState.Values.SelectMany(v => v.Errors)
                                                 .Select(e => e.ErrorMessage)
                                                 .ToArray();
                    return Json(new { sucesso = false, mensagem = string.Join("<br>", erros) });
                }
            }
            catch (Exception ex)
            {
                return Json(new { sucesso = false, mensagem = "Erro ao salvar no banco de dados: " + ex.Message });
            }
        }
    }
}
