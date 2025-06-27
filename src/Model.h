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

extern Person* Hosts;
extern std::vector<PersonQuarantine> HostsQuarantine;
extern Household* Households;
extern PopVar State, StateT[MAX_NUM_THREADS];
extern Cell* Cells, ** CellLookup;
extern Microcell* Mcells, ** McellLookup;
extern std::vector<uint16_t> mcell_country;
extern Place** Places;
extern AdminUnit AdUnits[MAX_ADUNITS];

//// Time Series defs:
//// TimeSeries is an array of type results, used to store (unsurprisingly) a time series of every quantity in results. Mostly used in RecordSample.
//// TSMeanNE and TSVarNE are the mean and variance of non-extinct time series. TSMeanE and TSVarE are the mean and variance of extinct time series. TSMean and TSVar are pointers that point to either extinct or non-extinct.
extern Results* TimeSeries, *TSMean, *TSVar, *TSMeanNE, *TSVarNE, *TSMeanE, *TSVarE; //// TimeSeries used in RecordSample, RecordInfTypes, SaveResults. TSMean and TSVar

extern Airport* Airports;
extern Events* InfEventLog;
extern int nEvents;


extern double inftype[INFECT_TYPE_MASK], inftype_av[INFECT_TYPE_MASK], infcountry[MAX_COUNTRIES], infcountry_av[MAX_COUNTRIES], infcountry_num[MAX_COUNTRIES];
extern double indivR0[MAX_SEC_REC][MAX_GEN_REC], indivR0_av[MAX_SEC_REC][MAX_GEN_REC];
extern double inf_household[MAX_HOUSEHOLD_SIZE + 1][MAX_HOUSEHOLD_SIZE + 1], denom_household[MAX_HOUSEHOLD_SIZE + 1];
extern double inf_household_av[MAX_HOUSEHOLD_SIZE + 1][MAX_HOUSEHOLD_SIZE + 1], AgeDist[NUM_AGE_GROUPS], AgeDist2[NUM_AGE_GROUPS];
extern double case_household[MAX_HOUSEHOLD_SIZE + 1][MAX_HOUSEHOLD_SIZE + 1], case_household_av[MAX_HOUSEHOLD_SIZE + 1][MAX_HOUSEHOLD_SIZE + 1];
extern double PropPlaces[NUM_AGE_GROUPS * AGE_GROUP_WIDTH][MAX_NUM_PLACE_TYPES];
extern double PropPlacesC[NUM_AGE_GROUPS * AGE_GROUP_WIDTH][MAX_NUM_PLACE_TYPES], AirTravelDist[MAX_DIST];
extern double PeakHeightSum, PeakHeightSS, PeakTimeSum, PeakTimeSS;

extern int DoInitUpdateProbs;

#endif // COVIDSIM_MODEL_H_INCLUDED_
