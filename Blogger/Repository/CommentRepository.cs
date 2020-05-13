using Blogger.Interface;
using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        BloggerContext context;
        //public IEnumerable<Post> GetPostMiners(int MyId)
        //{
        //    //var connection = context.Set<Messege>().FirstOrDefault(x => x.ReceiverId == MyId);
        //    //return context.Set<User>().Where(x => x.UserId == MyId).ToList();
        //}
    }
}