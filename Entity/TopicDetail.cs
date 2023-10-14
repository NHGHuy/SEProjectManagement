using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class TopicDetail
    {
        public int TagId { get; set; }
        public int TopicId { get; set; }
        public string? Note { get; set; }

        public virtual Tag Tag { get; set; } = null!;
        public virtual Topic Topic { get; set; } = null!;
    }
}
