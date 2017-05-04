namespace WellSpringPond.Services
{
   using WellSpringPond.Data;

    public abstract class Service
    {
        protected Service()
        {
            this.Context = new WellSpringPondContext();
        }
        
       protected WellSpringPondContext Context { get; }
        
    }
}
