using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MBApplication.Data;
using MBApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MBApplication.Controllers{

    [Route("api/[controller]")]
    public class Organizations : Controller
    {
        private MBAppDBContext _dbContext;
        private IMapper _mapper;

        public Organizations(MBAppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //GET api/Organizations/get
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return new JsonResult(ToOrganizationsViewModelList(_dbContext.Organizations.OrderBy(i => i.Id).Take(AllOrganizations).ToList()), DefaultJsonSettings);
        }

        //GET api/Organizations/get/1
        [HttpGet("Get/{id}")]
        public IActionResult Get(int? id)
        {
            var organization = _dbContext.Organizations.Where(i => i.Id == id).FirstOrDefault();

            if(organization != null)
            {
                return new JsonResult(_mapper.Map<OrganizationViewModel>(organization), DefaultJsonSettings);
            }
            else
            {
                return NotFound();
            }
        }

        //GET api/Organizations/getbyname/{name}
        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {
            var organization = _dbContext.Organizations.Where(n => n.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if(organization != null)
            {
                return new JsonResult(_mapper.Map<OrganizationViewModel>(organization), DefaultJsonSettings);
            }
            else
            {
                return NotFound(new { Error = String.Format("{0} has not been found.", name) });
            }
        }

        //POST api/Organizations
        [HttpPost()]
        public IActionResult Add([FromBody]OrganizationViewModel organizationToAdd)
        {
            if(organizationToAdd != null)
            {
                //Create a new organization with client-side json object
                var organization = _mapper.Map<Organization>(organizationToAdd);

                //Override system-based variables
                organization.CreatedDate = DateTime.Now;
                organization.LastModifiedDate = DateTime.Now;

                //Add the new Organizations
                _dbContext.Organizations.Add(organization);

                //Persist the data
                _dbContext.SaveChanges();

                //Return the newly created organization to browser
                return new JsonResult(_mapper.Map<OrganizationViewModel>(organization), DefaultJsonSettings);
            }
            else
            {
                return new StatusCodeResult(500);
            }
        }

        //PUT api/organizations/7
        [HttpPut("{id}")]
        public IActionResult Update(int? id, [FromBody]OrganizationViewModel organizationToUpdate)
        {
            if(id != null)
            {
                var organization = _dbContext.Organizations.Where(i => i.Id == id).FirstOrDefault();

                if(organization != null)
                {
                    //Handle updates on property-basis
                    organization.Name = organizationToUpdate.Name;
                    organization.Telephone = organizationToUpdate.Telephone;
                    organization.Email = organizationToUpdate.Email;
                    organization.Website = organizationToUpdate.Website;
                    organization.House = organizationToUpdate.House;
                    organization.Street = organizationToUpdate.Street;
                    organization.City = organizationToUpdate.City;
                    organization.State = organizationToUpdate.State;
                    organization.Zip = organizationToUpdate.Zip;
                    organization.Type=organizationToUpdate.Type;
                    
                    //Overriding system-based variable
                    organization.LastModifiedDate = DateTime.Now;
                    
                    //Persist changes to database
                    _dbContext.SaveChanges();

                    return new JsonResult(_mapper.Map<OrganizationViewModel>(organization), DefaultJsonSettings);
                }
                else
                {
                    return NotFound(new { Error = String.Format("organization ID {0} has not been found.", id) });
                }
            }
            else
            {
                return NotFound(new { Error = String.Format("organization ID {0} has not been found.", id) });
            }
        }

        //DELETE api/Organizations/8
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if(id != null)
            {
                var organization = _dbContext.Organizations.Where(i => i.Id == id).FirstOrDefault();

                if(organization != null)
                {
                    //Remove the organization to delete from DbContext
                    _dbContext.Organizations.Remove(organization);

                    //Persist data to database
                    _dbContext.SaveChanges();

                    //Return HTTP Status 200 (OK)
                    return new OkResult();
                }
                else
                {
                    return NotFound(new { Error = String.Format("organization ID {0} has not been found.", id) });
                }
            }
            else
            {
                return NotFound(new { Error = String.Format("organization ID {0} has not been found.", id) });
            }
        }

        //Return the total number of Organizations
        public int AllOrganizations
        {
            get
            {
                return _dbContext.Organizations.Count();
            }
        }

        // Maps a collection of organization entities into a list of OrganizationsViewModel objects.
        // Returns a mapped list of OrganizationsViewModel objects.
        private List<OrganizationViewModel> ToOrganizationsViewModelList(IEnumerable<Organization> Organizations)
        {
            var OrganizationsList = new List<OrganizationViewModel>();

            foreach (var organization in Organizations)
            {
                OrganizationsList.Add(_mapper.Map<OrganizationViewModel>(organization));
            }
            return OrganizationsList;
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