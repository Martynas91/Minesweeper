namespace MineSweeper
{
    public class Presenter
    {
        private readonly IModel _model;

        public Presenter(IModel model)
        {
            _model = model;
        }

        public void LoadGame(string level)
        {
            _model.LoadGame(level);       
        }

        public void LeftButtonClicked(CustomizedButton button)
        {
            _model.ProcessLeftClick(button);
        }

        public void RightButtonClicked(CustomizedButton button)
        {
            _model.ProcessRightClick(button);
        }
    }
}
