using System;

namespace MineSweeper
{
    public interface IController
    {
        void LoadGame(string level);
        void ButtonClicked(object sender, EventArgs args);

        void GameWin();
        void GameOver();
        void FlagsChanged(int flagsCount);
        void AddMapButton(CustomizedButton[,] control);
    }
}
