using System;
using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Module.Enums;

namespace SudokuSolver.Module.Models
{
    public class SudokuData
    {
        #region Properties

        public IList<SudokuCell> Cells { get; }

        #endregion Properties

        #region Constructors

        public SudokuData(IEnumerable<SudokuCellData> input)
        {
            this.Cells = new List<SudokuCell>();

            for (int x = 0; x < 9; x++)
                for (int y = 0; y < 9; y++)
                {
                    SudokuCellData bla = input.SingleOrDefault(cell => cell.X == x && cell.Y == y);
                    this.Cells.Add(new SudokuCell(bla ?? new SudokuCellData() { X = x, Y = y }));
                }
        }

        #endregion Constructors

        #region Methods

        public IEnumerable<SudokuCell> GetColumn(int index) => this.Cells.Where(x => x.X == index);

        public IEnumerable<SudokuCell> GetRow(int index) => this.Cells.Where(x => x.Y == index);

        public IEnumerable<SudokuCell> GetSegment(SegmentX x, SegmentY y) => this.Cells.Where(cell => cell.SegmentX == x && cell.SegmentY == y);

        public void SetCellPossibilities(int x, int y, IEnumerable<int> possibilities) => this.Cells.Single(cell => cell.X == x && cell.Y == y).Possibilities = possibilities;

        public void SetAllKnownCellValues()
        {
            foreach (var item in this.Cells.Where(x => x.Possibilities.Count() == 1))
                item.SetCellValue();
        }

        #endregion Methods
    }
}