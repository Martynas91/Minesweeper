using System;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class View : Form, IView
    {
        private readonly IController _controller;

        public View()
        {
            _controller = new Controller(this);

            InitializeComponent();
        }

        private void Start(object sender, EventArgs e)
        {
            _controller.LoadGame(cbLevel.Text);
            btStart.Enabled = false;
            btResume.Enabled = true;
        }

        private void Resume(object sender, EventArgs e)
        {
            Controls.Clear();
            InitializeComponent();
        }

        private void Stop(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void FlagsChanged(int flagsCount)
        {
            lblFlags.Text = flagsCount.ToString();
        }

        public void AddMapButtons(CustomizedButton[,] controls)
        {
            foreach (var item in controls)
            {
                item.MouseDown += OnButtonClick;
                Controls.Add(item);
            }
        }

        private void OnButtonClick(object sender, EventArgs args)
        {
            _controller.ButtonClicked(sender, args);
        }

        public void GameWin()
        {
            var dialogResult = MessageBox.Show(@"Play one more time?", @"Congratulations!", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Controls.Clear();
                Resume(this, null);
            }
            else
            {
                Stop(this, null);
            }
        }

        public void GameOver()
        {
            var dialogResult = MessageBox.Show(@"Retry?", @"Game Over", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Controls.Clear();
                Resume(this, null);
            }
            else
            {
                Stop(this, null);
            }
        }
    }
}
