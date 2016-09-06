using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;


        public MoviesController()
        {

            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Movies
        public ActionResult Random()
        {

            // Forma simples;
            var movie = new Movie() { Name = "Shrek" };

            // Forma simples retorno;
            //return View(movie);

            var custcustomers = new List<Customer>
            {
                new Customer {Name= "Customer 1" },
                new Customer {Name= "Customer 2" },
                new Customer {Name= "Customer 3" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = custcustomers

            };

            return View(viewModel);



            /*
                Varios tipos de retorno de ActionResult
             */

            // return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("home");

            /*
                Há outras formas de passar objetos para view
                atraves de viewbag e Viewdata mas não devem ser utilizados
                para este tipo de cenário complexo, pois havendo modificações por exemplo renomear nome de
                magic strings vai dar problemas principlamente viewbag que é do tipo dynamic e não dá erros em compile time

             */
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {

            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);


            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);

            // return Content("id=" + id.ToString());
        }

        // movies/ exewmplo base para paginação/ demo
        //public ActionResult index(int? pageIndex, string sortBy)
        //{

        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }

        //    return Content(String.Format("PageIndex={0}&sortBy={1}", pageIndex, sortBy));

        //}

        public ActionResult Index()
        {
            // exemplo via hardcoded
            //var movies = GetMovies();

            var movies = _context.Movies.Include(m => m.Genre).ToList();

            if (User.IsInRole("CanManageMovies"))
                return View("List", movies);

            return View("ListReadOnly", movies);



        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {

            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()

                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                // isto é a opção indicada nos tutoriais da microsoft, só que pode trazer problemas,
                // exemplo: Posso não querer atualizar todas as propriedades enviadas no post, ou alguem malicioso pode enviar campos para modificar
                //TryUpdateModel(customerInDb);

                // isto é mais seguro embora seja tedioso. A opção pode ser o uso de autoMapper

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
               // movieInDb.DateAdded = DateTime.Now;
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }


        // Exemplo  hardcoded sem usar entity Framework
        //private IEnumerable<Movie> GetMovies()
        //{

        //    return new List<Movie>
        //    {
        //        new Movie { Id=1,Name="Shrek"},
        //        new Movie { Id=2, Name="Walle-e"},
        //         new Movie {Id=3, Name="Ice Age"}
        //    };

        //}




        [Route("movies/released/{year}/{month}")]
        // este é um exemplo de route aplicando regex para limitir por exemplo o mes a 2 e o range entre 1 e 12. Isto chama-se mvcAttributeRoutes Constraints
        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {

            return Content(year + "/" + month);
        }

    }
}