using System;
using System.Collections.Generic;
using ConsoleSqlLiteEfCore;

using var ctx = new SampleDbContext();

ctx.Post.Add(new Post
{
    Title = "How to create N..N",
    Tags = new List<Tag>
    {
        new Tag
        {
            Name = "csharp"
        }
    }
});
ctx.SaveChanges();