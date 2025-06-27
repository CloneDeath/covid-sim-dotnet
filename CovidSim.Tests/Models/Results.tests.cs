using CovidSim.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Models;

[TestFixture]
public class Results_tests {
	[Test]
	public void ConstructorWorks() {
		var results = new Results();
		results.prevInf_age_adunit.Should().BeEmpty();
		results.incInf_age_adunit.Should().BeEmpty();
		results.cumInf_age_adunit.Should().BeEmpty();
		results.incC_country.Should().HaveCount(Country.MAX_COUNTRIES);
		results.incIa.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.incCa.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.incDa.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.incItype.Should().HaveCount(Constants.INFECT_TYPE_MASK);
		results.Rtype.Should().HaveCount(Constants.INFECT_TYPE_MASK);
		results.Rage.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.PropPlacesClosed.Should().HaveCount(Country.MAX_NUM_PLACE_TYPES);
		results.incI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.incC_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.cumT_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.incD_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.cumD_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.incH_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.incDC_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.incCT_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.incCC_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.incDCT_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.DCT_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.incI_keyworker.Should().HaveCount(2);
		results.incC_keyworker.Should().HaveCount(2);
		results.cumT_keyworker.Should().HaveCount(2);
		results.Mild_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.ILI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.SARI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.Critical_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.CritRecov_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.incMild_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.incILI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.incSARI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.incCritical_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.incCritRecov_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.cumMild_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.cumILI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.cumSARI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.cumCritical_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.cumCritRecov_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.incDeath_ILI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.incDeath_SARI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.incDeath_Critical_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.cumDeath_ILI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.cumDeath_SARI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.cumDeath_Critical_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		results.Mild_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.ILI_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.SARI_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.Critical_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.CritRecov_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.incMild_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.incILI_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.incSARI_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.incCritical_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.incCritRecov_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.cumMild_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.cumILI_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.cumSARI_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.cumCritical_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.cumCritRecov_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.incDeath_ILI_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.incDeath_SARI_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.incDeath_Critical_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.cumDeath_ILI_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.cumDeath_SARI_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		results.cumDeath_Critical_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
	}
}
