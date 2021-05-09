using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FamilyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private readonly IFamilyService familyService;
        public AdultController(IFamilyService familyService)
        {
            this.familyService = familyService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdultsAsync()
        {
            try
            {
                IList<Adult> adults = await familyService.GetAdultsAsync();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        //The method for getting the adult from the service works, as it shows the person that it receives.
        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult<IList<Adult>>> GetAdultsByCriteriaAsync([FromRoute] string name)
        {
            Console.WriteLine(name);
            try
            {
                IList<Adult> adults = await familyService.GetAdultByCriteriaAsync(name);
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Adult>> PostAdultAsync([FromBody] Adult adult)
        {
            try
            {
                await familyService.AddAdultAsync(adult);
                return Ok(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut]
        //I compare the adults I receive from the client with the ones from the json, replacing the ones who match with null,
        //as trying to make it work with delete
        //meant I couldn't send the list of the adults I wanted to delete, as HttpDelete only required the apiUrl
        //and didn't require anything else to be sent with it (Tried to make it work with Route and Query and I didn't get any results)
        //Sending the url with the objects I would want to delete would be pretty hard as the rule of the 3 layers would be broken,
        //I think (I would have to send the ids of all the adults I selected which I am not sure would work).
        //I am not sure if this is the correct way of doing it, hopefully after your feedback I might be able to fix it.
        
        public async Task<ActionResult> DeleteAdultAsync([FromBody] IList<Adult> adult)
        {
            try
            {
                await familyService.DeleteAdultsAsync(adult);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}