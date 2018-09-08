# Intro

Create a temporary directory that disposes itself after usage.

# Install

TODO

# Example Usage

```c#
// Creates a temporary directory under the Windows temp directory
using (var tempDirectory = new TempDir())
{
    // Use created temp directory in here
}

// Created temp directory no loger exists out here
```

```c#
// Creates a temporary directory under C:\SomeDirectory
using (var tempDirectory = new TempDir(@"C:\SomeDirectory"))
{
}
```