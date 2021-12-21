using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Amazonia.Web.BackOffice.Pages
{
    public class CadClienteModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public CadClienteModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
