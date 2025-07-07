using System.Runtime.Intrinsics.X86;

namespace classes3;

class Wizard
{
    // data members
    public string name;
    public int age;
    public string favSpell;
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
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
