public class Comment
{
    private string _name;
    private string _text;

    public Comment(string name, string text)
    {
        this._name = name;
        this._text = text;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetText()
    {
        return _text;
    }
}