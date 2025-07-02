using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CovidSim.Models;

namespace CovidSim.TBD1;

/// To speed up calculation of kernel values we provide a couple of lookup
/// tables.
///
/// lookup_ is a table of lookups. lookup_[0] is the kernel
/// value at a distance of 0, and lookup_.back() is the kernel value at the
/// largest possible distance.
///
/// hi_res_ is a higher-resolution table of lookups, also of lookup_.size()
/// elements.  hi_res_[n * expansion_factor_] corresponds to lookup_[n] for
/// n in [0, lookup_.size() / expansion_factor_]
///
/// Graphically:
///
/// Distance 0 ...                                                 Bound Box diagonal
/// lookup_[0] ... lookup_[lookup_.size() / expansion_factor_] ... lookup_.back()
/// hi_res_[0] ... hi_res_.back()
public class KernelLookup {
	/// Kernel lookup table
	private readonly List<double> lookup_ = new();

	/// Hi-res kernel lookup table for closer distances
	private readonly List<double> hi_res_ = new();

	/// Longest distance / lookup_.size()
	private double delta_;

	/// Size of kernel lookup table
	public int size_ = 4000000;

	/// The hi-res kernel extends only to the longest distance / expansion_factor_
	public int expansion_factor_;

	/// Resize the vectors and calculate delta_
	/// \param longest_distance The longest distance to lookup
	public void setup(double longest_distance) {
		var size = size_ + 1;
		lookup_.EnsureCapacity(size);
		hi_res_.EnsureCapacity(size);
		delta_ = longest_distance / size_;
	}

	/// Set the values in the lookup table
	/// \param norm Value to divide the probability by
	/// \param kernel The kernel to use when calculating the lookup tables
	public void init(double norm, KernelStruct kernel) {
		Func<double, double> fp;

		if (kernel.type_ == 1)
			fp = kernel.exponential;
		else if (kernel.type_ == 2)
			fp = kernel.power;
		else if (kernel.type_ == 3)
			fp = kernel.gaussian;
		else if (kernel.type_ == 4)
			fp = kernel.step;
		else if (kernel.type_ == 5)
			fp = kernel.power_b;
		else if (kernel.type_ == 6)
			fp = kernel.power_us;
		else if (kernel.type_ == 7)
			fp = kernel.power_exp;
		else
			throw new ArgumentException($"Unknown kernel type {kernel.type_}.");

		var self = this;
		Parallel.For(0, size_ + 1, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
			i => {
				self.lookup_[i] = fp(i * self.delta_) / norm;
				self.hi_res_[i] = fp(i * self.delta_ / self.expansion_factor_) / norm;
			});
	}

	/// Set the values in the cell lookup table
	/// \param lookup The kernel lookup table
	/// \param cell_lookup The cell lookup table
	/// \param cell_lookup_size Number of Cell*
	public static void init(KernelLookup lookup, Cell[] cell_lookup, int cell_lookup_size) {
		Parallel.For(0, cell_lookup_size, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
			(int i) => {
				var l = cell_lookup[i];
				l.tot_prob = 0.0f;
				for (var j = 0; j < cell_lookup_size; j++) {
					var m = cell_lookup[j];
					l.max_trans[j] = (float)lookup.num(dist2_cc_min(l, m));
					l.tot_prob += l.max_trans[j] * m.n;
				}
			});
	}

	/// Perform a lookup
	/// \param r2 The distance squared
	/// \return Probability
	public double num(double r2) {
		var t = r2 / delta_;
		if (t > size_) {
			throw new Exception($"r too large in NumKernel, r2: {r2}, delta_: {delta_}, size_: {size_}, t: {t}");
		}

		var s = t * expansion_factor_;
		if (s < size_) {
			t = s - Math.Floor(s);
			t = (1.0 - t) * hi_res_[(int)s] + t * hi_res_[(int)(s + 1.0)];
		} else {
			s = t - Math.Floor(t);
			t = (1.0 - s) * lookup_[(int)t] + s * lookup_[(int)(t + 1.0)];
		}
		return t;
	}
}
