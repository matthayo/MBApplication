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
    public class FamiliesController : Controller
    {
        private readonly MBAppDBContext _dbContext;
        private readonly IMapper _mapper;

        public FamiliesController(MBAppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //GET api/families/Get/1
        [HttpGet("Get/{id}")]
        public IActionResult Get(int? id)
        {
            var family = _dbContext.Families.Where(f => f.Id == id).FirstOrDefault();
            if (id != null)
            {
                return new JsonResult(_mapper.Map<FamilyViewModel>(family), DefaultJsonSettings);
            }
            else
            {
                return NotFound(new { Error = String.Format("Provide a Family Name to search!") });
            }
        }

        //GET api/families/GetByName/Anderson
        [HttpGet("GetByName/{familyname}")]
        public IActionResult GetByName(string familyName)
        {
            var family = _dbContext.Families.Where(f => f.FamilyName.Equals(familyName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (familyName != null)
            {
                return new JsonResult(_mapper.Map<FamilyViewModel>(family), DefaultJsonSettings);
            }
            else
            {
                return NotFound(new { Error = String.Format("Provide a Family Name to search!") });
            }
        }

        //GET api/families/GetFamilies
        [HttpGet("GetFamilies")]
        public IActionResult GetFamilies()
        {
            var families = _dbContext.Families.OrderBy(f => f.FamilyName).Take(AllFamilies).ToList();

            return new JsonResult(ToFamiliesViewModelList(families), DefaultJsonSettings);
        }

        //GET api/families/GetFamilies/10
        [HttpGet("GetFamilies/{n}")]
        public IActionResult GetFamilies(int n)
        {
            var families = _dbContext.Families.OrderBy(f => f.FamilyName).Take(n).ToList();

            return new JsonResult(ToFamiliesViewModelList(families), DefaultJsonSettings);
        }

        //POST api/families
        [HttpPost()]
        // [Authorize]
        public IActionResult Add([FromBody]FamilyViewModel familyToAdd)
        {
            if(familyToAdd != null)
            {
                //Create a new Family with the client-sent json data
                var family = _mapper.Map<Family>(familyToAdd);

                //Add the new Family
                _dbContext.Families.Add(family);

                //Persist changes to Database
                _dbContext.SaveChanges();

                //Return newly-created Family to browser
                return new JsonResult(_mapper.Map<FamilyViewModel>(family), DefaultJsonSettings);
            }
            else
            {
                //Return a generic HTTP Status 500 (Not Found) if the client payload is invalid.
                return new StatusCodeResult(500);
            }

        }

        //PUT api/families/12
        [HttpPut("{id}")]
        // [Authorize]
        public IActionResult Update(int? id, [FromBody]FamilyViewModel familyToUpdate)
        {
            if (id != null)
            {
                var family = _dbContext.Families.Where(i => i.Id == id).FirstOrDefault();

                if (family != null)
                {
                    //handle the update on property-basis
                    family.FamilyName = familyToUpdate.FamilyName;
                    family.City = familyToUpdate.City;
                    family.House = familyToUpdate.House;
                    family.State = familyToUpdate.State;
                    family.Street = familyToUpdate.Street;
                    family.Zip = familyToUpdate.Zip;

                    //persist changes to Database
                    _dbContext.SaveChanges();

                    //return the updated Family to browser
                    return new JsonResult(_mapper.Map<FamilyViewModel>(family), DefaultJsonSettings);
                }
                else
                {
                    return NotFound(new { Error = String.Format("Family ID {0} has not been found.", id) });
                }
            }
            else
            {
                return NotFound(new { Error = String.Format("Family ID {0} has not been found.", id) });
            }
            
        }

        //DELETE api/families/1
        [HttpDelete("{id}")]
        // [Authorize]
        public IActionResult Delete(int id)
        {
            var item = _dbContext.Families.Where(i => i.Id == id).FirstOrDefault();

            if(item != null)
            {
                //remove the item to delete from the DbContext.
                _dbContext.Families.Remove(item);

                //Persist the changes to Database
                _dbContext.SaveChanges();

                //Return HTTP Status 200 (OK)
                return new OkResult();
            }
            else
            {
                return NotFound(new { Error = String.Format("Family ID {0} has not been found.", id) });
            }
            
        }

        //Return the total number of Families
        public int AllFamilies
        {
            get
            {
                return _dbContext.Families.Count();
            }
        }

        // Maps a collection of Member entities into a list of MemberViewModel objects.
        // Returns a mapped list of MemberViewModel objects.
        private List<FamilyViewModel> ToFamiliesViewModelList(IEnumerable<Family> families)
        {
            var familiesList = new List<FamilyViewModel>();

            foreach (var family in families)
            {
                familiesList.Add(_mapper.Map<FamilyViewModel>(family));
            }
            return familiesList;
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