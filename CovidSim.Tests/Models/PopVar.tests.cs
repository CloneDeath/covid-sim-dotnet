using CovidSim.Models;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.Models;

[TestFixture]
public class PopVar_tests {
	[Test]
	public void ConstructorWorks() {
		var var = new PopVar();
		var.cumC_country.Should().HaveCount(Country.MAX_COUNTRIES);
		var.cumIa.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		var.cumCa.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		var.cumDa.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		var.cumI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumC_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumD_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumT_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumH_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumDC_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumCT_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumCC_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.trigDC_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumDCT_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.DCT_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumItype.Should().HaveCount(Constants.INFECT_TYPE_MASK);
		var.cumI_keyworker.Should().HaveCount(2);
		var.cumC_keyworker.Should().HaveCount(2);
		var.cumT_keyworker.Should().HaveCount(2);
		var.inf_queue.Should().HaveCount(Constants.MAX_NUM_THREADS);
		var.n_queue.Should().HaveCount(Constants.MAX_NUM_THREADS);
		var.host_closure_queue.Should().BeEmpty();
		var.p_queue.Should().HaveCount(Country.MAX_NUM_PLACE_TYPES);
		var.pg_queue.Should().HaveCount(Country.MAX_NUM_PLACE_TYPES);
		var.np_queue.Should().HaveCount(Country.MAX_NUM_PLACE_TYPES);
		var.NumPlacesClosed.Should().HaveCount(Country.MAX_NUM_PLACE_TYPES);
		var.cell_inf.Should().BeEmpty();
		var.CellMemberArray.Should().BeEmpty();
		var.CellSuscMemberArray.Should().BeEmpty();
		var.InvAgeDist.Should().BeEmpty();
		var.mvacc_queue.Should().BeEmpty();
		var.nct_queue.Should().HaveCount(Country.MAX_ADUNITS);
		var.dct_queue.Should().HaveCount(Country.MAX_ADUNITS);
		var.ndct_queue.Should().HaveCount(Country.MAX_ADUNITS);
		var.contact_dist.Should().HaveCount(Constants.MAX_CONTACTS+1);
		var.origin_dest.Should().HaveCount(Country.MAX_ADUNITS);
		var.Mild_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.ILI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.SARI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.Critical_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.CritRecov_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumMild_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumILI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumSARI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumCritical_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumCritRecov_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.Mild_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		var.ILI_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		var.SARI_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		var.Critical_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		var.CritRecov_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		var.cumMild_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		var.cumILI_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		var.cumSARI_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		var.cumCritical_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		var.cumCritRecov_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		var.cumDeath_ILI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumDeath_SARI_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumDeath_Critical_adunit.Should().HaveCount(Country.MAX_ADUNITS);
		var.cumDeath_ILI_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		var.cumDeath_SARI_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		var.cumDeath_Critical_age.Should().HaveCount(Constants.NUM_AGE_GROUPS);
		var.prevInf_age_adunit.Should().BeEmpty();
		var.cumInf_age_adunit.Should().BeEmpty();
	}
}
