using System.Web.Mvc;
using System.Web.Routing;

namespace GrapeSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Ignorar rotas que envolvem recursos específicos, como arquivos AXD.
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Rota específica para Login e Criar Conta, se quiser acessar diretamente.
            routes.MapRoute(
                name: "Auth",
                url: "auth/{action}",
                defaults: new { controller = "Cliente", action = "Login" }
            );

            // Rota padrão: define qual é a página inicial e como as rotas são mapeadas.
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
