using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UKParliament.CodeTest.Data.ViewModels;
using UKParliament.CodeTest.Services;

namespace UKParliament.CodeTest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        [HttpGet]
        public ActionResult<List<DepartmentViewModel>> Get()
        {
            try
            {
                var departments = _departmentService.Get();

                return Ok(departments);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
