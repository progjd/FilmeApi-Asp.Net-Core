using AutoMapper;
using FilmeApi.Data;
using FilmeApi.Data.Dtos;
using FilmeApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmeApi.Profiles;

namespace FilmeApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class FillmeController : ControllerBase

    {
        //instanciar o banco
        private FilmeDBContext _context;
        private IMapper _mapper;

        public FillmeController(FilmeDBContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }
       

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {
           
            Filme filme = _mapper.Map<Filme>(filmeDto);
            //salvar no banco
            _context.Filme.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarFilmeId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return _context.Filme;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmeId(int id)
        {
            Filme filme = _context.Filme.FirstOrDefault(f => f.Id == id);
            if(filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(filmeDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
         public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filme.FirstOrDefault(f => f.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Filme filme2 = _context.Filme.FirstOrDefault(f => f.Id == id);
            if (filme2 == null)
            {
                return NotFound();
            }
            _context.Remove(filme2);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
