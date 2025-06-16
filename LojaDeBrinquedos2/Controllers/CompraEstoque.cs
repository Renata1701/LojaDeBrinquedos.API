using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace LojaDeBrinquedos2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CompraEstoque : ControllerBase
{
    private static readonly List<CompraEstoque> _comprasEstoque = new();

    public int Id { get; set; }
    public required string FornecedorId { get; set; }
    public required object DataCompra { get; set; }
    public required object NotaFiscal { get; set; }
    public required object ValorTotal { get; set; }

    
    [HttpGet]
    public ActionResult<IEnumerable<CompraEstoque>> GetAll()
    {
        return Ok(_comprasEstoque);
    }

    
    [HttpGet("{id}")]
    public ActionResult<CompraEstoque> GetById(int id)
    {
        var compra = _comprasEstoque.FirstOrDefault(c => c.Id == id);
        if (compra == null) return NotFound();

        return Ok(compra);
    }

    
    [HttpPost]
    public ActionResult<CompraEstoque> Create(CompraEstoque novaCompra)
    {
        novaCompra.Id = _comprasEstoque.Any() ? _comprasEstoque.Max(c => c.Id) + 1 : 1;
        _comprasEstoque.Add(novaCompra);
        return CreatedAtAction(nameof(GetById), new { id = novaCompra.Id }, novaCompra);
    }

    
    [HttpPut("{id}")]
    public IActionResult Update(int id, CompraEstoque atualizada)
    {
        var compra = _comprasEstoque.FirstOrDefault(c => c.Id == id);
        if (compra == null) return NotFound();

        compra.FornecedorId = atualizada.FornecedorId;
        compra.DataCompra = atualizada.DataCompra;
        compra.NotaFiscal = atualizada.NotaFiscal;
        compra.ValorTotal = atualizada.ValorTotal;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var compra = _comprasEstoque.FirstOrDefault(c => c.Id == id);
        if (compra == null) return NotFound();

        _comprasEstoque.Remove(compra);
        return NoContent();
    }





}
