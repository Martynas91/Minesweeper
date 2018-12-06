namespace MineSweeper
{
    public interface IView
    {
        void GameWin();
        void GameOver();
        void FlagsChanged(int flagsCount);
        void AddMapButtons(CustomizedButton[,] control);
    }
}
