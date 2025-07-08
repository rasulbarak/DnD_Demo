using System.ComponentModel.Design;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using Microsoft.VisualBasic;

namespace classes3;

class Wizard
{
    // data members
    public string name;
    public int age;
    public string favSpell;
    public int health = 100;
    public int mana = 2;
    public float experience = 0;
    public bool alive = true;

    public static int Count = 0;

    // member functions
    public Wizard(string _name, int _age, string _favSpell)
    /*  
        This is our parametric constructor. No default constructor exists. This is the only one.
    */
    {
        name = _name;
        age = _age;
        favSpell = _favSpell;
        Count++;
    }

    public void castSpellAtOpp(Wizard opponent)
    /*
        Casts a spell on an opponent, decreases mana. Will decrease the health of the opponent if cast.
    */
    {
        if (alive == false)
        {
            Console.WriteLine("\nDead wizards can't cast spells!\nWizards can medidate to regenerate health.\n");
        }
        else if (mana == 0)
        {
            Console.WriteLine(name + " must medidate to regain mana!");
        }
        else if (opponent.alive == false)
        {
            Console.WriteLine(name + "is already dead!");
        }
        else    // wizard has both health and mana. can cast
        {
            Console.WriteLine(name + " casts " + favSpell + " at " + opponent.name + ".");
            experience += 0.3f;
            mana--;
            opponent.health -= 20;
            checkHealth(opponent);
        }

    }

    public void checkHealth(Wizard opponent)
    // checks health of the Wizard that has taken damage
    {
        if (opponent.health <= 0)
        {
            Console.WriteLine(opponent.name + " is dead.");
            opponent.alive = false;
        }
    }

    public void meditate(int hours = 1)
    /*
        Meditation adds to mana, depending on hours meditated.
    */
    {
        if (alive == false)
        {
            alive = true;   // wizard might be dead, make them alive
            health = 100;
            Console.WriteLine(name + " is now alive.");
        }

        switch (hours)
        {
            case 1:
                mana += 1;
                break;
            case 2:
                mana += 2;
                break;
            case 3:
                mana += 3;
                break;
            case 4:
                mana += 4;
                break;
            case 5:
                mana += 5;
                break;
            case > 5:
                // if hours is greater than 5
                mana += 6;
                break;
        }
        // cap mana at 10;
        if (mana > 10)
        {
            mana = 10;
        }
        Console.WriteLine(name + " has added " + hours + " to their mana.");
    }

}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to our DnD Game!.\nPress enter to continue.");
        Console.ReadLine();

        Console.WriteLine("How many players will there be? ");
        int playerNum = Convert.ToInt32(Console.ReadLine());

        // create one wizard per player
        Wizard[] players = new Wizard[playerNum];   // will hold characters in the game
        string wizardName;  // user will choose thier name for their character
        int wizardAge;
        string wizardSpell;
        for (int i = 0; i < playerNum; i++)
        {
            Console.Write("\nWhat will be your Wizard's name player " + (i + 1) + ": ");
            wizardName = Console.ReadLine();

            Console.Write("How old is your wizard: ");
            wizardAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("And what is your chosen spell: ");
            wizardSpell = Console.ReadLine();

            players[i] = new Wizard(wizardName, wizardAge, wizardSpell);
        }

        printInfo(players);

        // start the game
        // flip the coin to see who starts
        Random numberGen = new Random();
        int playerTurn = numberGen.Next(0, players.Length);
        Console.WriteLine(players[playerTurn].name + " will start.");

        Console.WriteLine("1. Cast Spell");
        Console.WriteLine("2. Medidate");
        Console.WriteLine("3. Skip Turn");
        Console.WriteLine("At any point, enter 0 to quit.");
        int choice = Convert.ToInt32(Console.ReadLine());
        Wizard currPlayer;

        while (choice != 0)
        {
            currPlayer = players[playerTurn];
            if (choice == 1)
            // player has chosen to cast a spell
            {
                Console.WriteLine(currPlayer.name + " has chosen to cast " + currPlayer.favSpell + ".");
            }
            else if (choice == 2)
            // player has chosen to medidate
            {
                Console.WriteLine(players[playerTurn].name + " has chosen to meditate.");
            }
            else if (choice == 3)
            // player has chosen to skip their turn
            {
                Console.WriteLine(players[playerTurn].name + " has chosen to skip their turn.");
            }
            else
            {
                choice = 0;
                continue;
            }
            // go to next player
            playerTurn = (playerTurn + 1) % players.Length;
            Console.WriteLine("Its now " + players[playerTurn].name + "'s turn.");
            Console.WriteLine("1. Cast Spell");
            Console.WriteLine("2. Medidate");
            Console.WriteLine("3. Skip Turn");
            // ask for options
            choice = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("\nThank you for playing!");
    }

    static void printInfo(Wizard[] players)
    /*
        Print info of all wizards.
    */
    {
        string name;
        int health;
        int mana;
        float experience;
        string condition = "Alive"; // assume alive
        for (int i = 0; i < players.Length; i++)
        {
            name = players[i].name;
            health = players[i].health;
            mana = players[i].mana;
            experience = players[i].experience;
            if (!players[i].alive)
            {
                condition = "Dead"; // assign dead if dead
            }
            Console.WriteLine("------------------");
            Console.WriteLine("Player: " + name);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Mana: " + mana);
            Console.WriteLine("Experience: " + experience);
            Console.WriteLine("Condition: " + condition);
        }
        Console.WriteLine("------------------");
    }
}
