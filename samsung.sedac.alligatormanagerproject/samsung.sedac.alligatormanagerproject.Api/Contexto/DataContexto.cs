using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using samsung.sedac.alligatormanagerproject.Api.DataConfig;
using samsung.sedac.alligatormanagerproject.Api.Entities;

namespace samsung.sedac.alligatormanagerproject.Api.Contexto
{
    public class DataContexto:IdentityDbContext<Users, Role, int,
                              IdentityUserClaim<int>,UserRole,
                              IdentityUserLogin<int>,IdentityRoleClaim<int>,
                              IdentityUserToken<int>>
    {
        public DbSet<Projetos> Projetos { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }

        public DataContexto(DbContextOptions<DataContexto> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjetosConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new DepartamentosConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
