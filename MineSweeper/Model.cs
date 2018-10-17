using System;
using System.Windows.Forms;

namespace MineSweeper
{
    public class Model : IModel
    {
        public EventHandler<FlagsEventHandler> OnFlagsChange;
        public EventHandler<Control> OnAddMapButton;
        public EventHandler<EventArgs> OnWin;
        public EventHandler<EventArgs> OnGameOver;

        private CustomizedButton[,] _gameButtons;
        private int _mapBounds;
        private int _bombsCount;
        private int _flagsCount;
        private const int ButtonSize = 25;

        public void LoadGame(string level)
        {
            _mapBounds = (int)(GameLevel)Enum.Parse(typeof(GameLevel), level);
            _bombsCount = (_mapBounds * _mapBounds) / 10;
            _flagsCount = _bombsCount;

            OnFlagsChange?.Invoke(this, new FlagsEventHandler() {FlagsCount = _flagsCount });

            CreateMap();
            AddBombs();
            AddNumbers();
        }

        private void CreateMap()
        {
            _gameButtons = new CustomizedButton[_mapBounds, _mapBounds];

            for (var i = 0; i < _gameButtons.GetLength(0); i++)
            {
                for (var j = 0; j < _gameButtons.GetLength(1); j++)
                {
                    _gameButtons[i, j] = new CustomizedButton()
                    {
                        IsVisited = false
                    };
                    _gameButtons[i, j].SetBounds((i + 1) * ButtonSize, (j + 1) * ButtonSize, ButtonSize, ButtonSize);

                    OnAddMapButton?.Invoke(this, _gameButtons[i, j]);
                }
            }
        }

        private void AddBombs()
        {
            var rand = new Random();

            for (var i = 0; i < _bombsCount; i++)
            {
                var numX = rand.Next(1, _gameButtons.GetLength(0));
                var numY = rand.Next(1, _gameButtons.GetLength(1));
                
                if (_gameButtons[numX, numY].Value == "BOMB")
                {
                    i--;
                    continue;
                }

                _gameButtons[numX, numY].Value = "BOMB";
            }
        }

        private void AddNumbers()
        {
            for (var i = 0; i < _mapBounds; i++)
            {
                for (var j = 0; j < _mapBounds; j++)
                {
                    if (_gameButtons[i, j].Value == "BOMB") continue;

                    var bombsArround = GeteighboursMineCount(i, j);

                    _gameButtons[i, j].Value = bombsArround.ToString();
                }
            }
        }

        private int GeteighboursMineCount(int x, int y)
        {
            var bombsCount = 0;
            for (var i = x - 1; i <= x + 1; i++)
            {
                if (i < 0 || i >= _mapBounds)
                    continue; 

                for (var j = y - 1; j <= y + 1; j++)
                {
                    if (j < 0 || j >= _mapBounds)
                        continue;

                    if (i == x && j == y)
                        continue;

                    if (_gameButtons[i, j].Value == "BOMB")
                        bombsCount += 1;
                }
            }
            return bombsCount;
        }

        public void ProcessLeftClick(CustomizedButton button)
        {
            if (button.Value == "BOMB")
            {
                ProcessBomb(button);
            }
            else
            {
                ProcessSafeButton(button);
            }

            CheckIfWin();
        }

        public void ProcessRightClick(CustomizedButton button)
        {
            if (button.Text == @"X")
            {
                button.Text = "";
                OnFlagsChange?.Invoke(this, new FlagsEventHandler() {FlagsCount = ++_flagsCount});

                if (button.Value == "BOMB")
                    _bombsCount++;

            }
            else
            {
                button.Text = @"X";
                OnFlagsChange?.Invoke(this, new FlagsEventHandler() { FlagsCount = --_flagsCount });

                if (button.Value == "BOMB")
                    _bombsCount--;
            }

            CheckIfWin();
        }

        private void CheckIfWin()
        {
            if (_bombsCount == 0)
                OnWin?.Invoke(this, EventArgs.Empty);
        }

        private void ProcessBomb(CustomizedButton button)
        {
            button.Text = @"B";
            button.Enabled = false;

            ShowBombs();

            OnGameOver?.Invoke(this, EventArgs.Empty);
        }

        private void ProcessSafeButton(CustomizedButton button)
        {
            var x = button.Location.X / ButtonSize - 1;
            var y = button.Location.Y / ButtonSize - 1;

            button.Text = button.Value;
            button.Enabled = false;
            button.IsVisited = true;

            if (button.Value == "0")
                OpenEmptyeighbours(x, y);
        }

        private void ShowBombs()
        {
            foreach (var item in _gameButtons)
            {
                if (!item.Enabled || item.Value != "BOMB") continue;
                item.Text = @"B";
                item.Enabled = false;
            }
        }

        private void OpenEmptyeighbours(int x, int y)
        {
            for (var i = x - 1; i <= x + 1; i++)
            {
                if (i < 0 || i >= _mapBounds)
                    continue; 

                for (var j = y - 1; j <= y + 1; j++)
                {
                    if (j < 0 || j >= _mapBounds)
                        continue;

                    if (i == x && j == y)
                        continue;

                    if (_gameButtons[i, j].IsVisited)
                        continue;

                    if (_gameButtons[i, j].Value == "0")
                    {
                        _gameButtons[i, j].Text = @"0";
                        _gameButtons[i, j].Enabled = false;
                        _gameButtons[i, j].IsVisited = true;

                        OpenEmptyeighbours(i, j);
                    }

                    else if (_gameButtons[i, j].Value != "BOMB")
                    {
                        _gameButtons[i, j].Text = _gameButtons[i, j].Value;
                        _gameButtons[i, j].Enabled = false;
                        _gameButtons[i, j].IsVisited = true;
                    }
                }
            }
        }
    }
}
