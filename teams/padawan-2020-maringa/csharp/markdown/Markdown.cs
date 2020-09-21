using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class Markdown
{
    private static string Wrap(string text, string tag) => $"<{tag}>{text}</{tag}>";

    private static string Parse(string markdown, string delimiter, string tag) =>
        Regex.Replace(markdown, $"{delimiter}(.+){delimiter}", $"<{tag}>$1</{tag}>");

    private static string ParseBold(string markdown) => Parse(markdown, "__", "strong");

    private static string ParseItalic(string markdown) => Parse(markdown, "_", "em");

    private static string ParseText(string markdown, bool list)
    {
        var parsedText = ParseItalic(ParseBold(markdown));

        return list ? parsedText : Wrap(parsedText, "p");
    }

    private static string ParseHeader(string markdown, bool list, out bool inListAfter)
    {
        var count = Regex.Match(markdown, @"^#+").Length;

        if (count == 0)
        {
            inListAfter = list;
            return null;
        }

        var headerTag = "h" + count;
        var headerHtml = Wrap(markdown.Substring(count + 1), headerTag);

        var closing = (list) ? "</ul>" : string.Empty;
        inListAfter = false;
        return $"{closing}{headerHtml}";
    }

    private static string ParseLineItem(string markdown, bool list, out bool inListAfter)
    {
        if (markdown.StartsWith("*"))
        {
            var innerHtml = Wrap(ParseText(markdown.Substring(2), true), "li");
            var closing = list ? string.Empty : "<ul>";
            inListAfter = true;
            return $"{closing}{innerHtml}";
        }

        inListAfter = list;
        return null;
    }

    private static string ParseParagraph(string markdown, bool list, out bool inListAfter)
    {
        string closing = (!list) ? "" : "</ul>";
        inListAfter = false;
        return $"{closing}{ParseText(markdown, false)}";
    }

    private static string ParseLine(string markdown, bool list, out bool inListAfter)
    {
        string result = ParseHeader(markdown, list, out inListAfter);

        if (result == null)
        {
            result = ParseLineItem(markdown, list, out inListAfter);
        }
        if (result == null)
        {
            result = ParseParagraph(markdown, list, out inListAfter);
        }

        return result ?? throw new ArgumentException("Invalid markdown");
    }

    public static string Parse(string markdown)
    {
        string[] lines = markdown.Split('\n');
        StringBuilder result = new StringBuilder();
        bool list = false;

        for (int i = 0; i < lines.Length; i++)
        {
            string lineResult = ParseLine(lines[i], list, out list);
            result.Append(lineResult);
        }
        string text = result.ToString();
        return list ? $"{text}</ul>" : text;
    }
}