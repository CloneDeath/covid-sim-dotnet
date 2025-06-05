namespace CovidSim;

//// SeverityClass definitions / labels (numbers arbitrary but must be different to each other).
public enum Severity {
	//// Flag value.
	Asymptomatic,
	Mild,
	// Influenza-like illness
	ILI,
	// Severe Acute Respiratory Infection
	SARI,
	// Critical (requires intensive care unit (ICU)
	Critical,
	//// Stepdown from ICU. Recovering from Critical (not recovered yet). Although depending on param.IncludeStepDownToDeath, can still die at Stepdown.
	Stepdown,
	//// label to avoid double counting.
	Dead,
	//// label to avoid double counting.
	Recovered
}
