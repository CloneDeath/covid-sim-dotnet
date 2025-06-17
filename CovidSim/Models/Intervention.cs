using System.Runtime.InteropServices;

namespace CovidSim.Models;

/**
 * @brief Deprecated intervention mechanism.
 *
 * Not currently being used, but may be reinstated.
 */
[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct Intervention {
	public int InterventionType;
	public int DoAUThresh;
	public int NoStartAfterMin;
	//dummy for 8 byte alignment
	public int dummy;
	public double StartTime;
	public double StopTime;
	public double MinDuration;
	public double RepeatInterval;
	public double TimeOffset;
	public double StartThresholdHigh;
	public double StartThresholdLow;
	public double StopThreshold;
	public double Level;
	public double LevelCellVar;
	public double LevelAUVar;
	public double LevelCountryVar;
	public double ControlParam;
	public double LevelClustering;
	public uint MaxRounds;
	public uint MaxResource;
};
