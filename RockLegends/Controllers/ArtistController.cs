using Microsoft.AspNetCore.Mvc;

namespace RockLegends.Controllers
{
    public class ArtistController : Controller
    {
        // Dependency Injection
        MusicContext _context;

        public ArtistController(MusicContext context)
        {
            _context = context;
        }

        

        public IActionResult Index()
        {
            // Haal de data op uit de DB
            var list = _context!.Artists!.ToList();

            //var query = from a in _context.Artists
            //            select new Artist
            //            {
            //                ArtistID = a.ArtistID,
            //                Name = a.Name,
            //                BeginYear = a.BeginYear,
            //                EndYear = a.EndYear
            //            };

            //var result = query.ToList();

            return View(list);
        }

        public async Task<IActionResult> AllArtists()
        {
            var artiesten = await _context.Artists.ToListAsync();
            return Json(artiesten);

            //return Content(artiesten.Count.ToString());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Artist newArtist)
        {
            if (ModelState.IsValid)
            {
                _context.Artists.Add(newArtist);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var artist = _context.Artists.Find(id);
            return View(artist);
        }


        [HttpPost]
        public IActionResult Edit(Artist newArtist)
        {
            if (ModelState.IsValid)
            {
                _context.Artists.Update(newArtist);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var artist = _context.Artists.Find(id);
            return View(artist);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteArtist(int id)
        {
            //var artist = new Artist { ArtistId = id };
            var artist = _context.Artists.Find(id);

            _context.Artists.Remove(artist!);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateUpdate(int id = 0)
        {
            var a = _context.Artists.Find(id);

            if (a == null)
                a = new Artist();

            return View(a);
        }

        [HttpPost]
        public IActionResult CreateUpdate(Artist a, int id = 0)
        {
            if (ModelState.IsValid)
            {
                if (a.ArtistID == 0)
                    _context.Artists.Add(a);
                else
                    _context.Artists.Update(a);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(a);
            }
        }

    }
}
