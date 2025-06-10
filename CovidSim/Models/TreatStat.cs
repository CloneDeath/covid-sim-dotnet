namespace CovidSim.Models;

// treatment status
public enum TreatStat {
	//// Untreated
	Untreated = 0,
	//// Untreated but flagged for treatment
	ToBeTreated = 1,
	//// Treated
	Treated = 2,
	//// Do not treat again (flag in TreatSweep there only to avoid code blocks being called again).
	DontTreatAgain = 3,
}
