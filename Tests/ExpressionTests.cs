using NUnit.Framework;
using EndIf.Yust;

namespace Tests
{
    public class Tests
    {
        [TestCase("25*40",   1000)]
        [TestCase("25 + 40",   65)]
        [TestCase("7 + 2 * 3", 13)]  // 7 2 3 * +
        [TestCase("7 * 2 + 3", 17)]
        [TestCase("(2 + 3)*7", 35)]  // 2 3 + 7 *
        [TestCase("7-5+1",      3)]
        [TestCase("7-5",        2)]
        [TestCase("7-(5+1)",    1)]
        [TestCase("4/2",        2)]
        [TestCase("1/3",      1/3)]
        public void TestCalculation(string expression, int result)
        {
            var p = new Proglet<int>(expression);

            Assert.AreEqual(result, p.Eval());
        }

        [TestCase("1=1", true)]
        [TestCase("1=0", false)]
        [TestCase("1>0", true)]
        [TestCase("1<0", false)]
        [TestCase("0<1", true)]
        [TestCase("4 >= 2", true)]
        [TestCase("4 <= 2", false)]
        [TestCase("4 <> 2", true)]
        [TestCase("1<0", false)]
        public void TestComparison(string expression, bool result)
        {
            var p = new Proglet<bool>(expression);

            Assert.AreEqual(result, p.Eval());
        }
    }
}