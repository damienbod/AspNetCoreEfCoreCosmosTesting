using AspNetCoreCosmos.DataAccess;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AspNetCoreCosmos.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MyDataService _myDataService;

        public IndexModel(ILogger<IndexModel> logger, MyDataService myDataService)
        {
            _logger = logger;
            _myDataService = myDataService;
        }

        public async Task OnGetAsync()
        {
            var data = await _myDataService.NameContains("test");
        }
    }
}
