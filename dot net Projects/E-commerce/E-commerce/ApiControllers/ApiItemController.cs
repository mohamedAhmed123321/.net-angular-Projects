using Bl;
using Bl.InterFaces;
using Domains.SpResult;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hiring.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiItemController : ControllerBase
    {
        #region PrivateFeilds
        private readonly SpHomePageInterFace<Sp_GetHomePageData_Result> _clsItems; 
        private readonly SpFilteredItemInterFace<Sp_GetFillteredItems_Result> _clsFilteredItems;
        #endregion
        #region ctx
        public ApiItemController(SpHomePageInterFace<Sp_GetHomePageData_Result> clsItems, SpFilteredItemInterFace<Sp_GetFillteredItems_Result> _clsFilteredItem)
        {
            _clsItems = clsItems;
            _clsFilteredItems = _clsFilteredItem;  
        } 
        #endregion
        // GET: api/<ApiJob>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // POST api/<ApiJob>
        [HttpPost]
        public ApiResponseModel<Sp_GetFillteredItems_Result> GetFilteredItem(FilteredItemsRequestModel Model)
        {
            try
            {

                ApiResponseModel<Sp_GetFillteredItems_Result> response = new ApiResponseModel<Sp_GetFillteredItems_Result>();
                response.Data = _clsFilteredItems.GetItems(Model.PageNumber, Model.Count,Model.Title,Model.RamSize,Model.CategoryName,Model.MinPrice,Model.MaxPrice);
                response.Error = "";
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                return new ApiResponseModel<Sp_GetFillteredItems_Result>
                {
                    IsSuccess = false,
                    Error = ex.Message

                };
            }
        }

        // POST api/<ApiJob>
        [HttpPost]
        public ApiResponseModel<Sp_GetHomePageData_Result> Post([FromBody] ItemRequestModel Model)
        {
            try
            {

                ApiResponseModel<Sp_GetHomePageData_Result> response = new ApiResponseModel<Sp_GetHomePageData_Result>();
                response.Data = _clsItems.GetContent(Model.PageNumber, Model.Count);
                response.Error = "";
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                return new ApiResponseModel<Sp_GetHomePageData_Result>
                {
                    IsSuccess = false,
                    Error = ex.Message

                };
            }

        }

        // PUT api/<ApiJob>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) 
        {
        }

        // DELETE api/<ApiJob>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
