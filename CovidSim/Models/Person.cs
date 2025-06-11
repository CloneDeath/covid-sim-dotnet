namespace CovidSim.Models;

public class Person
{
	/* place cell that person belongs to. Cells[person->pcell] holds this person */
	public int pcell;
	/* microcell that person belongs to., Mcells[person->mcell] holds this person */
	public int mcell;
	/* household that person belongs to. Household[person->hh] holds this person */
	public int hh;
	/* If >=0, Hosts[person->infector] was who infected this person */
	public int infector;
	/* Goes up to at least MAX_SEC_REC, also used as a temp variable? */
	public int listpos;

	//// indexed by i) place type. Value is the number of that place type (e.g. school no. 17; office no. 310 etc.) Place[i][person->PlaceLinks[i]], can be up to P.Nplace[i]
	public int[] PlaceLinks = [Country.MAX_NUM_PLACE_TYPES];
	public float infectiousness;
	public float susc;
	public float ProbAbsent;
	public float ProbCare;

	/** boolean: compliant with enhanced social distancing? */
	public uint esocdist_comply = 1;
	// also used to binary index cumI_keyworker[] and related arrays
	public uint keyworker = 1;
	public uint to_die = 1;
	//added hospitalisation flag: ggilani 28/10/2014, added flag to determined whether this person's infection is detected or not
	public uint detected = 1;
	/** boolean: care home resident? */
	public uint care_home_resident = 1;
	// can be 0, 1, or 2
	public uint quar_comply = 2;
	/** boolean: digitalContactTracingUser? */
	public uint digitalContactTracingUser = 1;
	/** boolean: digitalContactTraced? */
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
	//// Note we allow Severity_Final to take values: Severity_Mild, Severity_ILI, Severity_SARI, Severity_Critical (not e.g. Severity_Dead or Severity_RecoveringFromCritical)
	public Severity Severity_Final;

	//added hospitalisation flag: ggilani 28/10/2014, added flag to determined whether this person's infection is detected or not
	public ushort detected_time;
	public ushort absent_start_time, absent_stop_time;
	public ushort isolation_start_time;
	// Set in DoInfect function. infection time is time of infection;
	public ushort infection_time;
	// latent_time is a misnomer - it is the time at which person become infectious (i.e. infection time + latent period for this person). latent_time will also refer to time of onset with ILI or Mild symptomatic disease.
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

	//added this in to record total number of contacts each index case records: ggilani 13/04/20
	public int ncontacts;

	/** \brief  Query whether a host should be included in mass vaccination.
	*           The conditions for not being vaccinated are either: the host is dead,
	*           or the host is a current case, or the host has recovered from
	*           a symptomatic infection.
	*  \return  TRUE if this host should not be vaccinated for the above reasons.
	*/
	public bool do_not_vaccinate() {

	}

	/** \brief  Query whether a host is alive. This includes all states except the
	*           two death states (death through symptomatic, or asymptomatic illness).
	*  \return  TRUE if this host is alive.
	*/
	bool is_alive() const;

	/** \brief  Query whether a host is a current case. (InfStat::Case)
	*   \return TRUE if the host is a current case.
    */
	bool is_case() const;

	/** \brief  Query whether a host is dead. This includes death through either
	*           symptomatic or asymptomatic illess.
	*   \return TRUE if the host is dead
	*/
	bool is_dead() const;

	/** \brief  Query whether a host died with asymptomatic illness. (InfStat::Dead_WasAsymp)
	*   \return TRUE if the host is dead and was asymptomatic.
	*/
	bool is_dead_was_asymp() const;

	/** \brief  Query whether a host died with symptomatic illness. (InfStat::Dead_WasSymp)
	*   \return TRUE if the host is dead and was asymptomatic.
	*/
	bool is_dead_was_symp() const;

	/** \brief  Query whether a host was immune at the start of the epidemic. (InfStat::ImmuneAtStart)
	*   \return TRUE if the host was already immune.
	*/
	bool is_immune_at_start() const;

	/** \brief  Query whether an infected host is asymptomatic, hence not a case. (InfStat::InfectiousAsymptomaticNotCase)
	*   \return TRUE if a host is infectious but asymptomatic.
	*/
	bool is_infectious_asymptomatic_not_case() const;

	/** \brief  Query whether an infected host is about to become symptomatic. (InfStat::InfectiousAlmostSymptomatic)
	*   \return TRUE if the host is about to become symptomatic.
	*/
	bool is_infectious_almost_symptomatic() const;

	/** \brief  Query whether an infected host is in the latent period. (InfStat::Latent)
	*   \return TRUE if the host is in latent period.
	*/
	bool is_latent() const;

	/** \brief  Query whether an infected host is (currently) symptomic, or ever has been. Acceptable states are:
	*           Latent, Infectious Asymptomatic, Infectious Almost Symptomatic, Recovered from Asymptomatic infection,
	*           or died from Asymptomatic infection.
	*   \return TRUE if the host is not, and never was symptomatic.
	*/
	bool is_never_symptomatic() const;

	/** \brief  Query whether an infected host is not yet symptomatic, but could become so. Acceptable states are latent, susceptible, or
	*           Infectious Almost Symptomatic.
	*   \return TRUE if the host is infected but not yet symptomatic.
	*/
	bool is_not_yet_symptomatic() const;

	/** \brief  Query whether an infected host is a current or potential host for the epidemic. This excludes all who have recovered,
	*           died, or were immune at the start.
	*   \return TRUE if the host is susceptible, or currently infected.
	*/
	bool is_susceptible_or_infected() const;

	/** \brief  Query whether a host has recovered from infection. This includes recovery from both symptomatic and asymptomatic
	*           infections.
	*   \return TRUE if the host has recovered from symptomatic or asymptomatic infection.
	*/
	bool is_recovered() const;

	/** \brief  Query whether a host has recovered from a symptomatic infection.
	*   \return TRUE only if the host has recovered from symptomatic infection.
	*/
	bool is_recovered_symp() const;

	/** \brief  Query whether a host is susceptible.
	*   \return TRUE only if the host is in the susceptible state.
	*/
	bool is_susceptible() const;

	/** \brief  Set host to be a case. (See InfStat::Case)
	*/
	void set_case();

	/** \brief  Set host to have died.
	 *  For infections that were symptomatic, (ie, they passed through the InfStat::Case state),
	 *  the death state is InfStat::DeadWasSymp. Otherwise (ie, they passed through InfStat::InfectiousAsymptomaticNotCase),
	 *  the death state is InfStat::DeadWasAsymp.
	*/
	void set_dead();

	/** \brief  Set host to be initially immune. (See InfStat::ImmuneAtStart)
	*/
	void set_immune_at_start();

	/** \brief  Set host to be infectious, and about to become symptomatic. (See InfStat::InfectiousAlmostSymptomatic)
	*/
	void set_infectious_almost_symptomatic();

	/** \brief  Set host to be infectious, but asymptomatic, so not defined as a case. (See InfStat::InfectiousAsymptomaticNotCase)
	*/
	void set_infectious_asymptomatic_not_case();

	/** \brief  Set host to be in latent stage. (See InfStat::Latent)
	*/
	void set_latent();

	/** \brief  Set host to be recovered.
	*  For infections that were symptomatic, (ie, they passed through the InfStat::Case state),
	*  the recovery state is InfStat::RecoveredFromSymp. Otherwise (ie, they passed through InfStat::InfectiousAsymptomaticNotCase),
	*  the recovery state is InfStat::RecoveredFromAsymp.
	*/
	void set_recovered();

	/** \brief  Set host to be susceptible. (See InfStat::Susceptible)
	*/
	void set_susceptible();

private:
	InfStat inf;

};
