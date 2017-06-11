using _2014140065_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140065_PER.EntititesConfiguration
{
    public class TipoTripulacionConfiguration : EntityTypeConfiguration<TipoTripulacion>
    {
        public TipoTripulacionConfiguration()
        {
            //Configuración de Tablas
            ToTable("TipoTripulacion");
            HasKey(c => c.TipoTripulacionId);
            Property(c => c.Nombre).IsRequired().HasMaxLength(50);

            //Configuración de Relaciones
            HasRequired(c => c.Tripulacion)
                .WithMany(c => c.TipoTripulacion)
                .HasForeignKey(c => c.TripulacionId);
        }
    }
}
