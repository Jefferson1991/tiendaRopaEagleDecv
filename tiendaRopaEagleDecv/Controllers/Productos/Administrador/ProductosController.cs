using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tiendaRopaEagleDecv.Data.Dtos.DtoProductos;
using tiendaRopaEagleDecv.Services.Interfaces;

namespace tiendaRopaEagleDecv.Controllers.Productos.Administrador
{
    [Authorize(Roles = "Administrador")]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _productoService.Listar());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _productoService.ObtenerPorId(id);
            return producto == null ? NotFound() : Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductoDTO dto)
        {
            await _productoService.Crear(dto);
            return Ok("Producto creado");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductoDTO dto)
        {
            var updated = await _productoService.Actualizar(dto);
            return updated ? Ok("Producto actualizado") : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productoService.Eliminar(id);
            return deleted ? Ok("Producto eliminado") : NotFound();
        }
    }
}
