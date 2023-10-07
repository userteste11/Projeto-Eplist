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
    [Route("EpiList/Equipe")]
    public class EquipeController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public EquipeController(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        // GET: EpiList/Equipe/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            try
            {
                List<Equipe> equipes = _ctx.Equipes.Include(e => e.Unidade).ToList();
                return equipes.Count == 0 ? NotFound() : Ok(equipes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: EpiList/Equipe/1
        [HttpGet]
        [Route("{id}")]
        public IActionResult EquipeId(int id)
        {
            Equipe equipe = _ctx.Equipes.Include(e => e.Unidade).FirstOrDefault(e => e.EquipeID == id);
            return equipe == null ? NotFound("") : Ok(equipe);
        }

        // POST: EpiList/Equipe/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Equipe equipe)
        {
            try
            {
                _ctx.Add(equipe);
                _ctx.SaveChanges();
                return Created("", equipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: EpiList/Equipe/atualizar/1
        [HttpPut]
        [Route("atualizar/{id}")]
        public IActionResult AtualizarEquipe(int id, [FromBody] Equipe equipeAtualizada)
        {
            if (equipeAtualizada == null)
            {
                return BadRequest("Dados da equipe inválidos.");
            }

            Equipe equipe = _ctx.Equipes.FirstOrDefault(e => e.EquipeID == id);

            if (equipe == null)
            {
                return NotFound("Equipe não encontrada.");
            }

            equipe.NomeEquipe = equipeAtualizada.NomeEquipe;
            equipe.UnidadeID = equipeAtualizada.UnidadeID;

            _ctx.Equipes.Update(equipe);
            _ctx.SaveChanges();
            return Ok(equipe);
        }

        // DELETE: EpiList/Equipe/deletar/1
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult DeletarEquipe(int id)
        {
            Equipe equipeExistente = _ctx.Equipes.FirstOrDefault(e => e.EquipeID == id);

            if (equipeExistente == null)
            {
                return NotFound("Equipe não encontrada.");
            }

            _ctx.Equipes.Remove(equipeExistente);
            _ctx.SaveChanges();
            return NoContent();
        }
    }
}
