using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver.Module;
using SudokuSolver.Module.Models;

namespace SudokuSolver.UnitTests
{
    [TestClass]
    public class SolverTestsS
    {
        [TestMethod]
        public void Solver()
        {
            List<SudokuCellData> cellData =
                new List<SudokuCellData>()
                {
                    new Module.Models.SudokuCellData()
                    {
                        Value = 5,
                        X = 0,
                        Y= 8
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 4,
                        X = 1,
                        Y= 8
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 1,
                        X = 3,
                        Y= 8
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 2,
                        X = 4,
                        Y = 8 
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 7,
                        X = 5,
                        Y= 8
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 6,
                        X = 8,
                        Y= 8
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 6,
                        X = 0,
                        Y= 7
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 7,
                        X = 7,
                        Y= 7
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 7,
                        X = 0,
                        Y= 6
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 8,
                        X = 1,
                        Y= 6
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 6,
                        X = 4,
                        Y= 6
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 4,
                        X = 6,
                        Y = 6
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 5,
                        X = 8,
                        Y= 6
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 1,
                        X = 0,
                        Y= 5
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 7,
                        X = 3,
                        Y= 5
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 8,
                        X = 6,
                        Y= 5
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 6,
                        X = 3,
                        Y= 4
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 4,
                        X = 4,
                        Y= 4
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 5,
                        X = 5,
                        Y= 4
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 5,
                        X = 2,
                        Y= 3
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 1,
                        X = 5,
                        Y= 3
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 2,
                        X = 8,
                        Y= 3
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 4,
                        X = 0,
                        Y= 2
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 7,
                        X = 2,
                        Y= 2
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 1,
                        X = 4,
                        Y= 2
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 9,
                        X = 7,
                        Y= 2
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 8,
                        X = 8,
                        Y= 2
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 9,
                        X = 1,
                        Y= 1
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 1,
                        X = 8,
                        Y= 1
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 8,
                        X = 0,
                        Y= 0
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 2,
                        X = 3,
                        Y= 0
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 5,
                        X = 4,
                        Y= 0
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 9,
                        X = 5,
                        Y= 0
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 6,
                        X = 7,
                        Y= 0
                    },
                    new Module.Models.SudokuCellData()
                    {
                        Value = 4,
                        X = 8,
                        Y= 0
                    }
                };

            Solver solver = new Solver(cellData);

            solver.Solve();

            List<List<int?>> bla = solver.OutputGrid();


            string output = string.Join(Environment.NewLine, bla.Select(x => $"{string.Join(",", x)}")); 
            Assert.AreNotEqual(cellData.Count(), solver.Data.Cells.Count(x => x.Value != null));
        }
    }
}
