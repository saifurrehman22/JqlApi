using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.Models;
using WebDataInitializer;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JqlController : ControllerBase
    {
        private readonly List<JqlData> incidentsData;

        public JqlController()
        {
            // Initialize incidentsData using the initializer class
            incidentsData = DataInitializer.GetInitialData();
        }
       
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(incidentsData);
        }

        [HttpGet("GetDisplay")]
        public IActionResult GetDisplay(string displayName)
        {
            if (string.IsNullOrEmpty(displayName))
            {
                return Ok(incidentsData);
            }

            var filteredData = incidentsData
                .Where(incident => incident.DisplayName.ToLower() == displayName.ToLower())
                .ToList();

            return Ok(filteredData);
        }


    }

   
}
