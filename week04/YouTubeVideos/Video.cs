public class Video
{
    private string title;
    private string author;
    private int length; 
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
    }

    public string GetTitle()
    {
        return title;
    }

    public string GetAuthor()
    {
        return author;
    }

    public int GetLength()
    {
        return length;
    }

    public void AddComment(string name, string text)
    {
        Comment comment = new Comment(name, text);
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public IReadOnlyList<Comment> GetComments()
    {
        return comments; 
    }
}