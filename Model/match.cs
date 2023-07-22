namespace tennisGame.Model
{
  public class Match
  {
    private int _player1Score;
    private int _player2Score;
    private int _player1Games;
    private int _player2Games;
    private bool isTiebreak; // if true, then tiebreakPlayer1Score and tiebreakPlayer2Score are used
    private int tiebreakPlayer1Score;
    private int tiebreakPlayer2Score;
    private string _player1Name;
    private string _player2Name;
    public Match(string player1, string player2)
    {
      _player1Name = player1;
      _player2Name = player2;
    }
    public void PointWinBy(string player)
    {
      if (isTiebreak)
      {
        if (player == _player1Name)
        {
          tiebreakPlayer1Score++; // increment player1 score
        }
        else
        {
          tiebreakPlayer2Score++;
        }
      }
      else
      {
        if (player == _player1Name)
        {
          _player1Score++; // increment player1 score
        }
        else
        {
          _player2Score++;
        }
      }
      UpdateGameScore();
    }
    private void UpdateGameScore()
    {
      if (isTiebreak)
      {
        if ((tiebreakPlayer1Score >= 7 || tiebreakPlayer2Score >= 7) && Math.Abs(tiebreakPlayer1Score - tiebreakPlayer2Score) >= 2) // abs is absolute value
        {
          isTiebreak = false;
          if (tiebreakPlayer1Score > tiebreakPlayer2Score)
            _player1Games++; // increment player1 games
          else
            _player2Games++; // increment player2 games
          tiebreakPlayer1Score = 0; // reset tiebreak scores
          tiebreakPlayer2Score = 0; // reset tiebreak scores
        }
      }
      else if (_player1Score >= 4 || _player2Score >= 4)
      {
        if (Math.Abs(_player1Score - _player2Score) >= 2)
        {
          if (_player1Score > _player2Score)
            _player1Games++; // increment player1 games
          else
            _player2Games++;
          _player1Score = 0;
          _player2Score = 0;
        }
        else if (_player1Score == _player2Score && _player1Score == 3)
        {
          _player1Score = 3;
          _player2Score = 3;
        }
        else if (_player1Score == _player2Score && _player1Score >= 3)
        {
          _player1Score = 4;
          _player2Score = 4;
        }
      }
    }
    //showing the score
    public string score()
    {
      if (isTiebreak)
        return $"Set Score :  {_player1Games}-{_player2Games},Score:  {tiebreakPlayer1Score}-{tiebreakPlayer2Score}";
      else if (_player1Score == 4 && _player2Score == 4)
        return $"Set Score : {_player1Games}-{_player2Games},Score:  Deuce";
      else if (_player1Score == 3 && _player2Score == 3)
        return $"Set Score : {_player1Games}-{_player2Games},Score:  Deuce";
      else if (_player1Score == 4 && _player2Score == 3)
        return $"Set Score : {_player1Games}-{_player2Games},Score:  Advantage {_player1Name}";
      else if (_player1Score == 3 && _player2Score == 4)
        return $"Set Score : {_player1Games}-{_player2Games},Score:  Advantage {_player2Name}";
      else if (_player1Score >= 4 || _player2Score >= 4)
        return $"Set Score : {_player1Games}-{_player2Games},Score: {GetTennisScore(_player1Score)}-{GetTennisScore(_player2Score)}";
      else
        return $"Set Score : {_player1Games}-{_player2Games}, Score: {GetTennisScore(_player1Score)}-{GetTennisScore(_player2Score)}";
    }
    //Get points
    private string GetTennisScore(int points)
    {
      switch (points)
      {
        case 0:
          return "0";
        case 1:
          return "15";
        case 2:
          return "30";
        case 3:
          return "40";
        default:
          return "";
      }
    }
  }
}
