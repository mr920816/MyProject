using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Linq
{
    public class Student 
    {
        public int id;
        public int? gId;
        public string name;
        public string remark;
        public School SchName;
        public List<Scores> scores;
    }

    public class Scores
    {
        public Scores(int id, string sname, int score)
        {
            this.id = id;
            scoresName = sname;
            this.score = score;
        }
        public int id;
        public string scoresName;
        public int score;
    }


    public class Grade
    {
        public int id;
        public string gName;
        public string remark;
         
    }


    public class School
    {
        public int id;
        public string sName;
        public string remark;

    }
}
