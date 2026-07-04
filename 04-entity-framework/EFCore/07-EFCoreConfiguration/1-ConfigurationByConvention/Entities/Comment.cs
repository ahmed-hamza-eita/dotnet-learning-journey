using System;
using System.Collections.Generic;
using System.Text;

namespace _1_ConfigurationByConvention.Entities
{
      class  Comment
    {
        public int  CommentId { get; set; }
        public int TweetId { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
