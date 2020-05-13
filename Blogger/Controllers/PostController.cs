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
    [RoutePrefix("api/posts")]
    public class PostController : ApiController
    {
        IRepository<Post> repo;
        IPostRepository PostRepo;
        public PostController()
        {
            this.repo = new PostRepository();
            this.PostRepo = new PostRepository();
        }

        [Route("")] // Get data
        public IHttpActionResult Get()
        {
            var posts = repo.GetAll().ToList();
            //LINKS
            foreach (var post in posts)
            {
                post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts",               Method = "GET",    Rel = "Get All Posts" });
                post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts" + post.PostId, Method = "GET",    Rel = "Get a specific Post" });
                post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts",               Method = "POST",   Rel = "Create a new New Post" });
                post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts" + post.PostId, Method = "PUT",    Rel = "Update specific Post" });
                post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts" + post.PostId, Method = "DELETE", Rel = "Delete specific Post" });

            }


            return Ok(posts);
        }

        [Route("{id}", Name = "GetPostById")]
        public IHttpActionResult Get(int id) // Show data
        {
            var post = repo.Get(id);
            post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts",               Method = "GET",    Rel = "Get All Posts" });
            post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts" + post.PostId, Method = "GET",    Rel = "Get a specific Post" });
            post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts",               Method = "POST",   Rel = "Create a new New Post" });
            post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts" + post.PostId, Method = "PUT",    Rel = "Update specific Post" });
            post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts" + post.PostId, Method = "DELETE", Rel = "Delete specific Post" });
            return Ok(post);
        }

        [Route("")] // Post Data
        public IHttpActionResult Post([FromBody]Post post)
        {

            repo.Insert(post);
            string url = Url.Link("GetPostById", new { id = post.PostId });
            post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts",               Method = "GET",   Rel = "Get All Posts" });
            post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts" + post.PostId, Method = "GET",   Rel = "Get a specific Post" });
            post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts",               Method = "POST",  Rel = "Create a new New Post" });
            post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts" + post.PostId, Method = "PUT",   Rel = "Update specific Post" });
            post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts" + post.PostId, Method = "DELETE",Rel = "Delete specific Post" });
            return Created(url, post);
        }
        [Route("{id}")] //Update Data
        public IHttpActionResult Put([FromBody]Post post, [FromUri]int id)
        {
            post.PostId = id;
            repo.Update(post);
            post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts",               Method = "GET",    Rel = "Get All Posts" });
            post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts" + post.PostId, Method = "GET",    Rel = "Get a specific Post" });
            post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts",               Method = "POST",   Rel = "Create a new New Post" });
            post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts" + post.PostId, Method = "PUT",    Rel = "Update specific Post" });
            post.Links.Add(new Links() { HRef = "http://localhost:61234/api/posts" + post.PostId, Method = "DELETE", Rel = "Delete specific Post" });
            return Ok(post);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            repo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
