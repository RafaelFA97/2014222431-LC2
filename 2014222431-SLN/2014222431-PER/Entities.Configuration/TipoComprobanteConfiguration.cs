using _2014140065_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140065_PER.EntititesConfiguration
{
    public class TipoComprobanteConfiguration : EntityTypeConfiguration<TipoComprobante>
    {
        public TipoComprobanteConfiguration()
        {
            //Configuración de Tablas
            ToTable("TipoCombrobantes");
            HasKey(c => c.TipoComprobanteId);
            Property(c => c.NombreComprobante).IsRequired().HasMaxLength(30);

            //Configuración de Relaciones
            HasRequired(c => c.Venta)
                .WithMany(c => c.TipoComprobante)
                .HasForeignKey(c => c.VentaId);
        }
    }
}
