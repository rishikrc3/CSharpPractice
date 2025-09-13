# 1. What is a Collection in C#?

**Answer:**

A collection is a data structure that holds multiple items. Collections make it easy to store, access, and manipulate groups of data. For example, a list of names, numbers, or objects. Unlike single variables, collections allow iterating, searching, adding, and removing items efficiently.

Use case: storing multiple items of the same type, like a list of user IDs or product names.

# 2. What are the main types of collections in C#?

- **Array**: fixed-size, same-type elements (`int[] arr`)
- **List<T>**: dynamic array, generic (`List<int> nums`)
- **Dictionary<TKey, TValue>**: key-value pairs (`Dictionary<int, string>`)
- **Queue<T>**: FIFO (first in, first out)
- **Stack<T>**: LIFO (last in, first out)
- **HashSet<T>**: unordered collection of unique elements  
# 3. What is the difference between Array and List<T>?

**Answer:**

An array is a fixed-size collection that holds elements of the same type. Its size is determined when it is created and cannot be changed later. Arrays have limited built-in methods but support indexing, allowing fast access to elements.

A `List<T>` is a dynamic, growable collection that also stores elements of the same type using generics. Unlike arrays, lists can change in size at runtime and provide useful methods such as `Add`, `Remove`, and `Contains` for easy manipulation. Indexing is also supported, making it flexible and convenient for most programming scenarios.

**Code Example:**

```csharp
int[] arr = {1, 2, 3};         // fixed size

List<int> list = new List<int>();
list.Add(1);
list.Add(2);
```

# 4. How do you iterate through collections?

**Answer:**

You can iterate through collections using `for`, `foreach`, or LINQ. For example, given a list of names:

```csharp
List<string> names = new List<string>{"Alice", "Bob"};

foreach (var name in names) 
    Console.WriteLine(name);

for (int i = 0; i < names.Count; i++) 
    Console.WriteLine(names[i]);
```

# 5. What is a generic collection and what are its advantages?

**Answer:**

A generic collection is a type-safe collection that allows you to store elements of a specified type without needing to cast them later. The compiler ensures type safety at compile time, which prevents runtime errors. Generics also improve code reusability because the same code can work with different types, and they enhance performance by avoiding boxing and unboxing for value types.

For example, consider a generic list of integers and a generic dictionary of student names and their scores:

```csharp
List<int> numbers = new List<int>();
numbers.Add(5);
numbers.Add(10);

Dictionary<string, int> studentScores = new Dictionary<string, int>();
studentScores.Add("Alice", 95);
studentScores.Add("Bob", 88);

Console.WriteLine(numbers[0]);            // 5
Console.WriteLine(studentScores["Alice"]); // 95
```

# 7. What are common collection types in C#?

**Answer:**

C# provides several built-in collection types to store and manage data efficiently. A `Dictionary<TKey, TValue>` stores key-value pairs with unique keys, which is useful for fast lookups. A `HashSet<T>` is an unordered collection of unique elements, ideal for removing duplicates and checking membership quickly. A `Queue<T>` is a FIFO (first-in, first-out) collection where elements are added with `Enqueue()` and removed with `Dequeue()`. A `Stack<T>` is a LIFO (last-in, first-out) collection where elements are added with `Push()` and removed with `Pop()`.

**Example:**

```csharp
Dictionary<string, int> ages = new Dictionary<string, int>();
ages["Alice"] = 25;
ages["Bob"] = 30;
Console.WriteLine(ages["Bob"]); // 30

HashSet<int> numbers = new HashSet<int> {1, 2, 2, 3};
Console.WriteLine(numbers.Count); // 3

Queue<string> q = new Queue<string>();
q.Enqueue("A"); q.Enqueue("B");
Console.WriteLine(q.Dequeue()); // A

Stack<string> s = new Stack<string>();
s.Push("A"); s.Push("B");
Console.WriteLine(s.Pop()); // B
```
# 8. What is the difference between ArrayList and List<T>?

**Answer:**

`ArrayList` is a non-generic collection that stores elements as `object`. Since type safety is not enforced, you can accidentally store the wrong type, which may lead to runtime errors. `List<T>`, on the other hand, is a generic collection that is type-safe, meaning the compiler ensures all elements are of the specified type. This makes `List<T>` safer, more efficient, and the preferred choice for modern C# programming.

# 12 What is IEnumerable<T>?

**Answer:**

`IEnumerable<T>` is the most basic collection interface in C#. It allows you to iterate over a sequence of elements using `foreach`. It does not support adding, removing, or counting elements, but it can be used with LINQ for querying collections.

**Example:**
```csharp
List<int> numbers = new List<int> {1, 2, 3};
IEnumerable<int> enumerableNumbers = numbers;

foreach (var num in enumerableNumbers)
    Console.WriteLine(num); // 1, 2, 3

```
# 13. What is ICollection<T>?

**Answer:**

`ICollection<T>` extends `IEnumerable<T>` and adds features for managing a collection. It provides `Count` to get the number of elements, `Add` and `Remove` to modify the collection, and `Contains` to check if an element exists. This makes it suitable when you need to both iterate and manipulate a collection.

**Example:**
```csharp
ICollection<string> names = new List<string>();
names.Add("Alice");
names.Add("Bob");
Console.WriteLine(names.Count);     // 2
names.Remove("Alice");
Console.WriteLine(names.Contains("Alice")); // False
```
# 14. What is IList<T>?

**Answer:**

`IList<T>` extends `ICollection<T>` and adds **index-based access** to elements. This means you can get or set elements by their position in the list, making it useful for collections where order and random access matter. It inherits all the features of `ICollection<T>`, including `Add`, `Remove`, and `Count`, while also allowing direct access by index.

**Example:**
```csharp
IList<int> numbers = new List<int> {10, 20, 30};
Console.WriteLine(numbers[1]); // 20
numbers[1] = 25;               // modify element at index 1
Console.WriteLine(numbers[1]); // 25
```

# 15. What is IDictionary<TKey, TValue>?

**Answer:**

`IDictionary<TKey, TValue>` represents a collection of **key-value pairs** where each key is unique and maps to a value. It is useful for scenarios that require fast lookups, mapping, or association between keys and values. `IDictionary<TKey, TValue>` allows adding, removing, and retrieving elements efficiently using their keys.

**Example:**
```csharp
IDictionary<string, int> ages = new Dictionary<string, int>();
ages["Alice"] = 25;
ages["Bob"] = 30;
Console.WriteLine(ages["Alice"]); // 25
```
# 16. What does `<T>` mean in C# and why is it used?

`<T>` represents a **generic type parameter** in C#. Generics allow you to write classes, methods, interfaces, or collections that can operate on any data type while still maintaining **type safety**. Instead of writing separate code for each data type (like `int`, `string`, or `double`), you can write one generic definition and specify the type when using it. This promotes **code reusability**, **type safety**, and **better performance**.

- **Type Safety:** The compiler ensures that only the specified type can be used with the generic class or method, preventing runtime errors.
- **Code Reusability:** You can use the same generic code for multiple types without duplicating logic.
- **Performance:** Avoids boxing/unboxing for value types, which is required in non-generic collections like `ArrayList`.

**Example with a generic List:**
```csharp
List<int> numbers = new List<int>();   // T is int here
numbers.Add(10);
numbers.Add(20);
// numbers.Add("Hello"); // ❌ Compile-time error, type safety

List<string> names = new List<string>(); // T is string here
names.Add("Alice");
names.Add("Bob");
```

# 17. What is the difference between IEnumerable<T> and IQueryable<T>?

`IEnumerable<T>` and `IQueryable<T>` are both interfaces used to work with sequences of data, but they serve different purposes and are optimized for different scenarios.

- **IEnumerable<T>**  
  `IEnumerable<T>` is designed for **in-memory collections** such as arrays, lists, or any collection already loaded into memory. LINQ operations on `IEnumerable<T>` are performed **in memory**, and the filtering, ordering, or transformation happens **after the data is loaded**. This makes it simple and straightforward, but it may be inefficient for large datasets because all elements must be brought into memory before operations are applied.

  **Example:**
  ```csharp
  List<int> nums = new List<int> {1, 2, 3, 4, 5};

  // Filter in memory using IEnumerable<T>
  IEnumerable<int> result = nums.Where(x => x > 2);

  foreach(var n in result)
      Console.WriteLine(n); // 3, 4, 5
    ```

- `IQueryable<T>` is designed for **remote data sources**, such as databases. It supports **deferred execution**, meaning the query is **not executed until the data is actually needed**. LINQ queries on `IQueryable<T>` are translated into the underlying query language (for example, SQL when using Entity Framework), so only the required data is fetched. This improves performance for large datasets because the filtering and other operations happen **at the data source**, not in memory.

    **Example (Entity Framework):**
    ```csharp
    IQueryable<int> queryableResult = dbContext.Numbers.Where(x => x > 2);
    
    // The query is not executed until we enumerate it
    foreach(var n in queryableResult)
    Console.WriteLine(n);
    ```
# 18. What are generic methods?


Generic methods are **methods that can operate on different data types** without duplicating code. They use a **type parameter `<T>`**, which allows the method to work with any type specified at the time of the call. This makes code **more reusable, type-safe, and maintainable**, because the compiler ensures the correct type is used, avoiding runtime errors.

Generic methods are often used with **collections**, but they can be applied to any type. You define the type parameter `<T>` **before the return type** in the method signature.

**Example:**
```csharp
// Generic method that returns the first element of a list
T GetFirst<T>(List<T> list)
{
    return list[0];
}

// Using the generic method with integers
var nums = new List<int> {1, 2, 3};
Console.WriteLine(GetFirst(nums)); // 1

// Using the generic method with strings
var names = new List<string> {"Alice", "Bob", "Charlie"};
Console.WriteLine(GetFirst(names)); // Alice
```
# 19. What is the difference between List<T> and LinkedList<T>?

`List<T>` and `LinkedList<T>` are both collections in C#, but they have different internal structures and performance characteristics. `List<T>` is **array-based**, which means elements are stored in contiguous memory. This allows **fast access by index (O(1))**, but inserting or removing elements in the middle of the list can be slow, as it may require shifting elements. `LinkedList<T>`, on the other hand, is made up of **doubly linked nodes**, where each element points to the next and previous node. This makes inserting or removing elements in the middle **very fast (O(1))** if the node reference is known, but accessing elements by index is slower (O(n)) because you have to traverse the list. `LinkedList<T>` also has slightly higher memory overhead due to storing pointers for each node.



# 20. What is a SortedList<TKey, TValue> vs SortedDictionary<TKey, TValue>?

`SortedList<TKey, TValue>` and `SortedDictionary<TKey, TValue>` are both collections that store key-value pairs in a sorted order based on the key, but they use different internal data structures and have different performance characteristics. `SortedList<TKey, TValue>` uses an **array internally**, so it allows **fast retrieval by index** but **slower insertion or removal**, especially for large datasets, because elements may need to be shifted. `SortedDictionary<TKey, TValue>`, in contrast, uses a **binary search tree internally**, which allows **faster insertion and removal**, but retrieval by index is slower compared to `SortedList`. Both maintain the keys in sorted order, but the choice depends on whether your application prioritizes fast lookups (`SortedList`) or frequent insertions and deletions (`SortedDictionary`).
