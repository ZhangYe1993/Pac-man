using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LINQExamples : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        //var names = new[] { "Bill", "Steve", "James", "Juno" };

        ////query syntax
        //var namesWithAQuery = from name in names
        //                      where name.Contains('a')
        //                      select name;
        ////Method syntax
        ////"n goes to => this is calles a lambda expression
        ////methosds syntax has more operators and methods ,and is what the compiler converts query syntax tio
        //// it doesn't really matter which style you use ,but keep this in mind;
        //var namesWithAMethod = names.Where(n => n.Contains('a'));
        //foreach(var name in namesWithAQuery)
        //{
        //    Debug.Log(name);
        //}
        //foreach(var name in namesWithAMethod)
        //{
        //    Debug.Log(name);

        var students = new List<Student>()
        {
            new Student(){Name = "Chirs", age = 22, IQ = 218, Courses = new List<string>() { "Programming","being cool","too much type","music"} },
            new Student(){Name = "Jeff", age = 22, IQ = 200, Courses = new List<string>() { "programming","DRAWING","just dance","COOKING"} },
            new Student(){Name = "Rick", age = 90, IQ = 250, Courses = new List<string>() { "adventure","writing","imagnation","music"} },
            new Student(){Name = "Morty", age = 18, IQ = 250, Courses = new List<string>() { "adventure","drawing","shoot gun","LOL"} },
            new Student(){Name = "Lyon", age = 25, IQ = 220, Courses = new List<string>() { "beingAlone","programming","being actor","DOTA2"} },
            new Student(){Name = "Nan", age = 20, IQ = 220, Courses = new List<string>() { "bubble tea","milk tea","just dance","WangZHE"} }
        };

       
        //先排序，然后在takewhile中选择条件；
        var studentsWhoAreSmart = students.OrderByDescending(s => s.IQ).TakeWhile(s => s.IQ > 100);

        foreach (var student in studentsWhoAreSmart)
        {
            Debug.Log(student.Name);
        }
    }
        
    

    // Update is called once per frame


    public class Enemy
    {
        public string Name;
        public int HP;
    }

    public class Student
    {
        public string Name;
        public int age;
        public int IQ;
        public List<string> Courses;
    }
}
