namespace ServiceTeacher.Service.Domain.Entities
{
    /// <summary>
    /// Represent information of users
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        /// First name of user
        /// </summary>
        public string Firstname { get; set; }
        /// <summary>
        /// Second name of user
        /// </summary>
        public string Lastname { get; set; }
        /// <summary>
        /// Login string of user
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// chipers information of user
        /// </summary>
        public byte[] PasswordHash { get; set; }
        /// <summary>
        /// Current token of users
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Password salt
        /// </summary>
        public byte[] PasswordSalt { get; set; }
    }
}
