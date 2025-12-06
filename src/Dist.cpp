#include <cstdlib>
#include <cmath>

#include "Constants.h"
#include "Dist.h"
#include "Param.h"

#include "Model.h"

//// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// ****
//// **** DISTANCE FUNCTIONS (return distance-squared, which is input for every Kernel function)
//// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// ****


double dist2_mm(Microcell* a, Microcell* b)
{
	double x, y;
	int l, m;

	l = (int)(a - Mcells);
	m = (int)(b - Mcells);
	if (P.DoUTM_coords)
	{
		return dist2UTM(P.in_microcells_.width * fabs((double)(l / P.total_microcells_high_)), P.in_microcells_.height * fabs((double)(l % P.total_microcells_high_)),
			P.in_microcells_.width * fabs((double)(m / P.total_microcells_high_)), P.in_microcells_.height * fabs((double)(m % P.total_microcells_high_)));
	}
	x = P.in_microcells_.width * fabs((double)(l / P.total_microcells_high_ - m / P.total_microcells_high_));
	y = P.in_microcells_.height * fabs((double)(l % P.total_microcells_high_ - m % P.total_microcells_high_));
	return periodic_xy(x, y);
}

double dist2_raw(double ax, double ay, double bx, double by)
{
	if (P.DoUTM_coords)
	{
		return dist2UTM(ax, ay, bx, by);
	}
	return periodic_xy(fabs(ax - bx), fabs(ay - by));
}
