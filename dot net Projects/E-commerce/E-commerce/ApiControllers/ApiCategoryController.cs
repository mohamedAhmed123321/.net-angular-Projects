using Bl.Classes;
using Bl.InterFaces;
using Domains.SpResult;
using Domains.Tables;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_commerce.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCategoryController : ControllerBase
    {
        #region PrivateFeilds
        private readonly BusinessLayerInterFace<TbCategory> _clsCategory;
        #endregion
        #region ctx
        public ApiCategoryController(BusinessLayerInterFace<TbCategory> clsCategory)
        {
            _clsCategory = clsCategory;
        }
        #endregion
        // GET: api/<CategoryController>
        [HttpGet]
        public ApiResponseModel<TbCategory> Get()
        {
            try
            {
                ApiResponseModel<TbCategory> response = new ApiResponseModel<TbCategory>();
                response.Data = _clsCategory.GetAll();
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                return new ApiResponseModel<TbCategory>
                {
                    IsSuccess = false,
                    Error = ex.Message

                };
            }
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
