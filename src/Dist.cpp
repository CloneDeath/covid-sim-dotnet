#include <cstdlib>
#include <cmath>

#include "Constants.h"
#include "Dist.h"
#include "Param.h"

#include "Model.h"

//// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// ****
//// **** DISTANCE FUNCTIONS (return distance-squared, which is input for every Kernel function)
//// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// ****

double dist2(Person* a, Person* b)
{
	double x, y;

	if (P.DoUTM_coords)
		return dist2UTM(Households[a->hh].loc.x, Households[a->hh].loc.y, Households[b->hh].loc.x, Households[b->hh].loc.y);
	else
	{
		x = fabs(Households[a->hh].loc.x - Households[b->hh].loc.x);
		y = fabs(Households[a->hh].loc.y - Households[b->hh].loc.y);
		return periodic_xy(x, y);
	}
}
double dist2_cc(Cell* a, Cell* b)
{
	double x, y;
	int l, m;

	l = (int)(a - Cells);
	m = (int)(b - Cells);
	if (P.DoUTM_coords)
		return dist2UTM(P.in_cells_.width * fabs((double)(l / P.nch)), P.in_cells_.height * fabs((double)(l % P.nch)),
			P.in_cells_.width * fabs((double)(m / P.nch)), P.in_cells_.height * fabs((double)(m % P.nch)));
	else
	{
		x = P.in_cells_.width * fabs((double)(l / P.nch - m / P.nch));
		y = P.in_cells_.height * fabs((double)(l % P.nch - m % P.nch));
		return periodic_xy(x, y);
	}
}

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
