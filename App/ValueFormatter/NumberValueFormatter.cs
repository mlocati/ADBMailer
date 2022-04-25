using OfficeOpenXml;
using System.Globalization;

namespace ADBMailer.ValueFormatter
{
    internal class NumberValueFormatter : IValueFormatter
    {
        public readonly string FormatString;
        public readonly CultureInfo OutputCultureInfo;

        public NumberValueFormatter(bool isPercentage, int? decimalDigits, CultureInfo outputCultureInfo)
        {
            if (decimalDigits.HasValue)
            {
                this.FormatString = "#,##0." + new string('0', decimalDigits.Value);
            }
            else
            {
                this.FormatString = "#,##0.##########";
            }
            if (isPercentage)
            {
                this.FormatString += "%";
            }
            this.OutputCultureInfo = outputCultureInfo;
        }

        public string Format(ExcelRange cell)
        {
            decimal v;
            try
            {
                v = cell.GetValue<decimal>();
            }
            catch
            {
                return "";
            }
            if (v == 0M)
            {
                string? s;
                try
                {
                    s = cell.GetValue<string>();
                }
                catch
                {
                    s = null;
                }
                if (string.IsNullOrEmpty(s))
                {
                    return "";
                }
            }
            return v.ToString(this.FormatString, OutputCultureInfo);
        }
    }
}