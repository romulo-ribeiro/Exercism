using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private Dictionary<string, int> students = new Dictionary<string, int>();

    public void Add(string student, int grade)
    {
        students.Add(student,grade);
    }

    public IEnumerable<string> Roster()
    {
        var show = new List<string>();
        foreach (var student in students.OrderBy(x => x.Value).ThenBy(x => x.Key))
        {
            show.Add(student.Key);
        }
        return show;
    }

    public IEnumerable<string> Grade(int grade)
    {
        var gradeStudents = new List<string>();
        foreach (var x in students)
        {
            if (x.Value == grade)
                gradeStudents.Add(x.Key);
        }
        return gradeStudents.OrderBy(x => x);
    }
}