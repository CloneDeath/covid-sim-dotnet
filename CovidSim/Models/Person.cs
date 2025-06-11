namespace CovidSim.Models;

public class Person {
	private InfStat inf;

	/* the place cell that person belongs to. Cells[person->pcell] holds this person */
	public int pcell;
	/* microcell that person belongs to., Mcells[person->mcell] holds this person */
	public int mcell;
	/* household that person belongs to. Household[person->hh] holds this person */
	public int hh;
	/* If >=0, Hosts[person->infector] was who infected this person */
	public int infector;
	/* Goes up to at least MAX_SEC_REC, also used as a temp variable? */
	public int listpos;

	//// indexed by i) place type. Value is the number of that place type (e.g., school no. 17; office no. 310 etc.) Place[i][person->PlaceLinks[i]], can be up to P.Nplace[i]
	public int[] PlaceLinks = [Country.MAX_NUM_PLACE_TYPES];
	public float infectiousness;
	public float susc;
	public float ProbAbsent;
	public float ProbCare;

	// boolean: compliant with enhanced social distancing?
	public uint esocdist_comply = 1;
	// also used to binary index cumI_keyworker[] and related arrays
	public uint keyworker = 1;
	public uint to_die = 1;
	// added the hospitalization flag: ggilani 28/10/2014, added this flag to determine whether this person's infection is detected or not
	public uint detected = 1;
	// boolean: care home resident?
	public uint care_home_resident = 1;
	// can be 0, 1, or 2
	public uint quar_comply = 2;
	// boolean: digitalContactTracingUser?
	public uint digitalContactTracingUser = 1;
	// boolean: digitalContactTraced?
	public uint digitalContactTraced = 1;
	public uint index_case_dct = 2;

	// Range up to MAX_TRAVEL_TIME
	public byte Travelling;
	public byte age;
	// set to 0 and tested < 2. but never modified?
	public byte num_treats;
	// These can definitely get > 255
	public ushort[] PlaceGroupLinks = [Country.MAX_NUM_PLACE_TYPES];

	// INFECT_TYPE_MASK
	public short infect_type;

	public Severity Severity_Current;
	//// Note we allow Severity_Final to take values: Severity_Mild, Severity_ILI, Severity_SARI, Severity_Critical (not e.g., Severity_Dead or Severity_RecoveringFromCritical)
	public Severity Severity_Final;

	//added the hospitalization flag: ggilani 28/10/2014, added this flag to determine whether this person's infection is detected or not
	public ushort detected_time;
	public ushort absent_start_time, absent_stop_time;
	public ushort isolation_start_time;
	// Set in DoInfect function. infection time is the time of infection;
	public ushort infection_time;
	// latent_time is a misnomer - it is the time at which the person becomes infectious (i.e., infection time plus latent period for this person). latent_time will also refer to time of onset with ILI or Mild symptomatic disease.
	public ushort latent_time;
	// set in DoIncub function
	public ushort recovery_or_death_time;
	//// /*mild_time, ILI_time,*/ Time of infectiousness onset same for asymptomatic, Mild, and ILI infection so don't need mild_time etc.
	public ushort SARI_time;
	public ushort Critical_time;
	public ushort Stepdown_time;

	//// set in TreatSweep function.
	public ushort treat_start_time;
	public ushort treat_stop_time;
	public ushort vacc_start_time;

	//digital contact tracing start and end time: ggilani 10/03/20
	public ushort dct_start_time;
	public ushort dct_end_time;
	public ushort dct_trigger_time;
	public ushort dct_test_time;

	//added this in to record the total number of contacts each index case records: ggilani 13/04/20
	public int ncontacts;

	/**
	 * Query whether a host should be included in mass vaccination.
	 *           The conditions for not being vaccinated are either: the host is dead,
	 *           or the host is a current case, or the host has recovered from
	 *           a symptomatic infection.
	 * Returns  TRUE if this host should not be vaccinated for the above reasons.
	 */
	public bool do_not_vaccinate() =>
		// Originally: inf < InfStat.InfectiousAlmostSymptomatic) || (inf >= InfStat.Dead_WasAsymp)
		// i.e., inf is either < -1, or >= 5. (ie, -2, -3, -5, or 5. There is no status for -4)
		// 5 or -5 is "dead". -2 is "case". -3 is RecoveredFromSymp.
		is_dead() || is_case() || is_recovered_symp();

	/**
	 * Query whether a host is dead. This includes death through either
	 *  symptomatic or asymptomatic illness.
	 *  returns TRUE if the host is dead
	 */
	public bool is_dead() =>
		// In previous versions, this would have been abs(Hosts[i].inf) == InfStat.Dead
		inf == InfStat.Dead_WasSymp || inf == InfStat.Dead_WasAsymp;

	/**
	 * Query whether a host is alive. This includes all states except the
	 *           two death states (death through symptomatic, or asymptomatic illness).
	 * Returns  TRUE if this host is alive.
	 */
	public bool is_alive() => !is_dead();

	/**
	 * Query whether a host is a current case. (InfStat.Case)
	 * Returns TRUE if the host is a current case.
	 */
	public bool is_case() => inf == InfStat.Case;

	/**
	 * Query whether a host died with asymptomatic illness. (InfStat.Dead_WasAsymp)
	 * Returns TRUE if the host is dead and was asymptomatic.
	 */
	public bool is_dead_was_asymp() => inf == InfStat.Dead_WasAsymp;

	/**
	 * Query whether a host died with symptomatic illness. (InfStat.Dead_WasSymp)
	 * Returns TRUE if the host is dead and was asymptomatic.
	 */
	public bool is_dead_was_symp() => inf == InfStat.Dead_WasSymp;

	/**
	 * Query whether a host was immune at the start of the epidemic. (InfStat.ImmuneAtStart)
	 * Returns TRUE if the host was already immune.
	 */
	public bool is_immune_at_start() => inf == InfStat.ImmuneAtStart;

	/**
	 * Query whether an infected host is asymptomatic, hence not a case. (InfStat.InfectiousAsymptomaticNotCase)
	 * Returns TRUE if a host is infectious but asymptomatic.
	 */
	public bool is_infectious_asymptomatic_not_case() => inf == InfStat.InfectiousAsymptomaticNotCase;

	/**
	 * Query whether an infected host is about to become symptomatic. (InfStat.InfectiousAlmostSymptomatic)
	 * Returns TRUE if the host is about to become symptomatic.
	 */
	public bool is_infectious_almost_symptomatic() => inf == InfStat.InfectiousAlmostSymptomatic;

	/**
	 * Query whether an infected host is in the latent period. (InfStat.Latent)
	 * Returns TRUE if the host is in a latent period.
	 */
	public bool is_latent() => inf == InfStat.Latent;

	/**
	 * Query whether an infected host is (currently) symptomatic or ever has been. Acceptable states are:
	 *           Latent, Infectious Asymptomatic, Infectious Almost Symptomatic, Recovered from Asymptomatic infection,
	 *           or died from Asymptomatic infection.
	 * Returns TRUE if the host is not, and never was, symptomatic.
	 */
	public bool is_never_symptomatic() =>
		// In earlier code, this was written as (inf > 0) - all the positive numbered states.
		inf == InfStat.Latent || inf == InfStat.InfectiousAsymptomaticNotCase ||
		inf == InfStat.RecoveredFromAsymp || inf == InfStat.ImmuneAtStart ||
		inf == InfStat.Dead_WasAsymp;

	/**
	 * Query whether an infected host is not yet symptomatic but could become so. Acceptable states are latent, susceptible, or
	 *           Infectious Almost Symptomatic.
	 * Returns TRUE if the host is infected but not yet symptomatic.
	 */
	public bool is_not_yet_symptomatic() =>
		inf == InfStat.Susceptible ||
		inf == InfStat.Latent ||
		inf == InfStat.InfectiousAlmostSymptomatic;

	/**
	 * Query whether an infected host is a current or potential host for the epidemic. This excludes all who have recovered,
	 *           died, or were immune at the start.
	 * Returns TRUE if the host is susceptible or currently infected.
	 */
	public bool is_susceptible_or_infected() =>
		// In old versions, this would be abs(inf]) < InfStat.Recovered, so states included
		// Would be 0, +/- 1, and +/- 2, which in order are...
		inf == InfStat.Susceptible ||
		inf == InfStat.Latent || inf == InfStat.InfectiousAlmostSymptomatic ||
		inf == InfStat.InfectiousAsymptomaticNotCase || inf == InfStat.Case;

	/**
	 * Query whether a host has recovered from infection. This includes recovery from both symptomatic and asymptomatic
	 *           infections.
	 * Returns TRUE if the host has recovered from symptomatic or asymptomatic infection.
	 */
	public bool is_recovered() =>
		// In previous versions, abs(Hosts[i].inf) == InfStat.Recovered
		inf == InfStat.RecoveredFromSymp || inf == InfStat.RecoveredFromAsymp;

	/**
	 * Query whether a host has recovered from a symptomatic infection.
	 * Returns TRUE only if the host has recovered from symptomatic infection.
	 */
	public bool is_recovered_symp() => inf == InfStat.RecoveredFromSymp;

	/**
	 * Query whether a host is susceptible.
	 * Returns TRUE only if the host is in the susceptible state.
	 */
	public bool is_susceptible() => inf == InfStat.Susceptible;

	// Set host to be a case. (See InfStat.Case)
	public void set_case() {
		inf = InfStat.Case;
	}

	/**
	 * Set host to have died.
	 * For infections that were symptomatic, (i.e., they passed through the InfStat.Case state),
	 * the death state is InfStat.DeadWasSymp. Otherwise (i.e., they passed through InfStat.InfectiousAsymptomaticNotCase),
	 * the death state is InfStat.DeadWasAsymp.
	 */
	public void set_dead() {
		/*	In earlier code, this would be: inf = (InfStat)(InfStat_Dead * inf / abs(inf));
			Where inf / abs(inf) becomes +/- 1. So dead state has same sign as incoming state.

			Additionally, death only happens from two states: Case and InfectiousAsymptomaticNotCase,
			so the only valid incoming states are +/- 2. Hence, it is sufficient to say:-
		*/
		inf = inf == InfStat.Case ? InfStat.Dead_WasSymp : InfStat.Dead_WasAsymp;
	}

	// Set host to be initially immune. (See InfStat.ImmuneAtStart)
	public void set_immune_at_start() {
		inf = InfStat.ImmuneAtStart;
	}

	// Set host to be infectious and about to become symptomatic. (See InfStat.InfectiousAlmostSymptomatic)
	public void set_infectious_almost_symptomatic() {
		inf = InfStat.InfectiousAlmostSymptomatic;
	}

	// Set host to be infectious, but asymptomatic, so not defined as a case. (See InfStat.InfectiousAsymptomaticNotCase)
	public void set_infectious_asymptomatic_not_case() {
		inf = InfStat.InfectiousAsymptomaticNotCase;
	}

	// Set host to be in latent stage. (See InfStat.Latent)
	public void set_latent() {
		inf = InfStat.Latent;
	}

	/**
	 * Set host to be recovered.
	 * For infections that were symptomatic, (i.e., they passed through the InfStat.Case state),
	 * the recovery state is InfStat.RecoveredFromSymp. Otherwise (i.e., they passed through InfStat.InfectiousAsymptomaticNotCase),
	 * the recovery state is InfStat.RecoveredFromAsymp.
	 */
	public void set_recovered() {
		/*	Similar to deaths, this used to be: inf = (InfStat)(InfStat.Recovered * inf / abs(inf));
			Where inf / abs(inf) becomes +/- 1. So resulting state has same sign as incoming state.

			Recovery only happens from the same two states as death: Case and InfectiousAsymptomaticNotCase,
			so the only valid incoming states are +/- 2. Hence, it is sufficient to say:-
		*/

		inf = inf == InfStat.Case ? InfStat.RecoveredFromSymp : InfStat.RecoveredFromAsymp;
	}

	// Set host to be susceptible. (See InfStat.Susceptible)
	public void set_susceptible() {
		inf = InfStat.Susceptible;
	}
}
