# Async/Await & Task

## 1. What is asynchronous programming and why is it used?

Asynchronous programming allows your application to **perform long-running tasks without blocking the main thread**. This means your program can **start a task (like reading a file, making a network call, or querying a database) and continue executing other code while waiting for the task to complete**. This is especially important for **UI applications**, where blocking the main thread can make the interface unresponsive.

In C#, the **main thread** is the thread that starts when your program runs. For a console app, it executes the `Main` method; for a UI app (like WPF or WinForms), it handles user interactions, drawing controls, and events. Blocking the main thread by performing a long task synchronously can freeze the UI, but asynchronous programming lets the main thread continue running while other tasks happen in the background.

**Example:**
```csharp
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine($"Main thread ID: {Thread.CurrentThread.ManagedThreadId}");

        Task.Run(() =>
        {
            Console.WriteLine($"Background task started on thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(3000); // Simulate long work
            Console.WriteLine("Background task completed");
        });

        Console.WriteLine("Main thread continues running...");
        Console.ReadLine();
    }
}
```
## 2. What is a Task in C# and how do you create and run it?

A **Task** in C# represents a unit of work that runs asynchronously, allowing code to execute without blocking the main thread. It can either perform work without returning a value (`Task`) or return a result (`Task<TResult>`). Tasks are commonly used for background operations such as I/O, network requests, or heavy computations, while keeping the main thread free to handle other work or keep a user interface responsive. You can create and run a Task using `Task.Run()`, which is the simplest approach, or, in more advanced scenarios, `Task.Factory.StartNew()`. Alternatively, you can define an `async` method that returns a Task. Once a Task is started, you can wait for it to complete using `await`, which allows the calling code to continue executing other work without blocking. Tasks also integrate seamlessly with continuations, cancellation, and exception handling, making asynchronous programming more structured and maintainable compared to using raw threads.

**Example:**
```csharp
// Task without a result
Task t = Task.Run(() => Console.WriteLine("Work in background"));
await t;

// Task with a result
Task<int> t2 = Task.Run(() => 10 + 20);
int result = await t2;
Console.WriteLine(result); // 30
```
## 3. What is the difference between synchronous, asynchronous, and parallel code?

In **synchronous** programming, operations are performed one after another, and the current thread is **blocked** until each operation completes. For example, reading a large file using `File.ReadAllText("big.txt")` will block the thread until the file is fully read.

In **asynchronous** programming, the thread is **freed** while waiting for time-consuming operations such as I/O, network requests, or database calls. This allows the program to remain responsive, for instance, using `await File.ReadAllTextAsync("big.txt")`. 

**Parallel** programming, on the other hand, runs multiple operations **simultaneously on different threads**, usually for CPU-bound tasks, to fully utilize multiple cores. An example is using `Parallel.For` to execute a loop concurrently: `Parallel.For(0, 5, i => Console.WriteLine(i));`. While asynchronous programming improves responsiveness, parallel programming improves performance for compute-heavy workloads.

## 4. How do `async` and `await` work in C#?

In C#, `async` and `await` are used to **write asynchronous code** in a clear, linear style. A method marked with `async` can use the `await` keyword to **pause its execution until the awaited task completes** without blocking the calling thread. This allows other code to run in the meantime, improving responsiveness and efficiency, especially for I/O-bound operations. Once the awaited task finishes, execution resumes from where it left off. For example, an `async` method can wait for a delay and then continue:

```csharp
async Task SayHelloAsync()
{
    await Task.Delay(1000);  // non-blocking wait
    Console.WriteLine("Hello after 1 second");
}

await SayHelloAsync();
```
# 5. How do you handle exceptions in async code?

In asynchronous code, exceptions are raised inside a `Task`. When you use `await`, the exception is automatically re-thrown at the `await` point, so you can handle it with a normal `try/catch` block. If you don’t `await` a Task, the exception is stored in the Task object and will surface later when you access `task.Exception`. To avoid unobserved exceptions, always `await` your Tasks or handle their `Exception` property explicitly.

**Example:**
```csharp
try
{
    await Task.Run(() => throw new InvalidOperationException("Oops"));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message); // Oops
}
```
# 6. What are Task.WhenAll, Task.WhenAny, and Task.Delay?

In C#, the `Task` class provides utility methods to coordinate and schedule asynchronous operations:

- **`Task.WhenAll`** waits for *all* the provided tasks to complete. It’s useful when you want to wait until several independent operations are finished before continuing.
- **`Task.WhenAny`** completes as soon as *any one* of the provided tasks finishes. This is useful when you want to process the result of whichever task completes first.
- **`Task.Delay`** creates a task that completes after a specified time interval. Unlike `Thread.Sleep`, it is **non-blocking**, meaning the calling thread is not blocked while waiting.

**Example:**
```csharp
Task t1 = Task.Delay(1000); // completes after 1 second
Task t2 = Task.Delay(2000); // completes after 2 seconds

// Wait until both tasks complete
await Task.WhenAll(t1, t2);

// Continue as soon as the first task completes
Task finished = await Task.WhenAny(t1, t2);

Console.WriteLine("One task finished, then both eventually completed");
```