namespace _2014140065_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buses",
                c => new
                    {
                        BusId = c.Int(nullable: false, identity: true),
                        Placa = c.String(),
                        SerieMotor = c.String(),
                        TransporteId = c.Int(nullable: false),
                        Transporte_ServicioId = c.Int(),
                    })
                .PrimaryKey(t => t.BusId)
                .ForeignKey("dbo.Servicios", t => t.Transporte_ServicioId)
                .Index(t => t.Transporte_ServicioId);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        ServicioId = c.Int(nullable: false, identity: true),
                        NombreServicio = c.String(),
                        Tarifa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VentaId = c.Int(nullable: false),
                        AsuntoEncomienda = c.String(),
                        Peso = c.Double(),
                        NombreDestinatario = c.String(),
                        BusId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ServicioId)
                .ForeignKey("dbo.Buses", t => t.BusId, cascadeDelete: true)
                .ForeignKey("dbo.Ventas", t => t.VentaId, cascadeDelete: true)
                .Index(t => t.VentaId)
                .Index(t => t.BusId);
            
            CreateTable(
                "dbo.LugarViajes",
                c => new
                    {
                        LugarViajeId = c.Int(nullable: false, identity: true),
                        NombreLugar = c.String(),
                        TransporteId = c.Int(nullable: false),
                        EncomiendaId = c.Int(nullable: false),
                        BusId = c.Int(nullable: false),
                        Encomienda_ServicioId = c.Int(),
                        Transporte_ServicioId = c.Int(),
                    })
                .PrimaryKey(t => t.LugarViajeId)
                .ForeignKey("dbo.Buses", t => t.BusId, cascadeDelete: true)
                .ForeignKey("dbo.Servicios", t => t.Encomienda_ServicioId)
                .ForeignKey("dbo.Servicios", t => t.Transporte_ServicioId)
                .Index(t => t.BusId)
                .Index(t => t.Encomienda_ServicioId)
                .Index(t => t.Transporte_ServicioId);
            
            CreateTable(
                "dbo.TipoLugars",
                c => new
                    {
                        TipoLugarId = c.Int(nullable: false, identity: true),
                        NombreTipo = c.String(),
                        LugarViajeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoLugarId)
                .ForeignKey("dbo.LugarViajes", t => t.LugarViajeId, cascadeDelete: true)
                .Index(t => t.LugarViajeId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellidos = c.String(),
                        DNI = c.String(),
                        VentaId = c.Int(nullable: false),
                        TransporteId = c.Int(nullable: false),
                        Transporte_ServicioId = c.Int(),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Servicios", t => t.Transporte_ServicioId)
                .ForeignKey("dbo.Ventas", t => t.VentaId, cascadeDelete: true)
                .Index(t => t.VentaId)
                .Index(t => t.Transporte_ServicioId);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        VentaId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VentaId);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellidos = c.String(),
                        DNI = c.String(),
                        Edad = c.Int(nullable: false),
                        Sueldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cargo = c.String(),
                        VentaId = c.Int(),
                        BusId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EmpleadoId)
                .ForeignKey("dbo.Ventas", t => t.VentaId, cascadeDelete: true)
                .ForeignKey("dbo.Buses", t => t.BusId, cascadeDelete: true)
                .Index(t => t.VentaId)
                .Index(t => t.BusId);
            
            CreateTable(
                "dbo.TipoComprobantes",
                c => new
                    {
                        TipoComprobanteId = c.Int(nullable: false, identity: true),
                        NombreComprobante = c.String(),
                        VentaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoComprobanteId)
                .ForeignKey("dbo.Ventas", t => t.VentaId, cascadeDelete: true)
                .Index(t => t.VentaId);
            
            CreateTable(
                "dbo.TipoPagoes",
                c => new
                    {
                        TipoPagoId = c.Int(nullable: false, identity: true),
                        MetodoPago = c.String(),
                        VentaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoPagoId)
                .ForeignKey("dbo.Ventas", t => t.VentaId, cascadeDelete: true)
                .Index(t => t.VentaId);
            
            CreateTable(
                "dbo.TipoViajes",
                c => new
                    {
                        TipoViajeId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        TransporteId = c.Int(nullable: false),
                        Transporte_ServicioId = c.Int(),
                    })
                .PrimaryKey(t => t.TipoViajeId)
                .ForeignKey("dbo.Servicios", t => t.Transporte_ServicioId)
                .Index(t => t.Transporte_ServicioId);
            
            CreateTable(
                "dbo.TipoTripulacions",
                c => new
                    {
                        TipoTripulacionId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        TripulacionId = c.Int(nullable: false),
                        Tripulacion_EmpleadoId = c.Int(),
                    })
                .PrimaryKey(t => t.TipoTripulacionId)
                .ForeignKey("dbo.Empleadoes", t => t.Tripulacion_EmpleadoId)
                .Index(t => t.Tripulacion_EmpleadoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TipoTripulacions", "Tripulacion_EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Empleadoes", "BusId", "dbo.Buses");
            DropForeignKey("dbo.TipoViajes", "Transporte_ServicioId", "dbo.Servicios");
            DropForeignKey("dbo.LugarViajes", "Transporte_ServicioId", "dbo.Servicios");
            DropForeignKey("dbo.TipoPagoes", "VentaId", "dbo.Ventas");
            DropForeignKey("dbo.TipoComprobantes", "VentaId", "dbo.Ventas");
            DropForeignKey("dbo.Servicios", "VentaId", "dbo.Ventas");
            DropForeignKey("dbo.Clientes", "VentaId", "dbo.Ventas");
            DropForeignKey("dbo.Empleadoes", "VentaId", "dbo.Ventas");
            DropForeignKey("dbo.Clientes", "Transporte_ServicioId", "dbo.Servicios");
            DropForeignKey("dbo.Buses", "Transporte_ServicioId", "dbo.Servicios");
            DropForeignKey("dbo.TipoLugars", "LugarViajeId", "dbo.LugarViajes");
            DropForeignKey("dbo.LugarViajes", "Encomienda_ServicioId", "dbo.Servicios");
            DropForeignKey("dbo.LugarViajes", "BusId", "dbo.Buses");
            DropForeignKey("dbo.Servicios", "BusId", "dbo.Buses");
            DropIndex("dbo.TipoTripulacions", new[] { "Tripulacion_EmpleadoId" });
            DropIndex("dbo.TipoViajes", new[] { "Transporte_ServicioId" });
            DropIndex("dbo.TipoPagoes", new[] { "VentaId" });
            DropIndex("dbo.TipoComprobantes", new[] { "VentaId" });
            DropIndex("dbo.Empleadoes", new[] { "BusId" });
            DropIndex("dbo.Empleadoes", new[] { "VentaId" });
            DropIndex("dbo.Clientes", new[] { "Transporte_ServicioId" });
            DropIndex("dbo.Clientes", new[] { "VentaId" });
            DropIndex("dbo.TipoLugars", new[] { "LugarViajeId" });
            DropIndex("dbo.LugarViajes", new[] { "Transporte_ServicioId" });
            DropIndex("dbo.LugarViajes", new[] { "Encomienda_ServicioId" });
            DropIndex("dbo.LugarViajes", new[] { "BusId" });
            DropIndex("dbo.Servicios", new[] { "BusId" });
            DropIndex("dbo.Servicios", new[] { "VentaId" });
            DropIndex("dbo.Buses", new[] { "Transporte_ServicioId" });
            DropTable("dbo.TipoTripulacions");
            DropTable("dbo.TipoViajes");
            DropTable("dbo.TipoPagoes");
            DropTable("dbo.TipoComprobantes");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Ventas");
            DropTable("dbo.Clientes");
            DropTable("dbo.TipoLugars");
            DropTable("dbo.LugarViajes");
            DropTable("dbo.Servicios");
            DropTable("dbo.Buses");
        }
    }
}
