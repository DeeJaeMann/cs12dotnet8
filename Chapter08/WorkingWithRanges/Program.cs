string name = "Samantha Jones";

// Get lengths of first and last names
int lengthOfFirst = name.IndexOf(' ');
int lengthOfLast = name.Length - lengthOfFirst - 1;

// Using substring
// creates copy
string firstName = name.Substring(startIndex: 0, length: lengthOfFirst);

string lastName = name.Substring(startIndex: name.Length - lengthOfLast, length: lengthOfLast);

WriteLine($"First: {firstName}, Last: {lastName}");

// Using spans
ReadOnlySpan<char> nameAsSpan = name.AsSpan();
ReadOnlySpan<char> firstNameSpan = nameAsSpan[0..lengthOfFirst]; // From 0 to lengthOfFirst
ReadOnlySpan<char> lastNameSpan = nameAsSpan[^lengthOfLast..]; // From end to end

WriteLine($"First: {firstNameSpan}, Last: {lastNameSpan}");