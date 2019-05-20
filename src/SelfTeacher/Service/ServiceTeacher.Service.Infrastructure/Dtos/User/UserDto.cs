namespace SelfTeacher.Service.Infrastructure.Dtos
{
    /// <summary>
    /// User Dto for clients
    /// </summary>
    public class UserDto: EntityDto
    {
        /// <summary>
        /// First name of user
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Second name of user
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Login of user
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Email of users
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password of user
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Confirm Code of registration
        /// </summary>
        public string ConfirmCode { get; set; }
    }
}
