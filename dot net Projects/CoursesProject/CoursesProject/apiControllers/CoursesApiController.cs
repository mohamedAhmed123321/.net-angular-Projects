using Bl;
using CoursesProject.Models;
using Microsoft.AspNetCore.Mvc;
using Domains;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoursesProject.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesApiController : ControllerBase
    {
        Interface1<TbCourse> ClsCourse;
        public CoursesApiController(Interface1<TbCourse> ClsCourses) 
        {
            ClsCourse = ClsCourses;
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public ApiResponse GetAll()
        {
            try
            {
                ApiResponse OapiResponse = new ApiResponse();
                OapiResponse.Data = ClsCourse.GettAll();
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
                OapiResponse.Data = ClsCourse.GetById(id);
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
        [Route("GetAllWithData")]
        public ApiResponse GetAllWithData()
        {
            try
            {
                ApiResponse OapiResponse = new ApiResponse();
                OapiResponse.Data = ClsCourse.GettAllWithData();
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
        public ApiResponse Post([FromBody] TbCourse item)
        {
            try
            {
                ClsCourse.Save(item);
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
                ClsCourse.Delete(id);
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
