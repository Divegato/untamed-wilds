using System;

namespace UntamedWilds.Server
{
    public class Game : IGame
    {
        public Game()
        {
            this.CurrentState = State.MainMenu;
        }

        public State CurrentState { get; private set; }
        public World World { get; private set; }

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
                        break;
                    case 2:
                        this.World.ActiveCivilization = new Civilization();
                        break;
                    case 3:
                        this.World.ActiveCivilization.Settlement = new Settlement();
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

        public void New()
        {
            this.World = new World();
        }

        public World GetWorld()
        {
            return this.World;
        }
    }
}
