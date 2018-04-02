using LogCorner.BlogPost.Data.Model;
using LogCorner.BlogPost.Service;
using LogCorner.BlogPost.Web.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LogCorner.BlogPost.Web.Mvc.Controllers
{
    public class BlogController : Controller
    {
        private IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        // GET: Blog
        public ActionResult Index()
        {
            var list = _blogService.Get();
            var result = AutoMapper.Mapper.Map<IEnumerable<BlogViewModel>>(list);
            return View(result);
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            var list = _blogService.Get(id);
            var result = AutoMapper.Mapper.Map<BlogForDetailViewModel>(list);
            return View(result);
        }

        // GET: Blog/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(BlogForCreationViewModel blogViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var blog = AutoMapper.Mapper.Map<Blog>(blogViewModel);

            _blogService.Create(blog, User.Identity.Name);
            return RedirectToAction("Index");
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            var list = _blogService.Get(id);
            var result = AutoMapper.Mapper.Map<BlogForEditViewModel>(list);
            return View(result);
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BlogForEditViewModel blogViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var blog = AutoMapper.Mapper.Map<Blog>(blogViewModel);

            _blogService.Update(blog);
            return RedirectToAction("Index");
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            var details = _blogService.Get(id);
            var result = AutoMapper.Mapper.Map<BlogForDetailViewModel>(details);
            return View(result);
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BlogForDetailViewModel BlogForDetailViewModel)
        {
            try
            {
                _blogService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.InternalServerError = ex.Message;

                var details = _blogService.Get(id);
                BlogForDetailViewModel = AutoMapper.Mapper.Map<BlogForDetailViewModel>(details);
                return View(BlogForDetailViewModel);
            }
        }
    }
}