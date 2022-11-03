using System.Text.RegularExpressions;

namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputLines = File.ReadAllLines("input.txt");

            var boards = new List<Board>();

            var inputSequence = inputLines[0];
            var moveList = inputSequence.Split(',').Select(s => int.Parse(s)).ToList();

            for(int i=2; i<inputLines.Count(); i=i+6)
            {
                var board = new Board();
                
                for(int j=0;j<5; j++)
                {
                    //var boardLine = inputLines[i+j].Split(' ').Select(s=> int.Parse(s)).ToArray();
                    var boardLine = ParseLine(inputLines[i + j]);
                    for(int k=0; k<5; k++)
                    {
                        board.BoardSpaces[j, k] = boardLine[k];
                    }
                }
                boards.Add(board);
            }

            //            var results = boards.Select(b =>GetBoardResult(b, moveList));
            List<BoardResult> results = new List<BoardResult>();
            foreach(var board in boards)
            {
                var result = GetBoardResult(board, moveList);
                results.Add(result);
            }

            var winner = results.Where(r => r.IsWinner).OrderBy(r => r.NumMoves).First();
            var lastWinner = results.Where(r => r.IsWinner).OrderByDescending(r => r.NumMoves).First();
            var winningScore = ScoreWinner(winner);
            var lastWinningScore = ScoreWinner(lastWinner);
            
            Console.WriteLine($"Winner is {winningScore} with {winner.NumMoves} moves");
            Console.WriteLine($"Last Winner is {lastWinningScore} with {lastWinner.NumMoves} moves");


            Console.WriteLine("All Boards Read");
            Console.ReadLine();
        }

        private static int ScoreWinner(BoardResult winner)
        {
            int unmarkedSum = 0;
            for(int i= 0;i<5;i++) { 
                for(int j=0; j<5; j++)
                {
                    if(!winner.Board.BoardState[i,j])
                    {
                        unmarkedSum += winner.Board.BoardSpaces[i, j];
                    }
                }
            }

            return unmarkedSum* winner.WinningMove;

        }

        static BoardResult GetBoardResult(Board board, List<int> moveSeq)
        {
            var boardResult = new BoardResult();
            boardResult.Board = board;
            // setup the board state
            for (int i = 0; i < moveSeq.Count(); i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for(int k=0; k<5; k++)
                    {
                        if (board.BoardSpaces[j, k] == moveSeq[i])
                        {
                            board.BoardState[j, k] = true;                            
                        }
                    }

                    // check for row winners
                    board.RowState[j] = board.BoardState[j, 0] && board.BoardState[j, 1] && board.BoardState[j, 2] && board.BoardState[j, 3] && board.BoardState[j, 4];
                    if (board.RowState[j])
                    {
                        boardResult.IsWinner = true;
                        boardResult.NumMoves = i;
                        boardResult.WinningMove = moveSeq[i];
                        return boardResult;
                    }
                }

                // check for col winners
                for(int c = 0; c<5; c++)
                {
                    board.ColState[c] = board.BoardState[0, c] && board.BoardState[1, c] && board.BoardState[2, c] && board.BoardState[3, c] && board.BoardState[4, c];
                    if (board.ColState[c])
                    {
                        boardResult.IsWinner = true;
                        boardResult.NumMoves = i;
                        boardResult.WinningMove = moveSeq[i];
                        return boardResult;
                    }
                }

                
            }

            

            
            return boardResult;
        }        

        static int[] ParseLine(string line)
        {
            var digitRegex = new Regex("\\d+");

            var matches = digitRegex.Matches(line).Select(m=>m.Value).Select(v=>int.Parse(v)).ToArray();
            return matches;
        }
    }
}