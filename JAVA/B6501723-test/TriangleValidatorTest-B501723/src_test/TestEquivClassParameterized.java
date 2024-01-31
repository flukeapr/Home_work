import static org.junit.Assert.*;

import java.util.Arrays;
import java.util.Collection;

import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.Parameterized;

/**
 * https://web.archive.org/web/20140220002834/http://isagoksu.com/2009/development/agile-development/test-driven-development/using-junit-parameterized-annotation/
 * http://www.mkyong.com/unittest/junit-4-tutorial-6-parameterized-test/
 */

@RunWith(Parameterized.class)
public class TestEquivClassParameterized {

	private int a;
	private int b;
	private int c;
	private String expected;
	
	private TriangleValidator t;
	
	@Parameterized.Parameters
    public static Collection<Object[]> primeNumbers() {
        return Arrays.asList(new Object[][] {
        			// Weak-Strong Normal Equivalence Class Test Cases
                { 5, 5, 5, "Equilateral" },
                { 2, 2, 3, "Isosceles" },
                { 3, 4, 5, "Scalene Right Triangle" }, // แก้ไขจากที่ต้นฉบับอาจารย์ให้มา บรรทัดนี้ จาก expected Scalene เป็น Scalene Right Triangle เนื่องจากเข้าทฤษฏี พีทาโกรัส 3*3+ 4*4 = 5*5 จะได้ Scalene Right Triangle เป็นสามเหลี่ยมหน้าจั่วที่มีมุม 90 องศา
                { 4, 1, 2, "NotATriangle" },
                { 2, 2, 4, "Scalene" },
                { 9, 12, 15, "Isosceles Right Triangle" },
                { 3, 4, (int) Math.sqrt(25), "Isosceles Right Triangle" },
                
                // Weak Robust Equivalence Class Test Cases
                { -1, 5, 5, "a invalid" },
                { 5, -1, 5, "b invalid" },
                { 5, 5, -1, "c invalid" },
                { 201, 5, 5, "a invalid" },
                { 5, 201, 5, "b invalid" },
                { 5, 5, 201, "c invalid" },

                // Strong Robust Equivalence Class Test Cases
                { -1, 5, 5, "a invalid" },
                { 5, -1, 5, "b invalid" },
                { 5, 5, -1, "c invalid" },
                { -1, -1, 5, "a invalid" },
                { 5, -1, -1, "b invalid" },
                { -1, 5, -1, "a invalid" },
                { -1, -1, -1, "a invalid" },

                { 201, 5, 5, "a invalid" },
                { 5, 201, 5, "b invalid" },
                { 5, 5, 201, "c invalid" },
                { 201, 201, 5, "a invalid" },
                { 5, 201, 201, "b invalid" },
                { 201, 5, 201, "a invalid" },
                { 201, 201, 201, "a invalid" }
        });
    }
	
	@Before
    public void initialize() {
		t = new TriangleValidatorImp();
		
    }
	
	public TestEquivClassParameterized(int a, int b, int c, String expected){
		this.a = a;
		this.b = b;
		this.c = c;
		this.expected = expected;
	}
	
	@Test
	public void testDriver() {
		String ttype = t.validateTriangle(a, b, c);
		assertEquals(ttype, expected);
	}

}
