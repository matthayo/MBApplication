using System.Collections.Generic;
using MBApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MBApplication.Controllers
{
    [Route("api/[controller]")]
    public class MembersController : Controller
    {
        //GET api/members/GetNewMembers/10
        [HttpGet("GetNewMembers/{num}")]
        public JsonResult GetNewMembers(int num){
            var member = new List<MemberViewModel>();

            for(int i = 1; i <= num; i++) 
                member.Add(new MemberViewModel()
                {
                    Id = i,
                    FirstName = string.Format("Firstname{0}", i),
                    LastName = string.Format("Lastname{0}", i)
                });

            var settings = new JsonSerializerSettings(){
                Formatting = Formatting.Indented
            };

            return new JsonResult (member, settings);
        }
    }
}