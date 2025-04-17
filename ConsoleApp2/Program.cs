using ConsoleApp2.Entities;

var users = new List<User>
        {
            new User { Id = 1, Name = "Alice" },
            new User { Id = 2, Name = "Bob" },
            new User { Id = 3, Name = "Charlie" }
        };

var orders = new List<Order>
        {
            new Order { Id = 1, UserId = 1, Product = "Laptop", Amount = 1 },
            new Order { Id = 2, UserId = 2, Product = "Phone", Amount = 2 },
            new Order { Id = 3, UserId = 1, Product = "Mouse", Amount = 1 },
            new Order { Id = 4, UserId = 3, Product = "Keyboard", Amount = 5 }
        };


void JoinMethod()
{
    var result = users.Join(orders,
        users => users.Id,
        orders => orders.UserId,
        (users, orders) => new { UserName = users.Name, OrderProduct = orders.Product, 
            OrderAmount = orders.Amount});

    foreach (var entry in result)
    {
        Console.WriteLine($"{entry.UserName} bought {entry.OrderAmount} models of {entry.OrderProduct}");
    }
}

void GroupJoinMethod()
{
    var result = users.GroupJoin(orders,
        users => users.Id,
        orders => orders.UserId,
        (users, orders) => new {
            UserName = users.Name,
            OrderProduct = orders.Select(o => o.Product)
        });

    foreach (var entry in result)
    {
        Console.WriteLine($"{entry.UserName}: {String.Join(", ", entry.OrderProduct)}");
    }
}

void ZipMethod()
{
    var result = users.Zip(orders, (u, o) => $"{u.Name}: {o.Product}");

    foreach (var entry in result)
    {
        Console.WriteLine(entry);
    }
}

void GroupByMethod()
{
    var groupedOrders = orders
        .GroupBy(o => o.Product)
        .Select(x => new
        {
            Name = x.Key,
            Count = x.Count(),
        }).ToList();

    foreach (var group in groupedOrders)
    {
        Console.WriteLine(group);
    }
}

void SetOperations()
{
    List<int> list1 = new List<int> { 1, 1, 2, 3, 4 };
    List<int> list2 = new List<int> { 3, 4, 5, 6 };

    var concat = list1.Concat(list2).ToList();
    Console.WriteLine(String.Join(", ", concat));

    var union = list1.Union(list2).ToList();
    Console.WriteLine(String.Join(", ", union));

    var intersect = list1.Intersect(list2).ToList();
    Console.WriteLine(String.Join(", ", intersect));

    var except = list1.Except(list2).ToList();
    Console.WriteLine(String.Join(", ", except));
}

void AggregationMethods()
{
    var count = orders.Count();
    Console.WriteLine($"Orders count: {count}");

    var maxVal = orders.MaxBy(x => x.Amount);
    Console.WriteLine($"Most popular product: {maxVal.Product} with {maxVal.Amount}");

    var sumVal = orders.Sum(x => x.Amount);
    Console.WriteLine($"Total orders amount: {sumVal}");
}

void ElementOperators()
{
    var firstWithMoreThanOne = orders.First(x => x.Amount >= 2);
    Console.WriteLine($"First order with >= 2 amount: {firstWithMoreThanOne.Product}");

    var secondOrder = orders.ElementAt(1);
    Console.WriteLine($"Second order in the collecton: {secondOrder.Product}");
}

void GenerationMethods()
{
    var collectionOfOnes = Enumerable.Repeat(1, 5);

    Console.WriteLine(String.Join(", ", collectionOfOnes));
}