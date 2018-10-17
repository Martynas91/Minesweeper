using System.Windows.Forms;

namespace MineSweeper
{
    public class CustomizedButton : Button
    {
        public bool IsVisited { get; set; }
        public string Value { get; set; }
    }
}
