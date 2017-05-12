using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IBatis.Domain
{
    /// <summary>
    /// 文章实体
    /// </summary>
    public class Article
    {
        public string ArticleID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
    }
}