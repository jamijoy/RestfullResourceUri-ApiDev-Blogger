//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blogger.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string CommentWriter { get; set; }
        public string CommentText { get; set; }
        public List<Links> Links = new List<Links>();

        public virtual Post Post { get; set; }
    }
}