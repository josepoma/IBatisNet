using IBatis.Domain;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Repository;

namespace yanzhilong.Service
{
    public class ArticleService
    {
        IRepository<Article> repository = new MbRepository<Article>();
        
        public void Create(Article article)
        {
            repository.Insert("InsertArticle", article);
        }
         
        public Article GetArticleById(string articleID)
        {
            Article article = repository.GetByCondition("SelectArticleByCondition", new Article { ArticleID = articleID});
            return article;
        }

        public Article GetPreArticle(Article article)
        {
            Article articlePre = repository.GetByCondition("SelectArticleByPre", new Article { CreateAt = article.CreateAt});
            return articlePre;
        }

        public Article GetNextArticle(Article article)
        {
            Article articleNext = repository.GetByCondition("SelectArticleByNext", new Article { CreateAt = article.CreateAt });
            return articleNext;
        }

        public IList<Article> GetArticles()
        {
            IList<Article> articles = repository.GetList("SelectArticleByCondition", null);
            return articles;
        }

        public IList<Article> GetArticles(int pageCount)
        {
            IList<Article> articleList = repository.GetList("SelectArticleByCondition", new Article { }, pageCount);
            return articleList;
        }

        public int GetCount()
        {
            int count = repository.GetObject<int>("SelectArticleCount", null);
            return count;            
        }

        public void Update(Article article)
        {
            repository.Update("UpdateArticle", article);
        }

        public void Delete(string articleID)
        {
            repository.Delete("DeleteArticle", new Article { ArticleID = articleID});
        }
    }
}