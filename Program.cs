using System.Runtime.Intrinsics.X86;

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

    // member functions
    public Wizard(string _name, int _age, string _favSpell)
    /*  
        This is our parametric constructor. No default constructor exists. This is the only one.
    */
    {
        name = _name;
        age = _age;
        favSpell = _favSpell;
    }

    public void castSpellAtOpp(Wizard opponent)
    /*
        Casts a spell on an opponent if given. Will decrease the health of the opponent.
    */
    {
        Console.WriteLine(name + " casts " + favSpell + " at " + opponent.name + ".");
        experience += 0.3f;
        opponent.health -= 20;
        checkHealth(opponent);
    }

    public void checkHealth(Wizard opponent)
    // checks health of the Wizard that has taken damage
    {
        
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
