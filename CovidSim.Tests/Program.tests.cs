using System;
using CovidSim;
using NUnit.Framework;

namespace CovidSim.Tests;

[TestFixture]
public class Program_tests {
    [Test]
    public void Main_executes_without_error() {
        Program.Main(Array.Empty<string>());
        Program.Run();
    }
}
