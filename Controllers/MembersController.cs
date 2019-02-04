using AutoMapper;
using MBApplication.ViewModels;
using MBApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using Mapster;

namespace MBApplication.Controllers
{
    [Route("api/[controller]")]
    public class MembersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        
        public MembersController(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        //GET api/members/Get/1
        [HttpGet("Get/{id}")]
        public IActionResult Get(int? id)
        {
            var member = _dbContext.Members.Where(i => i.Id == id).FirstOrDefault();    
            if (id != null && int.TryParse(id.ToString(), out var n))
            {
                return new JsonResult (
                    member.Adapt<MemberViewModel>(),
                    new JsonSerializerSettings(){
                        Formatting = Formatting.Indented
                    });
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
            var members = _dbContext.Members.OrderBy(m => m.Id).Take(AllMembers).ToArray();

            return new JsonResult(
                members.Adapt<Member[]>(),
                new JsonSerializerSettings(){
                    Formatting = Formatting.Indented
                });
        }

        //GET api/members/GetMembers/10
        [HttpGet("GetMembers/{n}")]
        public IActionResult GetMembers(int n)
        {
            var members = _dbContext.Members.OrderBy(m => m.Id).Take(n).ToArray();

            return new JsonResult(
                members.Adapt<Member[]>(),
                new JsonSerializerSettings(){
                    Formatting = Formatting.Indented
                });
        }

        //Get api/members/GetByLastName/{name}
        [HttpGet("GetByLastName/{name}")]
        public IActionResult GetByLastName(string name){
            var member = _dbContext.Members.Where(i => i.LastName.Equals(name, StringComparison.OrdinalIgnoreCase));
            
            if(member != null){ 
                return new JsonResult(
                    member.Adapt<Member>(),
                    new JsonSerializerSettings(){
                        Formatting = Formatting.Indented
                    });
            }
            else
            {
                return NotFound(new {Error = String.Format("Member {0} has not been found", name)});
            }
        }

        //GET api/members/GetFamilyMembers/Anderson

        [HttpGet("GetFamilyMembersByName/{familyName}")]
        public IActionResult GetFamilyMembersByName(string familyName)
        {
            var members = _dbContext.Members.Where(i => i.LastName.Equals(familyName, StringComparison.OrdinalIgnoreCase)).ToArray();
            if (members != null)
            {
                return new JsonResult(
                members.Adapt<Member[]>(),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
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
            var members = _dbContext.Members.Where(i => i.FamilyId == id).ToArray();
            if (id != null)
            {
                return new JsonResult(
                 members.Adapt<Member[]>(),
                 new JsonSerializerSettings()
                 {
                     Formatting = Formatting.Indented
                 });
            }
            else
            {
                return NotFound(new {Error = String.Format("Family ID {0} has not been found", id)});
            }
        }

        //PUT /api/members
        [HttpPut]
        public IActionResult Add([FromBody]MemberViewModel memberToAdd)
        {
            if(memberToAdd != null)
            {
                return new StatusCodeResult(500);   
            }
            //Create a new Member from Json data
            var member = memberToAdd.Adapt<Member>();

            //Override system-based variable
            member.CreatedDate = DateTime.Now;
            member.LastModifiedDate = DateTime.Now;

            //Add the new member
            _dbContext.Members.Add(member);

            //Persist the changes
            _dbContext.SaveChanges();

            //Return the newly created member object
            return new JsonResult(
                member.Adapt<MemberViewModel>(), 
                new JsonSerializerSettings(){
                    Formatting = Formatting.Indented
                });
        }

        //POST api/members
        [HttpPost]
        public IActionResult Post([FromBody]MemberViewModel memberToUpdate)
        {
            if(memberToUpdate == null)
            {
                return new StatusCodeResult(500);
            }

            var member = _dbContext.Members.Where(i => i.Id == memberToUpdate.Id).FirstOrDefault();

            if(member == null)
            {
                return NotFound(new { Error = String.Format("Member ID {0} has not been found", member.Id) });
            }

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

            //persist changes to Database
            _dbContext.SaveChanges();

            //Return the newly update results
            return new JsonResult(member.Adapt<MemberViewModel>(),
            new JsonSerializerSettings(){
                Formatting = Formatting.Indented
            });
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
    }
}