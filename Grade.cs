using System;

namespace FinalProject
{
    internal class Grade
    {
        public string CourseID { get; set; }
        public double Score { get; set; }

        public Grade(string courseID, double score)
        {
            CourseID = courseID;
            Score = score;
        }

        public string GetLetterGrade()
        {
            if (Score >= 90)
            {
                return "A";
            }
            else if (Score >= 80)
            {
                return "B";
            }
            else if (Score >= 70)
            {
                return "C";
            }
            else if (Score >= 60)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }
    }
}