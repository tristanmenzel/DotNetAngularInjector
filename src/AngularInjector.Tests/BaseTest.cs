namespace AngularInjector.Tests
{
    public class BaseTest
    {
        public BaseTest()
        {
            _injector = new Injector();
            
        }
        protected Injector _injector;
    }
}
