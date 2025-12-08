namespace CovidSim;

public class InverseCdf {
	private readonly double[] cdf_values_ = new double[Constants.CDF_RES + 1];

	/**
	 * Function: set_neg_log
	 *
	 * Purpose: set defaults if not present in parameter file
	 * @param start_value - the value to use for cdf_values_[CDF_RES]
	 * @return void
	 */
	public void set_neg_log(double start_value) {
		cdf_values_[Constants.CDF_RES] = start_value;
		for (int i = 0; i < Constants.CDF_RES; i++)
			cdf_values_[i] = -log(1 - ((double)i) / Constants.CDF_RES);
	}

	/**
	 * Function: assign_exponent
	 *
	 * Purpose: exponentiate each quantile
	 * @return void
	 */
	public void assign_exponent() {
		for (int quantile = 0; quantile <= Constants.CDF_RES; quantile++) {
			cdf_values_[quantile] = exp(-cdf_values_[quantile]);
		}
	}

	/**
	 * Function: assign_exponent
	 *
	 * Purpose: exponentiate each quantile
	 * @param value - value of the exponent
	 * @return void
	 */
	public void assign_exponent(double value) {
		for (int i = 0; i <= Constants.CDF_RES; i++) {
			cdf_values_[i] = exp(value);
		}
	}

	/**
	 * Function: choose
	 *
	 * Purpose: choose a value from the InverseCdf data
	 * @param Mean
	 * @param tn - thread number
	 * @param timesteps_per_day
	 * @return value chosen from InverseCdf data
	 */
	public ushort choose(double Mean, int tn, double timesteps_per_day) {
		double q;

		var i = (int)floor(q = ranf_mt(tn) * CDF_RES); //// note q defined here as well as i.
		q -= ((double)i); //// remainder

		//// weighted average (sort of) between quartile values from CDF_RES. logged as it was previously exponentiated in ReadParams. Minus as exp(-cdf) was done in ReadParaams. Sort of
		var ti = -Mean * log(q * cdf_values_[i + 1] + (1.0 - q) * cdf_values_[i]);
		ushort Value = (ushort)floor(0.5 + (ti * timesteps_per_day));

		return Value;
	}

	public double[] get_values() {
		return cdf_values_;
	}

	// Overloading [] operator to access elements in array style
	public double this[int i] => cdf_values_[i];
}
