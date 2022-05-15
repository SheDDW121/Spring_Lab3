#include "pch.h"
#include <time.h>
#include <mkl.h>

extern "C"  _declspec(dllexport)
bool GetMKL(const int nx, double* x, double* y, const int N, double* value, double* deriv, double* int_lim, double* int_val, int& error, double* coef)
{
	try {
		DFTaskPtr Task;
		int code = dfdNewTask1D(&Task, nx, x, DF_NON_UNIFORM_PARTITION, 1, y, DF_MATRIX_STORAGE_ROWS);
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Problems in DLL_Lib " + code;
		}
		//float* coeff = new float[ny * 4 * (nx - 1)];
		code = dfdEditPPSpline1D(Task, DF_PP_CUBIC, DF_PP_NATURAL, DF_BC_FREE_END, NULL, DF_NO_IC, NULL, coef, DF_NO_HINT);  //свободные концы
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Problems in DLL_Lib " + code;
		}
		code = dfdConstruct1D(Task, DF_PP_SPLINE, DF_METHOD_STD);  //
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Problems in DLL_Lib " + code;
		}
		const double* tmp = new double[2]{ x[0], x[nx - 1] };
		code = dfdInterpolate1D(Task, DF_INTERP, DF_METHOD_PP, N, tmp,       //
			DF_UNIFORM_PARTITION, 1, new int[1]{ 1 }, NULL, value,
			DF_MATRIX_STORAGE_ROWS, NULL);

		if (code != DF_STATUS_OK) {
			error = code;
			throw "Problems in DLL_Lib " + code;
		}
		code = dfdInterpolate1D(Task, DF_INTERP, DF_METHOD_PP, 2, tmp,       //
			DF_UNIFORM_PARTITION, 3, new int[3]{1, 1, 1}, NULL, deriv,
			DF_MATRIX_STORAGE_ROWS, NULL);

		if (code != DF_STATUS_OK) {
			error = code;
			throw "Problems in DLL_Lib " + code;
		}

		code = dfdIntegrate1D(Task, DF_METHOD_PP, 3, new double[3]{ int_lim[0], int_lim[1], int_lim[0] },
			DF_NON_UNIFORM_PARTITION, new double[3]{ int_lim[1], int_lim[2], int_lim[2] },
			DF_NON_UNIFORM_PARTITION, NULL, NULL, int_val, DF_MATRIX_STORAGE_ROWS);

		if (code != DF_STATUS_OK) {
			error = code;
			throw "Problems in DLL_Lib " + code;
		}

		dfDeleteTask(&Task);
		if (code != DF_STATUS_OK) {
			error = code;
			throw "Problems in DLL_Lib " + code;
		}

	}
	catch (...) {
		throw;
	}
	return true;
}