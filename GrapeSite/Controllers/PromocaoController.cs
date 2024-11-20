using System;
using System.Linq;
using System.Web.Mvc;
using GrapeSite.Models;

namespace GrapeSite.Controllers
{
    public class PromocaoController : Controller
    {
        [HttpPost]
        public ActionResult AssinarNewsletter(string email)
        {
            try
            {
                // Valida se o e-mail não está vazio
                if (string.IsNullOrWhiteSpace(email))
                {
                    return Json(new { sucesso = false, mensagem = "E-mail não pode ser vazio." });
                }

                // Validação de formato de e-mail usando Data Annotation no modelo
                var promocao = new Promocao
                {
                    Email = email,
                    DataInscricao = DateTime.Now
                };

                // Validações de Data Annotations no modelo
                if (!TryValidateModel(promocao))
                {
                    var errorMessages = ModelState.Values.SelectMany(v => v.Errors)
                                                          .Select(e => e.ErrorMessage)
                                                          .ToList();

                    return Json(new { sucesso = false, mensagem = string.Join(" ", errorMessages) });
                }

                using (var db = new GrapeFazendaContext())
                {
                    // Verificar se o e-mail já está cadastrado
                    var emailExistente = db.Promocoes.FirstOrDefault(p => p.Email == email);

                    if (emailExistente != null)
                    {
                        return Json(new { sucesso = false, mensagem = "Erro: E-mail já cadastrado." });
                    }

                    // Adiciona o novo e-mail ao banco de dados
                    db.Promocoes.Add(promocao);
                    db.SaveChanges();
                }

                return Json(new { sucesso = true, mensagem = "E-mail assinado com sucesso!" });
            }
            catch (Exception ex)
            {
            
                var exceptionDetail = new System.Text.StringBuilder();
                var currentException = ex;

                while (currentException != null)
                {
                    exceptionDetail.AppendLine(currentException.Message);
                    currentException = currentException.InnerException;
                }

                // Log do erro
                Console.WriteLine("Erro ao salvar no banco de dados: " + exceptionDetail.ToString());

                return Json(new { sucesso = false, mensagem = "Erro ao salvar no banco de dados: " + exceptionDetail.ToString() });
            }
        }
    }
}
