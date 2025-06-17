using System.Runtime.InteropServices;

namespace CovidSim.Models;

/*
In the main InfectSweep loop, we cannot safely set
Hosts[infectee].infector and Hosts[infectee].infect_type, as concurrent
threads might be trying to set the values differently. We therefore
make a queue of `infection`s in `inf_queue` containing the information
we need, so that we can set the values after the main loop has finished.
*/
[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct Infection
{
	public int infector;
	public int infectee;
	public short infect_type;
}
