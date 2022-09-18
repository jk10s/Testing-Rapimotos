using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AppRapiMotos.Views.Home
{
    public class jk : PageModel
    {
        private readonly ILogger<jk> _logger;

        public jk(ILogger<jk> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}