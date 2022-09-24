using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

using src.Models;
using src.Database;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{

    private DatabaseContext _context { get; set; }

    public PersonController(DatabaseContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public ActionResult<List<Person>> Get()
    {
        var result = _context.Persons.Include(p => p.Contracts).ToList();

        if (!result.Any())
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Person> Post([FromBody] Person person)
    {
        try
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            return BadRequest(new
            {
                msg = "",
                status = HttpStatusCode.BadRequest
            });
        }

        return Created("Created", person);
    }

    [HttpPut("{id}")]
    public ActionResult<Object> Update([FromRoute] int id, [FromBody] Person person)
    {
        var result = _context.Persons.AsNoTracking().SingleOrDefault(e => e.Id == id);

        if (result is null)
        {
            return NotFound(new
            {
                msg = "Register not found",
                status = HttpStatusCode.NotFound
            });
        }

        try
        {
            _context.Persons.Update(person);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            return BadRequest(new
            {
                msg = "Error updating",
                status = HttpStatusCode.BadRequest
            });
        }

        return Ok(new
        {
            msg = $"Updated id {id} data!",
            status = HttpStatusCode.OK
        });
    }

    [HttpDelete("{id}")]
    public ActionResult<Object> Delete([FromRoute] int id)
    {
        var result = _context.Persons.SingleOrDefault(e => e.Id == id);

        if (result is null)
        {
            return BadRequest(new
            {
                msg = "Not found Id. Invalid request",
                status = HttpStatusCode.BadRequest
            });
        }

        _context.Persons.Remove(result);
        _context.SaveChanges();

        return Ok(new
        {
            msg = $"Person with Id: {id} deleted.",
            status = HttpStatusCode.OK
        });
    }
}