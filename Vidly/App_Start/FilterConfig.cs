using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // redireciona quando existem excptions
            filters.Add(new HandleErrorAttribute());
            // restrição autenticação
            filters.Add(new AuthorizeAttribute());

            // permitir apenas enderecos https
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
