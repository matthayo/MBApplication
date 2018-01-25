using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MBApplication.Data;
using MBApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MBApplication.Controllers
{
    [Route("api/[controller]")]
    public class MembershipsController : Controller
    {
        private readonly MBAppDBContext _dbContext;
        private readonly IMapper _mapper;
        public MembershipsController(MBAppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //GET /api/memberships/get/2
        [HttpGet("Get/{id}")]
        public IActionResult Get(int? id)
        {
            if(id !=null)
            {
                var membership = _dbContext.Memberships.Where(i => i.Id == id).FirstOrDefault();
                
                if(membership != null)
                {
                    return new JsonResult(_mapper.Map<MembershipViewModel>(membership), DefaultJsonSettings);
                }
                else
                {
                    return NotFound(new { Error = String.Format("Membership ID {0} has not been found", id) });
                }
            }
            else
            {
                return new StatusCodeResult(500);
            }
        }

        // //POST /api/memberships
        [HttpPost()]
        public IActionResult Add([FromBody]MembershipViewModel membershipToAdd)
        {
            try{
                //Create new Membership from client-side Json data
                var membership = _mapper.Map<Membership>(membershipToAdd);
                
                //Override system-based variables
                membership.CreatedDate = DateTime.Now;
                membership.LastModifiedDate = DateTime.Now;

                //Add the new Membership
                _dbContext.Memberships.Add(membership);

                //Persist the data to database
                _dbContext.SaveChanges();

                //Return the newly created membership
                return new JsonResult(_mapper.Map<MembershipViewModel>(membership));
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }
        

        // //PUT /api/memberships/7
        [HttpPut("{id}")]
        public IActionResult Update(int? id, [FromBody]MembershipViewModel membershipToUpdate)
        {
            if(id != null)
            {
                var membership = _dbContext.Memberships.Where(i => i.Id == id).FirstOrDefault();
                
                if(membership != null)
                {
                    //Update changes on property basis
                    membership.Status = membershipToUpdate.Status;
                    membership.MembershipBy = membershipToUpdate.MembershipBy;
                    membership.OrganizationId = membershipToUpdate.OrganizationId;

                    //Overriding system-based variables
                    membership.LastModifiedDate = DateTime.Now;

                    //Return the newly updated Membership 
                    return new JsonResult(_mapper.Map<MembershipViewModel>(membership), DefaultJsonSettings);
                }
                else
                {
                    return NotFound(new { Error = String.Format("Membership ID {0} has not been found", id) });
                }
            }
            else
            {
                return new StatusCodeResult(500);
            }
        }

        // //DELETE /api/memberships/9
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if(id != null)
            {
                var membership = _dbContext.Memberships.Where(i => i.Id == id).FirstOrDefault();
                
                if(membership != null)
                {
                    //Delete object from database
                    _dbContext.Memberships.Remove(membership);

                    //Persist the changes in database
                    _dbContext.SaveChanges();

                    //Return OK
                    return new OkResult();
                }
                else
                {
                    return NotFound(new { Error = String.Format("Membership ID {0} has not been found", id) });
                }
            }
            else
            {
                return new StatusCodeResult(500);
            }
        }
        //Return the total number of Members
        public int AllMemberships
        {
            get
            {
                return _dbContext.Memberships.Count();
            }
        }

        // Maps a collection of Member entities into a list of MembershipViewModel objects.
        // Returns a mapped list of MembershipViewModel objects.
        private List<MembershipViewModel> ToMembershipViewModelList(IEnumerable<Membership> memberships)
        {
            var membershipList = new List<MembershipViewModel>();

            foreach (var membership in memberships)
            {
                membershipList.Add(_mapper.Map<MembershipViewModel>(membership));
            }
            return membershipList;
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