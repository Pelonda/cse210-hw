using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Bake Bread", "Emma Stone", 420);
        video1.AddComment(new Comment("Ava", "This was really helpful!"));
        video1.AddComment(new Comment("Noah", "Great explanation."));
        video1.AddComment(new Comment("Liam", "I learned a lot."));
        videos.Add(video1);

        Video video2 = new Video("C# Classes Explained", "Code Master", 615);
        video2.AddComment(new Comment("Mia", "Perfect for beginners."));
        video2.AddComment(new Comment("Sophia", "Clear and easy to follow."));
        video2.AddComment(new Comment("Ethan", "Thanks for this video."));
        videos.Add(video2);

        Video video3 = new Video("Travel Tips for Europe", "Wander World", 530);
        video3.AddComment(new Comment("Olivia", "Adding this to my list!"));
        video3.AddComment(new Comment("James", "Very useful tips."));
        video3.AddComment(new Comment("Charlotte", "Loved the scenery."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}