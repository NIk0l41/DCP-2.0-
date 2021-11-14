using System;


namespace DCP_081
{
	public partial class Program
	{
		public static int[] ScaleWeights(int[] weights)
		{
			int wLen = weights.Length;
			int[] scaledWeights = new int[wLen];
			scaledWeights[wLen - 1] = 1;
			for (int weight = wLen - 1; weight > 0; weight--)
			{
				scaledWeights[weight - 1] = scaledWeights[weight] * weights[weight];
			}
			return scaledWeights;
		}

		public static int[] NaryFromInt2(int val, int[] scaledWeights, int[] weights)
		{
			//MaxLimit Check
			int totalMax = 1;
			for (int i = 0; i < weights.Length; i++)
			{
				totalMax *= weights[i];
			}
			if (val > totalMax)
				return null;
			///Contine
			int[] output = new int[scaledWeights.Length];
			for (int i = 0; i < scaledWeights.Length; i++)
			{
				while (val >= scaledWeights[i])
				{
					val -= scaledWeights[i];
					output[i] += 1;
				}
			}
			return output;
		}

		static DigitMap[] MapToInput(DigitMap[] mapLib, string[] input) {
			DigitMap[] mapping = new DigitMap[input.Length];
			//For each input item.
			for (int inputNo = 0; inputNo < input.Length; inputNo++) {
				//For each map in mapLib
				for (int possibleMap = 0; possibleMap < mapLib.Length; possibleMap++) {
					if (input[inputNo] == mapLib[possibleMap].digit) {
						mapping[inputNo] = mapLib[possibleMap];
					}
				}
			}
			return mapping;
		}
	}
}
