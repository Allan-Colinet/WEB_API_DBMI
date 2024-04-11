using ASP_Demo_Archi_DAL.Models;
using ASP_Demo_Archi_DAL.Repositories;
using ASP_Demo_Archi_DAL.Services;
using IMDB_Api.Exemples;
using IMDB_Api.Models;
using IMDB_Api.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDB_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepo _movieRepo;
        private readonly IPersonRepo _personRepo;

        public MovieController(IMovieRepo movieRepo, IPersonRepo personRepo)
        {
            _movieRepo = movieRepo;
            _personRepo = personRepo;
        }

        /// <summary>
        /// return a list of all movies
        /// </summary>
        /// <returns>List Movie</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            //object truc = new { Nom = "steve", Age = 22, AgeMental = 12 };/

            return Ok(_movieRepo.GetAll()) ;
        }

        /// <summary>
        /// return a Movie by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Movie object</returns>
        /// <remarks> take Id Movie in parameters and return Ok with object Movie</remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            return Ok(_movieRepo.GetById(id));
        }

        /// <summary>
        /// This action to create a new movie
        /// </summary>
        /// <param name="form"></param>
        /// <returns>return new Movie object</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MovieCreateForm), StatusCodes.Status400BadRequest)]
        public IActionResult Create(MovieCreateForm form)
        {
            if (!ModelState.IsValid) return BadRequest();
            _movieRepo.Create(form.ToDAL());
            return Ok();
        }

        /// <summary>
        /// This action delete one film by his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return Ok good request200</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            _movieRepo.Delete(id);
            return Ok();
        }

        /// <summary>
        /// here is the method to update one film
        /// </summary>
        /// <param name="m"></param>
        /// <param name="id"></param>
        /// <returns>return object Movie edit </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MovieCreateForm), StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody]MovieCreateForm m, [FromRoute]int id)
        {
            if(!ModelState.IsValid) return BadRequest();
            Movie movie = m.ToDAL();
            movie.Id = id;
            _movieRepo.Edit(movie);

            return Ok();

        }

        /// <summary>
        /// this method is to get a movie by person Id
        /// </summary>
        /// <param name="personId"></param>
        /// <returns>return a movie</returns>
        [HttpGet("ByActorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetMovieByPersonId(int personId)
        {
            return Ok(_movieRepo.GetMovieByPersonId(personId));
        }

    }
}
