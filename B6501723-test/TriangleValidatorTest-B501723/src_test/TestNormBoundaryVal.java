import static org.junit.Assert.*;

import org.junit.Test;

public class TestNormBoundaryVal {

	@Test
	public void test001() {
		TriangleValidator t = new TriangleValidatorImp();
		String ttype = t.validateTriangle(100, 100, 1);
		assertEquals(ttype, "Isosceles");
	}

	@Test
	public void test002() {
		TriangleValidator t = new TriangleValidatorImp();
		String ttype = t.validateTriangle(100, 100, 2);
		assertEquals(ttype, "Isosceles");
	}

	@Test
	public void test003() {
		TriangleValidator t = new TriangleValidatorImp();
		String ttype = t.validateTriangle(100, 100, 100);
		assertEquals(ttype, "Equilateral");
	}

	@Test
	public void test004() {
		TriangleValidator t = new TriangleValidatorImp();
		String ttype = t.validateTriangle(100, 100, 199);
		assertEquals(ttype, "Isosceles");
	}

	@Test
	public void test005() {
		TriangleValidator t = new TriangleValidatorImp();
		String ttype = t.validateTriangle(100, 100, 200);
		assertEquals(ttype, "NotATriangle");
	}

	@Test
	public void test006() {
		TriangleValidator t = new TriangleValidatorImp();
		String ttype = t.validateTriangle(100, 1, 100);
		assertEquals(ttype, "Isosceles");
	}

	@Test
	public void test007() {
		TriangleValidator t = new TriangleValidatorImp();
		String ttype = t.validateTriangle(100, 2, 100);
		assertEquals(ttype, "Isosceles");
	}

	@Test
	public void test008() {
		test003();
	}

	@Test
	public void test009() {
		TriangleValidator t = new TriangleValidatorImp();
		String ttype = t.validateTriangle(100, 199, 100);
		assertEquals(ttype, "Isosceles");
	}

	@Test
	public void test010() {
		TriangleValidator t = new TriangleValidatorImp();
		String ttype = t.validateTriangle(100, 200, 100);
		assertEquals(ttype, "NotATriangle");
	}

	@Test
	public void test011() {
		TriangleValidator t = new TriangleValidatorImp();
		String ttype = t.validateTriangle(1, 100, 100);
		assertEquals(ttype, "Isosceles");
	}

	@Test
	public void test012() {
		TriangleValidator t = new TriangleValidatorImp();
		String ttype = t.validateTriangle(2, 100, 100);
		assertEquals(ttype, "Isosceles");
	}

	@Test
	public void test013() {
		test003();
	}

	@Test
	public void test014() {
		TriangleValidator t = new TriangleValidatorImp();
		String ttype = t.validateTriangle(199, 100, 100);
		assertEquals(ttype, "Isosceles");
	}

	@Test
	public void test015() {
		TriangleValidator t = new TriangleValidatorImp();
		String ttype = t.validateTriangle(200, 100, 100);
		assertEquals(ttype, "NotATriangle");
	}
	
	@Test
	public void test016() {
		TriangleValidator t = new TriangleValidatorImp();
		
		for (int a = 1; a < 200; a++) {
	        for (int b = 1; b < 200; b++) {
	            for (int c = 1; c < 200; c++) {    
	                if (a != b && b != c && a != c) {
	                    String ttype = t.validateTriangle(a, b, c);
	                    if (ttype.equals("Scalene")) {
	                    	
	                    	assertEquals(ttype, "Scalene");
	                    }else if(ttype.equals("Scalene Right Triangle")) {
	                    	
	                    	assertEquals(ttype, "Scalene Right Triangle");
	                    }else {
	                    	
	                    	assertEquals(ttype, "NotATriangle");
	                    }
	                    
	                }
	            }
	        }
		}
	    }
	   
	@Test
	public void test017() {
		TriangleValidator t = new TriangleValidatorImp();
		
		String ttype = t.validateTriangle(3, 4, 5);
		
		assertEquals(ttype, "Scalene Right Triangle");
	    }
		
	
	@Test
	public void test018() {
	    TriangleValidator t = new TriangleValidatorImp();
	    String ttype = t.validateTriangle(3, 3, 4);
	    
	    assertEquals(ttype, "Isosceles Right Triangle");
	}
	@Test
	public void test019() {
	    TriangleValidator t = new TriangleValidatorImp();
	    String ttype = t.validateTriangle(1, 100, 100);
	    System.out.println(ttype);
	    assertEquals(ttype, "Isosceles");
	}

}
