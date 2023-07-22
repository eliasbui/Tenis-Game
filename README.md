
# Tennis Game

We are hosting a tennis tournament. To aid with this, we're developing a scoring system.

The scoring system for tennis works like this.

* A match has one set and a set has many games

* A game is won by the first player to have won at least 4 points in total and at least 2 points more than the opponent.

  * The running score of each game is described in a manner peculiar to tennis: scores from zero to three points are described as 0, 15, 30, 40, respectively

 * If at least 3 points have been scored by each player, and the scores are equal, the score is "deuce".

 * If at least 3 points have been scored by each side and a player has one more point than his opponent, the score of the game is "advantage" for the player in the lead.

* There are many games to a set in tennis

 * A player wins a set by winning at least 6 games and at least 2 games more than the opponent.

 * If one player has won six games and the opponent five, an additional game is played. If the leading player wins that game, the player wins the set 7–5. If the trailing player wins the game, a tie-break is played.

 * A tie-break, played under a separate set of rules, allows one player to win one more game and thus the set, to give a final set score of 7–6. A tie-break is scored one point at a time. The tie-break game continues until one player wins seven points by a margin of two or more points. Instead of being scored from 0, 15, 30, 40 like regular games, the score for a tie breaker goes up incrementally from 0 by 1. i.e a player's score will go  from 0 to 1 to 2 to 3 …etc.

* Add a score method that will return the current set score followed by the current game score

* Add a pointWonBy method that indicates who won the point

Constraints

* Only worry about 1 set
* Don't worry about validation, assume the client passes in correct data

More information on tennis scoring can be found here https://en.wikipedia.org/wiki/Tennis_scoring_system

For example:


The interface should look something like this in .Net:

```

  Match match = new Match("player 1", "player 2");
  match.pointWonBy("player 1");
  match.pointWonBy("player 2");
  // this will return "0-0, 15-15"
  match.score();

  match.pointWonBy("player 1");
  match.pointWonBy("player 1");
  // this will return "0-0, 40-15"
  match.score();

  match.pointWonBy("player 2");
  match.pointWonBy("player 2");
  // this will return "0-0, Deuce"
  match.score();

  match.pointWonBy("player 1");
  // this will return "0-0, Advantage player 1"
  match.score();

  match.pointWonBy("player 1");
  // this will return "1-0"
  match.score();

```
# Cách tính điểm tennis cơ bản
- Mỗi trận đấu quần vợt thường được thực hiện từ ba đến năm set (hiệp). Vận động viên nào giành nhiều set hơn sẽ giành chiến thắng trong trận đấu.

- Để thắng một set, vận động viên cần giành chiến thắng ít nhất 6 game. Trong trường hợp tỷ số set là 6-6, hai vận động viên sẽ thực hiện đánh loạt tie-break để xác định người giành chiến thắng set.

- Trong mỗi game đấu, điểm số được tính bắt đầu từ 0-15-30-40 và kết thúc. Tuy nhiên, thực tế chỉ có bốn điểm. Từ điểm số 0, lần lượt tăng lên 15, 30, 40 và cuối cùng là game. Khi cả hai vận động viên đạt được 3 điểm (40-40), tỷ số sẽ là "deuce" (hòa). Sau đó, nếu một vận động viên giành thêm một điểm nữa, được gọi là "advantage" (ưu thế), và nếu pha bóng tiếp theo lại mất điểm, tỷ số sẽ quay lại 40-40 (40 deuce). Game đấu có thể diễn ra mãi mãi cho đến khi một vận động viên giành cách biệt 2 điểm và dành chiến thắng game.

### Bắt đầu trận đấu
#### Bắt đầu giao bóng
- Trước khi bắt đầu trận đấu, trọng tài xác định người giao bóng bằng cách tung đồng xu hoặc quay vợt. Vận động viên được chọn sẽ lựa chọn phần sân mình bắt đầu hoặc lựa chọn phát bóng trước. Người còn lại sẽ lựa chọn đỡ bóng trước hoặc phần sân thi đấu.

- Vận động viên giao bóng sẽ tiếp tục giao bóng liên tục cho đến khi game đấu kết thúc. Vận động viên thực hiện giao bóng từ phần sân bên phải, bất kể phần sân nào.

#### Bắt đầu hiệp đấu tiếp theo
- Vận động viên thua set đấu trước sẽ được quyền lựa chọn giao bóng trước trong set đấu tiếp theo.

### Cách tính điểm tennis trong game đấu
- Trước khi thực hiện giao bóng, trọng tài thông báo điểm cho hai vận động viên. Vận động viên giao bóng sẽ được thông báo điểm trước. Ví dụ, 0-40 có nghĩa là bạn giao bóng nhưng chưa được điểm nào, đối thủ đã thắng 3 điểm.

### Điểm giao bóng
- Mỗi khi vận động viên thực hiện giao bóng, nếu mắc lỗi lần đầu, vận động viên sẽ được giao bóng lần thứ hai. Nếu tiếp tục mắc lỗi lần thứ hai, điểm được tính cho đối thủ.

- Nếu lần đầu bạn giao bóng chạm lưới nhưng bóng vẫn vào đúng phần sân nhận bóng của đối phương, pha bóng đó sẽ được thực hiện lại và bạn không bị tính là vi phạm luật.

### Bảng điểm trong game đấu
- Khi bắt đầu game, cả hai vận động viên đều có số điểm là: 0 - 0 (tiếng Anh đọc là "love"). Khi một vận động viên giành được một điểm, điểm số của họ sẽ tăng dần từ 0 lên 15, sau đó là 30, 40 và cuối cùng là "game". Vận động viên nào giành được 4 điểm trước và có cách biệt 2 điểm sẽ dành chiến thắng game.

### Cách tính điểm tie-break
- Trong game "tie-break", luật áp dụng tính điểm từ 1 đến 7. Vận động viên nào giành được 7 điểm trước sẽ dành chiến thắng. Khi tỷ số loạt tie-break là 6-6, áp dụng quy tắc 2 điểm lợi thế để xác định người giành chiến thắng.

### Thắng hiệp đấu, thắng trận đấu tennis
- Để thắng một hiệp đấu (hay set đấu), một vận động viên phải giành chiến thắng ít nhất 6 game đấu.

- Trong trường hợp tỷ số game đấu trong set đấu là 5-5, một vận động viên dành chiến thắng nếu giành chiến thắng 2 game đấu tiếp theo, tỷ số sẽ là 7-5.

- Trong trường hợp tỷ số game đấu trong set đấu là 6-6, vận động viên dành chiến thắng nếu giành chiến thắng ở game tie-break. Loạt tie-break sẽ là game thứ 13 và vận động viên giành được 7 điểm trước sẽ dành chiến thắng.

- Đối với các giải đấu grand slam, hiệp đấu thứ 5 sẽ áp dụng loạt tie-break đặc biệt để xác định người giành chiến thắng, cụ thể:


# Demo



https://github.com/Dthai16gg/Tenis-Game/assets/88380128/da38ebd3-1889-4546-a571-f485267a1410

