using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SuperTrouperApi.Controllers
{
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        private const string FILE = "./data/bigfile.zip";

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Waiting for some external API
                Thread.Sleep(2000);
                // Reading file
                using(var sr = new StreamReader(FILE))
                {
                    var sha512Manager = new SHA512Managed();
                    return Ok(sha512Manager.ComputeHash(sr.BaseStream));
                }
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
