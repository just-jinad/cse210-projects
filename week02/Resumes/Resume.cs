using System;
using System.Collections.Generic;

class Resume
{
    public string _userName;
    public List<Job> _jobList = new List<Job>();

  
    public void Display()
    {
        // return _UserName;
        Console.WriteLine($"Name: {_userName}");
        //Write a loop in Resume.Display() that walks _jobList and calls each job's own Display() method — plus print the "Jobs:" header once, in the right place.
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobList)
        {
            job.Display();
        }
       
    }
}