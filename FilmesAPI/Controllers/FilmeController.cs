using FilmesAPI.Data.DTO.Filme;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto createFilmeDto)
        {
            ReadFilmeDto readFilmeDto = _filmeService.AdicionarFilme(createFilmeDto);
            return CreatedAtAction(nameof(RecuperarFilmesPorId), new { Id = readFilmeDto.Id }, readFilmeDto);
        }

        [HttpGet]
        [Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria)
        {
            List<ReadFilmeDto> readFilmeDtos = _filmeService.RecuperarFilmes(classificacaoEtaria);

            if (!readFilmeDtos.Any())
            {
                return NotFound();
            }

            return Ok(readFilmeDtos);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
        public IActionResult RecuperarFilmesPorId(int id)
        {
            ReadFilmeDto readFilmeDto = _filmeService.RecuperarFilmesPorId(id);

            if (readFilmeDto == null || readFilmeDto.Id == 0)
            { 
                return NotFound();
            }

            return Ok(readFilmeDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto updateFilmeDto)
        {
            Result resultado = _filmeService.AtualizarFilme(id, updateFilmeDto);

            if (resultado.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeletarFilme(int id)
        {
            Result resultado = _filmeService.DeletarFilme(id);

            if (resultado.IsFailed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}