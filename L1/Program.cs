namespace L1
{
    internal class Program
    {
        static int CorrectInputInt()
        {
            int rez = -2000;
            bool isParseComplited = false;

            while (!isParseComplited)
            {
                isParseComplited = int.TryParse(Console.ReadLine(), out rez);
            }

            return rez;
        }
        static void Main(string[] args)
        {
            //int numberOfTeams;
            //do
            //{
            //    Console.Write("Enter amount of teams (1-20): ");
            //}
            //while (!int.TryParse(Console.ReadLine(), out numberOfTeams) || numberOfTeams < 1 || numberOfTeams > 20);

            //League league = new League(numberOfTeams);

            //for (int i = 0; i < numberOfTeams; i++)
            //{
            //    Console.Write($"\nEnter amount of played matches for team {i + 1}: ");
            //    league.SetMatchesPlayed(i, CorrectInputInt());

            //    Console.Write($"Enter amount of win matches for team {i + 1}: ");
            //    league.SetMatchesWon(i, CorrectInputInt());

            //    Console.Write($"Enter amount of losed matches for team {i + 1}: ");
            //    league.SetMatchesLost(i, CorrectInputInt());

            //    Console.Write($"Enter amount of drawns for team {i + 1}: ");
            //    league.SetMatchesDrawn(i, CorrectInputInt());
            //}

            //int pointsForWin, pointsForDraw;
            //do
            //{
            //    Console.Write("Enter amount of points for win (from 1 to 3): ");
            //}
            //while (!int.TryParse(Console.ReadLine(), out pointsForWin) || pointsForWin < 1 || pointsForWin > 3);

            //do
            //{
            //    Console.Write("Enter amount of points for drawn (from 0 to 1): ");
            //}
            //while (!int.TryParse(Console.ReadLine(), out pointsForDraw) || pointsForDraw < 0 || pointsForDraw > 1);

            //league.SetPointsForWin(pointsForWin);
            //league.SetPointsForDraw(pointsForDraw);

            //league.CalculateResults();
            //league.DisplayResults();
        }
    }
}
