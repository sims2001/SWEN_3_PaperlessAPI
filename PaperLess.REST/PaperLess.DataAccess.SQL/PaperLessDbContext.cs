using Microsoft.EntityFrameworkCore;
using PaperLess.DataAccess.Entities;

namespace PaperLess.DataAccess.SQL {

    public class PaperLessDbContext : DbContext {
        public DbSet<CorrespondentDAL> Correspondents { get; set; }
        public DbSet<TagDAL> Tags { get; set; }
        public DbSet<DocumentDAL> Documents { get; set; }
        public DbSet<DocumentTypeDAL> DocumentTypes { get; set; }

        public PaperLessDbContext(DbContextOptions<PaperLessDbContext> options ) : base(options) {

        }

    }

}