namespace tennisGame
{
  using Model;
  class Program
  {
    static void Main(string[] args)
    {
      var match = new Match("player 1", "player 2");
      Console.WriteLine("Welcome to the tennis game!");
      Console.WriteLine("Press 1 if player 1 wins the point, 2 if player 2 wins the point, or 0 to exit.");
      while (true)
      {
        var input = Console.ReadLine();
        if (input == "0")
        {
          break;
        }
        else if (input == "1")
        {
          match.PointWinBy("player 1");
        }
        else if (input == "2")
        {
          match.PointWinBy("player 2");
        }
        else
        {
          Console.WriteLine("Invalid input. Press 1 if player 1 wins the point, 2 if player 2 wins the point, or 0 to exit.");
          continue;
        }
        Console.WriteLine(match.score());
        Console.WriteLine("Please enter the next point winner (1, 2, or 0 to exit):");
      }
    }
  }
}
