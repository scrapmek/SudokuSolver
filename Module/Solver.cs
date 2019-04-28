using System;
using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Module.Enums;
using SudokuSolver.Module.Models;

namespace SudokuSolver.Module
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
                refineColumns();
                refineRows();
                refineSegments();
                refineExclusionaryRowPossibilities();
                refineExclusionaryColumnPossibilities();

                if (!this.changedPossibilities)
                    throw new Exception("No possibilities were changed in the cells, the solving algorithms cannot determine the next step to take. (Error 500: Puzzle too hard!)");
                else
                    this.Data.SetAllKnownCellValues();

                this.changedPossibilities = false;
            }
        }

        private void refineCellSet(IEnumerable<SudokuCell> bla)
        {
            for (int i = 1; i <= 9; i++)
                if (bla.Any(cell => cell.Value == i))
                    foreach (SudokuCell item in bla)
                    {
                        if (item.Value == null)
                        {
                            removeCellPossibility(item, i);
                        }
                    }
        }

        private void refineColumns()
        {
            for (int i = 0; i < 9; i++)
                refineCellSet(this.Data.GetColumn(i));
        }

        private void refineRows()
        {
            for (int i = 0; i < 9; i++)
                refineCellSet(this.Data.GetRow(i));
        }

        private void refineSegments()
        {
            foreach (SegmentX x in Helpers.SegmentXList)
                foreach (SegmentY y in Helpers.SegmentYList)
                    refineCellSet(this.Data.GetSegment(x, y));
        }

        private void refineExclusionaryRowPossibilities()
        {
            foreach (SegmentX x in Helpers.SegmentXList)
                foreach (SegmentY y in Helpers.SegmentYList)
                {
                    var cells = this.Data.GetSegment(x, y);
                    for (int i = 1; i <= 9; i++)
                    {
                        var perPossibility = cells.Where(cell => cell.Possibilities.Contains(i)).GroupBy(cell => cell.Y);

                        if (perPossibility.Count() == 1)
                        {
                            removeSegmentPossibilitiesByRow(
                                Helpers.SegmentXList.Where(seg => seg != x),
                                perPossibility.First().First().Y,
                                i);
                        }
                    }

                }
        }

        private void removeSegmentPossibilitiesByRow(IEnumerable<SegmentX> segments, int y, int possibilityToRemove)
        {
            foreach (var item in this.Data.Cells.Where(x => segments.Contains(x.SegmentX) && x.Y == y))
                this.removeCellPossibility(item, possibilityToRemove);
        }

        private void refineExclusionaryColumnPossibilities()
        {
            foreach (SegmentX x in Helpers.SegmentXList)
                foreach (SegmentY y in Helpers.SegmentYList)
                {
                    var cells = this.Data.GetSegment(x, y);
                    for (int i = 1; i <= 9; i++)
                    {
                        var perPossibility = cells.Where(cell => cell.Possibilities.Contains(i)).GroupBy(cell => cell.X);

                        if (perPossibility.Count() == 1)
                        {
                            removeSegmentPossibilitiesByColumn(
                                Helpers.SegmentYList.Where(seg => seg != y),
                                perPossibility.First().First().X,
                                i);
                        }
                    }

                }
        }

        private void removeSegmentPossibilitiesByColumn(IEnumerable<SegmentY> segments, int x, int possibilityToRemove)
        {
            foreach (var item in this.Data.Cells.Where(cell => segments.Contains(cell.SegmentY) && cell.X == x))
                this.removeCellPossibility(item, possibilityToRemove);
        }

        private void removeCellPossibility(SudokuCell cell, int possibility)
        {
            if (cell.Possibilities.Contains(possibility))
            {
                Data.RemoveCellPossibility(cell.X, cell.Y, possibility);
                this.changedPossibilities = true;
            }
        }
        #endregion Methods

    }
}