using System;
using System.Collections.Generic;
using System.Linq;
using Module.Enums;

namespace Module.Models
{

    public class SudokuCell
    {

        #region Properties

        public IEnumerable<int> Possibilities { get; set; } = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public SegmentX SegmentX => Helpers.GetSegmentX(this.X);

        public SegmentY SegmentY => Helpers.GetSegmentY(this.Y);

        public int? Value { get; private set; }

        public int X { get; }

        public int Y { get; }

        #endregion Properties

        #region Constructors

        public SudokuCell(SudokuCellData sudokuCellData)
        {
            this.X = sudokuCellData.X;
            this.Y = sudokuCellData.Y;
            this.Value = sudokuCellData.Value;
        }

        #endregion Constructors

        #region Methods

        public void SetCellValue()
        {
            if (this.Possibilities.Count() == 1)
                this.Value = this.Possibilities.Single();
            else
                throw new InvalidOperationException("It is not yet certain what the value of this cell should be.");
        }

        #endregion Methods
    }
}