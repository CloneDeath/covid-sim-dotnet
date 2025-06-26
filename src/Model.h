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

/**
 * @brief Recorded time-series variables (typically populated from the `POPVAR` state)
 *
 * In the function `RecordSample` we transform (copy parts, calculate summary statistics)
 * of the `POPVAR` state into a time-stamped `RESULTS` structure.
 *
 * NOTE: This struct must contain only doubles (and arrays of doubles) for the TSMean
 * 	     averaging code to work.
 */
struct Results
{
	// Initial values should not be touched by mean/var calculation
	double t;
	double** prevInf_age_adunit, ** incInf_age_adunit, ** cumInf_age_adunit; // prevalence, incidence, and cumulative incidence of infection by age and admin unit.

	// The following values must all be doubles or inline arrays of doubles
	// The first variable must be S.  If that changes change the definition of
	// ResultsDoubleOffsetStart below.
	double S, L, I, R, D, incC, incTC, incFC, incI, incR, incD, incDC, meanTG, meanSI ;
	double CT, incCT, incCC, DCT, incDCT; //added total numbers being contact traced and incidence of contact tracing: ggilani 15/06/17, and for digital contact tracing: ggilani 11/03/20
	double incC_country[MAX_COUNTRIES]; //added incidence of cases
	double cumT, cumUT, cumTP, cumV, cumTmax, cumVmax, cumDC, extinct, cumVG; //added cumVG
	double incHQ, incAC, incAH, incAA, incACS, incAPC, incAPA, incAPCS;
	double incIa[NUM_AGE_GROUPS], incCa[NUM_AGE_GROUPS], incDa[NUM_AGE_GROUPS];
	double incItype[INFECT_TYPE_MASK], Rtype[INFECT_TYPE_MASK], Rage[NUM_AGE_GROUPS], Rdenom;
	double rmsRad, maxRad, PropPlacesClosed[MAX_NUM_PLACE_TYPES], PropSocDist;
	double incI_adunit[MAX_ADUNITS], incC_adunit[MAX_ADUNITS], cumT_adunit[MAX_ADUNITS], incD_adunit[MAX_ADUNITS], cumD_adunit[MAX_ADUNITS], incH_adunit[MAX_ADUNITS], incDC_adunit[MAX_ADUNITS]; //added incidence of hospitalisation per day: ggilani 28/10/14, incidence of detected cases per adunit,: ggilani 03/02/15
	double incCT_adunit[MAX_ADUNITS], incCC_adunit[MAX_ADUNITS], incDCT_adunit[MAX_ADUNITS], DCT_adunit[MAX_ADUNITS]; //added incidence of contact tracing and number of people being contact traced per admin unit: ggilani 15/06/17
	double incI_keyworker[2], incC_keyworker[2], cumT_keyworker[2];

	///@{
	/** Severity States track the COVID-19 states (e.g., mild, critical, etc.) */
	double Mild, ILI, SARI, Critical, CritRecov;				// Prevalence				//// Must be: i) initialised to zero in SetUpModel. ii) outputted in SaveResults iii) outputted in SaveSummaryResults
	double incMild, incILI, incSARI, incCritical, incCritRecov;	// Incidence				//// Must be: i) initialised to zero in SetUpModel. ii) calculated in RecordSample iii) outputted in SaveResults.
	double cumMild, cumILI, cumSARI, cumCritical, cumCritRecov;	// cumulative incidence		//// Must be: i) initialised to zero in SetUpModel. ii) outputted in SaveResults
	double incDeath_ILI, incDeath_SARI, incDeath_Critical;		// tracks incidence of death from ILI, SARI & Critical severities
	double cumDeath_ILI, cumDeath_SARI, cumDeath_Critical;		// tracks cumulative deaths from ILI, SARI & Critical severities
	///@}

	/////// Severity States by admin unit
	double Mild_adunit[MAX_ADUNITS], ILI_adunit[MAX_ADUNITS], SARI_adunit[MAX_ADUNITS], Critical_adunit[MAX_ADUNITS], CritRecov_adunit[MAX_ADUNITS];				// Prevalence by admin unit
	double incMild_adunit[MAX_ADUNITS], incILI_adunit[MAX_ADUNITS], incSARI_adunit[MAX_ADUNITS], incCritical_adunit[MAX_ADUNITS], incCritRecov_adunit[MAX_ADUNITS];	// incidence by admin unit
	double cumMild_adunit[MAX_ADUNITS], cumILI_adunit[MAX_ADUNITS], cumSARI_adunit[MAX_ADUNITS], cumCritical_adunit[MAX_ADUNITS], cumCritRecov_adunit[MAX_ADUNITS]; // cumulative incidence by admin unit
	double incDeath_ILI_adunit[MAX_ADUNITS], incDeath_SARI_adunit[MAX_ADUNITS], incDeath_Critical_adunit[MAX_ADUNITS];		// tracks incidence of death from ILI, SARI & Critical severities
	double cumDeath_ILI_adunit[MAX_ADUNITS], cumDeath_SARI_adunit[MAX_ADUNITS], cumDeath_Critical_adunit[MAX_ADUNITS];		// tracks cumulative deaths from ILI, SARI & Critical severities

	/////// Severity States by age group
	double Mild_age[NUM_AGE_GROUPS], ILI_age[NUM_AGE_GROUPS], SARI_age[NUM_AGE_GROUPS], Critical_age[NUM_AGE_GROUPS], CritRecov_age[NUM_AGE_GROUPS];				// Prevalence by admin unit
	double incMild_age[NUM_AGE_GROUPS], incILI_age[NUM_AGE_GROUPS], incSARI_age[NUM_AGE_GROUPS], incCritical_age[NUM_AGE_GROUPS], incCritRecov_age[NUM_AGE_GROUPS];	// incidence by admin unit
	double cumMild_age[NUM_AGE_GROUPS], cumILI_age[NUM_AGE_GROUPS], cumSARI_age[NUM_AGE_GROUPS], cumCritical_age[NUM_AGE_GROUPS], cumCritRecov_age[NUM_AGE_GROUPS]; // cumulative incidence by admin unit
	double incDeath_ILI_age[NUM_AGE_GROUPS], incDeath_SARI_age[NUM_AGE_GROUPS], incDeath_Critical_age[NUM_AGE_GROUPS];		// tracks incidence of death from ILI, SARI & Critical severities
	double cumDeath_ILI_age[NUM_AGE_GROUPS], cumDeath_SARI_age[NUM_AGE_GROUPS], cumDeath_Critical_age[NUM_AGE_GROUPS];		// tracks cumulative deaths from ILI, SARI & Critical severities

	double prevQuarNotInfected, prevQuarNotSymptomatic; // Which people are under quarantine but not themselves infected/sypmtomatic?

	/////// possibly need quantities by age (later)
	//// state variables (S, L, I, R) and therefore (Mild, ILI) etc. changed in i) SetUpModel (initialised to zero); ii)

	//// above quantities need to be amended in following parts of code:
	//// i) SetUpModel (set to zero);
	//// ii) RecordSample: add to incidence / Timeseries).
	//// iii) SaveResults and SaveSummary results.
	///// need to update these quantities in InitModel (DONE), Record Sample (DONE) (and of course places where you need to increment, decrement).

};

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
