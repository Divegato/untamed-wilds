using System;

namespace UntamedWilds.Server
{
    public class Game
    {
        public Game()
        {
            this.CurrentState = State.MainMenu;
        }

        public State CurrentState { get; set; }
        public World World { get; set; }

        public Menu GetCurrentMenu()
        {
            Menu menu = new Menu();

            switch (this.CurrentState)
            {
                case State.MainMenu:
                    menu.Options.Add(new Menu.Option("Create New World", 1));
                    menu.Options.Add(new Menu.Option("Start New Civilization", 2));
                    menu.Options.Add(new Menu.Option("Start New Settlement", 3));
                    break;
                default:
                    break;
            }

            return menu;
        }

        public void ExecuteCommand(int number)
        {
            if (this.CurrentState == State.MainMenu)
            {
                switch (number)
                {
                    case 1:
                        this.World = new World();
                        this.World.Civilization = new Civilization();
                        this.World.Civilization.Settlement = new Settlement();
                        break;
                    case 2:
                        this.World.Civilization = new Civilization();
                        this.World.Civilization.Settlement = new Settlement();
                        break;
                    case 3:
                        this.World.Civilization.Settlement = new Settlement();
                        break;
                    default:
                        throw new InvalidCommandException();
                }
            }
        }
        
        public enum State
        {
            MainMenu
        }
    }
}
