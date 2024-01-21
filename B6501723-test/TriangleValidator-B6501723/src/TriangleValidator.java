
public abstract class TriangleValidator {

	/**
	 * @param a as int from 0 to 200
	 * @param b as int from 0 to 200
	 * @param c as int from 0 to 200
	 * @return "Equilateral", "Isosceles", "Scalene", "NotATriangle",
	 *         "a invalid", "b invalid", or "c invalid"
	 */
	public abstract String validateTriangle(int a, int b, int c);
	
}
