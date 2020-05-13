using Blogger.Interface;
using Blogger.Models;
using Blogger.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blogger.Controllers
{
    [RoutePrefix("api/comments")]
    public class CommentController : ApiController
    {
        IRepository<Comment> repo;
        ICommentRepository CommentRepo;
        public CommentController()
        {
            this.repo = new CommentRepository();
            this.CommentRepo = new CommentRepository();
        }

        [Route("")] // Get data
        public IHttpActionResult Get()
        {
            var comments = repo.GetAll().ToList();
            //LINKS
            foreach (var comment in comments)
            {
                comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments",                     Method = "GET",   Rel = "Get All Comments" });
                comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments" + comment.CommentId, Method = "GET",   Rel = "Get a specific Comment" });
                comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments",                     Method = "POST",  Rel = "Create a new New Comment" });
                comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments" + comment.CommentId, Method = "PUT",   Rel = "Update specific Comment" });
                comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments" + comment.CommentId, Method = "DELETE",Rel = "Delete specific Comment" });

            }


            return Ok(comments);
        }

        [Route("{id}", Name = "GetCommentById")]
        public IHttpActionResult Get(int id) // Show data
        {
            var comment = repo.Get(id);
            comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments",                     Method = "GET",   Rel = "Get All Comments" });
            comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments" + comment.CommentId, Method = "GET",   Rel = "Get a specific Comment" });
            comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments",                     Method = "POST",  Rel = "Create a new New Comment" });
            comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments" + comment.CommentId, Method = "PUT",   Rel = "Update specific Comment" });
            comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments" + comment.CommentId, Method = "DELETE",Rel = "Delete specific Comment" });
            return Ok(comment);
        }

        [Route("")] // Post Data
        public IHttpActionResult Post([FromBody]Comment comment)
        {
            repo.Insert(comment);
            string url = Url.Link("GetCommentById", new { id = comment.CommentId });
            comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments",                     Method = "GET",    Rel = "Get All Comments" });
            comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments" + comment.CommentId, Method = "GET",    Rel = "Get a specific Comment" });
            comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments",                     Method = "POST",   Rel = "Create a new New Comment" });
            comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments" + comment.CommentId, Method = "PUT",    Rel = "Update specific Comment" });
            comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments" + comment.CommentId, Method = "DELETE", Rel = "Delete specific Comment" });
            return Created(url, comment);
        }

        [Route("{id}")] //Update Data
        public IHttpActionResult Put([FromBody]Comment comment, [FromUri]int id)
        {
            comment.CommentId = id;
            repo.Update(comment);
            comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments", Method = "GET", Rel = "Get All Comments" });
            comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments" + comment.CommentId, Method = "GET", Rel = "Get a specific Comment" });
            comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments", Method = "POST", Rel = "Create a new New Comment" });
            comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments" + comment.CommentId, Method = "PUT", Rel = "Update specific Comment" });
            comment.Links.Add(new Links() { HRef = "http://localhost:61234/api/comments" + comment.CommentId, Method = "DELETE", Rel = "Delete specific Comment" });
            return Ok(comment);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            repo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
