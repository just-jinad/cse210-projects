using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        // TODO: split `text` on whitespace, wrap each token in a Word, add to _words
    }

    public void HideRandomWords(int numberToHide) { }
    public string GetDisplayText() { return ""; }
    public bool IsCompletelyHidden() { return false; }
}