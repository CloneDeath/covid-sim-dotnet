using System.Collections.Generic;

namespace CovidSim.Models;

public static class Model {
	public static Person[] Hosts = [];
	public static List<PersonQuarantine> HostsQuarantine = [];
	public static Household[] Households = [];
	public static PopVar State;
	public static PopVar[] StateT = new PopVar[Constants.MAX_NUM_THREADS];
	public static Cell[] Cells = [];
	public static Cell[][] CellLookup = [];
	public static Microcell[] Mcells = [];
	public static Microcell[][] McellLookup = [];
	public static List<ushort> mcell_country = [];
	public static Place[][] Places = [];
	public static AdminUnit[] AdUnits = new AdminUnit[Country.MAX_ADUNITS];

	//// Time Series defs:
	//// TimeSeries is an array of type results, used to store (unsurprisingly) a time series of every quantity in results. Mostly used in RecordSample.
	//// TSMeanNE and TSVarNE are the mean and variance of non-extinct time series. TSMeanE and TSVarE are the mean and variance of extinct time series. TSMean and TSVar are pointers that point to either extinct or non-extinct.
	public static Results[] TimeSeries = [];
	public static Results[] TSMean = [];
	public static Results[] TSVar = [];
	public static Results[] TSMeanNE = [];
	public static Results[] TSVarNE = [];
	public static Results[] TSMeanE = [];
	public static Results[] TSVarE = []; //// TimeSeries used in RecordSample, RecordInfTypes, SaveResults. TSMean and TSVar

	public static Airport[] Airports = [];
	public static Events[] InfEventLog = [];
	public static int nEvents;

	public static double[] inftype = new double[Constants.INFECT_TYPE_MASK];
	public static double[] inftype_av = new double[Constants.INFECT_TYPE_MASK];
	public static double[] infcountry = new double[Country.MAX_COUNTRIES];
	public static double[] infcountry_av = new double[Country.MAX_COUNTRIES];
	public static double[] infcountry_num = new double[Country.MAX_COUNTRIES];
	public static double[,] indivR0 = new double[Constants.MAX_SEC_REC, Constants.MAX_GEN_REC];
	public static double[,] indivR0_av = new double[Constants.MAX_SEC_REC, Constants.MAX_GEN_REC];
	public static double[,] inf_household = new double[Country.MAX_HOUSEHOLD_SIZE + 1, Country.MAX_HOUSEHOLD_SIZE + 1];
	public static double[] denom_household = new double[Country.MAX_HOUSEHOLD_SIZE + 1];
	public static double[,] inf_household_av = new double[Country.MAX_HOUSEHOLD_SIZE + 1, Country.MAX_HOUSEHOLD_SIZE + 1];
	public static double[] AgeDist = new double[Constants.NUM_AGE_GROUPS];
	public static double[] AgeDist2 = new double[Constants.NUM_AGE_GROUPS];
	public static double[,] case_household = new double[Country.MAX_HOUSEHOLD_SIZE + 1, Country.MAX_HOUSEHOLD_SIZE + 1];
	public static double[,] case_household_av = new double[Country.MAX_HOUSEHOLD_SIZE + 1, Country.MAX_HOUSEHOLD_SIZE + 1];
	public static double[,] PropPlaces = new double[Constants.NUM_AGE_GROUPS * Constants.AGE_GROUP_WIDTH, Country.MAX_NUM_PLACE_TYPES];
	public static double[,] PropPlacesC = new double[Constants.NUM_AGE_GROUPS * Constants.AGE_GROUP_WIDTH, Country.MAX_NUM_PLACE_TYPES];
	public static double[] AirTravelDist = new double[Country.MAX_DIST];
	public static double PeakHeightSum;
	public static double PeakHeightSS;
	public static double PeakTimeSum;
	public static double PeakTimeSS;

	public static int DoInitUpdateProbs;
}
