using System;
using System.Collections.Generic;
using System.Linq;
using Module.Enums;
using Module.Models;

namespace Module
{
    public class Solver
    {

        #region Fields

        private bool changedPossibilities = false;

        #endregion Fields

        #region Properties

        public SudokuData Data { get; private set; }

        #endregion Properties

        #region Constructors

        public Solver(IEnumerable<SudokuCellData> input) => this.Data = new SudokuData(input ?? throw new ArgumentNullException(nameof(input)));

        #endregion Constructors

        #region Methods

        public List<List<int?>> OutputGrid() => this.Data.Cells.GroupBy(cell => cell.Y).OrderByDescending(x => x.Key).Select(group => group.OrderBy(cell => cell.X).Select(cell => cell.Value).ToList()).ToList();

        public void Solve()
        {
            while (this.Data.Cells.Any(x => x.Value == null))
            {
                solveColumns();
                solveRows();
                solveSegments();

                if (!this.changedPossibilities)
                    break; //throw new Exception("No possibilities were changed in the cells, the solving algorithms cannot determine the next step to take.");
                else
                    this.Data.SetAllKnownCellValues();

                this.changedPossibilities = false;
            }
        }

        private void solveCellSet(IEnumerable<SudokuCell> bla)
        {
            for (int i = 0; i < 9; i++)
                if (bla.Any(cell => cell.Value == i))
                    foreach (SudokuCell item in bla)
                    {
                        if (item.Value == null)
                        {
                            var newPossibilities = item.Possibilities.Except(new List<int>() { i }).ToList();

                            if (!newPossibilities.SequenceEqual(item.Possibilities))
                            {
                                this.Data.SetCellPossibilities(item.X, item.Y, newPossibilities);
                                this.changedPossibilities = true;
                            }
                        }
                    }
        }

        private void solveColumns()
        {
            for (int i = 0; i < 9; i++)
                solveCellSet(this.Data.GetColumn(i));
        }

        private void solveRows()
        {
            for (int i = 0; i < 9; i++)
                solveCellSet(this.Data.GetRow(i));
        }

        private void solveSegments()
        {
            foreach (SegmentX x in Helpers.SegmentXList)
                foreach (SegmentY y in Helpers.SegmentYList)
                    solveCellSet(this.Data.GetSegment(x, y));
        }

        #endregion Methods

    }
}