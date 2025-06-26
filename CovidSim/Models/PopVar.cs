using System.Runtime.InteropServices;

namespace CovidSim.Models;

/**
 * The global state of the model.
 */
[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct PopVar() {
	public int S;
	public int L;
	public int I;
	public int R;
	public int D;
	public int cumI;
	public int cumR;
	public int cumD;
	public int cumC;
	public int cumTC;
	public int cumFC;
	public int cumDC;
	public int trigDetectedCases;
	public int cumTG;
	public int cumSI;
	public int nTG;

	//Added cumulative hospitalisation: ggilani 28/10/14
	public int cumH;

	// Added total and cumulative contact tracing: ggilani 15/06/17, and equivalents for digital contact tracing: ggilani 11/03/20
	public int cumCT;
	public int cumCC;
	public int DCT;
	public int cumDCT;

	//added cumulative cases by country: ggilani 12/11/14
	public int[] cumC_country = new int[Country.MAX_COUNTRIES];

	// age specific versions of above variables. e.g. cumI is cumulative infections. cumIa is cumulative infections by age group.
	public int cumHQ;
	public int cumAC;
	public int cumAA;
	public int cumAH;
	public int cumACS;
	public int cumAPC;
	public int cumAPA;
	public int cumAPCS;

	public int[] cumIa = new int[Constants.NUM_AGE_GROUPS];
	public int[] cumCa = new int[Constants.NUM_AGE_GROUPS];
	public int[] cumDa = new int[Constants.NUM_AGE_GROUPS];

	// added cumulative hospitalisation per admin unit: ggilani 28/10/14, cumulative detected cases per adunit: ggilani 03/02/15
	public int[] cumI_adunit = new int[Country.MAX_ADUNITS];
	public int[] cumC_adunit = new int[Country.MAX_ADUNITS];
	public int[] cumD_adunit = new int[Country.MAX_ADUNITS];
	public int[] cumT_adunit = new int[Country.MAX_ADUNITS];
	public int[] cumH_adunit = new int[Country.MAX_ADUNITS];
	public int[] cumDC_adunit = new int[Country.MAX_ADUNITS];

	//added cumulative CT per admin unit: ggilani 15/06/17
	public int[] cumCT_adunit = new int[Country.MAX_ADUNITS];
	public int[] cumCC_adunit = new int[Country.MAX_ADUNITS];
	public int[] trigDC_adunit = new int[Country.MAX_ADUNITS];

	//added cumulative and overall digital contact tracing per adunit: ggilani 11/03/20
	public int[] cumDCT_adunit = new int[Country.MAX_ADUNITS];
	public int[] DCT_adunit = new int[Country.MAX_ADUNITS];
	public int[] cumItype = new int[Constants.INFECT_TYPE_MASK];
	public int[] cumI_keyworker = new int[2];
	public int[] cumC_keyworker = new int[2];
	public int[] cumT_keyworker = new int[2];

	// the queue (i.e. list) of infections. 1st index is thread, 2nd is person.
	public Infection[] inf_queue = new Infection[Constants.MAX_NUM_THREADS];

	// number of infections in inf_queue
	public int[] n_queue = new int[Constants.MAX_NUM_THREADS];

	// When places close, buffer host index, and closure times here.
	public HostClosure[] host_closure_queue = [];

	// Number of host closures in host_closure_queue.
	public int host_closure_queue_size;

	// np_queue is number of places in place queue (by place type), p_queue, and pg_queue is the actual place and place-group queue (i.e. list) of places. 1st index is place type, 2nd is place.
	public int[] p_queue = new int[Country.MAX_NUM_PLACE_TYPES];
	public int[][] pg_queue = new int[Country.MAX_NUM_PLACE_TYPES][];
	public int[][] np_queue = new int[Country.MAX_NUM_PLACE_TYPES][];
	public int[] NumPlacesClosed = new int[Country.MAX_NUM_PLACE_TYPES];
	public int n_mvacc;
	public int mvacc_cum;

	//// List of cumulative spatial infectiousnesses by person within cell. Negative value will refer to that person having their place closed
	public float[] cell_inf = [];

	//added cumVG, cumVG_daily
	public double sumRad2;
	public double maxRad2;
	public double cumT;
	public double cumV;
	public double cumVG;
	public double cumUT;
	public double cumTP;
	public double cumV_daily;
	public double cumVG_daily;

	public int[] CellMemberArray = [];
	public int[] CellSuscMemberArray = [];
	public int[][] InvAgeDist = [];
	public int[] mvacc_queue = [];

	// queue for contact tracing: ggilani 12/06/17
	public int[] nct_queue = new int[Country.MAX_ADUNITS];
	//queues for digital contact tracing: ggilani 14/04/20
	public ContactEvent[] dct_queue = new ContactEvent[Country.MAX_ADUNITS];
	//queues for digital contact tracing: ggilani 10/03/20
	public int[] ndct_queue = new int[Country.MAX_ADUNITS];
	//added this to store contact distribution: ggilani 13/04/20
	public int[] contact_dist = new int[Constants.MAX_CONTACTS+1];
	//added intermediate storage for calculation of origin-destination matrix: ggilani 02/02/15
	public double[] origin_dest = new double[Country.MAX_ADUNITS];

	///// Prevalence quantities (+ by admin unit)
	public int Mild;
	public int ILI;
	public int SARI;
	public int Critical;
	public int CritRecov;
	/*cumulative incidence*/
	public int cumMild;
	public int cumILI;
	public int cumSARI;
	public int cumCritical;
	public int cumCritRecov;
	public int[] Mild_adunit = new int[Country.MAX_ADUNITS];
	public int[] ILI_adunit = new int[Country.MAX_ADUNITS];
	public int[] SARI_adunit = new int[Country.MAX_ADUNITS];
	public int[] Critical_adunit = new int[Country.MAX_ADUNITS];
	public int[] CritRecov_adunit = new int[Country.MAX_ADUNITS];
	/// cum incidence quantities. (+ by admin unit)
	public int[] cumMild_adunit = new int[Country.MAX_ADUNITS];
	public int[] cumILI_adunit = new int[Country.MAX_ADUNITS];
	public int[] cumSARI_adunit = new int[Country.MAX_ADUNITS];
	public int[] cumCritical_adunit = new int[Country.MAX_ADUNITS];
	public int[] cumCritRecov_adunit = new int[Country.MAX_ADUNITS];
	public int[] Mild_age = new int[Constants.NUM_AGE_GROUPS];
	public int[] ILI_age = new int[Constants.NUM_AGE_GROUPS];
	public int[] SARI_age = new int[Constants.NUM_AGE_GROUPS];
	public int[] Critical_age = new int[Constants.NUM_AGE_GROUPS];
	public int[] CritRecov_age = new int[Constants.NUM_AGE_GROUPS];
	/// cum incidence quantities. (+ by age group)
	public int[] cumMild_age = new int[Constants.NUM_AGE_GROUPS];
	public int[] cumILI_age = new int[Constants.NUM_AGE_GROUPS];
	public int[] cumSARI_age = new int[Constants.NUM_AGE_GROUPS];
	public int[] cumCritical_age = new int[Constants.NUM_AGE_GROUPS];
	public int[] cumCritRecov_age = new int[Constants.NUM_AGE_GROUPS];

	// tracks cumulative deaths from ILI, SARI & Critical severities
	public int cumDeath_ILI;
	public int cumDeath_SARI;
	public int cumDeath_Critical;
	// tracks cumulative deaths from ILI, SARI & Critical severities
	public int[] cumDeath_ILI_adunit = new int[Country.MAX_ADUNITS];
	public int[] cumDeath_SARI_adunit = new int[Country.MAX_ADUNITS];
	public int[] cumDeath_Critical_adunit = new int[Country.MAX_ADUNITS];
	public int[] cumDeath_ILI_age = new int[Constants.NUM_AGE_GROUPS];
	public int[] cumDeath_SARI_age = new int[Constants.NUM_AGE_GROUPS];
	public int[] cumDeath_Critical_age = new int[Constants.NUM_AGE_GROUPS];

	// prevalence, incidence, and cumulative incidence of infection by age and admin unit.
	public int[][] prevInf_age_adunit = [];
	public int[][] cumInf_age_adunit = [];

	//// above quantities need to be amended in following parts of code:
	//// i) InitModel (set to zero);
	//// ii) RecordSample: (collate from threads);
	//// iii) RecordSample: add to incidence / Timeseries).
	//// iv) SaveResults
	//// v) SaveSummaryResults
	///// And various parts of Update.cpp where variables need must be incremented, decremented.
}
