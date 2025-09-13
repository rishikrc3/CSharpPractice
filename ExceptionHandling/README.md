# 1. What is an exception in C# and why is it used?


An **exception** in C# is an object that represents an **error or unexpected situation** that occurs during program execution. Instead of letting the program **crash immediately**, exceptions allow developers to **detect, handle, and respond to errors gracefully**.

Exceptions help separate **normal program logic** from **error-handling logic**, making code cleaner and more maintainable. They are commonly used for situations like invalid input, file not found, network errors, or division by zero.

**Example:**
```csharp
try
{
    int a = 10;
    int b = 0;
    int result = a / b; // This will throw a DivideByZeroException
}
catch(DivideByZeroException ex)
{
    Console.WriteLine("Cannot divide by zero! " + ex.Message);
}
finally
{
    Console.WriteLine("This block runs regardless of exception.");
}
```
# 2. How do try, catch, and finally blocks work in C#?

**Answer:**

In C#, **try, catch, and finally** blocks are used to **handle exceptions** and manage code that may fail:

- **try:** Contains the code that might throw an exception.
- **catch:** Handles the exception if one is thrown. You can catch specific exception types (like `FormatException`) or general exceptions (`Exception`).
- **finally:** Runs **always**, whether an exception occurred or not. It’s typically used for **cleanup tasks**, such as closing files, releasing database connections, or freeing resources.

**Example:**
```csharp
try
{
    int x = int.Parse("abc"); // This will throw a FormatException
}
catch (FormatException ex)
{
    Console.WriteLine($"Invalid number: {ex.Message}");
}
finally
{
    Console.WriteLine("Cleanup code always runs");
}
```
# 2. How do try, catch, and finally blocks work in C#?

In C#, **try, catch, and finally** blocks are used to **handle exceptions** and manage code that may fail:

- **try:** Contains the code that might throw an exception.
- **catch:** Handles the exception if one is thrown. You can catch specific exception types (like `FormatException`) or general exceptions (`Exception`).
- **finally:** Runs **always**, whether an exception occurred or not. It’s typically used for **cleanup tasks**, such as closing files, releasing database connections, or freeing resources.

**Example:**
```csharp
try
{
    int x = int.Parse("abc"); // This will throw a FormatException
}
catch (FormatException ex)
{
    Console.WriteLine($"Invalid number: {ex.Message}");
}
finally
{
    Console.WriteLine("Cleanup code always runs");
}
```
# 3. What is the difference between `throw;` and `throw ex;` in C#?

**Answer:**

In C#, both `throw;` and `throw ex;` are used to re-throw exceptions, but they behave differently with regard to the **call stack**:

- **`throw;`**  
  Rethrows the current exception while **preserving the original call stack**. This is preferred because it keeps the original location where the exception occurred, making debugging easier.

- **`throw ex;`**  
  Throws the caught exception as a **new exception**, which **resets the call stack** to the point of the `throw ex;`. This can make debugging harder because you lose the original source of the exception.

**Example:**
```csharp
try
{
    int x = int.Parse("abc"); // This will throw a FormatException
}
catch (Exception ex)
{
    Console.WriteLine("Logging…");
    throw; // Keeps original location of error
    // throw ex; // Would reset the call stack
}
```
# 4. How do you create and use custom exceptions in C#?

**Answer:**

In C#, you can create **custom exceptions** by defining a class that **inherits from `Exception`** (or one of its subclasses). Custom exceptions are useful for representing **domain-specific errors**, making error handling clearer and more precise.

**Steps to create and use a custom exception:**

1. **Define the custom exception class:**
```csharp
public class InvalidOrderException : Exception
{
    public InvalidOrderException(string message) : base(message) {}
}
throw new InvalidOrderException("Order ID not found");


```
# 5. What happens with exceptions in Task or Parallel code in C#?

In C#, when an exception occurs inside a **Task** or **parallel operation**, it does **not immediately propagate** like normal exceptions. Instead, the exception is **wrapped inside an `AggregateException`**. You can handle these exceptions by using `await` (in async methods) or by calling `Task.Wait()` and inspecting the `InnerExceptions` collection.

**Example:**
```csharp
using System;
using System.Threading.Tasks;

var t = Task.Run(() => throw new InvalidOperationException("Boom"));

try
{
    t.Wait(); // Wait for task to complete
}
catch (AggregateException ex)
{
    // Iterate through all inner exceptions
    foreach (var inner in ex.InnerExceptions)
        Console.WriteLine(inner.Message); // Boom
}
```
# 6. When should you catch vs rethrow vs swallow exceptions in C#?

**Answer:**

In C#, deciding how to handle exceptions depends on **whether you can meaningfully respond to them**:

- **Catch and handle:**  
  Only catch an exception if you can **recover from it** or add useful information, such as logging, retrying, or providing a fallback value.

- **Rethrow (`throw;`):**  
  Use `throw;` to pass the exception up the call stack when **higher-level code should decide how to handle it**. This preserves the original stack trace.

- **Swallowing exceptions:**  
  Avoid catching exceptions without any action. Silently swallowing errors **hides bugs** and makes debugging difficult.

**Example:**
```csharp
try
{
    DoWork(); // Some operation that might fail
}
catch (IOException ex)
{
    // Log the error
    Log(ex);

    // Rethrow to let higher layers handle it
    throw;
}
```