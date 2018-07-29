using BCSProjectAPI.BusinessLayer.Manager;
using System.Web.Http;

namespace BCSProjectAPI.Controllers
{
    //[Authorize]
    public class DepartmentsController : ApiController
    {
        DepartmentManager _departmentManager;

        public DepartmentsController()
        {
            _departmentManager = new DepartmentManager();
        }

        // GET api/departments
        [HttpGet]
        public IHttpActionResult GetDepartments()
        {
            var result = _departmentManager.GetDepartments();
            return Ok(result);
        }
    }
}
