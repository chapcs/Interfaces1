using System.Runtime.CompilerServices;

interface INose
{
    int Ear();
    string Face { get; }
}

// this class works to provide read-only access to face and put that onto the lower classes as well
abstract class Picasso : INose
{
    private string face;
    public virtual string Face { get { return face;} }
    public abstract int Ear();
    public Picasso(string face)
    {
        this.face = face;
    }
}

class Clowns : Picasso
{
    public Clowns() : base("Clowns") { } // calls base class constructor and passes a string
    public override int Ear()
    {
        return 7;
    }
}

class Acts : Picasso
{
    public Acts() : base("Acts") { }
    public override int Ear()
    {
        return 5;
    }
}

class Of2016 : Clowns 
{
    public override string Face { get { return "Of2016"; } } // overrides the property because it cannot call Picasso constructor like the other two classes, we implement clowns because of the same Ear()
    private static void Main(string[] args)
    {
        string result = "";
        INose[] i = new INose[3]; //discussed below
        i[0] = new Acts();
        i[1] = new Clowns();
        i[2] = new Of2016();
        for (int x = 0; x < 3; x++)
        {
            result += $"{i[x].Ear()} {i[x].Face}\n";
        }
        Console.WriteLine(result);
        Console.ReadKey();
    }
}
/*Regarding Line 31 (INose[] i = new INose[3];), you are correct that interfaces cannot be directly instantiated. 
 * However, an array of interface references can be created. It means you are creating an array of INose interface references, 
 * and each element in the array can hold an object of a class that implements the INose interface. So, in the loop at the end, 
 * you can call the Ear() and Face properties on the objects stored in the array, and the appropriate implementations in the derived classes will be executed. */