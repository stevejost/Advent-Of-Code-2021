namespace Day4
{
    internal class BoardResult
    {
        public bool IsWinner { get; set; }
        public int NumMoves { get; set; }
        public int WinningMove { get; set; }

        public Board Board { get; set; }
    }
}