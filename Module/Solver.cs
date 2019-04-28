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
            foreach (int i in Helpers.PossibleNumbers)
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
            foreach (int i in Helpers.Coordinates)
                refineCellSet(this.Data.GetColumn(i));
        }

        private void refineExclusionaryColumnPossibilities()
        {
            foreach (SegmentX x in Helpers.SegmentXList)
                foreach (SegmentY y in Helpers.SegmentYList)
                {
                    var cells = this.Data.GetSegment(x, y);

                    foreach (int i in Helpers.PossibleNumbers)
                        refineExclusionaryColumnPossibilities(cells, i, y);
                }
        }

        private void refineExclusionaryColumnPossibilities(IEnumerable<SudokuCell> cells, int i, SegmentY segment)
        {
            var perPossibility = cells.Where(cell => cell.Possibilities != null && cell.Possibilities.Contains(i)).GroupBy(cell => cell.X);

            if (perPossibility.Count() == 1)
            {
                removeSegmentPossibilitiesByColumn(
                    Helpers.SegmentYList.Where(seg => seg != segment),
                    perPossibility.First().First().X,
                    i);
            }
        }

        private void refineExclusionaryRowPossibilities()
        {
            foreach (SegmentX x in Helpers.SegmentXList)
                foreach (SegmentY y in Helpers.SegmentYList)
                {
                    var cells = this.Data.GetSegment(x, y);
                    foreach (int i in Helpers.PossibleNumbers)
                        refineExclusionaryRowPossibilities(cells, i, x);
                }
        }

        private void refineExclusionaryRowPossibilities(IEnumerable<SudokuCell> cells, int i, SegmentX segment)
        {
            var perPossibility = cells.Where(cell => cell.Possibilities != null && cell.Possibilities.Contains(i)).GroupBy(cell => cell.Y);

            if (perPossibility.Count() == 1)
                removeSegmentPossibilitiesByRow(
                    Helpers
                        .SegmentXList
                        .Where(seg => seg != segment),
                    perPossibility.First().First().Y,
                    i);
        }

        private void refineRows()
        {
            
            foreach (int i in Helpers.Coordinates)
                refineCellSet(this.Data.GetRow(i));
        }

        private void refineSegments()
        {
            foreach (SegmentX x in Helpers.SegmentXList)
                foreach (SegmentY y in Helpers.SegmentYList)
                    refineCellSet(this.Data.GetSegment(x, y));
        }
        private void removeCellPossibility(SudokuCell cell, int possibility)
        {
            if (cell.Value == null && cell.Possibilities.Contains(possibility))
            {
                Data.RemoveCellPossibility(cell.X, cell.Y, possibility);
                this.changedPossibilities = true;
            }
        }

        private void removeSegmentPossibilitiesByColumn(IEnumerable<SegmentY> segments, int x, int possibilityToRemove)
        {
            foreach (var item in this.Data.Cells.Where(cell => segments.Contains(cell.SegmentY) && cell.X == x))
                this.removeCellPossibility(item, possibilityToRemove);
        }

        private void removeSegmentPossibilitiesByRow(IEnumerable<SegmentX> segments, int y, int possibilityToRemove)
        {
            foreach (var item in this.Data.Cells.Where(x => segments.Contains(x.SegmentX) && x.Y == y))
                this.removeCellPossibility(item, possibilityToRemove);
        }

        #endregion Methods
    }
}