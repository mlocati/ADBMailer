using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ADBMailer
{
    public class WordMapper
    {
        public class Field
        {
            public readonly string Name;
            public readonly Dictionary<string, ValueFormatter.IValueFormatter> Placeholders;

            public Field(string name, Dictionary<string, ValueFormatter.IValueFormatter> placeholders)
            {
                this.Name = name;
                this.Placeholders = placeholders;
            }

            public override string ToString()
            {
                return this.Name;
            }
        }

        private readonly CultureInfo OutputCultureInfo;

        public WordMapper(CultureInfo outputCultureInfo)
        {
            this.OutputCultureInfo = outputCultureInfo;
        }

        public Field[] GetFields(string wordFile)
        {
            if (FieldStorage.GetLastMapping(FieldStorage.Kind.WordFields, wordFile, this.OutputCultureInfo.Name) is Field[] result)
            {
                return result;
            }
            using var doc = WordprocessingDocument.Open(wordFile, false, new OpenSettings() { AutoSave = false });
            if (doc.MainDocumentPart == null)
            {
                throw new Exception($"Il documento di Word {wordFile} non contiene la parte principale del documento");
            }
            return this.ActuallyGetFields(wordFile, doc.MainDocumentPart);
        }

        public Field[] GetFields(string wordFile, MainDocumentPart mainDocumentPart)
        {
            if (FieldStorage.GetLastMapping(FieldStorage.Kind.WordFields, wordFile, this.OutputCultureInfo.Name) is Field[] result)
            {
                return result;
            }
            return this.ActuallyGetFields(wordFile, mainDocumentPart);
        }

        private readonly Regex RxSort = new(@"^(?<pre>[^0-9]*)(?<num>[0-9]{1,9})");

        private Field[] ActuallyGetFields(string wordFile, MainDocumentPart mainDocumentPart)
        {
            var fields = new Dictionary<string, Dictionary<string, ValueFormatter.IValueFormatter>>();
            if (mainDocumentPart.Document.Body != null)
            {
                foreach (var para in mainDocumentPart.Document.Body.Descendants<Paragraph>())
                {
                    this.GetFields(para, fields);
                }
            }
            if (fields.Count == 0)
            {
                throw new Exception($"Nessun campo trovato nel documento di Word {wordFile}");
            }
            var result = new List<Field>(fields.Count);
            foreach (var kv in fields)
            {
                result.Add(new Field(kv.Key, kv.Value));
            }
            result.Sort(delegate (Field a, Field b)
            {
                var matchA = RxSort.Match(a.Name);
                var matchB = RxSort.Match(b.Name);
                if (matchA.Success && matchB.Success && matchA.Groups["pre"].Value == matchB.Groups["pre"].Value)
                {
                    var intA = int.Parse(matchA.Groups["num"].Value);
                    var intB = int.Parse(matchB.Groups["num"].Value);
                    if (intA != intB)
                    {
                        return intA - intB;
                    }
                }
                return String.Compare(a.Name, b.Name);
            });
            var finalResult = result.ToArray();
            FieldStorage.SetLastMapping(FieldStorage.Kind.WordFields, wordFile, finalResult, this.OutputCultureInfo.Name);
            return finalResult;
        }

        private static readonly Regex RxQuickCheck = new(@"<[^<]+>", RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture | RegexOptions.Compiled);
        private static readonly Regex RxMatchPlaceholder = new(@"(?<placeholder><(?<field>[\w]+)(:(?<flags>[%\w]*))?>)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture | RegexOptions.Compiled);

        private void GetFields(Paragraph para, Dictionary<string, Dictionary<string, ValueFormatter.IValueFormatter>> fields)
        {
            if (!RxQuickCheck.IsMatch(para.InnerText))
            {
                return;
            }
            var contiguousRuns = new List<Run>();
            string contiguousRunsText = "";
            foreach (var run in para.Elements<Run>())
            {
                var texts = run.Elements<Text>();
                if (!texts.Any() && !contiguousRunsText.Contains('<'))
                {
                    contiguousRuns.Clear();
                    contiguousRunsText = "";
                    continue;
                }
                contiguousRuns.Add(run);
                foreach (var text in texts)
                {
                    contiguousRunsText += text.InnerText;
                    if (!contiguousRunsText.Contains('<'))
                    {
                        contiguousRuns.Clear();
                        contiguousRunsText = "";
                        continue;
                    }
                    var match = RxMatchPlaceholder.Match(contiguousRunsText);
                    if (!match.Success)
                    {
                        continue;
                    }
                    while (match.Success)
                    {
                        this.AddFoundField(fields, match.Groups["placeholder"].Value, match.Groups["field"].Value, match.Groups["flags"].Value);
                        match = match.NextMatch();
                    }
                    if (contiguousRuns.Count > 1)
                    {
                        contiguousRuns.Clear();
                        contiguousRuns.Add(run);
                        contiguousRunsText = text.InnerText;
                    }
                }
            }
        }

        public static void ReplacePlaceholder(MainDocumentPart mainDocumentPart, string placeholder, string value)
        {
            if (mainDocumentPart.Document.Body != null)
            {
                foreach (var para in mainDocumentPart.Document.Body.Descendants<Paragraph>())
                {
                    ReplacePlaceholder(para, placeholder, value);
                }
            }
        }

        private static void ReplacePlaceholder(Paragraph para, string placeholder, string value)
        {
            if (!RxQuickCheck.IsMatch(para.InnerText))
            {
                return;
            }
            Text? firstText = null;
            var contiguousRuns = new List<Run>();
            string contiguousRunsText = "";
            var allRuns = para.Elements<Run>().ToArray<Run>();
            foreach (var run in allRuns)
            {
                var allTexts = run.Elements<Text>().ToArray<Text>();
                if (allTexts.Length == 0 && !contiguousRunsText.Contains('<'))
                {
                    firstText = null;
                    contiguousRuns.Clear();
                    contiguousRunsText = "";
                    continue;
                }
                contiguousRuns.Add(run);
                foreach (var text in allTexts)
                {
                    contiguousRunsText += text.InnerText;
                    if (!contiguousRunsText.Contains('<'))
                    {
                        firstText = null;
                        contiguousRuns.Clear();
                        contiguousRunsText = "";
                        continue;
                    }
                    if (firstText == null)
                    {
                        firstText = text;
                    }
                    if (!contiguousRunsText.Contains(placeholder))
                    {
                        continue;
                    }
                    contiguousRunsText = contiguousRunsText.Replace(placeholder, value);
                    firstText.Text = contiguousRunsText;
                    for (var i = contiguousRuns.Count - 1; i >= 1; i--)
                    {
                        contiguousRuns[i].Remove();
                    }
                    contiguousRuns.Clear();
                    contiguousRuns.Add(run);
                }
            }
        }

        private static readonly Regex RxFieldNumber = new(@"^(?<type>[%N])(?<decimals>[0-9]+)?$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture | RegexOptions.Compiled);

        private void AddFoundField(Dictionary<string, Dictionary<string, ValueFormatter.IValueFormatter>> fields, string placeholder, string field, string flags)
        {
            field = field.ToLowerInvariant();
            if (!fields.ContainsKey(field))
            {
                fields.Add(field, new Dictionary<string, ValueFormatter.IValueFormatter>());
            }
            if (fields[field].ContainsKey(placeholder))
            {
                return;
            }
            ValueFormatter.IValueFormatter formatter;
            if (flags.Length == 0)
            {
                formatter = new ValueFormatter.StringValueFormatter();
            }
            else
            {
                var fieldNumberMatch = RxFieldNumber.Match(flags);
                if (fieldNumberMatch.Success)
                {
                    formatter = new ValueFormatter.NumberValueFormatter(
                        fieldNumberMatch.Groups["type"].Value.Equals("%"),
                        fieldNumberMatch.Groups["decimals"].Value == "" ? null : int.Parse(fieldNumberMatch.Groups["decimals"].Value),
                        this.OutputCultureInfo
                    );
                }
                else
                {
                    throw new Exception($"Campo di Word non valido: <{field}:{flags}>");
                }
            }
            fields[field].Add(placeholder, formatter);
        }
    }
}