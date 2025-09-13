# 1. What is LINQ in C#?



LINQ, which stands for **Language Integrated Query**, is a feature in C# that allows developers to **query and manipulate collections of data in a declarative, SQL-like syntax**. Instead of writing loops and conditional statements manually to filter, transform, or sort data, LINQ provides a concise and readable way to express these operations directly in code.

LINQ works with various data sources, including **arrays, lists, XML documents, databases (via Entity Framework), and even custom collections**, making it highly versatile. It supports standard operations like filtering (`Where`), projection (`Select`), ordering (`OrderBy`), grouping (`GroupBy`), and aggregation (`Sum`, `Count`), all with a consistent syntax.

**Why LINQ is useful:**
- **Readable and maintainable:** Queries are more expressive and closer to natural language or SQL, reducing complex nested loops.
- **Less error-prone:** Minimizes off-by-one errors or index mistakes that can happen in manual loops.
- **Consistent:** Same syntax works across different data sources (in-memory collections, databases, XML).
- **Chainable operations:** LINQ supports **method chaining**, allowing multiple transformations in a single statement.

**Example:**
```csharp
int[] numbers = {1, 2, 3, 4, 5};

// Filter even numbers using LINQ
var evenNumbers = numbers.Where(n => n % 2 == 0);

// Iterate and print results
foreach (var n in evenNumbers)
    Console.WriteLine(n); // 2, 4
```
# 2. What are the benefits of using LINQ?

LINQ provides **clean, readable, and maintainable code** by reducing boilerplate loops. It is **type-safe**, works with different data sources like arrays, lists, or databases, and integrates seamlessly with **Lambda expressions**. LINQ also supports **deferred execution**, meaning queries only run when the results are actually needed, which can improve performance.

# 3. What are the different types of LINQ in C#?

LINQ in C# comes in several flavors depending on the data source:

- **LINQ to Objects:** Querying in-memory collections like arrays or lists.
- **LINQ to SQL / LINQ to Entities:** Querying databases using SQL-like syntax.
- **LINQ to XML:** Querying and manipulating XML documents.
- **Parallel LINQ (PLINQ):** Querying collections in parallel to improve performance.

**Example (LINQ to Objects):**
```csharp
List<int> nums = new List<int> {1, 2, 3, 4};

// Filter numbers greater than 2
var result = nums.Where(n => n > 2);

foreach(var n in result)
    Console.WriteLine(n); // 3, 4
```
# 4. What is a Lambda expression?

A Lambda expression is an **inline anonymous function** used to define simple logic, often with LINQ. It uses the `=>` syntax, where the left side represents the parameter(s) and the right side represents the expression or code block.

**Example:**
```csharp
// Lambda with a Func delegate
Func<int, int> square = x => x * x;
Console.WriteLine(square(5)); // 25

// Lambda with LINQ
List<int> nums = new List<int> {1, 2, 3};
var evens = nums.Where(n => n % 2 == 0);

foreach(var n in evens)
    Console.WriteLine(n); // 2
```
# 5. What is the difference between query syntax and method syntax in LINQ?

LINQ provides two ways to write queries: **query syntax** and **method syntax**.

- **Query syntax** looks similar to SQL and is more declarative, which can be easier to read for complex queries.
- **Method syntax** uses **Lambda expressions** and extension methods, offering more flexibility and allowing chaining of multiple operations.

**Example:**
```csharp
int[] numbers = {1, 2, 3, 4};

// Query syntax
var evens1 = from n in numbers
             where n % 2 == 0
             select n;

// Method syntax
var evens2 = numbers.Where(n => n % 2 == 0);

// Output
foreach(var n in evens2)
    Console.WriteLine(n); // 2, 4
```

# 6. How do you filter, sort, and project data using LINQ?


LINQ provides powerful methods to **filter, sort, and transform data** in a clean, readable way.

- **Filtering:** Use the `Where()` method with a Lambda expression to select elements that meet a condition.
- **Sorting:** Use `OrderBy()` to sort in ascending order and `OrderByDescending()` to sort in descending order.
- **Projection:** Use `Select()` to transform data or extract specific fields into a new form, including anonymous types.

**Examples:**

```csharp
// Sample data
List<int> numbers = new List<int> {1, 2, 3, 4, 5};

// Filter numbers greater than 3
var greaterThan3 = numbers.Where(n => n > 3);
foreach (var n in greaterThan3)
    Console.WriteLine(n); // 4, 5

// Sort numbers
List<int> nums = new List<int> {3, 1, 4, 2};
var sortedAsc = nums.OrderBy(n => n);          // 1, 2, 3, 4
var sortedDesc = nums.OrderByDescending(n => n); // 4, 3, 2, 1

// Project data
List<string> names = new List<string> {"Alice", "Bob"};
var nameLengths = names.Select(n => n.Length);
foreach (var len in nameLengths)
    Console.WriteLine(len); // 5, 3

// Project into anonymous types
var nameInfo = names.Select(n => new { Name = n, Length = n.Length });
foreach (var info in nameInfo)
    Console.WriteLine($"Name: {info.Name}, Length: {info.Length}");
// Output:
// Name: Alice, Length: 5
// Name: Bob, Length: 3
```
# 7. What are First(), FirstOrDefault(), Single(), and SingleOrDefault() in LINQ?


These LINQ methods are used to retrieve **specific elements** from a collection based on a condition:

- **First():** Returns the **first element** that matches a condition. Throws an exception if no element is found.
- **FirstOrDefault():** Returns the **first element** matching a condition, or a **default value** (like `0` for integers or `null` for reference types) if none is found.
- **Single():** Returns **exactly one element** matching a condition. Throws an exception if **zero or more than one element** is found.
- **SingleOrDefault():** Returns **the single element** matching a condition, or a **default value** if none exists. Throws if more than one element matches.

**Example:**
```csharp
List<int> nums = new List<int> {2, 4, 6};

// First element greater than 3
Console.WriteLine(nums.First(n => n > 3));          // 4

// First element greater than 10, returns default 0
Console.WriteLine(nums.FirstOrDefault(n => n > 10)); // 0

// Single element equal to 4
Console.WriteLine(nums.Single(n => n == 4));        // 4

// Single element equal to 10, returns default 0
Console.WriteLine(nums.SingleOrDefault(n => n == 10)); // 0
```
# 8. How do you use Any(), All(), and Contains() in LINQ?



These LINQ methods are used to **check conditions on a collection** without manually iterating through it:

- **Any():** Returns `true` if **any element** in the collection satisfies the given condition.
- **All():** Returns `true` if **all elements** satisfy the condition.
- **Contains():** Returns `true` if the collection **contains a specific element**.

**Example:**
```csharp
List<int> nums = new List<int> {2, 4, 6};

// Check if any element > 5
Console.WriteLine(nums.Any(n => n > 5)); // True

// Check if all elements are even
Console.WriteLine(nums.All(n => n % 2 == 0)); // True

// Check if collection contains 4
Console.WriteLine(nums.Contains(4)); // True

```
# 9. How do you combine LINQ queries?

In LINQ, you can **chain multiple methods** together to perform complex operations in a single, readable statement. For example, you can filter data, sort it, and transform it all at once without writing multiple loops or temporary variables. This makes your code **concise, readable, and easy to maintain**.

**Example:**
```csharp
List<int> nums = new List<int> {5, 2, 8, 1};

// Filter numbers greater than 2, sort ascending, and multiply each by 2
var result = nums.Where(n => n > 2)
                 .OrderBy(n => n)
                 .Select(n => n * 2);

foreach(var n in result)
    Console.WriteLine(n); // 6, 10, 16
```
# 10. How do you use LINQ with complex objects?

**Answer:**

LINQ can be used with **collections of objects**, allowing you to filter, sort, or project data based on object properties. This is useful when working with classes or structured data, making queries concise and readable without manual loops.

**Example:**
```csharp
// Define a class
class Student 
{ 
    public string Name; 
    public int Score; 
}

// Sample data
var students = new List<Student>
{
    new Student {Name = "Alice", Score = 90},
    new Student {Name = "Bob", Score = 75}
};

// Filter students with Score > 80 and select their names
var topStudents = students.Where(s => s.Score > 80)
                          .Select(s => s.Name);

foreach(var name in topStudents)
    Console.WriteLine(name); // Alice
```