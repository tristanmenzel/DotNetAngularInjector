using NUnit.Framework;
using Shouldly;

namespace AngularInjector.Tests
{
    [TestFixture]
    public class WhenThereIsAnAnnotationAndOneParameter : BaseTest
    {
        [Test]
        public void TheInputShouldContainAnInjectStatementForOneDependency()
        {
            const string input = "angular.module('blah').controller('blahblah', blahblah);/*inject(blahblah)*/function blahblah(a){}";
            const string expected = "angular.module('blah').controller('blahblah', blahblah);/*inject(blahblah)*/blahblah.$inject=['a'];function blahblah(a){}";

            var res = _injector.Inject(input);

            res.ShouldBe(expected);
        }
    }
}