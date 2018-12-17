﻿using System;
using System.Collections.Generic;

namespace News
{
    public partial class CommentPerson
    {
        public uint Id { get; set; }
        public uint CommentId { get; set; }
        public uint PersonId { get; set; }

        public Comment Comment { get; set; }
        public Person Person { get; set; }
    }
}