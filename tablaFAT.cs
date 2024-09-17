namespace ClassTablaFAT{

public class TablaFAT{
    public string nombreArchivo { get; set ;}
    public string rutaDatosInicial { get; set ;}
    public bool papelera { get; set ;}
    public int cantidadDatos { get; set ;}
    public string fechaCreacion { get; set ;}
    public string fechaModificacion { get; set ;}
    public string fechaEliminacion { get; set ;}
    
    public TablaFAT(string nombreArchivo, string rutaDatosInicial, bool papelera, int cantidadDatos, string fechaCreacion, string fechaModificacion, string fechaEliminacion) {
        this.nombreArchivo = nombreArchivo;
        this.rutaDatosInicial = rutaDatosInicial;
        this.papelera = papelera;
        this.cantidadDatos = cantidadDatos;
        this.fechaCreacion = fechaCreacion;
        this.fechaModificacion = fechaModificacion;
        this.fechaEliminacion = fechaEliminacion;
        }
    public string LeerDatos()
    {
        return $"Nombre Archivo: {nombreArchivo}\n" +
            $"Ruta Datos Inicial: {rutaDatosInicial}\n" +
            $"En Papelera: {papelera}\n" +
            $"Cantidad Datos: {cantidadDatos}\n" +
            $"Fecha Creación: {fechaCreacion}\n" +
            $"Fecha Modificación: {fechaModificacion}\n" +
            $"Fecha Eliminación: {fechaEliminacion}";
    }
    }
}
