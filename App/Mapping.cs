using System.Text.RegularExpressions;

namespace ADBMailer
{
    public class Mapping
    {
        public readonly ExcelMapper.Header[] ExcelHeaders;
        public readonly WordMapper.Field[] WordFields;
        private ExcelMapper.Header[] _recipientFields;
        private ExcelMapper.Header? _pdfFilenameField;

        public ExcelMapper.Header[] RecipientFields
        {
            get => this._recipientFields;
            set => this._recipientFields = value;
        }

        public ExcelMapper.Header? PDFFilenameField
        {
            get => this._pdfFilenameField;
            set => this._pdfFilenameField = value;
        }

        public readonly Dictionary<string, ExcelMapper.Header?> SelectedWordFields;

        public Mapping(ExcelMapper.Header[] excelHeaders, WordMapper.Field[] wordFields, Mapping? previousMapping)
        {
            this.ExcelHeaders = excelHeaders;
            this.WordFields = wordFields;
            var recipientFields = new List<ExcelMapper.Header>(previousMapping == null ? 1 : previousMapping.RecipientFields.Length);
            if (previousMapping != null)
            {
                foreach (var previousRecipientField in previousMapping.RecipientFields)
                {
                    var found = this.FindExcelHeader(previousRecipientField);
                    if (found != null)
                    {
                        recipientFields.Add(found);
                    }
                }
            }
            this._recipientFields = recipientFields.ToArray();
            this._pdfFilenameField = null;
            if (previousMapping != null && previousMapping.PDFFilenameField != null)
            {
                this._pdfFilenameField = this.FindExcelHeader(previousMapping.PDFFilenameField);
            }
            var selectedWordFields = new Dictionary<string, ExcelMapper.Header?>();
            foreach (var wordField in this.WordFields)
            {
                ExcelMapper.Header? found = null;
                if (previousMapping != null)
                {
                    if (previousMapping.SelectedWordFields.ContainsKey(wordField.Name))
                    {
                        var old = previousMapping.SelectedWordFields[wordField.Name];
                        if (old != null)
                        {
                            found = this.FindExcelHeader(old);
                        }
                    }
                }
                selectedWordFields.Add(wordField.Name, found);
            }
            this.SelectedWordFields = selectedWordFields;
        }

        private static readonly Regex RxIsEmailHeader = new(@"^e[\-.]?mail\s*\d*$", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture);

        public void AutoAssociate()
        {
            if (this.RecipientFields.Length == 0)
            {
                var recipientFields = new List<ExcelMapper.Header>();
                foreach (var excelHeader in this.ExcelHeaders)
                {
                    if (RxIsEmailHeader.IsMatch(excelHeader.Name))
                    {
                        recipientFields.Add(excelHeader);
                    }
                }
                if (recipientFields.Count > 0)
                {
                    this.RecipientFields = recipientFields.ToArray();
                }
            }
            if (this.PDFFilenameField == null)
            {
                foreach (var excelHeader in this.ExcelHeaders)
                {
                    if (excelHeader.Name.Equals("socio", StringComparison.OrdinalIgnoreCase))
                    {
                        this.PDFFilenameField = excelHeader;
                        break;
                    }
                }
            }
            foreach (var kv in this.SelectedWordFields)
            {
                if (kv.Value != null)
                {
                    continue;
                }
                foreach (var excelHeader in this.ExcelHeaders)
                {
                    if (string.Compare(kv.Key, excelHeader.Name, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        this.SelectedWordFields[kv.Key] = excelHeader;
                        break;
                    }
                }
            }
        }

        private ExcelMapper.Header? FindExcelHeader(ExcelMapper.Header oldExcelHeader)
        {
            foreach (var excelHeader in this.ExcelHeaders)
            {
                if (excelHeader.Column == oldExcelHeader.Column && excelHeader.Name == oldExcelHeader.Name)
                {
                    return excelHeader;
                }
            }
            foreach (var excelHeader in this.ExcelHeaders)
            {
                if (excelHeader.Name == oldExcelHeader.Name)
                {
                    return excelHeader;
                }
            }
            return null;
        }
    }
}