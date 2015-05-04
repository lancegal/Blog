using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using Blog.DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using TDD.DbTestHelpers.Core;

namespace Blog.DAL.Tests
{
    [DeploymentItem(@"D:\Krzysiek\Blog\Blog.DAL.Tests\Fixtures\posts.yml")]
    [TestClass]
    public class RepositoryTests : DbBaseTest<BlogFixtures>
    {
        [TestMethod]
        public void GetAllPost_OnePostInDb_ReturnOnePost()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            context.SaveChanges();

            // -- prepare data in db
            /*context.Posts.ToList().ForEach(x => context.Posts.Remove(x));
            context.Posts.Add(new Post
            {
                Author = "test",
                Content = "test, test, test..."
            });*/
            // act
            var result = repository.GetAllPosts();
            // assert
            Assert.AreEqual(1, result.Count());
        }
        [TestMethod]
        public void AddPost_NewPostInDb_ReturnOneMorePost()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            context.SaveChanges();

            
            // act
            var initializeCount = repository.GetAllPosts().Count();

            repository.AddPost(new Post() { Content = "BlabLa", Author="Me"});

            // assert
            Assert.AreEqual(initializeCount, repository.GetAllPosts().Count());
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AddPost_NewPostInDbWithoutAuthor_ReturnExeption()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            context.SaveChanges();

            repository.AddPost(new Post() { Content = "BlabLa"});
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AddPost_NewPostInDbWithoutContent_ReturnExeption()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();
            context.SaveChanges();

            repository.AddPost(new Post() { Author = "BlabLa" });

        }
    }
}
