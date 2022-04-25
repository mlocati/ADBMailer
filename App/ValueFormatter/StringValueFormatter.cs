using OfficeOpenXml;

namespace ADBMailer.ValueFormatter
{
    internal class StringValueFormatter : IValueFormatter
    {
        public StringValueFormatter()
        {
        }

        public string Format(ExcelRange cell)
        {
            return cell.GetValue<string>() ?? string.Empty;
        }
    }
}