namespace LINQ_Practice;
public class Player
{
    public string Name { set; get; }
    public int age { set; get; }

    public Player(string Name, int age)
    {
        this.Name = Name;
        this.age = age;
    }
    public Player(string Name)
    {
        this.Name = Name;
    }
    public Player() { }
    public void Display()
    {
        Console.WriteLine(Name);
    }
}