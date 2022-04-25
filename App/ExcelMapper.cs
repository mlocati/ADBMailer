using OfficeOpenXml;

namespace ADBMailer
{
    public class ExcelMapper
    {
        public class Header
        {
            public readonly int Row;
            public readonly int Column;
            public readonly string ColumnLetter;
            public readonly string Name;

            public Header(int row, int column, string name)
            {
                this.Row = row;
                this.Column = column;
                this.ColumnLetter = OfficeOpenXml.ExcelAddress.GetAddressCol(column);
                this.Name = name;
            }

            public override string ToString()
            {
                return $"{this.Name} (colonna {this.ColumnLetter})";
            }
        }

        public ExcelMapper()
        {
        }

        public Header[] GetColumnHeaders(string excelFile)
        {
            if (FieldStorage.GetLastMapping(FieldStorage.Kind.ExcelFields, excelFile) is Header[] result)
            {
                return result;
            }
            var fileInfo = new FileInfo(excelFile);
            if (!fileInfo.Exists)
            {
                throw new Exception($"Impossibile trovare il file {excelFile}");
            }
            using var package = new ExcelPackage(fileInfo);
            if (package.Workbook.Worksheets.Count < 1)
            {
                throw new Exception($"Il documento di Excel {excelFile} non contiene alcun foglio");
            }
            return this.ActuallyGetColumnHeaders(excelFile, package.Workbook.Worksheets[0]);
        }

        public Header[] GetColumnHeaders(string excelFile, ExcelWorksheet sheet)
        {
            if (FieldStorage.GetLastMapping(FieldStorage.Kind.ExcelFields, excelFile) is Header[] result)
            {
                return result;
            }
            return this.ActuallyGetColumnHeaders(excelFile, sheet);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Possible future changes>")]
        private Header[] ActuallyGetColumnHeaders(string excelFile, ExcelWorksheet sheet)
        {
            if (sheet.Dimension == null)
            {
                throw new Exception($"Il foglio nel documento di Excel {excelFile} è vuoto");
            }
            var headerRow = sheet.Dimension.Start.Row;
            var firstColumn = sheet.Dimension.Start.Column;
            var lastColumn = sheet.Dimension.End.Column;
            var list = new List<Header>(lastColumn - firstColumn + 1);
            for (var column = firstColumn; column <= lastColumn; column++)
            {
                string value = sheet.Cells[headerRow, column].GetValue<string>();
                value = value == null ? "" : value.Trim();
                if (value.Length != 0)
                {
                    list.Add(new Header(headerRow, column, value));
                }
            }
            if (list.Count == 0)
            {
                throw new Exception($"Il foglio nel documento di Excel {excelFile} non contiene alcun dato");
            }
            var actualResult = list.ToArray();
            FieldStorage.SetLastMapping(FieldStorage.Kind.ExcelFields, excelFile, actualResult);
            return actualResult;
        }
    }
}