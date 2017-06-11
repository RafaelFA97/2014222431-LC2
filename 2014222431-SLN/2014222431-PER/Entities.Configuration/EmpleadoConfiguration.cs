using _2014140065_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140065_PER.EntititesConfiguration
{
    public class EmpleadoConfiguration : EntityTypeConfiguration<Empleado>
    {
        public EmpleadoConfiguration()
        {
            //Configuración de Tablas
            ToTable("Empleados");
            HasKey(c => c.EmpleadoId);
            Property(c => c.Nombre).IsRequired().HasMaxLength(30);
            Property(c => c.Apellidos).IsRequired().HasMaxLength(30);
            Property(c => c.DNI).IsRequired().HasMaxLength(8);

            //Configuración de Relaciones
            Map<Administrativo>(m => m.Requires("Discriminator").HasValue("Administrativo"));
            Map<Tripulacion>(m => m.Requires("Discriminator").HasValue("Tripulacion"));
        }
    }
}
