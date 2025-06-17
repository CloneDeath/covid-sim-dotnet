using System.Runtime.InteropServices;

namespace CovidSim.Models;

/**
 * @brief Contact event used for tracking contact tracing events
 *
 * Currently stores: contact and index case (both ints) and contact time (unsigned short int)
 * Thanks to igfoo
 */
[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct ContactEvent
{
	public int contact;
	public int index;
	public ushort contact_time;
};
