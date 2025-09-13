# 1. What is C#?

C# is a modern, object-oriented programming language developed by Microsoft.  
It runs on the .NET platform and can be used to build web apps, desktop apps, mobile apps, games, and APIs.

Key features of C#:
- Strongly typed language
- Automatic memory management (garbage collection)
- Supports object-oriented programming principles:
    - Encapsulation
    - Inheritance
    - Polymorphism  

# 2. What are Value Types and Reference Types?
Value types store the actual data. Examples: int, bool, double, struct. Copying a value type creates a new, independent copy.

Reference types store a reference to the object in memory. Examples: string, class, array. Copying a reference type copies the pointer, so both variables refer to the same object.  
Note: string is a reference type but immutable (its value cannot be changed once created).


# 3. How do you declare variables in C#?

**Answer:**

You specify the type and name of a variable.  
`var` lets the compiler infer the type.

# 4. What are Constants and Readonly Fields?


`const` values cannot change and are known at compile time.

`readonly` values can be assigned at declaration or in the constructor, useful for values known only at runtime.

# 5. Class vs Struct ?
A class is a reference type, which means it is stored on the heap and variables hold a reference to the object. Classes support inheritance and polymorphism, making them useful for larger and more complex objects.

A struct is a value type, which means it is stored on the stack and variables hold the actual data. Structs do not support inheritance and are better suited for small, lightweight objects like points or coordinates.

# 6. What are Arrays and Lists?

An array is a fixed-size collection that stores elements of the same type. Once created, the size of an array cannot be changed. Arrays provide fast access to elements using an index but are less flexible when it comes to resizing or modifying the collection.

A `List<T>` is a dynamic, growable, generic collection. Unlike arrays, lists can increase or decrease in size as needed. They provide useful methods such as `Add`, `Remove`, `Insert`, and `Contains`, making them easier to work with when the number of elements is not known in advance.

# 7. What is an Interface?

An interface defines a contract that specifies methods, properties, or events a class must implement. It does not contain any implementation itself, only the signatures. By programming to an interface rather than a concrete class, you reduce dependencies in your code. This makes the system more flexible and easier to extend or modify, since different classes can implement the same interface in their own way without affecting the rest of the code.

