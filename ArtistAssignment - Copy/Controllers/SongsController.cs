using ArtistAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using ArtistAssignment.ViewModels;

namespace ArtistAssignment.Controllers
{
    
    public class SongsController : Controller
    {
        private ApplicationDbContext _context;

        public SongsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Songs
        [AllowAnonymous]
        public ActionResult Index(string searchString)
        {
            var songs = _context
               .Songs
               .Include(s => s.Album.Artist)
               ;

            if (!string.IsNullOrEmpty(searchString))
            {
                songs = songs.Where(s => s.Title.Contains(searchString));
            }


            if (User.IsInRole("Administrator"))
            {
                return View(songs);
            }
            return View("SongsWithoutNone",songs.ToList());
        }      
   
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var song = _context.Songs.Include(s => s.Album.Artist)
               .SingleOrDefault(a=>a.ID==id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        //Get
        public ActionResult Create()
        {
            var viewModel = new SongFormViewModel
            {
                Song = new Song(),
                Albums = _context.Albums.ToList()
            };
            return View("SongForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Song song)
        {
            song.Youtube = $"https://www.youtube.com/embed/{song.Youtube}";

            if (song.ID == 0)
            {
                _context.Songs.Add(song);
            }
            else
            {

                //update
                var songInDb = _context.Songs.Single(p => p.ID == song.ID);
                songInDb.Title = song.Title;
                songInDb.Youtube = song.Youtube;
                songInDb.AlbumId = song.AlbumId;

            }


            if (!ModelState.IsValid)
            {
                var viewModel = new SongFormViewModel
                {
                    Song = new Song(),
                    Albums = _context.Albums.ToList()
                };
                return View("SongForm", viewModel);
            }
            else 
            {
                _context.SaveChanges();
            }
            return RedirectToAction("Index","Songs");
        }

        [Authorize(Roles = RoleName.Administrator+","+RoleName.Editor)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var song = _context.Songs.Include(s=>s.Album).SingleOrDefault(s=>s.ID==id);

            if (song==null)
            {
                return HttpNotFound();
            }
            var viewModel = new SongFormViewModel
            {
                Song = song,
                Albums = _context.Albums.ToList()
            };
            return View("SongForm", viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}