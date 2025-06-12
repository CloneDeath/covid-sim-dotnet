using CovidSim.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Models;

[TestFixture]
public abstract class Person_tests {
	[TestFixture]
	public class Person_do_not_vaccinate_tests : Person_tests {
		[Test]
		public void InitiallyFalse() {
			var person = new Person();
			person.do_not_vaccinate().Should().BeFalse();
		}

		[Test]
		public void WhenSusceptible_ReturnFalse() {
			var person = new Person();
			person.set_susceptible();
			person.do_not_vaccinate().Should().BeFalse();
		}

		[Test]
		public void WhenLatent_ReturnFalse() {
			var person = new Person();
			person.set_latent();
			person.do_not_vaccinate().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAlmostSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_infectious_almost_symptomatic();
			person.do_not_vaccinate().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAsymptomaticNotCase_ReturnFalse() {
			var person = new Person();
			person.set_infectious_asymptomatic_not_case();
			person.do_not_vaccinate().Should().BeFalse();
		}

		[Test]
		public void WhenACase_ReturnTrue() {
			var person = new Person();
			person.set_case();
			person.do_not_vaccinate().Should().BeTrue();
		}

		[Test]
		public void WhenRecoveredAndAsymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_recovered();
			person.do_not_vaccinate().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredButSymptomatic_ReturnTrue() {
			var person = new Person();
			person.set_case();
			person.set_recovered();
			person.do_not_vaccinate().Should().BeTrue();
		}

		[Test]
		public void WhenImmuneAtStart_ReturnFalse() {
			var person = new Person();
			person.set_immune_at_start();
			person.do_not_vaccinate().Should().BeFalse();
		}

		[Test]
		public void WhenDead_ReturnTrue() {
			var person = new Person();
			person.set_dead();
			person.do_not_vaccinate().Should().BeTrue();
		}

		[Test]
		public void WhenDeadAndWasSick_ReturnTrue() {
			var person = new Person();
			person.set_case();
			person.set_dead();
			person.do_not_vaccinate().Should().BeTrue();
		}
	}

	[TestFixture]
	public class Person_is_dead_tests : Person_tests {
		[Test]
		public void InitiallyFalse() {
			var person = new Person();
			person.is_dead().Should().BeFalse();
		}

		[Test]
		public void WhenSusceptible_ReturnFalse() {
			var person = new Person();
			person.set_susceptible();
			person.is_dead().Should().BeFalse();
		}

		[Test]
		public void WhenLatent_ReturnFalse() {
			var person = new Person();
			person.set_latent();
			person.is_dead().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAlmostSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_infectious_almost_symptomatic();
			person.is_dead().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAsymptomaticNotCase_ReturnFalse() {
			var person = new Person();
			person.set_infectious_asymptomatic_not_case();
			person.is_dead().Should().BeFalse();
		}

		[Test]
		public void WhenACase_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.is_dead().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredAndAsymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_recovered();
			person.is_dead().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredButSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_recovered();
			person.is_dead().Should().BeFalse();
		}

		[Test]
		public void WhenImmuneAtStart_ReturnFalse() {
			var person = new Person();
			person.set_immune_at_start();
			person.is_dead().Should().BeFalse();
		}

		[Test]
		public void WhenDead_ReturnTrue() {
			var person = new Person();
			person.set_dead();
			person.is_dead().Should().BeTrue();
		}

		[Test]
		public void WhenDeadAndWasSick_ReturnTrue() {
			var person = new Person();
			person.set_case();
			person.set_dead();
			person.is_dead().Should().BeTrue();
		}
	}

	[TestFixture]
	public class Person_is_alive_tests : Person_tests {
		[Test]
		public void InitiallyTrue() {
			var person = new Person();
			person.is_alive().Should().BeTrue();
		}

		[Test]
		public void WhenSusceptible_ReturnTrue() {
			var person = new Person();
			person.set_susceptible();
			person.is_alive().Should().BeTrue();
		}

		[Test]
		public void WhenLatent_ReturnTrue() {
			var person = new Person();
			person.set_latent();
			person.is_alive().Should().BeTrue();
		}

		[Test]
		public void WhenInfectiousAlmostSymptomatic_ReturnTrue() {
			var person = new Person();
			person.set_infectious_almost_symptomatic();
			person.is_alive().Should().BeTrue();
		}

		[Test]
		public void WhenInfectiousAsymptomaticNotCase_ReturnTrue() {
			var person = new Person();
			person.set_infectious_asymptomatic_not_case();
			person.is_alive().Should().BeTrue();
		}

		[Test]
		public void WhenACase_ReturnTrue() {
			var person = new Person();
			person.set_case();
			person.is_alive().Should().BeTrue();
		}

		[Test]
		public void WhenRecoveredAndAsymptomatic_ReturnTrue() {
			var person = new Person();
			person.set_recovered();
			person.is_alive().Should().BeTrue();
		}

		[Test]
		public void WhenRecoveredButSymptomatic_ReturnTrue() {
			var person = new Person();
			person.set_case();
			person.set_recovered();
			person.is_alive().Should().BeTrue();
		}

		[Test]
		public void WhenImmuneAtStart_ReturnTrue() {
			var person = new Person();
			person.set_immune_at_start();
			person.is_alive().Should().BeTrue();
		}

		[Test]
		public void WhenDead_ReturnFalse() {
			var person = new Person();
			person.set_dead();
			person.is_alive().Should().BeFalse();
		}

		[Test]
		public void WhenDeadAndWasSick_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_dead();
			person.is_alive().Should().BeFalse();
		}
	}

	[TestFixture]
	public class Person_is_case_tests : Person_tests {
		[Test]
		public void InitiallyFalse() {
			var person = new Person();
			person.is_case().Should().BeFalse();
		}

		[Test]
		public void WhenSusceptible_ReturnFalse() {
			var person = new Person();
			person.set_susceptible();
			person.is_case().Should().BeFalse();
		}

		[Test]
		public void WhenLatent_ReturnFalse() {
			var person = new Person();
			person.set_latent();
			person.is_case().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAlmostSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_infectious_almost_symptomatic();
			person.is_case().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAsymptomaticNotCase_ReturnFalse() {
			var person = new Person();
			person.set_infectious_asymptomatic_not_case();
			person.is_case().Should().BeFalse();
		}

		[Test]
		public void WhenACase_ReturnTrue() {
			var person = new Person();
			person.set_case();
			person.is_case().Should().BeTrue();
		}

		[Test]
		public void WhenRecoveredAndAsymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_recovered();
			person.is_case().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredButSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_recovered();
			person.is_case().Should().BeFalse();
		}

		[Test]
		public void WhenImmuneAtStart_ReturnFalse() {
			var person = new Person();
			person.set_immune_at_start();
			person.is_case().Should().BeFalse();
		}

		[Test]
		public void WhenDead_ReturnFalse() {
			var person = new Person();
			person.set_dead();
			person.is_case().Should().BeFalse();
		}

		[Test]
		public void WhenDeadAndWasSick_ReturnFalse() {
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
		public void WhenSusceptible_ReturnFalse() {
			var person = new Person();
			person.set_susceptible();
			person.is_dead_was_asymp().Should().BeFalse();
		}

		[Test]
		public void WhenLatent_ReturnFalse() {
			var person = new Person();
			person.set_latent();
			person.is_dead_was_asymp().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAlmostSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_infectious_almost_symptomatic();
			person.is_dead_was_asymp().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAsymptomaticNotCase_ReturnFalse() {
			var person = new Person();
			person.set_infectious_asymptomatic_not_case();
			person.is_dead_was_asymp().Should().BeFalse();
		}

		[Test]
		public void WhenACase_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.is_dead_was_asymp().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredAndAsymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_recovered();
			person.is_dead_was_asymp().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredButSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_recovered();
			person.is_dead_was_asymp().Should().BeFalse();
		}

		[Test]
		public void WhenImmuneAtStart_ReturnFalse() {
			var person = new Person();
			person.set_immune_at_start();
			person.is_dead_was_asymp().Should().BeFalse();
		}

		[Test]
		public void WhenDead_ReturnTrue() {
			var person = new Person();
			person.set_dead();
			person.is_dead_was_asymp().Should().BeTrue();
		}

		[Test]
		public void WhenDeadAndWasSick_ReturnFalse() {
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
		public void WhenSusceptible_ReturnFalse() {
			var person = new Person();
			person.set_susceptible();
			person.is_dead_was_symp().Should().BeFalse();
		}

		[Test]
		public void WhenLatent_ReturnFalse() {
			var person = new Person();
			person.set_latent();
			person.is_dead_was_symp().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAlmostSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_infectious_almost_symptomatic();
			person.is_dead_was_symp().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAsymptomaticNotCase_ReturnFalse() {
			var person = new Person();
			person.set_infectious_asymptomatic_not_case();
			person.is_dead_was_symp().Should().BeFalse();
		}

		[Test]
		public void WhenACase_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.is_dead_was_symp().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredAndAsymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_recovered();
			person.is_dead_was_symp().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredButSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_recovered();
			person.is_dead_was_symp().Should().BeFalse();
		}

		[Test]
		public void WhenImmuneAtStart_ReturnFalse() {
			var person = new Person();
			person.set_immune_at_start();
			person.is_dead_was_symp().Should().BeFalse();
		}

		[Test]
		public void WhenDead_ReturnFalse() {
			var person = new Person();
			person.set_dead();
			person.is_dead_was_symp().Should().BeFalse();
		}

		[Test]
		public void WhenDeadAndWasSick_ReturnTrue() {
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
		public void WhenSusceptible_ReturnFalse() {
			var person = new Person();
			person.set_susceptible();
			person.is_immune_at_start().Should().BeFalse();
		}

		[Test]
		public void WhenLatent_ReturnFalse() {
			var person = new Person();
			person.set_latent();
			person.is_immune_at_start().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAlmostSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_infectious_almost_symptomatic();
			person.is_immune_at_start().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAsymptomaticNotCase_ReturnFalse() {
			var person = new Person();
			person.set_infectious_asymptomatic_not_case();
			person.is_immune_at_start().Should().BeFalse();
		}

		[Test]
		public void WhenACase_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.is_immune_at_start().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredAndAsymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_recovered();
			person.is_immune_at_start().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredButSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_recovered();
			person.is_immune_at_start().Should().BeFalse();
		}

		[Test]
		public void WhenImmuneAtStart_ReturnTrue() {
			var person = new Person();
			person.set_immune_at_start();
			person.is_immune_at_start().Should().BeTrue();
		}

		[Test]
		public void WhenDead_ReturnFalse() {
			var person = new Person();
			person.set_dead();
			person.is_immune_at_start().Should().BeFalse();
		}

		[Test]
		public void WhenDeadAndWasSick_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_dead();
			person.is_immune_at_start().Should().BeFalse();
		}
	}

	[TestFixture]
	public class Person_is_infectious_asymptomatic_not_case_tests : Person_tests {
		[Test]
		public void InitiallyFalse() {
			var person = new Person();
			person.is_infectious_asymptomatic_not_case().Should().BeFalse();
		}

		[Test]
		public void WhenSusceptible_ReturnFalse() {
			var person = new Person();
			person.set_susceptible();
			person.is_infectious_asymptomatic_not_case().Should().BeFalse();
		}

		[Test]
		public void WhenLatent_ReturnFalse() {
			var person = new Person();
			person.set_latent();
			person.is_infectious_asymptomatic_not_case().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAlmostSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_infectious_almost_symptomatic();
			person.is_infectious_asymptomatic_not_case().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAsymptomaticNotCase_ReturnTrue() {
			var person = new Person();
			person.set_infectious_asymptomatic_not_case();
			person.is_infectious_asymptomatic_not_case().Should().BeTrue();
		}

		[Test]
		public void WhenACase_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.is_infectious_asymptomatic_not_case().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredAndAsymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_recovered();
			person.is_infectious_asymptomatic_not_case().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredButSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_recovered();
			person.is_infectious_asymptomatic_not_case().Should().BeFalse();
		}

		[Test]
		public void WhenImmuneAtStart_ReturnFalse() {
			var person = new Person();
			person.set_immune_at_start();
			person.is_infectious_asymptomatic_not_case().Should().BeFalse();
		}

		[Test]
		public void WhenDead_ReturnFalse() {
			var person = new Person();
			person.set_dead();
			person.is_infectious_asymptomatic_not_case().Should().BeFalse();
		}

		[Test]
		public void WhenDeadAndWasSick_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_dead();
			person.is_infectious_asymptomatic_not_case().Should().BeFalse();
		}
	}

	[TestFixture]
	public class Person_is_infectious_almost_symptomatic_tests : Person_tests {
		[Test]
		public void InitiallyFalse() {
			var person = new Person();
			person.is_infectious_almost_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenSusceptible_ReturnFalse() {
			var person = new Person();
			person.set_susceptible();
			person.is_infectious_almost_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenLatent_ReturnFalse() {
			var person = new Person();
			person.set_latent();
			person.is_infectious_almost_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAlmostSymptomatic_ReturnTrue() {
			var person = new Person();
			person.set_infectious_almost_symptomatic();
			person.is_infectious_almost_symptomatic().Should().BeTrue();
		}

		[Test]
		public void WhenInfectiousAsymptomaticNotCase_ReturnFalse() {
			var person = new Person();
			person.set_infectious_asymptomatic_not_case();
			person.is_infectious_almost_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenACase_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.is_infectious_almost_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredAndAsymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_recovered();
			person.is_infectious_almost_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredButSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_recovered();
			person.is_infectious_almost_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenImmuneAtStart_ReturnFalse() {
			var person = new Person();
			person.set_immune_at_start();
			person.is_infectious_almost_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenDead_ReturnFalse() {
			var person = new Person();
			person.set_dead();
			person.is_infectious_almost_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenDeadAndWasSick_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_dead();
			person.is_infectious_almost_symptomatic().Should().BeFalse();
		}
	}

	[TestFixture]
	public class Person_is_latent_tests : Person_tests {
		[Test]
		public void InitiallyFalse() {
			var person = new Person();
			person.is_latent().Should().BeFalse();
		}

		[Test]
		public void WhenSusceptible_ReturnFalse() {
			var person = new Person();
			person.set_susceptible();
			person.is_latent().Should().BeFalse();
		}

		[Test]
		public void WhenLatent_ReturnTrue() {
			var person = new Person();
			person.set_latent();
			person.is_latent().Should().BeTrue();
		}

		[Test]
		public void WhenInfectiousAlmostSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_infectious_almost_symptomatic();
			person.is_latent().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAsymptomaticNotCase_ReturnFalse() {
			var person = new Person();
			person.set_infectious_asymptomatic_not_case();
			person.is_latent().Should().BeFalse();
		}

		[Test]
		public void WhenACase_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.is_latent().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredAndAsymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_recovered();
			person.is_latent().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredButSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_recovered();
			person.is_latent().Should().BeFalse();
		}

		[Test]
		public void WhenImmuneAtStart_ReturnFalse() {
			var person = new Person();
			person.set_immune_at_start();
			person.is_latent().Should().BeFalse();
		}

		[Test]
		public void WhenDead_ReturnFalse() {
			var person = new Person();
			person.set_dead();
			person.is_latent().Should().BeFalse();
		}

		[Test]
		public void WhenDeadAndWasSick_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_dead();
			person.is_latent().Should().BeFalse();
		}
	}

	[TestFixture]
	public class Person_is_never_symptomatic_tests : Person_tests {
		[Test]
		public void InitiallyFalse() {
			var person = new Person();
			person.is_never_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenSusceptible_ReturnFalse() {
			var person = new Person();
			person.set_susceptible();
			person.is_never_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenLatent_ReturnTrue() {
			var person = new Person();
			person.set_latent();
			person.is_never_symptomatic().Should().BeTrue();
		}

		[Test]
		public void WhenInfectiousAlmostSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_infectious_almost_symptomatic();
			person.is_never_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenInfectiousAsymptomaticNotCase_ReturnTrue() {
			var person = new Person();
			person.set_infectious_asymptomatic_not_case();
			person.is_never_symptomatic().Should().BeTrue();
		}

		[Test]
		public void WhenACase_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.is_never_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredAndAsymptomatic_ReturnTrue() {
			var person = new Person();
			person.set_recovered();
			person.is_never_symptomatic().Should().BeTrue();
		}

		[Test]
		public void WhenRecoveredButSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_recovered();
			person.is_never_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenImmuneAtStart_ReturnTrue() {
			var person = new Person();
			person.set_immune_at_start();
			person.is_never_symptomatic().Should().BeTrue();
		}

		[Test]
		public void WhenDead_ReturnTrue() {
			var person = new Person();
			person.set_dead();
			person.is_never_symptomatic().Should().BeTrue();
		}

		[Test]
		public void WhenDeadAndWasSick_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_dead();
			person.is_never_symptomatic().Should().BeFalse();
		}
	}

	[TestFixture]
	public class Person_is_not_yet_symptomatic_tests : Person_tests {
		[Test]
		public void InitiallyTrue() {
			var person = new Person();
			person.is_not_yet_symptomatic().Should().BeTrue();
		}

		[Test]
		public void WhenSusceptible_ReturnTrue() {
			var person = new Person();
			person.set_susceptible();
			person.is_not_yet_symptomatic().Should().BeTrue();
		}

		[Test]
		public void WhenLatent_ReturnTrue() {
			var person = new Person();
			person.set_latent();
			person.is_not_yet_symptomatic().Should().BeTrue();
		}

		[Test]
		public void WhenInfectiousAlmostSymptomatic_ReturnTrue() {
			var person = new Person();
			person.set_infectious_almost_symptomatic();
			person.is_not_yet_symptomatic().Should().BeTrue();
		}

		[Test]
		public void WhenInfectiousAsymptomaticNotCase_ReturnFalse() {
			var person = new Person();
			person.set_infectious_asymptomatic_not_case();
			person.is_not_yet_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenACase_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.is_not_yet_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredAndAsymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_recovered();
			person.is_not_yet_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenRecoveredButSymptomatic_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_recovered();
			person.is_not_yet_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenImmuneAtStart_ReturnFalse() {
			var person = new Person();
			person.set_immune_at_start();
			person.is_not_yet_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenDead_ReturnFalse() {
			var person = new Person();
			person.set_dead();
			person.is_not_yet_symptomatic().Should().BeFalse();
		}

		[Test]
		public void WhenDeadAndWasSick_ReturnFalse() {
			var person = new Person();
			person.set_case();
			person.set_dead();
			person.is_not_yet_symptomatic().Should().BeFalse();
		}
	}
}
