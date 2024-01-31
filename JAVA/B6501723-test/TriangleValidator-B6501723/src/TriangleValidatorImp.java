
public class TriangleValidatorImp extends TriangleValidator {

	@Override
	public String validateTriangle(int a, int b, int c) {
		
		if(!(a>=1 && a<=200))
			return "a invalid";
		if(!(b>=1 && b<=200))
			return "b invalid";
		if(!(c>=1 && c<=200))
			return "c invalid";
		
		boolean c4 = a < b+c;
		boolean c5 = b < a+c;
		boolean c6 = c < a+b;
		
		if(!(c4 & c5 & c6))
			return "NotATriangle";
		else if(a==b && b == c)
			return "Equilateral";
		
		else if(a!=b && a!=c && b!=c) {
			if (isRightAngleTriangle(a, b, c)) 
				 return "Scalene Right Triangle";
			 
	            else 
	            	return "Scalene";
		}
				 
		
			 
		else  if (a == b && a != c) {
            return "Isosceles Right Triangle";
        } else if (a != b && b == c) {
            return "Isosceles Right Triangle";
        }
            else
                return "Isosceles";
            
            
        
		
		
	}
	private boolean isRightAngleTriangle(int a, int b, int c) {
	    // ทฤษฎีบทพีทาโกรัส a, b และ c คือ a กำลัง 2 + b กำลัง 2 = c กำลัง 2
	    return (a * a + b * b == c * c) || (b * b + c * c == a * a) || (a * a + c * c == b * b);
	}
	
	
}
