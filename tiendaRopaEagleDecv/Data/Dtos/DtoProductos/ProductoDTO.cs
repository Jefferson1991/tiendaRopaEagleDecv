namespace tiendaRopaEagleDecv.Data.Dtos.DtoProductos
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Marca { get; set; }
        public string ImagenUrl { get; set; }
        public int IdCategoria { get; set; }
    }
}
