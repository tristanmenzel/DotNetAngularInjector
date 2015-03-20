using NUnit.Framework;
using Shouldly;

namespace AngularInjector.Tests
{
    [TestFixture]
    public class WhenThereAreNoAnnotations:BaseTest
    {
        [Test]
        public void TheInputShouldBeUnchanged()
        {
            const string input = "angular.module('blah').controller('blahblah', blahblah);function blahblah(a, b, c){}";

            var res = _injector.Inject(input);

            res.ShouldBe(input);
        }
    }
}