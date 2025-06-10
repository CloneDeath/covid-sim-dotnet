namespace CovidSim.Models;

/**
 * @brief Holds microcells.
 *
 * Keeps track of susceptible, latent and infected people (in addition to details like who
 * is vaccinated, treated etc.) Also contains data for the spatial gravity model for social
 * interactions (probability distributions).
*/
public struct Cell() {
	/* number of people in cell (members) */
	public int n;
	// numbers of Susceptible
	public int S;
	// Latently infected
	public int L;
	// Infectious
	public int I;
	// Recovered
	public int R;
	//Dead
	public int D;

	public int cumTC;
	public int S0;
	public int tot_treat;
	public int tot_vacc;

	// pointers to people in cell. e.g. *susceptible identifies where the final susceptible member of cell is.
	public int[] members;
	public int[] susceptible;
	public int[] latent;
	public int[] infected;

	public int[] InvCDF;
	public float tot_prob;
	public float[] cum_trans;
	public float[] max_trans;

	public short[] CurInterv = [Country.MAX_INTERVENTION_TYPES];
}
