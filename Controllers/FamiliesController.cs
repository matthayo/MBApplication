using AutoMapper;
using MBApplication.ViewModels;
using MBApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace MBApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public FamiliesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET api/families/GetFamilyById/1
        [HttpGet("GetFamilyById/{id}")]
        public IActionResult Get(int? id)
        {
            var family = _dbContext.Families
                                    .Where(f => f.Id == id)
                                    .FirstOrDefault();
            if (id != null)
            {
                //Using AutoMapper
                // return new JsonResult(_mapper.Map<FamilyViewModel>(family), DefaultJsonSettings); 

                //Using Mapster
                return new JsonResult(
                    family.Adapt<FamilyViewModel>(),
                    new JsonSerializerSettings(){
                        Formatting = Formatting.Indented
                    }
                );
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
            var family = _dbContext.Families
                                    .Where(f => f.FamilyName.Equals(familyName, StringComparison.OrdinalIgnoreCase))
                                    .FirstOrDefault();
            if (familyName != null)
            {
                // return new JsonResult(_mapper.Map<FamilyViewModel>(family), DefaultJsonSettings);

                //Using Mapster
                return new JsonResult(
                    family.Adapt<FamilyViewModel>(),
                    new JsonSerializerSettings(){
                        Formatting = Formatting.Indented
                    }
                );
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
            var families = _dbContext.Families
                                        .OrderByDescending(f => f.LastModifiedDate)
                                        .Take(AllFamilies)
                                        .ToArray();

            // return new JsonResult(ToFamiliesViewModelList(families), DefaultJsonSettings);

            return new JsonResult(
                families.Adapt<FamilyViewModel[]>(),
                new JsonSerializerSettings(){
                    Formatting = Formatting.Indented
                }
            );
        }

        //GET api/families/GetFamilies/10
        [HttpGet("GetFamilies/{n}")]
        public IActionResult GetFamilies(int n)
        {
            var families = _dbContext.Families.OrderBy(f => f.FamilyName).Take(n).ToList();

            // return new JsonResult(ToFamiliesViewModelList(families), DefaultJsonSettings);

            return new JsonResult(
               families.Adapt<FamilyViewModel[]>(),
               new JsonSerializerSettings()
               {
                   Formatting = Formatting.Indented
               }
           );
        }

        //PUT api/families
        [HttpPut]
        // [Authorize]
        public IActionResult Put([FromBody]FamilyViewModel familyToAdd)
        {
            if(familyToAdd != null)
            {
                //Create a new Family with the client-sent json data
                var family = familyToAdd.Adapt<Family>();

                //Override system-based variable
                family.CreatedDate = DateTime.Now;
                family.LastModifiedDate = DateTime.Now;

                if(family.AptNumber == "") 
                    family.AptNumber = null;

                //Add the new Family
                _dbContext.Families.Add(family);

                //Persist changes to Database
                _dbContext.SaveChanges();

                //Return newly-created Family to browser
                return new JsonResult(
                    family.Adapt<FamilyViewModel>(),
                    new JsonSerializerSettings(){
                        Formatting = Formatting.Indented
                    });
            }
            else
            {
                //Return a generic HTTP Status 500 (Not Found) if the client payload is invalid.
                return new StatusCodeResult(500);
            }

        }

        //POST api/families/
        [HttpPost]
        // [Authorize]
        public IActionResult Post([FromBody]FamilyViewModel familyToUpdate)
        {
            if(familyToUpdate == null)
                return new StatusCodeResult(500);

            var family = _dbContext.Families.Where(i => i.Id == familyToUpdate.Id).FirstOrDefault();

            if (family == null)
                return NotFound ( new {
                    Error = String.Format("Family with ID {0} has not been found", familyToUpdate.Id)
                });
                 
            //handle the update on property-basis
            family.Id = familyToUpdate.Id;
            family.FamilyName = familyToUpdate.FamilyName;
            family.AptNumber = familyToUpdate.AptNumber;
            family.City = familyToUpdate.City;
            family.House = familyToUpdate.House;
            family.State = familyToUpdate.State;
            family.Street = familyToUpdate.Street;
            family.Zip = familyToUpdate.Zip;

            //Override system-based variable
            family.LastModifiedDate = DateTime.Now;

            //If field is empty convert to a Null value.
            if(family.AptNumber == "") 
                family.AptNumber = null;

            //persist changes to Database
            _dbContext.SaveChanges();

            //return the updated Family to browser
            return new JsonResult(
                family.Adapt<FamilyViewModel>(), 
                new JsonSerializerSettings(){
                    Formatting = Formatting.Indented
                });
        }

        //DELETE api/families/1
        [HttpDelete("{id}")]
        // [Authorize]
        public IActionResult Delete(int id)
        {

            var family = _dbContext.Families.Where(i => i.Id == id).FirstOrDefault();

            if(family == null)
            {
                return NotFound(new { Error = String.Format("Family ID {0} has not been found.", id) });
            }

            //remove the item to delete from the DbContext.
            _dbContext.Families.Remove(family);

            //Persist the changes to Database
            _dbContext.SaveChanges();

            //Return HTTP Status 200 (OK)
            return new OkResult();
        }

        //Return the total number of Families
        public int AllFamilies
        {
            get
            {
                return _dbContext.Families.Count();
            }
        }
    }
}