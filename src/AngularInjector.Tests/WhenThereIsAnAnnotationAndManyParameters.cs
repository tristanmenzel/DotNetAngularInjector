using NUnit.Framework;
using Shouldly;

namespace AngularInjector.Tests
{
    [TestFixture]
    public class WhenThereIsAnAnnotationAndManyParameters : BaseTest
    {
        [Test]
        public void TheInputShouldContainAnInjectStatementForManyDependencies()
        {
            const string input = "angular.module('blah').controller('blahblah', blahblah);/*inject(blahblah)*/function blahblah(a, b, c, d){}";
            const string expected = "angular.module('blah').controller('blahblah', blahblah);/*inject(blahblah)*/blahblah.$inject=['a','b','c','d'];function blahblah(a, b, c, d){}";

            var res = _injector.Inject(input);

            res.ShouldBe(expected);
        }
    }
}