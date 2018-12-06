using System;
using System.Windows.Forms;

namespace MineSweeper
{
    public class Controller : IController
    {
        private readonly IView _view;
        private readonly IModel _model;

        public Controller(IView view)
        {
            _view = view;
            _model = new Model(this);
        }

        public void LoadGame(string level)
        {
            _model.LoadGame(level);
        }

        public void ButtonClicked(object sender, EventArgs args)
        {
            var button = sender as CustomizedButton;
            if (button == null) return;

            var e = (MouseEventArgs)args;

            if (e.Button == MouseButtons.Left)
                _model.ProcessLeftClick(button);

            else if (e.Button == MouseButtons.Right)
            {
                _model.ProcessRightClick(button);
            }
        }

        public void GameWin()
        {
            _view.GameWin();
        }

        public void GameOver()
        {
            _view.GameOver();
        }

        public void FlagsChanged(int flagsCount)
        {
            _view.FlagsChanged(flagsCount);
        }

        public void AddMapButton(CustomizedButton[,] control)
        {
            _view.AddMapButtons(control);
        }
    }
}
