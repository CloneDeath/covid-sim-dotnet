using System.Runtime.InteropServices;

namespace CovidSim.Models;

/**
 * Apply place closure effects to household in a thread-safe way.
 */
[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct HostClosure {
	public int host_index;
	public ushort start_time;
	public ushort stop_time;
}
