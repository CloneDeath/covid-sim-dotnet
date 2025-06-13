namespace CovidSim.Models;

/**
 * @brief The basic unit of the simulation and is associated to a geographical location.
 *
 * Interventions (e.g., school closures) are tracked at this level. It contains a list of its
 * members (people), places (schools, universities, workplaces etc.), road networks, links to
 * airports etc.
 */
public class Microcell
{
	/* Note use of short int here limits max run time to USHRT_MAX*ModelTimeStep - e.g. 65536*0.25=16384 days=44 yrs.
	   Global search and replace of 'unsigned short int' with 'int' would remove this limit, but use more memory.
	*/
	// Number of people in microcell
	public int n;
	// admin unit microcell belongs to
	public int adunit;
	// array of members/hosts of microcell
	public int[] members = [];

	// list of places (of various place types) within microcell
	public int[] places = [Country.MAX_NUM_PLACE_TYPES];
	// number of places (of various place types) within mircocell
	public ushort[] NumPlacesByType = [Country.MAX_NUM_PLACE_TYPES];
	public ushort keyworkerproph;
	public ushort move_trig;
	public ushort place_trig;
	public ushort socdist_trig;
	public ushort keyworkerproph_trig;

	public ushort move_start_time;
	public ushort move_end_time;
	public ushort place_end_time;
	public ushort socdist_end_time;
	public ushort keyworkerproph_end_time;
	public TreatStat moverest;
	public TreatStat treat;
	public TreatStat vacc;
	public TreatStat socdist;
	public TreatStat placeclose;
	public ushort treat_trig;
	public ushort vacc_trig;
	public ushort treat_start_time, treat_end_time;
	public ushort vacc_start_time;
	public IndexList[] AirportList = [];
};
