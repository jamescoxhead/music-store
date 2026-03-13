using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Web.Models;

namespace MusicStore.Web.Controllers
{
    public class StoreManagerController : Controller
    {
        MusicStoreEntities dataContext = new MusicStoreEntities();

        // GET: StoreManager
        public ActionResult Index()
        {
            var albums = dataContext.Albums.Include(a => a.Genre).Include(a => a.Artist);
            return View(albums.ToList());
        }

        // GET: StoreManager/Details/5
        public ActionResult Details(int id)
        {
            Album album = dataContext.Albums.Find(id);
            return View(album);
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(dataContext.Genres, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(dataContext.Artists, "ArtistId", "Name");
            return View();
        }

        // POST: StoreManager/Create
        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                dataContext.Albums.Add(album);
                dataContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(dataContext.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(dataContext.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int id)
        {
            Album album = dataContext.Albums.Find(id);
            ViewBag.GenreId = new SelectList(dataContext.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(dataContext.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        // POST: StoreManager/Edit/5
        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                dataContext.Entry(album).State = EntityState.Modified;
                dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(dataContext.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(dataContext.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int id)
        {
            Album album = dataContext.Albums.Find(id);
            return View(album);
        }

        // POST: StoreManager/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = dataContext.Albums.Find(id);
            dataContext.Albums.Remove(album);
            dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            dataContext.Dispose();
            base.Dispose(disposing);
        }
    }
}
