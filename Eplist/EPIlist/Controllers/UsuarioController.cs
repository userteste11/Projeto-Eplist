using EPIlist.Models;
using Microsoft.AspNetCore.Mvc;
using Namespace.Data;

namespace EPIlist.Controllers;

[ApiController]
[Route("Eplist/Usuario")]
public class UsuarioController : ControllerBase
{

    private readonly AppDataContext _ctx;

    public UsuarioController(AppDataContext ctx) => _ctx = ctx;

    [HttpGet]
    [Route("listar")]

    public IActionResult listar(){
        try
        {
            List<Usuario> usuarios = _ctx.Usuarios.ToList();
            return usuarios.Count ==0 ? NotFound() : Ok(usuarios);

        }catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route("{id}")]

    public IActionResult UsuarioId(int id)
    {
        Usuario usuario = _ctx.Usuarios.FirstOrDefault(e => e.UsuarioID == id);
        return usuario == null ? NotFound(""): Ok(usuario);
    }

    [HttpPost]
    [Route("cadastrar")]

    public IActionResult Cadastrar([FromBody] Usuario usuario)
    {
        try
        {
            _ctx.Add(usuario);
            _ctx.SaveChanges();
            return Created("", usuario);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    [HttpPut]
    [Route("atualizar/{id}")]

    public IActionResult AtualizarUsuario(int id, [FromBody] Usuario usuarioAtualizado)
    {
        if (usuarioAtualizado == null)
        {
            return BadRequest("Dados do usuario invalido");
        }

        Usuario usuario = _ctx.Usuarios.FirstOrDefault(e => e.UsuarioID == id);
        
        if(usuario == null)
        {
            return NotFound("Usuario não encontrado");
        }

        usuario.Nome = usuarioAtualizado.Nome;
        usuario.CPF = usuarioAtualizado.CPF;
        usuario.Telefone = usuarioAtualizado.Telefone;
        usuario.Cargo = usuarioAtualizado.Cargo;
        usuario.Email = usuarioAtualizado.Email;

        _ctx.Update(usuario);
        _ctx.SaveChanges();
        return Ok(usuario);
        
    }

    [HttpDelete]
    [Route("Deletar/{id}")]
    public IActionResult DeletarUsuario(int id)
    {
        Usuario usuarioExistente = _ctx.Usuarios.FirstOrDefault(e => e.UsuarioID == id);

        if(usuarioExistente == null)
        {
            return NotFound("Usuario não encontrado");
        }

        _ctx.Usuarios.Remove(usuarioExistente);
        _ctx.SaveChanges();
        return NoContent();
    }
}
