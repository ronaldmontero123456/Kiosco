using System.Data.Entity;

namespace WpfApp1
{
    internal class TemplateDbContext : DbContext
    {
        public TemplateDbContext() : base("name=DBEntities")
        {

        }
        public DbSet<Template> Template { get; set; }
    }
}
