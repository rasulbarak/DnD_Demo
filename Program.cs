using System.ComponentModel.Design;
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
        if (mana != 0)
        {
            Console.WriteLine(name + " casts " + favSpell + " at " + opponent.name + ".");
            experience += 0.3f;
            mana--;
            opponent.health -= 20;
            checkHealth(opponent);
        }
        else
        {
            Console.WriteLine(name + " must medidate to regain mana!");
        }
    }

    public void checkHealth(Wizard opponent)
    // checks health of the Wizard that has taken damage
    {
        if (opponent.health <= 0)
        {
            Console.WriteLine("\n" + opponent.name + " is dead.\nWizards can meditate to regenerate health.");
            opponent.alive = false;
        }
    }

    public void meditate()
    /*
        Meditation adds to mana as well as health (if less than full)
    */
    {
        
    }

}

class Program
{
    static void Main(string[] args)
    {
        Wizard wizard1 = new Wizard("Jacquine", 123, "Expertomo Topeno");
        Wizard wizard2 = new Wizard("Potter Parry", 19, "Hocus Pocus");

        wizard1.castSpellAtOpp(wizard2);
        wizard1.castSpellAtOpp(wizard2);
        wizard1.castSpellAtOpp(wizard2);
        wizard1.castSpellAtOpp(wizard2);
        wizard1.castSpellAtOpp(wizard2);
    }
}
