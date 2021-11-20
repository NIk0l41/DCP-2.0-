using System;
namespace DCP_087
{
	partial class Program
	{

		/// <summary>
		/// Checks if a point is North of another point.
		/// </summary>
		/// <param name="aCoord">First points Coordinates.</param>
		/// <param name="bCoord">Second poonts Coordinates.</param>
		/// <returns></returns>
		static bool IsNorthOf((int x, int y) aCoord, (int x, int y) bCoord) {
			bool isNorthOf = (aCoord.y > bCoord.y) ? true : false;
			return isNorthOf;
		}

		/// <summary>
		/// Checks if a point is South of another point.
		/// </summary>
		/// <param name="aCoord">First points Coordinates.</param>
		/// <param name="bCoord">Second poonts Coordinates.</param>
		/// <returns></returns>
		static bool IsSouthOf((int x, int y) aCoord, (int x, int y) bCoord) {
			bool isSouthOf = (aCoord.y < bCoord.y) ? true : false;
			return isSouthOf;
		}

		/// <summary>
		/// Checks if a point is East of another point.
		/// </summary>
		/// <param name="aCoord">First points Coordinates.</param>
		/// <param name="bCoord">Second poonts Coordinates.</param>
		/// <returns></returns>
		static bool IsEastOf((int x, int y) aCoord, (int x, int y) bCoord) {
			bool isEastOf = (aCoord.x > bCoord.x) ? true : false;
			return isEastOf;
		}

		/// <summary>
		/// Checks if a point is West of another point.
		/// </summary>
		/// <param name="aCoord">First points Coordinates.</param>
		/// <param name="bCoord">Second poonts Coordinates.</param>
		/// <returns></returns>
		static bool IsWestOf((int x, int y) aCoord, (int x, int y) bCoord) {
			bool isWestOf = (aCoord.x < bCoord.x) ? true : false;
			return isWestOf;
		}
	}
}
