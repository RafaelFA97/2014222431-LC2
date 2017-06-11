using _2014140065_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140065_PER.EntititesConfiguration
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            //Configuración de Tablas
            ToTable("Clientes");
            HasKey(c => c.ClienteId);
            Property(c => c.Nombre).IsRequired().HasMaxLength(30);
            Property(c => c.Apellidos).IsRequired().HasMaxLength(30);
            Property(c => c.DNI).IsRequired().HasMaxLength(8);

            //Configuración de Relaciones
            HasRequired(c => c.Transporte)
                .WithMany(c => c.Cliente)
                .HasForeignKey(c => c.TransporteId);

            HasRequired(c => c.Venta)
                .WithMany(c => c.Cliente)
                .HasForeignKey(c => c.VentaId);
        }
    }
}
