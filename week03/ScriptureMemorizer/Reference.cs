public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    // Reference("proverbs", 3, 5, 6) => "Proverbs 3:5-6"

    public Reference(string book, int chapter, int verse, int endVerse) : this(book, chapter, verse)
    {
        _endVerse = endVerse;
    }

    public string GetDisplayText() { return ""; }
}