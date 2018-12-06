namespace MineSweeper
{
    public abstract class GameRules
    {
        public int MapBounds { get; set; }
        public int BombsCount { get; set; }
        public int FlagsCount { get; set; }
        public int ButtonSize = 25;

        public CustomizedButton[,] GameButtons { get; set; }

        public void OpenEmptyNeighbours(int x, int y)
        {
            for (var i = x - 1; i <= x + 1; i++)
            {
                if (i < 0 || i >= MapBounds)
                    continue;

                for (var j = y - 1; j <= y + 1; j++)
                {
                    if (j < 0 || j >= MapBounds)
                        continue;

                    if (i == x && j == y)
                        continue;

                    if (GameButtons[i, j].IsVisited)
                        continue;

                    if (GameButtons[i, j].Value == "0")
                    {
                        GameButtons[i, j].Text = @"0";
                        GameButtons[i, j].Enabled = false;
                        GameButtons[i, j].IsVisited = true;

                        OpenEmptyNeighbours(i, j);
                    }

                    else if (GameButtons[i, j].Value != "BOMB")
                    {
                        GameButtons[i, j].Text = GameButtons[i, j].Value;
                        GameButtons[i, j].Enabled = false;
                        GameButtons[i, j].IsVisited = true;
                    }
                }
            }
        }

        public int GetNeighboursMineCount(int x, int y)
        {
            var bombsCount = 0;
            for (var i = x - 1; i <= x + 1; i++)
            {
                if (i < 0 || i >= MapBounds)
                    continue;

                for (var j = y - 1; j <= y + 1; j++)
                {
                    if (j < 0 || j >= MapBounds)
                        continue;

                    if (i == x && j == y)
                        continue;

                    if (GameButtons[i, j].Value == "BOMB")
                        bombsCount += 1;
                }
            }
            return bombsCount;
        }

        public void ShowBombs()
        {
            foreach (var item in GameButtons)
            {
                if (!item.Enabled || item.Value != "BOMB") continue;
                item.Text = @"B";
                item.Enabled = false;
            }
        }
    }
}
