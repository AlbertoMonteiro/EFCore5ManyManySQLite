using System.Collections.Generic;

namespace ConsoleSqlLiteEfCore
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PostTag> Posts { get; set; }
    }
}