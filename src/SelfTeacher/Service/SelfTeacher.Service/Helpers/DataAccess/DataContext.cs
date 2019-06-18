using Microsoft.EntityFrameworkCore;
using ServiceTeacher.Service.Domain.Entities;

namespace SelfTeacher.Service.Helpers.DataAccess
{
    /// <summary>
    /// Class for work with data
    /// </summary>
    public class DataContext: DbContext
    {
        #region ctor
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        #endregion

        #region data mappers
        /// <summary>
        /// User Collections
        /// </summary>
        public DbSet<User> Users { get; set; }
        #endregion
    }
}
