using System;
using System.Collections.Generic;

class Resume
{
    public string _userName;
    public List<Job> _jobList = new List<Job>();

  
    public void Display()
    {
        Console.WriteLine($"Name: {_userName}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobList)
        {
            job.Display();
        }
       
    }
}