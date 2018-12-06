using System;

namespace MineSweeper
{
    public class Model : GameRules, IModel
    {
        private readonly IController _controller;

        public Model(IController controller)
        {
            _controller = controller;
        }

        public void LoadGame(string level)
        {
            CreateRules(level);
            CreateMap();
            AddBombs();
            AddNumbers();
        }

        private void CreateRules(string level)
        {
            MapBounds = (int)(GameLevel)Enum.Parse(typeof(GameLevel), level);
            BombsCount = MapBounds * MapBounds / 10;
            FlagsCount = BombsCount;

            _controller.FlagsChanged(FlagsCount);
        }

        private void CreateMap()
        {
            GameButtons = new CustomizedButton[MapBounds, MapBounds];

            for (var i = 0; i < GameButtons.GetLength(0); i++)
            {
                for (var j = 0; j < GameButtons.GetLength(1); j++)
                {
                    GameButtons[i, j] = new CustomizedButton
                    {
                        IsVisited = false
                    };
                    GameButtons[i, j].SetBounds((i + 1) * ButtonSize, (j + 1) * ButtonSize, ButtonSize, ButtonSize);
                }
            }

            _controller.AddMapButton(GameButtons);
        }

        private void AddBombs()
        {
            var rand = new Random();

            for (var i = 0; i < BombsCount; i++)
            {
                var numX = rand.Next(1, GameButtons.GetLength(0));
                var numY = rand.Next(1, GameButtons.GetLength(1));
                
                if (GameButtons[numX, numY].Value == "BOMB")
                {
                    i--;
                    continue;
                }

                GameButtons[numX, numY].Value = "BOMB";
            }
        }

        private void AddNumbers()
        {
            for (var i = 0; i < MapBounds; i++)
            {
                for (var j = 0; j < MapBounds; j++)
                {
                    if (GameButtons[i, j].Value == "BOMB") continue;

                    var bombsArround = GetNeighboursMineCount(i, j);

                    GameButtons[i, j].Value = bombsArround.ToString();
                }
            }
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
                _controller.FlagsChanged(++FlagsCount);

                if (button.Value == "BOMB")
                    BombsCount++;

            }
            else
            {
                button.Text = @"X";
                _controller.FlagsChanged(--FlagsCount);

                if (button.Value == "BOMB")
                    BombsCount--;
            }

            CheckIfWin();
        }

        private void CheckIfWin()
        {
            if (BombsCount == 0)
                _controller.GameWin();
        }

        private void ProcessBomb(CustomizedButton button)
        {
            button.Text = @"B";
            button.Enabled = false;

            ShowBombs();

            _controller.GameOver();
        }

        private void ProcessSafeButton(CustomizedButton button)
        {
            var x = button.Location.X / ButtonSize - 1;
            var y = button.Location.Y / ButtonSize - 1;

            button.Text = button.Value;
            button.Enabled = false;
            button.IsVisited = true;

            if (button.Value == "0")
                OpenEmptyNeighbours(x, y);
        }
    }
}
