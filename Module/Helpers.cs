using System;
using System.Collections.Generic;
using SudokuSolver.Module.Enums;

namespace SudokuSolver.Module
{
    public class Helpers
    {
        #region Properties
        public static IEnumerable<int> PossibleNumbers { get; } = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public static IEnumerable<int> Coordinates { get; } = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        public static IEnumerable<SegmentX> SegmentXList { get; } = new List<SegmentX> { SegmentX.Left, SegmentX.Center, SegmentX.Right };
        public static IEnumerable<SegmentY> SegmentYList { get; } = new List<SegmentY> { SegmentY.Bottom, SegmentY.Middle, SegmentY.Top };

        #endregion Properties

        #region Methods

        public static SegmentX GetSegmentX(int x)
        {
            if (x >= 0 && x <= 2) return SegmentX.Left;
            else if (x >= 3 && x <= 5) return SegmentX.Center;
            else if (x >= 6 && x <= 8) return SegmentX.Right;
            else
                throw new ArgumentOutOfRangeException($"The X coordinate of the cell was out of range, {nameof(SegmentX)} could not be determined.");
        }

        public static SegmentY GetSegmentY(int y)
        {
            if (y >= 0 && y <= 2) return SegmentY.Bottom;
            else if (y >= 3 && y <= 5) return SegmentY.Middle;
            else if (y >= 6 && y <= 8) return SegmentY.Top;
            else
                throw new ArgumentOutOfRangeException($"The Y coordinate of the cell was out of range, {nameof(SegmentY)} could not be determined.");
        }

        #endregion Methods

    }
}