using System.Runtime.InteropServices;

namespace CovidSim.Models;

/**
 * Supports producing individual infection events from the simulation (and is not used that
 * much because it was developed for Ebola, and slows the simulation).
 *
 * Added Events struct to allow us to log and write out infection events: ggilani 10/10/14
 */
[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct Events {
	public double infectee_x;
	public double infectee_y;
	public double t;
	public double t_infector;
	public int run;
	public int infectee_ind;
	public int infector_ind;
	public int type;
	public int infectee_adunit;
	public int listpos;
	public int infectee_cell;
	public int infector_cell;
	public int thread;
}
