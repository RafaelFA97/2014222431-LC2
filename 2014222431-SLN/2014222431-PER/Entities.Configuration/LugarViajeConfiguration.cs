using _2014140065_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140065_PER.EntititesConfiguration
{
    public class LugarViajeConfiguration : EntityTypeConfiguration<LugarViaje>
    {
        public LugarViajeConfiguration()
        {
            //Configuración de Tablas
            ToTable("LugaresViaje");
            HasKey(c => c.LugarViajeId);
            Property(c => c.NombreLugar).IsRequired().HasMaxLength(50);

            //Configuración de Relaciones
            HasMany(c => c.TipoLugar)
                .WithRequired(c => c.LugarViaje)
                .HasForeignKey(c => c.LugarViajeId);

            HasRequired(c => c.Encomienda)
                .WithMany(c => c.LugarViaje)
                .HasForeignKey(c => c.EncomiendaId);

            HasRequired(c => c.Transporte)
                .WithMany(c => c.LugarViaje)
                .HasForeignKey(c => c.TransporteId);
        }
    }
}
