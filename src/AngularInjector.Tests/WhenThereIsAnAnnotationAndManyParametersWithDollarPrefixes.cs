using NUnit.Framework;
using Shouldly;

namespace AngularInjector.Tests
{
    [TestFixture]
    public class WhenThereIsAnAnnotationAndManyParametersWithDollarPrefixes : BaseTest
    {
        [Test]
        public void TheInputShouldContainAnInjectStatementForManyDependencies()
        {
            const string input = "angular.module('blah').controller('blahblah', blahblah);/*inject(blahblah)*/function blahblah($scope, $timeout){}";
            const string expected = "angular.module('blah').controller('blahblah', blahblah);/*inject(blahblah)*/blahblah.$inject=['$scope','$timeout'];function blahblah($scope, $timeout){}";

            var res = _injector.Inject(input);

            res.ShouldBe(expected);
        }
    }
}