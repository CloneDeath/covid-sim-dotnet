#include <cstdlib>
#include <cmath>

#include "Constants.h"
#include "Dist.h"
#include "Param.h"

#include "Model.h"

//// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// ****
//// **** DISTANCE FUNCTIONS (return distance-squared, which is input for every Kernel function)
//// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// **** //// ****


double dist2_raw(double ax, double ay, double bx, double by)
{
	if (P.DoUTM_coords)
	{
		return dist2UTM(ax, ay, bx, by);
	}
	return periodic_xy(fabs(ax - bx), fabs(ay - by));
}
