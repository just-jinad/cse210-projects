using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("The Great Adventure", "John Doe", 300);
        video1.AddComment("Alice", "Amazing video!");
        video1.AddComment("Bob", "I learned a lot from this.");
        video1.AddComment("Charlie", "Can't wait for the next one!");
        videos.Add(video1);


        Video video2 = new Video("Cooking 101", "Jane Smith", 600);
        video2.AddComment("David", "Great recipe!");
        video2.AddComment("Eve", "Thanks for sharing.");
        video2.AddComment("Frank", "I tried this and it turned out delicious!");
        videos.Add(video2);


        Video video3 = new Video("Travel Vlog: Paris", "Emily Johnson", 900);
        video3.AddComment("Grace", "Beautiful shots!");
        video3.AddComment("Hannah", "I want to visit Paris now!");
        video3.AddComment("Ian", "Thanks for the travel tips.");
        videos.Add(video3);

        Video video4 = new Video("Tech Review: New Smartphone", "Michael Brown", 450);
        video4.AddComment("Jack", "Great review!");
        video4.AddComment("Karen", "I was considering buying this phone, and your review helped me decide.");
        video4.AddComment("Liam", "I appreciate the detailed analysis.");
        videos.Add(video4);


        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"Comment by {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine("_________________________________");

        }


    }
}