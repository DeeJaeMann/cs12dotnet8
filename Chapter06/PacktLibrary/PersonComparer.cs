namespace Packt.Shared;

public class PersonComparer : IComparer<Person?>
{
    public int Compare(Person? x, Person? y)
    {
        int position;

        // Check object first
        if((x is not null) && (y is not null))
        {
            // Check Name
            if((x.Name is not null) && (y.Name is not null))
            {
                // compare name lengths
                int result = x.Name.Length.CompareTo(y.Name.Length);

                if (result == 0)
                {
                    // compare by names
                    return x.Name.CompareTo(y.Name);
                }
                else
                {
                    // compare by length
                    position = result;
                }
            }
            else if ((x.Name is not null) && (y.Name is null))
            {
                // x precedes y
                position = -1;
            }
            else if ((x.Name is null) && (y.Name is not null))
            {
                // x follows y
                position = 1;
            }
            else
            {
                // x and y are at same position
                position = 0;
            } // End Name check
        }
        else if ((x is not null) && (y is null))
        {
            // x precedes y
            position = -1;
        }
        else if ((x is null) && (y is not null))
        {
            // x follows y
            position = 1;
        }
        else
        {
            // x and y are same position
            position = 0;
        } // End object check
        return position;
    }
}