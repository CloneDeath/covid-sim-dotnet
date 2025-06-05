# Contribution Guidelines

This project is gradually being ported from C++ to C#. The following rules
apply to any work performed in this repository.

1. **C# only.** Modify only the C# code. C++ files may be deleted when their
   functionality has been completely ported, but existing C++ code should not be
   edited.
2. **One class per file.** Each C# class must live in its own source file.
3. **Structured unit tests.** Unit test files must be named
   `ClassName.tests.cs` and contain an `abstract class ClassName_tests` that
   serves as a shared test fixture. For every function under test, create a
   nested class inside this abstract class (for example
   `ClassName_Expand_tests`) that inherits from the outer class. This pattern
   allows common setup and teardown code to be shared.

   Example:

   ```csharp
   // Foo.tests.cs
   using NUnit.Framework;

   [TestFixture]
   public abstract class Foo_tests
   {
       [SetUp]
       public void Setup() { /* common setup */ }

       [TestFixture]
       public class Foo_DoSomething_tests : Foo_tests
       {
           [Test]
           public void Returns_expected_value()
           {
               // Test Foo.DoSomething
           }
       }

       [TestFixture]
       public class Foo_Validate_tests : Foo_tests
       {
           [Test]
           public void Throws_on_invalid_input()
           {
               // Test Foo.Validate
           }
       }
   }
   ```
4. **Related files.** Source files should depend on each other only when they
   share a base type or interface or are very closely related variants.
5. **Clean Code principles.** Follow Robert Martin's *Clean Code* and the
   SOLID principles. Keep in mind Michael Feathers' *Working Effectively with
   Legacy Code* when modifying existing code.
