using ConsoleApp1;

TestValues test = new TestValues();
test.list = new List<int> { 1, 2, 3, 4, 5 };

Console.WriteLine("\nUsing simple methods");

bool LargerThanThree(int value)
{
    return (value > 3);
}

var filteredList = test.filter(LargerThanThree);

foreach (int value in filteredList)
{
    Console.WriteLine(value);
}

Console.WriteLine("\nUsing anonymous methods");

FilterDelegate largerThanThree = delegate(int value)
{
    return (value > 3);
};

filteredList = test.filter(largerThanThree);

foreach (int value in filteredList)
{
    Console.WriteLine(value);
}

Console.WriteLine("\nUsing lambda expressions");

FilterDelegate largerThanThreeAlt = value => (value > 3);

filteredList = test.filter(largerThanThreeAlt);

foreach (int value in filteredList)
{
    Console.WriteLine(value);
}

Console.WriteLine("\nUsing collection extension methods");

Console.WriteLine($"maximum value obtained via extension method: {test.GetMax()}");

Console.WriteLine("\nUsing select/where operations");

Console.WriteLine("Filtering values larger than 3 via WHERE");
var newFilteredList = test.list.Where(x => x > 3);

foreach (int value in newFilteredList)
{
    Console.WriteLine(value);
}

Console.WriteLine("Doubling a list via SELECT");

var doubledList = test.list.Select(x => 2 * x);

foreach (int value in doubledList)
{
    Console.WriteLine(value);
}

Console.WriteLine("\nGetting elems larger than 3, but using query syntax");

newFilteredList = from value in test.list
                  where value > 3
                  select value;

foreach (int value in newFilteredList)
{
    Console.WriteLine(value);
}