using EndIf.Yust;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class VariableTests
    {
        [TestCase("Age > 22", true)]
        public void ComparisonTest(string expression, bool result)
        {
            var context = new Dictionary<string, object>
            {
                { "Age", 25 }
            };

            var p = new Proglet<bool>(expression);

            Assert.AreEqual(result, p.Eval(context));
        }

        [TestCase("Age > 22", "Age")]
        [TestCase("Age + Kids > 22", "Age,Kids")]
        public void VariablesUsedTest(string expression, string result)
        {
            var p = new Proglet<bool>(expression);

            IEnumerable<string> variables = p.VariablesUsed();

            Assert.AreEqual(result, string.Join(',',variables.OrderBy(s => s)));
        }
    }
}
