namespace CovidSim;

public static class Constants {
	/**
	 * Math constant defined as the ratio of a circle's circumference to its diameter.
	 *
	 * TODO: since all calculations using this constant are being automatically
	 * type-casted to double, should the precision be extended for more accuracy in
	 * the simulations?
	 *
	 * Eventually could be replaced with C++20's std::numbers::pi.
	 * https://en.cppreference.com/w/cpp/header/numbers
	 */
	// full double precision: 3.14159265358979323846
	public const double PI = 3.1415926535;

	/**
	 * An arc minute of latitude along any line of longitude in meters.
	 *
	 * Also known as the International Nautical Mile.
	 *
	 * @see https://en.wikipedia.org/wiki/Nautical_mile
	 */
	public const int NMI = 1852;

	/**
	 * The number of arc minutes in one degree.
	 *
	 * @see https://en.wikipedia.org/wiki/Minute_and_second_of_arc
	 */
	public const int ARCMINUTES_PER_DEGREE = 60;

	/**
	 * The number of degrees in a complete rotation.
	 *
	 * @see https://en.wikipedia.org/wiki/Turn_(angle)
	 */
	public const int DEGREES_PER_TURN = 360;

	/**
	 * The earth's circumference in meters.
	 *
	 * The units of cancellation:
	 *    meters/minute * minutes/degree * degrees = meters
	 */
	public const int EARTH_CIRCUMFERENCE = NMI * ARCMINUTES_PER_DEGREE * DEGREES_PER_TURN;

	/**
	 * The earth's diameter in meters.
	 */
	public const double EARTH_DIAMETER = EARTH_CIRCUMFERENCE / PI;

	/**
	 * The Earth's radius in meters.
	 *
	 * The previous hardcoded value used 6366707 which was derived from the
	 * following formula:
	 *
	 *     Earth's radius (m) = Earth's circumference / 2 * Pi
	 *
	 * where Earth's circumference can be derived with the following formula:
	 *
	 *     Earth's circumference (m) = NMI * ARCMINUTES_PER_DEGREE * DEGREES_PER_TURN
	 */
	public const double EARTHRADIUS = EARTH_DIAMETER / 2;

	public const int OUTPUT_DIST_SCALE = 1000;
	public const int MAX_PLACE_SIZE = 20000;
	public const int MAX_NUM_SEED_LOCATIONS = 10000;

	public const int MAX_CLP_COPIES = 50;

	public const int CDF_RES = 20; // resolution of (inverse) cumulative distribution functions, used mostly for severity progressions/delay distributions.
	public const int INFPROF_RES = 56;

	public const int NUM_AGE_GROUPS = 17;
	public const int AGE_GROUP_WIDTH = 5;
	public const int DAYS_PER_YEAR = 364;
	public const int INFECT_TYPE_MASK = 16;
	public const int MAX_GEN_REC = 20;
	public const int MAX_SEC_REC = 500;
	public const int INF_QUEUE_SCALE = 5;
	public const int MAX_TRAVEL_TIME = 14;

	public const int MAX_INFECTIOUS_STEPS = 2550;

	public const int MAX_NUM_THREADS = 96;
	public const int CACHE_LINE_SIZE = 64;

	// define maximum number of contacts
	public const int MAX_CONTACTS = 500;

	public const int MAX_DUR_IMPORT_PROFILE = 10245;

	public const int MAX_AIRPORTS = 5000;
	public const int NNA = 10;
	// Need to use define for MAX_DIST_AIRPORT_TO_HOTEL to avoid differences between GCC and clang in requirements to share const doubles in OpenMP default(none) pragmas
	public const double MAX_DIST_AIRPORT_TO_HOTEL = 200000.0;
	public const int MIN_HOTELS_PER_AIRPORT = 20;
	public const int HOTELS_PER_1000PASSENGER = 10;


	// For various "over time" parameters that allow scaling of NPI effectiveness.
	public const int MAX_NUM_INTERVENTION_CHANGE_TIMES = 100;

	// To allow IFR to scale over time.
	public const int MAX_NUM_CFR_CHANGE_TIMES = 100;

	// MS generates a lot of C26451 overflow warnings. Below is shorthand
	// to increase the cast size and clean them up.
	public static long _I64(int x) => x;

	// Settings (numbers not arbitrary - don't change without checking)
	// const int PrimarySchool		= 0;
	// const int SecondarySchool	= 1;
	// const int University		= 2;
	// const int Workplace			= 3;
	public const int House				= Country.MAX_NUM_PLACE_TYPES;      // Max number of potential place types.
	public const int Spatial			= Country.MAX_NUM_PLACE_TYPES + 1;  // community

	// NPIs
	public const int CaseIsolation				= 0;
	public const int HomeQuarantine			= 1;
	public const int PlaceClosure				= 2;
	public const int SocialDistancing			= 3;
	public const int EnhancedSocialDistancing	= 4;
	public const int DigContactTracing			= 5;
}
