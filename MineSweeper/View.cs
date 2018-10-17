using System;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class View : Form
    {
        private readonly Presenter _presenter;
        private readonly Model _model;


        public View()
        {
            _model = new Model();
            _presenter = new Presenter(_model);
            SubscribeToModelEvents();

            Start();
        }

        private void SubscribeToModelEvents()
        {
            _model.OnFlagsChange += FlagsChanged;
            _model.OnAddMapButton += AddMapButton;
            _model.OnGameOver += GameOver;
            _model.OnWin += GameWin;
        }

        private void Start()
        {
            InitializeComponent();
        }

        private void FlagsChanged(object sender, FlagsEventHandler e)
        {
            lblFlags.Text = e.FlagsCount.ToString();
        }

        private void AddMapButton(object sender, Control e)
        {
            e.MouseDown += OnButtonClick;
            Controls.Add(e);
            ResumeLayout();
        }

        private void OnButtonClick(object sender, EventArgs args)
        {
            var button = sender as CustomizedButton;
            if (button == null) return;

            MouseEventArgs e = (MouseEventArgs)args;

            if (e.Button == MouseButtons.Left)
                _presenter.LeftButtonClicked(button);

            else if (e.Button == MouseButtons.Right)
            {
                _presenter.RightButtonClicked(button);
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            _presenter.LoadGame(cbLevel.Text);
        }

        public void GameWin(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(@"Congratulations!", @"Play one more time?", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Controls.Clear();
                Start();
            }
            else
            {
                Close();
            }
        }

        public void GameOver(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(@"Game Over", @"Retry?", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Controls.Clear();
                Start();
            }
            else
            {
                Close();
            }
        }

    }
}
