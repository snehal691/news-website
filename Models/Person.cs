using System;
using System.Collections.Generic;

namespace News
{
    public partial class Person
    {
        public Person()
        {
            CommentPerson = new HashSet<CommentPerson>();
            PersonRole = new HashSet<PersonRole>();
        }

        public uint Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }

        public ICollection<CommentPerson> CommentPerson { get; set; }
        public ICollection<PersonRole> PersonRole { get; set; }
    }
}
