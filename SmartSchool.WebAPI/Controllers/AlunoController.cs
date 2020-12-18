using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>(){
            new Aluno(){
                Id=1,
                Nome="Marcos",
                Sobrenome="Almeida",
                Telefone="1199934540"
            },
            new Aluno(){
                Id = 2,
                Nome="Marta",
                Sobrenome="Kent",
                Telefone="1199934540"
            },
            new Aluno(){
                Id = 3,
                Nome="Laura",
                Sobrenome="Maria",
                Telefone="1199934540"
            },
        };
        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("byid/{id}")]
        public IActionResult GetById(int id)
        {
            var Aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (Aluno == null) return BadRequest("Aluno Não Encontrado!");

            return Ok(Aluno);
        }

        [HttpGet("{nome}")]
        public IActionResult GetById(string nome)
        {
            var Aluno = Alunos.FirstOrDefault(a => a.Nome == nome);
            if (Aluno == null) return BadRequest("Aluno Não Encontrado!");

            return Ok(Aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }
    }
}