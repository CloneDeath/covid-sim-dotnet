namespace CovidSim.Models;

public struct PersonQuarantine() {
	// can be 0, 1, 2
	public byte comply = 2;

	// timestep quarantine is started
	public ushort start_time = ushort.MaxValue - 1;
}
