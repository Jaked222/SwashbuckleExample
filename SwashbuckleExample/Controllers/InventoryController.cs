using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SwashbuckleExample.Attributes;
using SwashbuckleExample.Models;

namespace SwashbuckleExample.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        /// <summary>
        /// searches inventory
        /// </summary>
        /// <param name="searchString">pass an optional search string for looking up inventory</param>
        /// <param name="skip"></param>
        /// <param name="limit"></param>
        [HttpGet]
        [ProducesResponseType(typeof(List<InventoryItem>), 200)]
        [ValidateModelState]
        public IActionResult SearchInventory([FromQuery]string searchString, [FromQuery]int? skip, [FromQuery][Range(0, 50)]int? limit)
        {
            string exampleJson = null;
            exampleJson = "[ {\n  \"releaseDate\" : \"2016-08-29T09:12:33.001Z\",\n  \"name\" : \"Widget Adapter\",\n  \"id\" : \"d290f1ee-6c54-4b01-90e6-d701748f0851\",\n  \"manufacturer\" : {\n    \"phone\" : \"408-867-5309\",\n    \"name\" : \"ACME Corporation\",\n    \"homePage\" : \"https://www.acme-corp.com\"\n  }\n}, {\n  \"releaseDate\" : \"2016-08-29T09:12:33.001Z\",\n  \"name\" : \"Widget Adapter\",\n  \"id\" : \"d290f1ee-6c54-4b01-90e6-d701748f0851\",\n  \"manufacturer\" : {\n    \"phone\" : \"408-867-5309\",\n    \"name\" : \"ACME Corporation\",\n    \"homePage\" : \"https://www.acme-corp.com\"\n  }\n} ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<InventoryItem>>(exampleJson)
            : default(List<InventoryItem>);

            return StatusCode(200, example);
        }

        [HttpPost]
        [ValidateModelState]
        [ProducesResponseType(201)]
        public virtual IActionResult AddInventory([FromBody]InventoryItem inventoryItem)
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            return StatusCode(201);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 409 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(409);
        }
    }
}
