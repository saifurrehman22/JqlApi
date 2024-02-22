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


        [HttpGet("GetAllDisplay")]
        public IActionResult GetAllDisplay(string displayName)
        {
            if (string.IsNullOrEmpty(displayName))
            {
                return BadRequest("Display name cannot be empty.");
            }
      
            var remainingDisplayNames = incidentsData
                .Where(incident => !incident.DisplayName.Equals(displayName, StringComparison.OrdinalIgnoreCase))
                .Select(incident => incident.DisplayName)
                .Distinct()
                .ToList();

            return Ok(remainingDisplayNames);
        }


        [HttpGet("GetDisplayAndOperator")]
        public IActionResult GetDisplayAndOperator(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return BadRequest("Value cannot be empty.");
            }

            var jqlData = incidentsData
                .FirstOrDefault(incident => incident.Value.Equals(value, StringComparison.OrdinalIgnoreCase));

            if (jqlData != null)
            {
                var result = new
                {
                    DisplayName = jqlData.DisplayName,
                    Operators = jqlData.Operators
                };

                return Ok(result);
            }

            return NotFound("Value not found.");
        }



        [HttpGet("GetDetailsWithSpace")]
        public IActionResult GetDetails(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return BadRequest("Value cannot be empty.");
            }

            var jqlData = incidentsData
                .FirstOrDefault(incident => incident.Value.Equals(value.Trim(), StringComparison.OrdinalIgnoreCase));

            if (jqlData != null)
            {
                var result = new
                {
                    DisplayName = jqlData.DisplayName,
                    Operators = value.Contains(" ") ? jqlData.Operators : null
                };

                return Ok(result);
            }

            return NotFound("Value not found.");
        }









        
        [HttpGet("GetDetailsWithSpaceInAllData")]
        public IActionResult GetDetailsWithSpaceInAllData(string value)
        {
            if (value == "value" || value.Contains(" ") )
            {
                var allData = incidentsData
         .Select(incident => new
         {
             DisplayName = incident.DisplayName,
             Operators = value.Contains(" ") ? incident.Operators : null
         })
         .ToList();

                if (allData.Any())
                {
                    return Ok(allData);
                }
            }
 
               return NotFound("No data found.");
        }



        //   get value on base of all data 

        [HttpGet("GetData")]
        public IActionResult GetData(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return BadRequest("Search query cannot be empty.");
            }

            var matchingData = incidentsData
                .Where(incident =>
                    incident.DisplayName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    incident.Value.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    incident.Types.Any(type => type.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)) ||
                    incident.Operators.Any(op => op.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)))
                .Select(incident => new
                {
                    DisplayName = incident.DisplayName,
                    Value = incident.Value,
                    Types = incident.Types,
                    Operators = incident.Operators
                })
                .ToList();

            if (matchingData.Any())
            {
                return Ok(matchingData);
            }

            return NotFound("No matching data found for the provided search query.");
        }






        //   get value on base of DispalyName

        [HttpGet("GetDataFromDispalyName")]                         
        public IActionResult GetDataFromDispalyName(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return BadRequest("Search query cannot be empty.");
            }

            var matchingData = incidentsData
                .Where(incident => incident.DisplayName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                .Select(incident => new
                {
                    DisplayName = incident.DisplayName
                })
                .ToList();

            if (matchingData.Any())
            {
                return Ok(matchingData);
            }

            return NotFound("No matching data found for the provided search query.");
        }



        //  get value on base of DispalyName


        [HttpGet("GetDataFromDispalyNameAndOperator")]
        public IActionResult GetDataFromDispalyNameAndOperator(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return BadRequest("Search query cannot be empty.");
            }


            var matchingData = incidentsData
                .Where(incident => incident.DisplayName.Contains(searchQuery.TrimEnd(), StringComparison.OrdinalIgnoreCase))
                .Select(incident => new
                {
                    DisplayName = incident.DisplayName,
                    Operators = searchQuery.Contains(" ") ? incident.Operators : null
                })
                .ToList();

            if (matchingData.Any())
            {
                return Ok(matchingData);
            }

            return NotFound("No matching data found for the provided search query.");
        }

    }

   
}
