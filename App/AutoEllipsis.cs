using System.Text.RegularExpressions;

namespace ADBMailer
{
    /// <see cref="https://www.codeproject.com/Articles/37503/Auto-Ellipsis"/>
    internal class AutoEllipsis
    {
        /// <summary>
        /// Specifies ellipsis format and alignment.
        /// </summary>
        [Flags]
        public enum EllipsisFormat
        {
            /// <summary>
            /// Text is not modified.
            /// </summary>
            None = 0,

            /// <summary>
            /// Text is trimmed at the end of the string. An ellipsis (...) is drawn in place of remaining text.
            /// </summary>
            End = 1,

            /// <summary>
            /// Text is trimmed at the begining of the string. An ellipsis (...) is drawn in place of remaining text.
            /// </summary>
            Start = 2,

            /// <summary>
            /// Text is trimmed in the middle of the string. An ellipsis (...) is drawn in place of remaining text.
            /// </summary>
            Middle = 3,

            /// <summary>
            /// Preserve as much as possible of the drive and filename information. Must be combined with alignment information.
            /// </summary>
            Path = 4,

            /// <summary>
            /// Text is trimmed at a word boundary. Must be combined with alignment information.
            /// </summary>
            Word = 8
        }

        /// <summary>
        /// String used as a place holder for trimmed text.
        /// </summary>
        public static readonly string EllipsisChars = "...";

        private static readonly Regex prevWord = new(@"\W*\w*$");
        private static readonly Regex nextWord = new(@"\w*\W*");

        /// <summary>
        /// Truncates a text string to fit within a given control width by replacing trimmed text with ellipses.
        /// </summary>
        /// <param name="text">String to be trimmed.</param>
        /// <param name="ctrl">text must fit within ctrl width.
        ///	The ctrl's Font is used to measure the text string.</param>
        /// <param name="options">Format and alignment of ellipsis.</param>
        /// <returns>This function returns text trimmed to the specified witdh.</returns>
        public static string Compact(string text, Control ctrl, EllipsisFormat options)
        {
            if (text.Length == 0)
            {
                return "";
            }

            // no aligment information
            if ((EllipsisFormat.Middle & options) == 0)
            {
                return text;
            }

            using var dc = ctrl.CreateGraphics();
            var size = TextRenderer.MeasureText(dc, text, ctrl.Font);

            // control is large enough to display the whole text
            if (size.Width <= ctrl.Width)
            {
                return text;
            }

            var pre = "";
            var mid = text;
            var post = "";

            var isPath = (EllipsisFormat.Path & options) != 0;

            // split path string into <drive><directory><filename>
            if (isPath)
            {
                pre = Path.GetPathRoot(text) ?? "";
                mid = (Path.GetDirectoryName(text) ?? "")[pre.Length..];
                post = Path.GetFileName(text);
            }

            int len = 0;
            int seg = mid.Length;
            string fit = "";

            // find the longest string that fits into
            // the control boundaries using bisection method
            while (seg > 1)
            {
                seg -= seg >> 1;

                int left = len + seg;
                int right = mid.Length;

                if (left > right)
                {
                    continue;
                }

                if ((EllipsisFormat.Middle & options) == EllipsisFormat.Middle)
                {
                    right -= left / 2;
                    left -= left / 2;
                }
                else if ((EllipsisFormat.Start & options) != 0)
                {
                    right -= left;
                    left = 0;
                }

                // trim at a word boundary using regular expressions
                if ((EllipsisFormat.Word & options) != 0)
                {
                    if ((EllipsisFormat.End & options) != 0)
                    {
                        left -= prevWord.Match(mid, 0, left).Length;
                    }
                    if ((EllipsisFormat.Start & options) != 0)
                    {
                        right += nextWord.Match(mid, right).Length;
                    }
                }

                // build and measure a candidate string with ellipsis
                string tst = mid[..left] + EllipsisChars + mid[right..];

                // restore path with <drive> and <filename>
                if (isPath)
                {
                    tst = Path.Combine(Path.Combine(pre, tst), post);
                }
                size = TextRenderer.MeasureText(dc, tst, ctrl.Font);

                // candidate string fits into control boundaries, try a longer string
                // stop when seg <= 1
                if (size.Width <= ctrl.Width)
                {
                    len += seg;
                    fit = tst;
                }
            }

            if (len == 0) // string can't fit into control
            {
                // "path" mode is off, just return ellipsis characters
                if (!isPath)
                {
                    return EllipsisChars;
                }

                // <drive> and <directory> are empty, return <filename>
                if (pre.Length == 0 && mid.Length == 0)
                {
                    return post;
                }

                // measure "C:\...\filename.ext"
                fit = Path.Combine(Path.Combine(pre, EllipsisChars), post);

                size = TextRenderer.MeasureText(dc, fit, ctrl.Font);

                // if still not fit then return "...\filename.ext"
                if (size.Width > ctrl.Width)
                {
                    fit = Path.Combine(EllipsisChars, post);
                }
            }
            return fit;
        }
    }
}