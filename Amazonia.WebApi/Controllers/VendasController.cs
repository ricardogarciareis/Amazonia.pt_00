using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Amazonia.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        [HttpGet]
        public int GetNumeroVendas()
        {
            var rand = new Random().Next();
            return rand;
        }
    }
}
