using System;

public class Class1
{
	public int[] ScaleWeights(int[] weights) {
		int wLen = weights.Length;
		int[] scaledWeights = new int[wLen];
		scaledWeights[wLen - 1] = 1;
		for (int weight = wLen - 1; weight > 0; weight--) {
			scaledWeights[weight - 1] = scaledWeights[weight] * weights[weight];
		}
		return scaledWeights;
	}

	public int[] NaryFromInt2(int val, int[] scaledWeights) {
		//MaxLimit Check
		int totalMax = 1;
		for (int i = 0; i < scaledWeights.Length; i++) {
			totalMax *= scaledWeights[i];
		}
		if (val > totalMax)
			return null;
		///Contine
		int[] output = new int[scaledWeights.Length];
		for (int i = 0; i < scaledWeights.Length; i++) {
			while (val >= scaledWeights[i]) {
				val -= scaledWeights[i];
				output[i] += 1;
			}
		}
		return output;
	}
}
