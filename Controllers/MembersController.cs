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
        private readonly MBAppDBContext _dbContext;
        private readonly IMapper _mapper;
        
        public MembersController(MBAppDBContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //GET api/members/Get/1
        [HttpGet("Get/{id}")]
        public IActionResult Get(int? id)
        {
            var member = _dbContext.Members.Where(i => i.Id == id).FirstOrDefault();    
            if (id != null && int.TryParse(id.ToString(), out var n))
            {
                return new JsonResult (_mapper.Map<MemberViewModel>(member), DefaultJsonSettings);
            }
            else
            {
                return NotFound(new { Error = String.Format("Member ID {0} has not been found", id) });
            }
        }

        //GET api/members/GetMembers
        [HttpGet("GetAllMembers")]
        public IActionResult GetAllMembers()
        {
            var members = _dbContext.Members.OrderBy(m => m.Id).Take(AllMembers).ToList();

            return new JsonResult(ToMemberViewModelList(members), DefaultJsonSettings);
        }

        //GET api/members/GetMembers/10
        [HttpGet("GetMembers/{n}")]
        public IActionResult GetMembers(int n)
        {
            var members = _dbContext.Members.OrderBy(m => m.Id).Take(n).ToList();

            return new JsonResult(ToMemberViewModelList(members), DefaultJsonSettings);
        }

        //GET api/members/GetFamilyMembers/Anderson

        [HttpGet("GetFamilyMembersByName/{familyName}")]
        public IActionResult GetFamilyMembersByName(string familyName)
        {
            var members = _dbContext.Members.Where(i => i.LastName.Equals(familyName, StringComparison.OrdinalIgnoreCase));
            if (familyName != null)
            {
                return new JsonResult(ToMemberViewModelList(members), DefaultJsonSettings);
            }
            else
            {
                return NotFound(new { Error = String.Format("Family Name {0} has not been found", familyName) });
            }
        }

        //GET api/members/GetFamilyMembers/1
        [HttpGet("GetFamilyMembersById/{id}")]
        public IActionResult GetFamilyMembersById(int? id)
        {
            var members = _dbContext.Members.Where(i => i.FamilyId == id);
            if (id != null)
            {
                return new JsonResult(ToMemberViewModelList(members), DefaultJsonSettings);
            }
            else
            {
                return NotFound(new {Error = String.Format("Family ID {0} has not been found", id)});
            }
        }

        //POST /api/members
        [HttpPost()]
        public IActionResult Add([FromBody]PremiseViewModel memberToAdd)
        {
            if(memberToAdd != null)
            {   
                //Create a new Member from Json data
                var member = _mapper.Map<Member>(memberToAdd);

                //Override system-based variable
                member.CreatedDate = DateTime.Now;
                member.LastModifiedDate = DateTime.Now;

                //Add the new member
                _dbContext.Members.Add(member);

                //Persist the changes
                _dbContext.SaveChanges();

                //Return the newly created member object
                return new JsonResult(_mapper.Map<MemberViewModel>(member), DefaultJsonSettings);
            }
            else
            {
                return new StatusCodeResult(500);
            }
        }

        //PUT api/members/1
        [HttpPut("{id}")]
        public IActionResult Update(int? id, [FromBody]MemberViewModel memberToUpdate)
        {
            if(id != null)
            {
                var member = _dbContext.Members.Where(i => i.Id == id).FirstOrDefault();

                if(member != null)
                {
                    //Handling changes on property-basis
                    member.FamilyId = memberToUpdate.FamilyId;
                    member.FirstName = memberToUpdate.FirstName;
                    member.MiddleName = memberToUpdate.MiddleName;
                    member.LastName = memberToUpdate.LastName;
                    member.Email = memberToUpdate.Email;
                    member.Telephone = memberToUpdate.Telephone;
                    member.Gender = memberToUpdate.Gender;
                    member.MaritalStatus = memberToUpdate.MaritalStatus;
                    member.DateOfBirth = memberToUpdate.DateOfBirth;

                    //Overriding System-based variables
                    member.LastModifiedDate = DateTime.Now;

                    //Return the newly update results
                    return new JsonResult(_mapper.Map<MemberViewModel>(member));
                }
                else
                {
                    return NotFound(new { Error = String.Format("Member ID {0} has not been found", id) });
                }
            }
            else
            {
                return new StatusCodeResult(500);
            }
        }

        //DELETE /api/delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if(id != null)
            {
                var member = _dbContext.Members.Where(i => i.Id == id).FirstOrDefault();
                if(member != null)
                {
                    //Delete member from database
                    _dbContext.Members.Remove(member);

                    //Persist data to database
                    _dbContext.SaveChanges();

                    return new OkResult();
                }
                else
                {
                    return NotFound(new { Error = String.Format("Member ID {0} has not been found", id) });
                }
            }
            else
            {
                return new StatusCodeResult(500);
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