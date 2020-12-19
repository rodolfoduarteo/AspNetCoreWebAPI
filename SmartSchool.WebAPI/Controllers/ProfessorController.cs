using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public readonly IRepository _repo;
        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pro = _repo.GetAllProfessores(true);
            return Ok(pro);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
             _repo.Add(professor);
            if(_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var pro = _repo.GetProfessoreById(id, true);
            if(pro == null) return BadRequest("Professor não encontrado");

            _repo.Update(professor);
            _repo.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var pro = _repo.GetProfessoreById(id, true);
            if(pro == null) return BadRequest("Professor não encontrado");

            _repo.Update(professor);
            _repo.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessoreById(id, false);
            if(professor == null) return BadRequest("Professor não encontrado");

            _repo.Remove(professor);
            _repo.SaveChanges();
            return Ok(professor);
            
        }

    }
}