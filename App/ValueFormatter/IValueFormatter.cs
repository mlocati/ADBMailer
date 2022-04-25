using OfficeOpenXml;

namespace ADBMailer.ValueFormatter
{
    public interface IValueFormatter
    {
        public string Format(ExcelRange cell);
    }
}