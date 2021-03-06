﻿using System;
using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Module.Enums;

namespace SudokuSolver.Module.Models
{
    public class SudokuCell
    {
        #region Properties

        public IEnumerable<int> Possibilities { get; set; } = Helpers.PossibleNumbers;

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
            if (sudokuCellData.Value != null)
                this.Possibilities = null;;
        }

        #endregion Constructors

        #region Methods

        public void SetCellValue()
        {
            if (this.Possibilities.Count() == 1)
            {
                this.Value = this.Possibilities.Single();
                this.Possibilities = null;
            }
            else
                throw new InvalidOperationException("It is not yet certain what the value of this cell should be.");
        }

        #endregion Methods
    }
}