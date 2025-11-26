using System;

namespace pe.com.ciberelectrik
{
    public partial class SP_MostrarClienteTodo_Result
    {
        public int codcli { get; set; }
        public string nomcli { get; set; }
        public string apepcli { get; set; }
        public string apemcli { get; set; }
        public string doccli { get; set; }
        public string dircli { get; set; }
        public string telcli { get; set; }
        public string celcli { get; set; }
        public string corcli { get; set; }
        public Nullable<bool> estcli { get; set; }
        public int coddis { get; set; }
        public string nomdis { get; set; }
        public int codtipd { get; set; }
        public string nomtipd { get; set; }
        public int codsex { get; set; }
        public string nomsex { get; set; }
    }

    public partial class SP_MostrarEmpleadoTodo_Result
    {
        public int codemp { get; set; }
        public string nomemp { get; set; }
        public string apepemp { get; set; }
        public string apememp { get; set; }
        public string docemp { get; set; }
        public string diremp { get; set; }
        public string telemp { get; set; }
        public string celemp { get; set; }
        public string coremp { get; set; }
        public string usuemp { get; set; }
        public string claemp { get; set; }
        public Nullable<bool> estemp { get; set; }
        public int coddis { get; set; }
        public string nomdis { get; set; }
        public int codrol { get; set; }
        public string nomrol { get; set; }
        public int codtipd { get; set; }
        public string nomtipd { get; set; }
        public int codsex { get; set; }
        public string nomsex { get; set; }
    }

    public partial class SP_MostrarRolTodo_Result
    {
        public int codrol { get; set; }
        public string nomrol { get; set; }
        public Nullable<bool> estrol { get; set; }
    }

    public partial class SP_MostrarSexoTodo_Result
    {
        public int codsex { get; set; }
        public string nomsex { get; set; }
        public Nullable<bool> estsex { get; set; }
    }

    public partial class SP_MostrarTipoDocumentoTodo_Result
    {
        public int codtipd { get; set; }
        public string nomtipd { get; set; }
        public Nullable<bool> esttipd { get; set; }
    }

    public partial class SP_MostrarTicketPedidoTodo_Result
    {
        public int nroped { get; set; }
        public Nullable<System.DateTime> fecped { get; set; }
        public Nullable<bool> estped { get; set; }
        public int codcli { get; set; }
        public string nomcli { get; set; }
        public int codemp { get; set; }
        public string nomemp { get; set; }
    }

    public partial class SP_MostrarDetalleTicketPedidoTodo_Result
    {
        public int nrodet { get; set; }
        public Nullable<int> candet { get; set; }
        public Nullable<decimal> predet { get; set; }
        public int nroped { get; set; }
        public int codpro { get; set; }
        public string nompro { get; set; }
    }
}
