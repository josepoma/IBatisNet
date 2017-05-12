using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yanzhilong.Service;
using IBatis.Domain;
using System.Collections.Generic;

namespace IBaisTest.Service
{
    [TestClass]
    public class ArticleServiceTest
    {
        static ArticleService articleService = null;
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            articleService = new ArticleService();
        }

        [TestMethod]
        public void ArticleCreate()
        {
            Article article = new Article();
            article.ArticleID = Guid.NewGuid().ToString();
            article.Title = "Title";
            article.Content = "Content";
            article.CreateAt = DateTime.Now;
            articleService.Create(article);

            Article articleResult = articleService.GetArticleById(article.ArticleID);
            Assert.IsNotNull(articleResult);
        }

        [TestMethod]
        public void ArticleDelete()
        {
            articleService.Delete("1d8e186d-0d30-4f1a-91d5-cd9294d7015f");
            Article article = articleService.GetArticleById("1d8e186d-0d30-4f1a-91d5-cd9294d7015f");
            Assert.IsNull(article);
        }

        [TestMethod]
        public void ArticleUpdate()
        {
            Article article = articleService.GetArticleById("8bd39d38-3a81-49b8-bcf2-7ca6893676dc");
            article.Title = "TitleNew";
            article.Content = "ContentNew";
            article.CreateAt = DateTime.Now;
            articleService.Update(article);

            Article articleResult = articleService.GetArticleById("8bd39d38-3a81-49b8-bcf2-7ca6893676dc");
            Assert.IsTrue(articleResult.Title == article.Title);
        }

        [TestMethod]
        public void GetArticleById()
        {
            Article article = articleService.GetArticleById("8bd39d38-3a81-49b8-bcf2-7ca6893676dc");
            Assert.IsNotNull(article);
        }

        [TestMethod]
        public void GetArticles()
        {
            IList<Article> articles = articleService.GetArticles();
            Assert.IsTrue(articles.Count > 0);
        }

        [TestMethod]
        public void GetArticlesByPage()
        {
            IList<Article> articles = articleService.GetArticles(1);
            Assert.IsTrue(articles.Count > 0);
        }
    }
}
