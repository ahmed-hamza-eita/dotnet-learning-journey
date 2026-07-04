using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace _1_ConfigurationByConvention.Entities
{
      class  Tweet
    {
        public int  TweetId { get; set; }
        public int UserId { get; set; }
        public string TweetText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
