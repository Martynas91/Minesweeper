namespace MineSweeper
{
    public interface IModel
    {
        void LoadGame(string level);
        void ProcessLeftClick(CustomizedButton button);
        void ProcessRightClick(CustomizedButton button);
    }
}
