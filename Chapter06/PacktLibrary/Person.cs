﻿namespace Packt.Shared;

public class Person : IComparable<Person?>
{
    #region Properties

    public string? Name { get; set; }
    public DateTimeOffset Born { get; set; }
    public List<Person> Children = new();

    // Allow multiple spouses to be stored for a person
    public List<Person> Spouses = new();

    // read-only property
    public bool Married => Spouses.Count > 0;

    #endregion
    #region Operators

    // Define + operator to "marry"
    public static bool operator +(Person p1, Person p2)
    {
        Marry(p1, p2);

        // Confirm both are now married
        return p1.Married && p2.Married;
    }

    // Define * operator to "multiply"
    public static Person operator *(Person p1, Person p2)
    {
        // Return a ref to the baby that results from multiply
        return Procreate(p1, p2);
    }

    #endregion
    #region Methods

    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {Born:dddd}.");
    }

    public void WriteChildrenToConsole()
    {
        string term = Children.Count == 1 ? "child" : "children";
        WriteLine($"{Name} has {Children.Count} {term}.");
    }

    // static method to marry two people
    public static void Marry(Person p1, Person p2)
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p2);

        if (p1.Spouses.Contains(p2) || p2.Spouses.Contains(p1))
        {
            throw new ArgumentException(
                string.Format("{0} is already married to {1}.",
                arg0: p1.Name, arg1: p2.Name));
        }
        p1.Spouses.Add(p2);
        p2.Spouses.Add(p1);
    }

    // Instance method to marry another person
    public void Marry(Person partner)
    {
        Marry(this, partner);
    }

    public void OutputSpouses()
    {
        if (Married)
        {
            string term = Spouses.Count == 1 ? "person" : "people";
            WriteLine($"{Name} is married to {Spouses.Count} {term}:");
            foreach (Person spouse in Spouses)
            {
                WriteLine($"  {spouse.Name}");
            }
        }
        else
        {
            WriteLine($"{Name} is a singleton.");
        }
    }

    /// <summary>
    /// Static method to "multiply" aka procreate and have a child together.
    /// </summary>
    /// <param name="p1">Parent 1</param>
    /// <param name="p2">Parent 2</param>
    /// <returns>A Person object that is the child of Parent 1 and parent2.</returns>
    /// <exception cref="ArgumentNullException">If p1 or p2 are null.</exception>
    /// <exception cref="ArgumentException">If p1 and p2 are not married.</exception> 
    public static Person Procreate(Person p1, Person p2)
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p2);

        if (!p1.Spouses.Contains(p2) && !p2.Spouses.Contains(p1))
        {
            throw new ArgumentException(string.Format(
                "{0} must be married to {1} to procreate with them.",
                arg0: p1.Name, arg1: p2.Name));
        }

        Person baby = new()
        {
            Name = $"Baby of {p1.Name} and {p2.Name}",
            Born = DateTimeOffset.Now
        };

        p1.Children.Add(baby);
        p2.Children.Add(baby);

        return baby;
    }

    // Instance method to "multiply"
    public Person ProcreateWith(Person partner)
    {
        return Procreate(this, partner);
    }

    #endregion
    #region Overridden methods

    public override string ToString()
    {
        return $"{Name} is a {base.ToString()}.";
    }

    #endregion
    #region Delegates

    // DeLagte field to define event
    public event EventHandler? Shout;

    // Data field for event
    public int AngerLevel;

    // Method to trigger event under certain conditions
    public void Poke()
    {
        AngerLevel++;

        if (AngerLevel < 3) return;

        // If something is listening to the event
        if (Shout is not null)
        {
            Shout(this, EventArgs.Empty);
        }
        // C# 6 and later can be simplified to:
        // Shout?.Invoke(this, EventArgs.Empty);
    }

    public int CompareTo(Person? other)
    {
        int position;

        if (other is not null)
        {
            if ((Name is not null) && (other.Name is not null))
            {
                // If both values are not null, use string implemenation of CompareTo
                position = Name.CompareTo(other.Name);
            }
            else if ((Name is not null) && (other.Name is null))
            {
                // This person preceded other person
                position = -1;
            }
            else if ((Name is null) && (other.Name is not null))
            {
                // This person follows other person
                position = 1;
            }
            else
            {
                // This person and other are same position
                position = 0;
            }
        }
        else if (other is null)
        {
            // This person preceded other person
            position = -1;
        }
        else
        {
            // This and other are same position
            position = 0;
        }
        return position;
    }

    #endregion
}
