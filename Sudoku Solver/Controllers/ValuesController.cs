using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Module;
using Module.Models;

namespace Sudoku_Solver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public ActionResult<List<List<int?>>> Post([FromBody] IEnumerable<SudokuCellData> value)
        {
            Module.Solver solver = new Solver(value);

            solver.Solve();

            return solver.OutputGrid();
        }
    }
}
