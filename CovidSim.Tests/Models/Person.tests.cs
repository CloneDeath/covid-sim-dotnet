using CovidSim.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Models;

[TestFixture]
public abstract class Person_tests {
	[TestFixture]
	public class Person_do_not_vaccinate_tests : Person_tests {
		[Test]
		public void IsFalseInitially() {
			var person = new Person();

			person.do_not_vaccinate().Should().BeFalse();
		}

		[Test]
		public void IsTrueIfThePersonIsDead() {
			var person = new Person();
			person.set_dead();

			person.do_not_vaccinate().Should().BeTrue();
		}

		[Test]
		public void IsTrueIfThePersonIsACase() {
			var person = new Person();
			person.set_case();

			person.do_not_vaccinate().Should().BeTrue();
		}

		[Test]
		public void IsTrueIfThePersonIsRecoveredButSymptomatic() {
			var person = new Person();
			person.set_case();
			person.set_recovered();

			person.do_not_vaccinate().Should().BeTrue();
		}
	}

	[TestFixture]
	public class Person_is_dead_tests : Person_tests {
		[Test]
		public void IsFalseInitially() {
			var person = new Person();

			person.is_dead().Should().BeFalse();
		}

		[Test]
		public void IsTrueIfThePersonIsDead() {
			var person = new Person();
			person.set_dead();

			person.is_dead().Should().BeTrue();
		}

		[Test]
		public void IsFalseIfThePersonIsACase() {
			var person = new Person();
			person.set_case();

			person.is_dead().Should().BeFalse();
		}

		[Test]
		public void IsTrueIfThePersonWasACaseThenDied() {
			var person = new Person();
			person.set_case();
			person.set_dead();

			person.is_dead().Should().BeTrue();
		}
	}

	[TestFixture]
	public class Person_is_alive_tests : Person_tests {
		[Test]
		public void IsTrueInitially() {
			var person = new Person();

			person.is_alive().Should().BeTrue();
		}

		[Test]
		public void IsFalseIfThePersonIsDead() {
			var person = new Person();
			person.set_dead();

			person.is_alive().Should().BeFalse();
		}

		[Test]
		public void IsTrueIfThePersonIsACase() {
			var person = new Person();
			person.set_case();

			person.is_alive().Should().BeTrue();
		}

		[Test]
		public void IsTrueIfThePersonWasACaseThenRecovered() {
			var person = new Person();
			person.set_case();
			person.set_recovered();

			person.is_alive().Should().BeTrue();
		}

		[Test]
		public void IsFalseIfThePersonWasACaseThenDied() {
			var person = new Person();
			person.set_case();
			person.set_dead();

			person.is_alive().Should().BeFalse();
		}
	}

	[TestFixture]
	public class Person_is_case_tests : Person_tests {
		[Test]
		public void IsFalseInitially() {
			var person = new Person();

			person.is_case().Should().BeFalse();
		}

		[Test]
		public void IsTrueIfThePersonIsACase() {
			var person = new Person();
			person.set_case();

			person.is_case().Should().BeTrue();
		}

		[Test]
		public void IsFalseIfThePersonIsDead() {
			var person = new Person();
			person.set_dead();

			person.is_case().Should().BeFalse();
		}

		[Test]
		public void IsFalseIfThePersonWasACaseThenRecovered() {
			var person = new Person();
			person.set_case();
			person.set_recovered();

			person.is_case().Should().BeFalse();
		}

		[Test]
		public void IsFalseIfThePersonWasACaseThenDied() {
			var person = new Person();
			person.set_case();
			person.set_dead();

			person.is_case().Should().BeFalse();
		}
	}

	[TestFixture]
	public class Person_is_dead_was_asymp_tests : Person_tests {
		[Test]
		public void InitiallyFalse() {
			var person = new Person();
			person.is_dead_was_asymp().Should().BeFalse();
		}

		[Test]
		public void TrueIfThePersonIsDead() {
			var person = new Person();
			person.set_dead();
			person.is_dead_was_asymp().Should().BeTrue();
		}

		[Test]
		public void FalseIfThePersonWasSickThenDied() {
			var person = new Person();
			person.set_case();
			person.set_dead();
			person.is_dead_was_asymp().Should().BeFalse();
		}
	}

	[TestFixture]
	public class Person_is_dead_was_symp_tests : Person_tests {
		[Test]
		public void InitiallyFalse() {
			var person = new Person();
			person.is_dead_was_symp().Should().BeFalse();
		}

		[Test]
		public void FalseIfThePersonIsDead() {
			var person = new Person();
			person.set_dead();
			person.is_dead_was_symp().Should().BeFalse();
		}

		[Test]
		public void TrueIfThePersonWasACaseThenDied() {
			var person = new Person();
			person.set_case();
			person.set_dead();
			person.is_dead_was_symp().Should().BeTrue();
		}
	}

	[TestFixture]
	public class Person_is_immune_at_start_tests : Person_tests {
		[Test]
		public void InitiallyFalse() {
			var person = new Person();
			person.is_immune_at_start().Should().BeFalse();
		}

		[Test]
		public void TrueIfThePersonIsInitiallySetToImmune() {
			var person = new Person();
			person.set_immune_at_start();

			person.is_immune_at_start().Should().BeTrue();
		}
	}

	[TestFixture]
	public class Person_is_infectious_asymptomatic_not_case_tests : Person_tests {
		[Test]
		public void IsInitiallyFalse() {
			var person = new Person();
			person.is_infectious_asymptomatic_not_case().Should().BeFalse();
		}

		[Test]
		public void IsTrueWhenSet() {
			var person = new Person();
			person.set_infectious_asymptomatic_not_case();
			person.is_infectious_asymptomatic_not_case().Should().BeTrue();
		}
	}

	[TestFixture]
	public class Person_is_infectious_almost_symptomatic_tests : Person_tests {
		[Test]
		public void IsInitiallyFalse() {
			var person = new Person();
			person.is_infectious_almost_symptomatic().Should().BeFalse();
		}

		[Test]
		public void IsTrueWhenSet() {
			var person = new Person();
			person.set_infectious_almost_symptomatic();
			person.is_infectious_almost_symptomatic().Should().BeTrue();
		}
	}

	[TestFixture]
	public class Person_is_latent_tests : Person_tests {
		[Test]
		public void IsInitiallyFalse() {
			var person = new Person();
			person.is_latent().Should().BeFalse();
		}

		[Test]
		public void IsTrueWhenSet() {
			var person = new Person();
			person.set_latent();
			person.is_latent().Should().BeTrue();
		}
	}

	[TestFixture]
	public class Person_is_never_symptomatic_tests : Person_tests {
		[Test]
		public void IsInitiallyTrue() {
			var person = new Person();
			person.is_never_symptomatic().Should().BeTrue();
		}

		[Test]
		public void IsTrueWhenLatent() {
			var person = new Person();
			person.set_latent();
			person.is_never_symptomatic().Should().BeTrue();
		}

		[Test]
		public void IsTrueWhenInfectiousAsymptomaticNotCase() {
			var person = new Person();
			person.set_infectious_asymptomatic_not_case();
			person.is_never_symptomatic().Should().BeTrue();
		}

		[Test]
		public void IsTrueIfRecoveredFromAsymptomatic() {
			var person = new Person();
			person.set_recovered();
			person.is_never_symptomatic().Should().BeTrue();
		}

		[Test]
		public void IsFalseIfRecoveredButWasSick() {
			var person = new Person();
			person.set_case();
			person.set_recovered();
			person.is_never_symptomatic().Should().BeFalse();
		}

		[Test]
		public void IsTrueIfPersonWasImmuneAtStart() {
			var person = new Person();
			person.set_immune_at_start();
			person.is_never_symptomatic().Should().BeTrue();
		}

		[Test]
		public void IsTrueIfPersonDied() {
			var person = new Person();
			person.set_dead();
			person.is_never_symptomatic().Should().BeTrue();
		}

		[Test]
		public void IsFalseIfPersonDiedWhileSick() {
			var person = new Person();
			person.set_case();
			person.set_dead();
			person.is_never_symptomatic().Should().BeFalse();
		}
	}

	[TestFixture]
	public class Person_is_not_yet_symptomatic_tests : Person_tests {
		[Test]
		public void IsInitiallyTrue() {
			var person = new Person();
			person.is_not_yet_symptomatic().Should().BeTrue();
		}

		[Test]
		public void IsTrueIfPersonSusceptible() {
			var person = new Person();
			person.set_susceptible();
			person.is_not_yet_symptomatic().Should().BeTrue();
		}

		[Test]
		public void IsTrueIfThePersonIsLatent() {
			var person = new Person();
			person.set_latent();
			person.is_not_yet_symptomatic().Should().BeTrue();
		}

		[Test]
		public void IsTrueIfPersonIsInfectiousAlmostSymptomatic() {
			var person = new Person();
			person.set_infectious_almost_symptomatic();
			person.is_not_yet_symptomatic().Should().BeTrue();
		}

		[Test]
		public void IsFalseIfPersonIsInfectionAsymptomaticButNotACase() {
			var person = new Person();
			person.set_infectious_asymptomatic_not_case();
			person.is_not_yet_symptomatic().Should().BeFalse();
		}

		[Test]
		public void IsFalseIfPersonIsACase() {
			var person = new Person();
			person.set_case();
			person.is_not_yet_symptomatic().Should().BeFalse();
		}

		[Test]
		public void IsFalseIfThePersonHasRecovered() {
			var person = new Person();
			person.set_recovered();
			person.is_not_yet_symptomatic().Should().BeFalse();
		}

		[Test]
		public void IsFalseIfThePersonDied() {
			var person = new Person();
			person.set_dead();
			person.is_not_yet_symptomatic().Should().BeFalse();
		}
	}
}
