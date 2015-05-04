using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDD.DbTestHelpers.Yaml;
using Blog.DAL.Infrastructure;

namespace Blog.DAL.Tests
{
    public class BlogFixtures : YamlDbFixture<BlogContext, BlogFixturesModel>
    {
        public BlogFixtures()
        {
            SetYamlFiles("posts.yml");
        }
    }
}
