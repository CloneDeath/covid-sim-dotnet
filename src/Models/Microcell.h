#ifndef COVIDSIM_MODELS_MICRO_CELL_H_INCLUDED_
#define COVIDSIM_MODELS_MICRO_CELL_H_INCLUDED_

#include "../IndexList.h"


enum struct TreatStat { // treatment status

	//// Untreated
	Untreated = 0,
	//// Untreated but flagged for treatment
	ToBeTreated = 1,
	//// Treated
	Treated = 2,
	//// Do not treat again (flag in TreatSweep there only to avoid code blocks being called again).
	DontTreatAgain = 3,
};

#endif
