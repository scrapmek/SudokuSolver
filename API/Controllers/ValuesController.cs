using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SudokuSolver.Module;
using SudokuSolver.Module.Models;

namespace SudokuSolver.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public ActionResult<List<List<int?>>> Post([FromBody] IEnumerable<SudokuCellData> value)
        {
            Solver solver = new Solver(value);

            solver.Solve();

            return solver.OutputGrid();
        }
    }
}
