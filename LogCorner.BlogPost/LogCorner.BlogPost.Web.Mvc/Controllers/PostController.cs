using LogCorner.BlogPost.Data.Model;
using LogCorner.BlogPost.Service;
using LogCorner.BlogPost.Web.Mvc.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LogCorner.BlogPost.Web.Mvc.Controllers
{
    public class PostController : Controller
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: Post
        public ActionResult Index(IEnumerable<PostViewModel> model, int blogId)
        {
            ViewBag.blogId = blogId;
            return PartialView(model);
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            var result = _postService.Get(id);
            var post = AutoMapper.Mapper.Map<PostViewModel>(result);
            return View(post);
        }

        // GET: Post/Create
        public ActionResult Create(int blogId)
        {
            return View(new PostForCreationViewModel
            { BlogId = blogId });
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(int blogId, PostForCreationViewModel postForCreationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            postForCreationViewModel.BlogId = blogId;
            var post = AutoMapper.Mapper.Map<Post>(postForCreationViewModel);
            _postService.Create(post);
            return RedirectToAction("Details", new { Controller = "Blog", id = blogId });
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _postService.Get(id);
            var post = AutoMapper.Mapper.Map<PostForEditViewModel>(result);
            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PostForEditViewModel postForEditViewModel)
        {
            // postForEditViewModel.BlogId = blogId;
            var post = AutoMapper.Mapper.Map<Post>(postForEditViewModel);
            _postService.Update(post);
            return RedirectToAction("Details", new { Controller = "Blog", id = postForEditViewModel.BlogId });
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _postService.Get(id);
            var post = AutoMapper.Mapper.Map<PostViewModel>(result);
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, int blogId)
        {
            _postService.Delete(id);
            var result = _postService.Get(id);
            return RedirectToAction("Details", new { Controller = "Blog", id = blogId });
        }
    }
}