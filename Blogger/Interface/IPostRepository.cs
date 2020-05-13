using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Interface
{
    interface IPostRepository : IRepository<Post>
    {
        //IEnumerable<User> GetConnectedPeople(int MyId);
    }
}