namespace CovidSim;

public static class Country {
	public const int MAX_HOUSEHOLD_SIZE = 10;
	public const int MAX_INTERVENTION_TYPES = 1;
	public const int MAX_INTERVENTIONS_PER_ADUNIT = 10;

	public const int ADUNIT_LOOKUP_SIZE = 1000000;
	public const int MAX_COUNTRIES = 100;
	public const int MAX_NUM_PLACE_TYPES = 5;
	public const int MAX_ADUNITS = 3200;

	// Maximal absent time - used for array sizing
	public const int MAX_ABSENT_TIME = 8;

	public const int MAX_DIST = 2000;
}
