using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio21diasAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Desafio21diasAPI.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/")]
        [AllowAnonymous]
        public Home Get()
        {
            return new Home();
        }
    }
}
