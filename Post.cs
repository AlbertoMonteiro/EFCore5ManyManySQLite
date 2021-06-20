using System.Collections.Generic;

namespace ConsoleSqlLiteEfCore
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<PostTag> Tags { get; set; }
    }
}