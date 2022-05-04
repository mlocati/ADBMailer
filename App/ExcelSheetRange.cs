using OfficeOpenXml;

namespace ADBMailer
{
    public class ExcelSheetRange
    {
        public readonly int HeaderRow;
        public readonly int FirstDataRow;
        public readonly int LastDataRow;
        public readonly int FirstColumn;
        public readonly int LastColumn;

        public ExcelSheetRange(ExcelWorksheet sheet)
        {
            var startRow = sheet.Dimension.Start.Row;
            var endRow = sheet.Dimension.End.Row;
            var startColumn = sheet.Dimension.Start.Column;
            var endColumn = sheet.Dimension.End.Column;
            this.HeaderRow = startRow;
            while (this.HeaderRow < endRow && IsRowEmpty(sheet, this.HeaderRow, startColumn, endColumn))
            {
                this.HeaderRow++;
            }
            this.FirstDataRow = this.HeaderRow + 1;
            while (this.FirstDataRow < endRow && IsRowEmpty(sheet, this.FirstDataRow, startColumn, endColumn))
            {
                this.FirstDataRow++;
            }
            this.LastDataRow = Math.Max(this.FirstDataRow, endRow);
            while (this.LastDataRow > this.FirstDataRow && IsRowEmpty(sheet, this.LastDataRow, startColumn, endColumn))
            {
                this.LastDataRow--;
            }
            this.FirstColumn = startColumn;
            while (this.FirstColumn < endColumn && IsColumnEmpty(sheet, this.FirstColumn, this.HeaderRow, this.LastDataRow))
            {
                this.FirstColumn++;
            }
            this.LastColumn = endColumn;
            while (this.LastColumn > this.FirstColumn && IsColumnEmpty(sheet, this.LastColumn, this.HeaderRow, this.LastDataRow))
            {
                this.LastColumn--;
            }
        }

        private static bool IsRowEmpty(ExcelWorksheet sheet, int row, int startColumn, int endColumn)
        {
            for (var column = startColumn; column <= endColumn; column++)
            {
                if (!IsCellEmpty(sheet, row, column))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsColumnEmpty(ExcelWorksheet sheet, int column, int startRow, int endRow)
        {
            for (var row = startRow; row <= endRow; row++)
            {
                if (!IsCellEmpty(sheet, row, column))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsCellEmpty(ExcelWorksheet sheet, int row, int column)
        {
            var value = sheet.Cells[row, column]?.Value?.ToString();
            if (!string.IsNullOrEmpty(value))
            {
                return false;
            }
            return true;
        }
    }
}