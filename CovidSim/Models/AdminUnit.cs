using System.Runtime.InteropServices;

namespace CovidSim.Models;

/**
 * A political entity that administers a geographical area.
 */
[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct AdminUnit {
	public int id;
	public int cnt_id;
	// ggilani 05/01/15. NI is number of interventions in admin unit.
	public int NI;
	//added n - number of people in admin unit
	public int n;
	public Intervention InterventionList = new Intervention[MAX_INTERVENTIONS_PER_ADUNIT];
	public string cnt_name;
	public string ad_name;
	public int NP;
	public int place_close_trig;
	public double CaseIsolationTimeStart;
	public double HQuarantineTimeStart;
	public double DigitalContactTracingTimeStart;
	//added these to admin unit in the hope of getting specific start times for Italy: ggilani 16/03/20
	public double SocialDistanceTimeStart;
	public double PlaceCloseTimeStart;
	//adding in admin level delays and durations for admin units: ggilani 17/03/20
	public double SocialDistanceDelay;
	public double HQuarantineDelay;
	public double CaseIsolationDelay;
	public double PlaceCloseDelay;
	public double DCTDelay;
	public double SocialDistanceDuration;
	public double HQuarantineDuration;
	public double CaseIsolationPolicyDuration;
	public double PlaceCloseDuration;
	public double DCTDuration;
	//arrays for admin unit based digital contact tracing: ggilani 10/03/20
	public int[] dct = [];
	public int ndct;
	//storage for origin-destination matrix between admin units: ggilani 28/01/15
	public double[] origin_dest = [];
};
