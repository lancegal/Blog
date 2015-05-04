using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDD.DbTestHelpers.Yaml;
using Blog.DAL.Model;

namespace Blog.DAL.Tests
{
    public class BlogFixturesModel
    {
        public FixtureTable<Post> Posts { get; set; }
    }
}
