
using System.Linq;
using Mapster;
using MBApplication.Data;
using MBApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MBApplication.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private ApplicationDbContext _DbContext;

        public TestController(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        [HttpGet("TestResult/{name}")]
        public IActionResult GetTestResult(string name)
        {
            try
            {
                var member = _DbContext.Members
                                            .Where(m => m.LastName.ToUpper() == name.ToUpper())
                                            .Include(f => f.Family)
                                            .ToArray();

                return new JsonResult(
                    // family.Adapt<FamilyViewModel>(),
                    member.Adapt<MemberViewModel[]>(),
                    new JsonSerializerSettings()
                    {
                        Formatting = Formatting.Indented
                    });
            }
            catch (System.Exception)
            {
                throw;
            }
            
        }
    }
}
