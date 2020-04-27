using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenSourceBlog.DAL;
using OpenSourceBlog.Database;
using OpenSourceBlog.Database.Models;

namespace OpenSourceBlog.Controllers
{
    public class PostCommentsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public PostCommentsController() { }

        public PostCommentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       
        // GET: PostComments/Details/5
        public IEnumerable<PostComment> Details(System.Guid id)
        {
            if (id == null)
            {
                return null;
            }
            IEnumerable<PostComment> postComment = _unitOfWork._postCommentRepository.GetAll().Where(x => x.PostId == id);
            if (postComment == null)
            {
                return null;
            }
            return postComment;
        }

     

        // POST: PostComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       
        public ActionResult Create([Bind(Include = "PostCommentRowId,BlogId,PostCommentId,PostId,ParentCommentId,CommentDate,Author,Email,Website,Comment,Country,IP,IsApproved,ModeratedBy,Avatar,IsSpam,IsDeleted")] PostComment postComment)
        {
            IEnumerable<Post> getPost = _unitOfWork._postRepository.GetAll().Where(x => x.PostId == postComment.PostId);
            int postrowid = getPost.First().PostRowId;
            if (ModelState.IsValid)
            {
                _unitOfWork._postCommentRepository.Create(postComment);
                _unitOfWork.Save();
            }
            Post post = _unitOfWork._postRepository.Get(Convert.ToInt32(postrowid));
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.Comments = _unitOfWork._postCommentRepository.GetAll().Where(x => x.PostId == post.PostId).OrderByDescending(x => x.CommentDate).ToList();
            return View("~/Views/Admin/Posts/Details.cshtml", post);
        }

        // GET: PostComments/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostComment postComment = _unitOfWork._postCommentRepository.Get(id);
            if (postComment == null)
            {
                return HttpNotFound();
            }
            return View(postComment);
        }

    }
}
