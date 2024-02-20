using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        // Sample data
        private readonly List<IncidentData> incidentsData = new List<IncidentData>
            {
                new IncidentData
                {
                    Value = "a4j-incident-creation-deduplication-alias",
                    DisplayName = "a4j-incident-creation-deduplication-alias",
                    Auto = true,
                    Orderable = true,
                    Searchable = true,
                    Operators = new List<string> { "=", "!=", "in", "not in", "is", "is not" },
                    Types = new List<string> { "java.lang.String" }
                },
                new IncidentData
                {
                    Value = "Account.category",
                    DisplayName = "Account.category",
                    Auto = true,
                    Orderable = true,
                    Searchable = true,
                    Operators = new List<string> { "=", "!=", "in", "not in", "is", "is not" },
                    Types = new List<string> { "java.lang.String" }
                }
            };

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

    public class IncidentData
    {
        public string Value { get; set; }
        public string DisplayName { get; set; }
        public bool Auto { get; set; }
        public bool Orderable { get; set; }
        public bool Searchable { get; set; }
        public List<string> Operators { get; set; }
        public List<string> Types { get; set; }
    }
}
