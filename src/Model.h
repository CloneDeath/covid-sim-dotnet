#ifndef COVIDSIM_MODEL_H_INCLUDED_
#define COVIDSIM_MODEL_H_INCLUDED_

#include <cstdint>
#include <cstddef>
#include <vector>

#include "Country.h"
#include "Constants.h"
#include "InfStat.h"
#include "IndexList.h"

#include "geometry/Vector2.h"

#include "Models/Cell.h"
#include "Models/Household.h"
#include "Models/Microcell.h"
#include "Models/Person.h"

//// need to test that inequalities in IncubRecoverySweep can be replaced if you initialize to USHRT_MAX, rather than zero.
//// need to output quantities by admin unit

#pragma pack(push, 2)

// The offset (in number of doubles) of the first double field in Results.
const std::size_t ResultsDoubleOffsetStart = offsetof(Results, S) / sizeof(double);

/*
  HQ - quarantined households
  AH - Quarantined (and perhaps sick) working adults
  AC - Non-quarantined working adult cases absent thru sickness.
  AA - Absent working adults who are caring for sick children (only assigned if no non-working, quarantine or sick adults available).
  ACS - Children below care requirement cut-off age who are absent (sick or quarantined)

  APC - Non-quarantined working adult cases absent due to closure of their workplace (excl teachers).
  APA - Absent working adults who are caring for children at home due to school closure (only assigned if no non-working, quarantine or sick adults available).
  ACS - Children below care requirement cut-off age who are absent due to school closure


  AH x rq + AC + AA +(APC+APA) x rc = total adult absence
  rq=ratio of quarantine time to duration of absence due to illness
  rc=ratio of school/workplace closure duration of absence due to illness
*/

#pragma pack(pop)

#endif // COVIDSIM_MODEL_H_INCLUDED_
