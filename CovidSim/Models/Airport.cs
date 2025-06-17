using System.Runtime.InteropServices;
using CovidSim.Geometry;

namespace CovidSim.Models;

/**
 * @brief Airport state.
 *
 * Not used for COVID-19 right now. Might be more relevant for USA and
 * other countries that have lots of internal flights. Slows the simulation.
 */
[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct Airport() {
	public int num_mcell;
	public int num_place;
	public int[] Inv_prop_traffic = new int[129];
	public int[] Inv_DestMcells = new int[1025];
	public int[] Inv_DestPlaces = new int[1025];
	public ushort num_connected;
	public ushort[] conn_airports = [];
	public float total_traffic;
	public Vector2f loc = new(0, 0);
	public float[] prop_traffic = [];
	public IndexList[] DestMcells = [];
	public IndexList[] DestPlaces = [];
}
