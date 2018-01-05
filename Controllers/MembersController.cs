using AutoMapper;
using MBApplication.ViewModels;
using MBApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MBApplication.Controllers
{
    [Route("api/[controller]")]
    public class MembersController : Controller
    {
        private readonly MBAppContext _dbContext;
        private readonly IMapper _mapper;
        
        public MembersController(MBAppContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext; 
            _mapper = mapper;   
        }

        //GET api/members/Get/1
        [HttpGet("Get/{id}")]
        public IActionResult Get(int? id)
        {
            var member = _dbContext.Members.Where(i => i.Id == id).FirstOrDefault();    
            if (id != null)
            {
                
                return new JsonResult (_mapper.Map<MemberViewModel>(member), DefaultJsonSettings);
            }
            else
            {
                return NotFound();
            }
        }

        //GET api/members/GetMembers
        [HttpGet("GetMembers")]
        public IActionResult GetMembers()
        {
            var members = _dbContext.Members.OrderBy(m => m.DateOfBirth).Take(AllMembers).ToList();

            return new JsonResult(ToMemberViewModelList(members), DefaultJsonSettings);
        }

        //GET api/members/GetMembers/10
        [HttpGet("GetMembers/{n}")]
        public IActionResult GetMembers(int n)
        {
            var members = _dbContext.Members.OrderBy(m => m.DateOfBirth).Take(n).ToList();

            return new JsonResult(ToMemberViewModelList(members), DefaultJsonSettings);
        }

        //GET api/members/GetFamilyMembers/1
        [HttpGet("GetFamilyMembers/{id}")]
        public IActionResult GetFamilyMembers(int? id)
        {
            var members = _dbContext.Members.Where(i => i.FamilyId == id);
            if (id != null)
            {

                return new JsonResult(ToMemberViewModelList(members), DefaultJsonSettings);
            }
            else
            {
                return NotFound(new {Error = String.Format("Family ID {0} has not been found")});
            }
        }


        //Return the total number of Members
        public int  AllMembers
        {
             get
             {
                 return _dbContext.Members.Count();
             }
        }

        // Maps a collection of Member entities into a list of MemberViewModel objects.
        // Returns a mapped list of MemberViewModel objects.
        private List<MemberViewModel> ToMemberViewModelList(IEnumerable<Member> members)
        {
            var membersList = new List<MemberViewModel>();

            foreach (var member in members)
            {
                membersList.Add(_mapper.Map<MemberViewModel>(member));
            }
            return membersList;
        }
        
        // Returns a suitable JsonSerializerSettings object that can be used to generate the 
        // JsonResult return value for this Controller's methods.
        private JsonSerializerSettings DefaultJsonSettings
        {
            get
            {
                return new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                };
            }
        }
    }
}