using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Linq
{
    public class Student 
    {
        public int id;
        public string name;
        public string remark;
        public List<Scores> scores;
    }

    public class Scores
    {
        public Scores(int id, string name, int score)
        {
            this.id = id;
            scoresName = name;
            this.score = score;
        }
        public int id;
        public string scoresName;
        public int score;
    }
}
