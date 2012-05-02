using System;
using System.Windows.Forms;
using UntamedWilds.Server;

namespace UntamedWilds.FormsClient
{
    public partial class FormClient : Form
    {
        private Game Game;

        public FormClient()
        {
            InitializeComponent();
            Game = new Game();
        }

        private void Render()
        {
            RenderMenu(this.Game.GetCurrentMenu());
        }

        private void RenderMenu(UntamedWilds.Server.Menu menu)
        {
            this.menuStrip.Items.Clear();

            foreach (UntamedWilds.Server.Menu.Option option in menu.Options)
            {
                MenuItem menuItem = new MenuItem(option.Text);
                menuItem.Tag = option.Value;
                menuItem.Click += new EventHandler(menuItem_Click);
            }
        }

        public void menuItem_Click(object sender, EventArgs e)
        {
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            Render();
        }
    }
}
