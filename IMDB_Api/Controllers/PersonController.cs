using ASP_Demo_Archi_DAL.Repositories;
using IMDB_Api.Models;
using IMDB_Api.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDB_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepo _personRepo;

        public PersonController (IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        /// <summary>
        /// This method to create a new person
        /// </summary>
        /// <param name="person"></param>
        /// <returns>object of new person</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(PersonCreateForm), StatusCodes.Status400BadRequest)]
        public IActionResult Create(PersonCreateForm form)
        {
            if (!ModelState.IsValid) return BadRequest();
            _personRepo.Create(form.ToDAL());
            return Ok();
        }

        /// <summary>
        /// This method is to search a person by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return person object by id</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_personRepo.GetById(id));
        }
        /// <summary>
        /// this method return a list of all the persons
        /// </summary>
        /// <returns>return object list Person</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(_personRepo.GetAll());
        }
    }
}
