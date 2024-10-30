using Bl;
using CoursesProject.Models;
using Domains;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoursesProject.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        Interface1<TbInstructor> ClsInstructor;
        public InstructorController(Interface1<TbInstructor> ClsInstructors)
        {
            ClsInstructor = ClsInstructors;
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public ApiResponse GetAll()
        {
            try
            {
                ApiResponse OapiResponse = new ApiResponse();
                OapiResponse.Data = ClsInstructor.GettAll();
                OapiResponse.Errors = null;
                OapiResponse.StatusCode = "200";
                return OapiResponse;
            }
            catch
            (Exception ex)
            {
                ApiResponse oApiResponse = new ApiResponse();
                oApiResponse.Data = null;
                oApiResponse.Errors = ex.Message;
                oApiResponse.StatusCode = "502";
                return oApiResponse;

            }
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public ApiResponse Get(int id)
        {
            try
            {
                ApiResponse OapiResponse = new ApiResponse();
                OapiResponse.Data = ClsInstructor.GetById(id);
                OapiResponse.Errors = null;
                OapiResponse.StatusCode = "200";
                return OapiResponse;
            }
            catch
            (Exception ex)
            {
                ApiResponse oApiResponse = new ApiResponse();
                oApiResponse.Data = null;
                oApiResponse.Errors = ex.Message;
                oApiResponse.StatusCode = "502";
                return oApiResponse;

            }
        }
        [HttpGet]
        public ApiResponse GetAllWithData()
        {
            try
            {
                ApiResponse OapiResponse = new ApiResponse();
                OapiResponse.Data = ClsInstructor.GettAllWithData();
                OapiResponse.Errors = null;
                OapiResponse.StatusCode = "200";
                return OapiResponse;
            }
            catch
            (Exception ex)
            {
                ApiResponse oApiResponse = new ApiResponse();
                oApiResponse.Data = null;
                oApiResponse.Errors = ex.Message;
                oApiResponse.StatusCode = "502";
                return oApiResponse;

            }
        }

        // POST api/<CoursesController>
        [HttpPost]
        [Route("Post")]
        public ApiResponse Post([FromBody] TbInstructor item)
        {
            try
            {
                ClsInstructor.Save(item);
                ApiResponse oApiResponse = new ApiResponse();
                oApiResponse.Data = "done";
                oApiResponse.Errors = null;
                oApiResponse.StatusCode = "200";
                return oApiResponse;
            }
            catch (Exception ex)
            {
                ApiResponse oApiResponse = new ApiResponse();
                oApiResponse.Data = null;
                oApiResponse.Errors = ex.Message;
                oApiResponse.StatusCode = "502";
                return oApiResponse;
            }
        }
        [HttpPost]
        [Route("Delete")]
        public ApiResponse Delete([FromBody] int id)
        {
            try
            {
                ClsInstructor.Delete(id);
                ApiResponse oApiResponse = new ApiResponse();
                oApiResponse.Data = "done";
                oApiResponse.Errors = null;
                oApiResponse.StatusCode = "200";
                return oApiResponse;
            }
            catch (Exception ex)
            {
                ApiResponse oApiResponse = new ApiResponse();
                oApiResponse.Data = null;
                oApiResponse.Errors = ex.Message;
                oApiResponse.StatusCode = "502";
                return oApiResponse;
            }
        }
    }
}
