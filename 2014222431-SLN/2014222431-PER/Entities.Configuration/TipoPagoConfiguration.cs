using _2014140065_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140065_PER.EntititesConfiguration
{
    public class TipoPagoConfiguration : EntityTypeConfiguration<TipoPago>
    {
        public TipoPagoConfiguration()
        {
            //Configuración de Tablas
            ToTable("TipoPagos");
            HasKey(c => c.TipoPagoId);
            Property(c => c.MetodoPago).IsRequired().HasMaxLength(50);

            //Configuración de Relaciones
            HasRequired(c => c.Venta)
                .WithMany(c => c.TipoPago)
                .HasForeignKey(c => c.VentaId);
        }
    }
}
