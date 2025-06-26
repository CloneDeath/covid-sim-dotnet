using System.Runtime.InteropServices;

namespace CovidSim.Models;

/**
 * @brief Recorded time-series variables (typically populated from the `POPVAR` state)
 *
 * In the function `RecordSample` we transform (copy parts, calculate summary statistics)
 * of the `POPVAR` state into a time-stamped `RESULTS` structure.
 *
 * NOTE: This struct must contain only doubles (and arrays of doubles) for the TSMean
 * 	     averaging code to work.
 */
[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct Results() {
	// Initial values should not be touched by mean/var calculation
	public double t;
	// prevalence, incidence, and cumulative incidence of infection by age and admin unit.
	public double[][] prevInf_age_adunit = [];
	public double[][] incInf_age_adunit = [];
	public double[][] cumInf_age_adunit = [];

	// The following values must all be doubles or inline arrays of doubles
	// The first variable must be S.  If that changes change the definition of
	// ResultsDoubleOffsetStart below.
	public double S;
	public double L;
	public double I;
	public double R;
	public double D;
	public double incC;
	public double incTC;
	public double incFC;
	public double incI;
	public double incR;
	public double incD;
	public double incDC;
	public double meanTG;
	public double meanSI ;
	//added total numbers being contact traced and incidence of contact tracing: ggilani 15/06/17, and for digital contact tracing: ggilani 11/03/20
	public double CT;
	public double incCT;
	public double incCC;
	public double DCT;
	public double incDCT;
	//added incidence of cases
	public double[] incC_country = new double[Country.MAX_COUNTRIES];
	public double cumT;
	public double cumUT;
	public double cumTP;
	public double cumV;
	public double cumTmax;
	public double cumVmax;
	public double cumDC;
	public double extinct;
	public double cumVG;
	public double incHQ;
	public double incAC;
	public double incAH;
	public double incAA;
	public double incACS;
	public double incAPC;
	public double incAPA;
	public double incAPCS;
	public double[] incIa = new double[Constants.NUM_AGE_GROUPS];
	public double[] incCa = new double[Constants.NUM_AGE_GROUPS];
	public double[] incDa = new double[Constants.NUM_AGE_GROUPS];
	public double[] incItype = new double[Constants.INFECT_TYPE_MASK];
	public double[] Rtype = new double[Constants.INFECT_TYPE_MASK];
	public double[] Rage = new double[Constants.NUM_AGE_GROUPS];
	public double Rdenom;
	public double rmsRad;
	public double maxRad;
	public double[] PropPlacesClosed = new double[Country.MAX_NUM_PLACE_TYPES];
	public double PropSocDist;
	//added incidence of hospitalisation per day: ggilani 28/10/14, incidence of detected cases per adunit,: ggilani 03/02/15
	public double[] incI_adunit = new double[Country.MAX_ADUNITS];
	public double[] incC_adunit = new double[Country.MAX_ADUNITS];
	public double[] cumT_adunit = new double[Country.MAX_ADUNITS];
	public double[] incD_adunit = new double[Country.MAX_ADUNITS];
	public double[] cumD_adunit = new double[Country.MAX_ADUNITS];
	public double[] incH_adunit = new double[Country.MAX_ADUNITS];
	public double[] incDC_adunit = new double[Country.MAX_ADUNITS];

	//added incidence of contact tracing and number of people being contact traced per admin unit: ggilani 15/06/17
	public double[] incCT_adunit = new double[Country.MAX_ADUNITS];
	public double[] incCC_adunit = new double[Country.MAX_ADUNITS];
	public double[] incDCT_adunit = new double[Country.MAX_ADUNITS];
	public double[] DCT_adunit = new double[Country.MAX_ADUNITS];
	public double[] incI_keyworker = new double[2];
	public double[] incC_keyworker = new double[2];
	public double[] cumT_keyworker = new double[2];

	///@{
	/** Severity States track the COVID-19 states (e.g., mild, critical, etc.) */
	// Prevalence				//// Must be: i) initialised to zero in SetUpModel. ii) outputted in SaveResults iii) outputted in SaveSummaryResults
	public double Mild;
	public double ILI;
	public double SARI;
	public double Critical;
	public double CritRecov;

	// Incidence				//// Must be: i) initialised to zero in SetUpModel. ii) calculated in RecordSample iii) outputted in SaveResults.
	public double incMild;
	public double incILI;
	public double incSARI;
	public double incCritical;
	public double incCritRecov;

	// cumulative incidence		//// Must be: i) initialised to zero in SetUpModel. ii) outputted in SaveResults
	public double cumMild;
	public double cumILI;
	public double cumSARI;
	public double cumCritical;
	public double cumCritRecov;

	// tracks incidence of death from ILI, SARI & Critical severities
	public double incDeath_ILI;
	public double incDeath_SARI;
	public double incDeath_Critical;

	// tracks cumulative deaths from ILI, SARI & Critical severities
	public double cumDeath_ILI;
	public double cumDeath_SARI;
	public double cumDeath_Critical;
	///@}

	/////// Severity States by admin unit
	// Prevalence by admin unit
	public double[] Mild_adunit = new double[Country.MAX_ADUNITS];
	public double[] ILI_adunit = new double[Country.MAX_ADUNITS];
	public double[] SARI_adunit = new double[Country.MAX_ADUNITS];
	public double[] Critical_adunit = new double[Country.MAX_ADUNITS];
	public double[] CritRecov_adunit = new double[Country.MAX_ADUNITS];

	// incidence by admin unit
	public double[] incMild_adunit = new double[Country.MAX_ADUNITS];
	public double[] incILI_adunit = new double[Country.MAX_ADUNITS];
	public double[] incSARI_adunit = new double[Country.MAX_ADUNITS];
	public double[] incCritical_adunit = new double[Country.MAX_ADUNITS];
	public double[] incCritRecov_adunit = new double[Country.MAX_ADUNITS];

	// cumulative incidence by admin unit
	public double[] cumMild_adunit = new double[Country.MAX_ADUNITS];
	public double[] cumILI_adunit = new double[Country.MAX_ADUNITS];
	public double[] cumSARI_adunit = new double[Country.MAX_ADUNITS];
	public double[] cumCritical_adunit = new double[Country.MAX_ADUNITS];
	public double[] cumCritRecov_adunit = new double[Country.MAX_ADUNITS];

	// tracks incidence of death from ILI, SARI & Critical severities
	public double[] incDeath_ILI_adunit = new double[Country.MAX_ADUNITS];
	public double[] incDeath_SARI_adunit = new double[Country.MAX_ADUNITS];
	public double[] incDeath_Critical_adunit = new double[Country.MAX_ADUNITS];

	// tracks cumulative deaths from ILI, SARI & Critical severities
	public double[] cumDeath_ILI_adunit = new double[Country.MAX_ADUNITS];
	public double[] cumDeath_SARI_adunit = new double[Country.MAX_ADUNITS];
	public double[] cumDeath_Critical_adunit = new double[Country.MAX_ADUNITS];

	/////// Severity States by age group
	// Prevalence by admin unit
	public double[] Mild_age = new double[Constants.NUM_AGE_GROUPS];
	public double[] ILI_age = new double[Constants.NUM_AGE_GROUPS];
	public double[] SARI_age = new double[Constants.NUM_AGE_GROUPS];
	public double[] Critical_age = new double[Constants.NUM_AGE_GROUPS];
	public double[] CritRecov_age = new double[Constants.NUM_AGE_GROUPS];

	// incidence by admin unit
	public double[] incMild_age = new double[Constants.NUM_AGE_GROUPS];
	public double[] incILI_age = new double[Constants.NUM_AGE_GROUPS];
	public double[] incSARI_age = new double[Constants.NUM_AGE_GROUPS];
	public double[] incCritical_age = new double[Constants.NUM_AGE_GROUPS];
	public double[] incCritRecov_age = new double[Constants.NUM_AGE_GROUPS];

	// cumulative incidence by admin unit
	public double[] cumMild_age = new double[Constants.NUM_AGE_GROUPS];
	public double[] cumILI_age = new double[Constants.NUM_AGE_GROUPS];
	public double[] cumSARI_age = new double[Constants.NUM_AGE_GROUPS];
	public double[] cumCritical_age = new double[Constants.NUM_AGE_GROUPS];
	public double[] cumCritRecov_age = new double[Constants.NUM_AGE_GROUPS];

	// tracks incidence of death from ILI, SARI & Critical severities
	public double[] incDeath_ILI_age = new double[Constants.NUM_AGE_GROUPS];
	public double[] incDeath_SARI_age = new double[Constants.NUM_AGE_GROUPS];
	public double[] incDeath_Critical_age = new double[Constants.NUM_AGE_GROUPS];

	// tracks cumulative deaths from ILI, SARI & Critical severities
	public double[] cumDeath_ILI_age = new double[Constants.NUM_AGE_GROUPS];
	public double[] cumDeath_SARI_age = new double[Constants.NUM_AGE_GROUPS];
	public double[] cumDeath_Critical_age = new double[Constants.NUM_AGE_GROUPS];

	// Which people are under quarantine but not themselves infected/sypmtomatic?
	public double prevQuarNotInfected;
	public double prevQuarNotSymptomatic;

	/////// possibly need quantities by age (later)
	//// state variables (S, L, I, R) and therefore (Mild, ILI) etc. changed in i) SetUpModel (initialised to zero); ii)

	//// above quantities need to be amended in following parts of code:
	//// i) SetUpModel (set to zero);
	//// ii) RecordSample: add to incidence / Timeseries).
	//// iii) SaveResults and SaveSummary results.
	///// need to update these quantities in InitModel (DONE), Record Sample (DONE) (and of course places where you need to increment, decrement).

}
