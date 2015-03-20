using NUnit.Framework;
using Shouldly;

namespace AngularInjector.Tests
{
    [TestFixture]
    public class WhenThereIsAnAnnotationButNoParameters : BaseTest
    {
        [Test]
        public void TheInputShouldBeUnchanged()
        {
            const string input = "angular.module('blah').controller('blahblah', blahblah);/*inject(blahblah)*/function blahblah(){}";

            var res = _injector.Inject(input);

            res.ShouldBe(input);
        }
    }
}