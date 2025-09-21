using L1;

namespace tests
{
    public class LeagueTests
    {
        [Fact]
        public void CalculateResults_Should_Calculate_Correct_Points()
        {
            // Arrange
            var league = new League(3);
            league.SetMatchesPlayed(0, 10);
            league.SetMatchesWon(0, 6);
            league.SetMatchesLost(0, 3);
            league.SetMatchesDrawn(0, 1);

            league.SetMatchesPlayed(1, 10);
            league.SetMatchesWon(1, 4);
            league.SetMatchesLost(1, 5);
            league.SetMatchesDrawn(1, 1);

            league.SetMatchesPlayed(2, 10);
            league.SetMatchesWon(2, 7);
            league.SetMatchesLost(2, 2);
            league.SetMatchesDrawn(2, 1);

            league.SetPointsForWin(3);  
            league.SetPointsForDraw(1); 

            // Act
            league.CalculateResults();

            // Assert
            Assert.Equal(19, league.GetFinalPoints(0));
            Assert.Equal(13, league.GetFinalPoints(1)); 
            Assert.Equal(22, league.GetFinalPoints(2)); 
        }

        [Fact]
        public void CalculateAveragePoints_Should_Return_Correct_Average()
        {
            // Arrange
            var league = new League(3);
            league.SetMatchesPlayed(0, 10);
            league.SetMatchesWon(0, 6);
            league.SetMatchesLost(0, 3);
            league.SetMatchesDrawn(0, 1);

            league.SetMatchesPlayed(1, 10);
            league.SetMatchesWon(1, 4);
            league.SetMatchesLost(1, 5);
            league.SetMatchesDrawn(1, 1);

            league.SetMatchesPlayed(2, 10);
            league.SetMatchesWon(2, 7);
            league.SetMatchesLost(2, 2);
            league.SetMatchesDrawn(2, 1);

            league.SetPointsForWin(3);  
            league.SetPointsForDraw(1); 

            // Act
            league.CalculateResults();
            double averagePoints = league.GetAveragePoints();

            // Assert
            Assert.Equal(18.0, averagePoints);
        }

        [Fact]
        public void TeamsNotInTop3_Should_Return_Correct_Count()
        {
            // Arrange
            var league = new League(5);
            league.SetMatchesPlayed(0, 10);
            league.SetMatchesWon(0, 6);
            league.SetMatchesLost(0, 3);
            league.SetMatchesDrawn(0, 1);

            league.SetMatchesPlayed(1, 10);
            league.SetMatchesWon(1, 4);
            league.SetMatchesLost(1, 5);
            league.SetMatchesDrawn(1, 1);

            league.SetMatchesPlayed(2, 10);
            league.SetMatchesWon(2, 7);
            league.SetMatchesLost(2, 2);
            league.SetMatchesDrawn(2, 1);

            league.SetMatchesPlayed(3, 10);
            league.SetMatchesWon(3, 5);
            league.SetMatchesLost(3, 4);
            league.SetMatchesDrawn(3, 1);

            league.SetMatchesPlayed(4, 10);
            league.SetMatchesWon(4, 3);
            league.SetMatchesLost(4, 6);
            league.SetMatchesDrawn(4, 1);

            league.SetPointsForWin(3); 
            league.SetPointsForDraw(1); 

            // Act
            league.CalculateResults();
            int numberOfteamsNotInTop3 = league.GetTeamsNotInTop3();

            // Assert
            Assert.Equal(2, numberOfteamsNotInTop3);
        }

        [Fact]
        public void SortTeamsByPoints_Should_Sort_Correctly()
        {
            // Arrange
            var league = new League(3);
            league.SetMatchesPlayed(0, 10);
            league.SetMatchesWon(0, 5);
            league.SetMatchesLost(0, 3);
            league.SetMatchesDrawn(0, 2);

            league.SetMatchesPlayed(1, 10);
            league.SetMatchesWon(1, 6);
            league.SetMatchesLost(1, 2);
            league.SetMatchesDrawn(1, 2);

            league.SetMatchesPlayed(2, 10);
            league.SetMatchesWon(2, 4);
            league.SetMatchesLost(2, 5);
            league.SetMatchesDrawn(2, 1);

            league.SetPointsForWin(3); 
            league.SetPointsForDraw(1);

            // Act
            league.CalculateResults();

            // Assert
            var sortedPoints = league.GetSortedPoints();
            Assert.Equal(20, sortedPoints[0]);
            Assert.Equal(17, sortedPoints[1]);
            Assert.Equal(13, sortedPoints[2]);
        }
        [Fact]
        public void DisplayResults_Should_Print_Correct_Output()
        {
            // Arrange
            var league = new League(4);
            league.SetMatchesPlayed(0, 10);
            league.SetMatchesWon(0, 6);
            league.SetMatchesLost(0, 3);
            league.SetMatchesDrawn(0, 1);

            league.SetMatchesPlayed(1, 10);
            league.SetMatchesWon(1, 4);
            league.SetMatchesLost(1, 5);
            league.SetMatchesDrawn(1, 1);

            league.SetMatchesPlayed(2, 10);
            league.SetMatchesWon(2, 7);
            league.SetMatchesLost(2, 2);
            league.SetMatchesDrawn(2, 1);

            league.SetMatchesPlayed(3, 10);
            league.SetMatchesWon(3, 3);
            league.SetMatchesLost(3, 6);
            league.SetMatchesDrawn(3, 1);

            league.SetPointsForWin(3);  
            league.SetPointsForDraw(1); 

            league.CalculateResults();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                league.DisplayResults();
                string result = sw.ToString();

                // Assert
                Assert.Contains("Total teams points:", result);
                Assert.Contains("Team 1: 19 points", result);
                Assert.Contains("Team 2: 13 points", result);
                Assert.Contains("Team 3: 22 points", result);
                Assert.Contains("Team 4: 10 points", result);
                Assert.Contains("Total league points: 64 points", result);
                Assert.Contains("Average amount of points: 16.00", result);
                Assert.Contains("Amount of teams not in top-3: 1", result);
                Assert.Contains("Top-3 teams:", result);
                Assert.Contains("Place 1: 22 points", result);
                Assert.Contains("Place 2: 19 points", result);
                Assert.Contains("Place 3: 13 points", result);
            }
        }

        [Fact]
        public void CalculateResults_Should_Handle_Zero_Teams()
        {
            // Arrange
            var league = new League(0);

            // Act & Assert
            league.CalculateResults();
            Assert.Equal(0, league.GetTeamsNotInTop3());
            Assert.Equal(double.NaN, league.GetAveragePoints());
        }

        [Fact]
        public void GetFinalPoints_Should_Return_Zero_For_Uninitialized_Teams()
        {
            // Arrange
            var league = new League(2);

            // Act & Assert
            Assert.Equal(0, league.GetFinalPoints(0));
            Assert.Equal(0, league.GetFinalPoints(1));
        }

        [Fact]
        public void CalculateResults_Should_Handle_All_Draws()
        {
            // Arrange
            var league = new League(3);
            for (int i = 0; i < 3; i++)
            {
                league.SetMatchesPlayed(i, 5);
                league.SetMatchesWon(i, 0);
                league.SetMatchesLost(i, 0);
                league.SetMatchesDrawn(i, 5);
            }
            league.SetPointsForWin(3);
            league.SetPointsForDraw(1);

            // Act
            league.CalculateResults();

            // Assert
            for (int i = 0; i < 3; i++)
            {
                Assert.Equal(5, league.GetFinalPoints(i));
            }
        }

        [Fact]
        public void GetSortedPoints_Should_Return_Correct_Sorted_Array()
        {
            // Arrange
            var league = new League(3);
            league.SetMatchesWon(0, 3);
            league.SetMatchesWon(1, 1);
            league.SetMatchesWon(2, 2);
            league.SetPointsForWin(3);
            league.CalculateResults();

            // Act
            var sortedPoints = league.GetSortedPoints();

            // Assert
            Assert.Equal(new int[] { 9, 6, 3 }, sortedPoints);
        }

        [Fact]
        public void GetTeamsNotInTop3_Should_Handle_Exactly_Three_Teams()
        {
            // Arrange
            var league = new League(3);

            // Act & Assert
            Assert.Equal(0, league.GetTeamsNotInTop3());
        }

        [Fact]
        public void CalculateResults_Should_Accurately_Compute_TotalLeaguePoints()
        {
            // Arrange
            var league = new League(2);
            league.SetMatchesWon(0, 4);
            league.SetMatchesWon(1, 2);
            league.SetPointsForWin(3);

            // Act
            league.CalculateResults();

            // Assert
            Assert.Equal(12, league.GetFinalPoints(0));
            Assert.Equal(6, league.GetFinalPoints(1));
            Assert.Equal(18.0 / 2, league.GetAveragePoints());
        }
    }
}