namespace News.Models
{
    public partial class Person
    {
        public uint Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public uint RoleId { get; set; }
    }
}
