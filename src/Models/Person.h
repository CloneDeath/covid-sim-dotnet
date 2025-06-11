#ifndef COVIDSIM_MODELS_PERSON_H_INCLUDED_
#define COVIDSIM_MODELS_PERSON_H_INCLUDED_

#include <cstdint>
#include <limits>

#include "../Country.h"
#include "../InfStat.h"

struct PersonQuarantine
{
	uint8_t  comply;		// can be 0, 1, 2
	uint16_t start_time;	// timestep quarantine is started

	// don't remove the extra parentheses around std::numeric_limits<uint16_t>::max
	// because it conflicts with the max() preprocessor macro in MSVC builds
	PersonQuarantine() : comply(2), start_time((std::numeric_limits<uint16_t>::max)()-1) {}
};

#endif
