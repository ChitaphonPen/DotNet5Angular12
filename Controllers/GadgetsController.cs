using webappmssql.Data;
using webappmssql.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace webappmssql.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class GadgetsController: ControllerBase
    {
        private readonly MyWorldDBContext _myWorldDBContext;

        public GadgetsController(MyWorldDBContext myWorldDBContext)
        {
            _myWorldDBContext = myWorldDBContext;
        }
        

        // Method Get
        // https://localhost:5001/Gadgets/all
        [HttpGet]
        [Route("all")]
        public IActionResult GetAllGadget()
        {
            var allGadgets = _myWorldDBContext.Gadgets.ToList();
            return Ok(allGadgets);
        }

        // Method Post
        // https://localhost:5001/Gadgets/add
        [HttpPost]
        [Route("add")]
        public IActionResult AddGadget(Gadgets gadget)
        {
            _myWorldDBContext.Gadgets.Add(gadget);
            _myWorldDBContext.SaveChanges();
            return Ok(gadget.Id);
        }

        // Method Put
        // https://localhost:5001/Gadgets/update
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateGadget(Gadgets gadget)
        {
            _myWorldDBContext.Gadgets.Update(gadget);
            _myWorldDBContext.SaveChanges();
            return NoContent();
        }

        // Method Delete
        // https://localhost:5001/Gadgets/delete/xx
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteGadget(int id)
        {
            var gadgetToDelete = _myWorldDBContext.Gadgets.Where(x => x.Id == id).FirstOrDefault();
            if (gadgetToDelete == null)
            {
                return NotFound();
            }
            _myWorldDBContext.Gadgets.Remove(gadgetToDelete);
            _myWorldDBContext.SaveChanges();
            return NoContent();
        }
    }
}