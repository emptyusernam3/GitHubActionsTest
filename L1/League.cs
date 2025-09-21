using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    public class League
    {
        private int numberOfTeams;
        private int[] matchesPlayed;
        private int[] matchesWon;
        private int[] matchesLost;
        private int[] matchesDrawn;
        private int pointsForWin;
        private int pointsForDraw;
        private int[] finalPoints;
        private int totalLeaguePoints;

        public League(int numberOfTeams)
        {
            this.numberOfTeams = numberOfTeams;
            matchesPlayed = new int[numberOfTeams];
            matchesWon = new int[numberOfTeams];
            matchesLost = new int[numberOfTeams];
            matchesDrawn = new int[numberOfTeams];
            finalPoints = new int[numberOfTeams];
        }

        public void SetMatchesPlayed(int teamIndex, int value) => matchesPlayed[teamIndex] = value;

        public void SetMatchesWon(int teamIndex, int value) => matchesWon[teamIndex] = value;

        public void SetMatchesLost(int teamIndex, int value) => matchesLost[teamIndex] = value;

        public void SetMatchesDrawn(int teamIndex, int value) => matchesDrawn[teamIndex] = value;

        public void SetPointsForWin(int points) => pointsForWin = points;

        public void SetPointsForDraw(int points) => pointsForDraw = points;

        public int GetFinalPoints(int teamIndex) => finalPoints[teamIndex];
        public double GetAveragePoints() => (double)totalLeaguePoints / numberOfTeams;
        public int GetTeamsNotInTop3() => Math.Max(0, numberOfTeams - 3);

        public int[] GetSortedPoints()
        {
            int[] sortedPoints = (int[])finalPoints.Clone();
            Array.Sort(sortedPoints, (a, b) => b.CompareTo(a));
            return sortedPoints;
        }
        public void CalculateResults()
        {
            totalLeaguePoints = 0;
            for (int i = 0; i < numberOfTeams; i++)
            {
                finalPoints[i] = (matchesWon[i] * pointsForWin) + (matchesDrawn[i] * pointsForDraw);
                totalLeaguePoints += finalPoints[i];
            }
        }

        public void DisplayResults()
        {
            Console.WriteLine("\nTotal teams points:");
            for (int i = 0; i < numberOfTeams; i++)
            {
                Console.WriteLine($"Team {i + 1}: {finalPoints[i]} points");
            }

            // Среднее количество очков
            double averagePoints = (double)totalLeaguePoints / numberOfTeams;
            Console.WriteLine($"\nTotal league points: {totalLeaguePoints} points");
            Console.WriteLine($"Average amount of points: {averagePoints:F2}");

            // Количество команд, не попавших в топ-3
            int nonTopTeams = Math.Max(0, numberOfTeams - 3);
            Console.WriteLine($"Amount of teams not in top-3: {nonTopTeams}");

            // Сортировка команд по очкам
            Array.Sort(finalPoints, (a, b) => b.CompareTo(a));

            // Вывод топ-3 команд
            Console.WriteLine("\nTop-3 teams:");
            for (int i = 0; i < Math.Min(3, numberOfTeams); i++)
            {
                Console.WriteLine($"Place {i + 1}: {finalPoints[i]} points");
            }
        }
    }
}
