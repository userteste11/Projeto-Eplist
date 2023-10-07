using EPIlist.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Namespace.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EPIlist.Controllers
{
    [ApiController]
    [Route("EpiList/Unidade")]
    public class UnidadeController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public UnidadeController(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        // GET: EpiList/Unidade/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            try
            {
                List<Unidade> unidades = _ctx.Unidades.ToList();
                return unidades.Count == 0 ? NotFound() : Ok(unidades);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: EpiList/Unidade/1
        [HttpGet]
        [Route("{id}")]
        public IActionResult UnidadeId(int id)
        {
            Unidade unidade = _ctx.Unidades.FirstOrDefault(u => u.UnidadeID == id);
            return unidade == null ? NotFound("") : Ok(unidade);
        }

        // POST: EpiList/Unidade/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Unidade unidade)
        {
            try
            {
                _ctx.Add(unidade);
                _ctx.SaveChanges();
                return Created("", unidade);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: EpiList/Unidade/atualizar/1
        [HttpPut]
        [Route("atualizar/{id}")]
        public IActionResult AtualizarUnidade(int id, [FromBody] Unidade unidadeAtualizada)
        {
            if (unidadeAtualizada == null)
            {
                return BadRequest("Dados da unidade inválidos.");
            }

            Unidade unidade = _ctx.Unidades.FirstOrDefault(u => u.UnidadeID == id);

            if (unidade == null)
            {
                return NotFound("Unidade não encontrada.");
            }

            unidade.Nome = unidadeAtualizada.Nome;
            unidade.TecnicoID = unidadeAtualizada.TecnicoID;
            unidade.GestorID = unidadeAtualizada.GestorID;

            _ctx.Unidades.Update(unidade);
            _ctx.SaveChanges();
            return Ok(unidade);
        }

        // DELETE: EpiList/Unidade/deletar/1
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult DeletarUnidade(int id)
        {
            Unidade unidadeExistente = _ctx.Unidades.FirstOrDefault(u => u.UnidadeID == id);

            if (unidadeExistente == null)
            {
                return NotFound("Unidade não encontrada.");
            }

            _ctx.Unidades.Remove(unidadeExistente);
            _ctx.SaveChanges();
            return NoContent();
        }
    }
}