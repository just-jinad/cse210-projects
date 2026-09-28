public class Video
{
    private string _title;
    private string _author;
    private int _length; 
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        this._title = title;
        this._author = author;
        this._length = length;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLength()
    {
        return _length;
    }

    public void AddComment(string name, string text)
    {
        Comment comment = new Comment(name, text);
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public IReadOnlyList<Comment> GetComments()
    {
        return _comments; 
    }
}