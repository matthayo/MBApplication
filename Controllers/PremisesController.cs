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
    public class Premises : Controller
    {
        private MBAppContext _dbContext;
        private IMapper _mapper;

        public Premises(MBAppContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //GET api/premises/get/1
        [HttpGet("Get/{id}")]
        public IActionResult Get(int? id)
        {
            var premise = _dbContext.Premises.Where(i => i.Id == id).FirstOrDefault();

            if(premise != null)
            {
                return new JsonResult(_mapper.Map<PremiseViewModel>(premise), DefaultJsonSettings);
            }
            else
            {
                return NotFound();
            }
        }

        //GET api/premises/getbyname/{name}
        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {
            var premise = _dbContext.Premises.Where(n => n.Name == name).FirstOrDefault();

            if(premise != null)
            {
                return new JsonResult(_mapper.Map<PremiseViewModel>(premise), DefaultJsonSettings);
            }
            else
            {
                return NotFound();
            }
        }

        //POST api/premises
        [HttpPost()]
        public IActionResult Add([FromBody]PremiseViewModel premiseToAdd)
        {
            if(premiseToAdd != null)
            {
                //Create a new Premise with client-side json object
                var premise = _mapper.Map<Premise>(premiseToAdd);

                //Override system-based variables
                premise.CreatedDate = DateTime.Now;
                premise.LastModifiedDate = DateTime.Now;

                //Add the new Premises
                _dbContext.Premises.Add(premise);

                //Persist the data
                _dbContext.SaveChanges();

                //Return the newly created Premise to browser
                return new JsonResult(_mapper.Map<PremiseViewModel>(premise), DefaultJsonSettings);
            }
            else
            {
                return new StatusCodeResult(500);
            }
        }

        //PUT api/premises/7
        [HttpPut("{id}")]
        public IActionResult Update(int? id, [FromBody]PremiseViewModel premiseToUpdate)
        {
            if(id != null)
            {
                var premise = _dbContext.Premises.Where(i => i.Id == id).FirstOrDefault();

                if(premise != null)
                {
                    //handle updates on property-basis
                    premise.Name = premiseToUpdate.Name;
                    premise.Telephone = premiseToUpdate.Telephone;
                    premise.Email = premiseToUpdate.Email;
                    premise.Website = premiseToUpdate.Website;
                    premise.House = premiseToUpdate.House;
                    premise.Street = premiseToUpdate.Street;
                    premise.City = premiseToUpdate.City;
                    premise.State = premiseToUpdate.State;
                    premise.Zip = premiseToUpdate.Zip;
                    premise.Type=premiseToUpdate.Type;
                    
                    //Overriding system-based variable
                    premise.LastModifiedDate = DateTime.Now;
                    
                    //Persist changes to database
                    _dbContext.SaveChanges();

                    return new JsonResult(_mapper.Map<PremiseViewModel>(premise), DefaultJsonSettings);
                }
                else
                {
                    return NotFound(new { Error = String.Format("Premise ID {0} has not been found.", id) });
                }
            }
            else
            {
                return NotFound(new { Error = String.Format("Premise ID {0} has not been found.", id) });
            }
        }

        //DELETE api/premises/8
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if(id != null)
            {
                var premise = _dbContext.Premises.Where(i => i.Id == id).FirstOrDefault();

                if(premise != null)
                {
                    //Remove the Premise to delete from DbContext
                    _dbContext.Premises.Remove(premise);

                    //Persist data to database
                    _dbContext.SaveChanges();

                    //Return HTTP Status 200 (OK)
                    return new OkResult();
                }
                else
                {
                    return NotFound(new { Error = String.Format("Premise ID {0} has not been found.", id) });
                }
            }
            else
            {
                return NotFound(new { Error = String.Format("Premise ID {0} has not been found.", id) });
            }
        }

        //Return the total number of Premises
        public int AllPremises
        {
            get
            {
                return _dbContext.Premises.Count();
            }
        }

        // Maps a collection of Premise entities into a list of PremiseViewModel objects.
        // Returns a mapped list of PremisesViewModel objects.
        private List<PremiseViewModel> ToPremisesViewModelList(IEnumerable<Premise> premises)
        {
            var premisesList = new List<PremiseViewModel>();

            foreach (var premise in premises)
            {
                premisesList.Add(_mapper.Map<PremiseViewModel>(premise));
            }
            return premisesList;
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