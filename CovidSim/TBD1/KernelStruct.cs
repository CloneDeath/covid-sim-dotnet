using System;

namespace CovidSim.TBD1;

/// A probability distribution
public class KernelStruct {
	/// Which distribution to use
	public int type_;

	/// Distribution parameter
	public double shape_;

	/// Representative distance
	public double scale_;

	/// Distribution parameter
	public double p3_;

	/// Distribution parameter
	public double p4_;

	/// \param r2 The distance squared
	/// \return Probability
	public double exponential(double r2) {
		return Math.Exp(-Math.Sqrt(r2) / scale_);
	}

	/// \param r2 The distance squared
	/// \return Probability
	public double power(double r2) {
		double t = -shape_ * Math.Log(Math.Sqrt(r2) / scale_ + 1.0);
		return (t < -690.0) ? 0.0 : Math.Exp(t);
	}

	/// \param r2 The distance squared
	/// \return Probability
	public double power_b(double r2) {
		double t = 0.5 * shape_ * Math.Log(r2 / (scale_ * scale_));
		return (t > 690.0) ? 0.0 : (1.0 / (Math.Exp(t) + 1.0));
	}

	/// \param r2 The distance squared
	/// \return Probability
	public double power_us(double r2) {
		double t = Math.Log(Math.Sqrt(r2) / scale_ + 1.0);
		return (t < -690.0) ? 0.0 : (Math.Exp(-shape_ * t) + p3_ * Math.Exp(-p4_ * t)) / (1.0 + p3_);
	}

	/// \param r2 The distance squared
	/// \return Probability
	public double power_exp(double r2) {
		double d = Math.Sqrt(r2);
		double t = -shape_ * Math.Log(d / scale_ + 1.0);
		return (t < -690.0) ? 0.0 : Math.Exp(t - Math.Pow(d / p3_, p4_));
	}

	/// Gaussian distribution a.k.a. normal distribution and bell curve
	/// \param r2 The distance squared
	/// \return Probability
	public double gaussian(double r2) {
		return Math.Exp(-r2 / (scale_ * scale_));
	}

	/// Step function
	/// \param r2 The distance squared
	/// \return Probability
	public double step(double r2) {
		return (r2 > scale_ * scale_) ? 0.0 : 1.0;
	}
}
