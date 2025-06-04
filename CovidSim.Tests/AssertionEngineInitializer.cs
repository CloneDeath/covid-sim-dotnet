using CovidSim.Tests;
using FluentAssertions;

[assembly: FluentAssertions.Extensibility.AssertionEngineInitializer(
	typeof(AssertionEngineInitializer),
	nameof(AssertionEngineInitializer.AcknowledgeSoftWarning))]

namespace CovidSim.Tests;

public static class AssertionEngineInitializer {
	public static void AcknowledgeSoftWarning() {
		License.Accepted = true;
	}
}
