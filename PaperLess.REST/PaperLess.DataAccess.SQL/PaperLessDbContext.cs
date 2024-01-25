using Microsoft.EntityFrameworkCore;
using PaperLess.DataAccess.Entities;

namespace PaperLess.DataAccess.SQL {

    public class PaperLessDbContext : DbContext {
        public virtual DbSet<CorrespondentDAL> Correspondents { get; set; }
        public virtual DbSet<TagDAL> Tags { get; set; }
        public virtual DbSet<DocumentDAL> Documents { get; set; }
        public virtual DbSet<DocumentTypeDAL> DocumentTypes { get; set; }

        public PaperLessDbContext(DbContextOptions<PaperLessDbContext> options ) : base(options) {

        }

    }

}