using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Test_Zortout_API.External;
using Test_Zortout_API.External.Interface;
using Test_Zortout_API.Models;
using Test_Zortout_API.Models.Request;
using Test_Zortout_API.Services.Interface;

namespace Test_Zortout_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestServices _testServices;

        public TestController(ITestServices testServices)
        {
            _testServices = testServices;
        }

        [HttpPost]
        [Route("TotalSales")]
        [ProducesResponseType(typeof(TotalSalesResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResource), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTotalSales(TotalSalesRequest request)
        {
            try
            {
                var result = await _testServices.GetTotalSales(request);
                var response = new TotalSalesResponse(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorInnerResources = JsonConvert.DeserializeObject<List<ErrorInnerResource>>(ex.Message);
                return BadRequest(new ErrorResource(errorInnerResources));
            }
        }

        [HttpPost]
        [Route("Authenticate")]
        [ProducesResponseType(typeof(AuthenticateResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResource), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAuthenticate(AuthenticateRequest request)
        {
            try
            {
                var result = await _testServices.GetAuthenticate(request);
                var response = new AuthenticateResponse(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorInnerResources = JsonConvert.DeserializeObject<List<ErrorInnerResource>>(ex.Message);
                return BadRequest(new ErrorResource(errorInnerResources));
            }
        }

        [HttpPost]
        [Route("Cost")]
        [ProducesResponseType(typeof(CostResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResource), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCost([FromBody]CostRequest request, [FromHeader] [Required] string token)
        {
            try
            {
                var result = await _testServices.GetCost(request, token);
                var response = new CostResponse(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorInnerResources = JsonConvert.DeserializeObject<List<ErrorInnerResource>>(ex.Message);
                return BadRequest(new ErrorResource(errorInnerResources));
            }
        }
    }
}
