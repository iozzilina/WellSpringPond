namespace WellSpringPond.Services
{
   using WellSpringPond.Data;

    public abstract class Service
    {
        protected Service(WellSpringPondContext context)
        {
            this.Context = context;
        }
        
       protected WellSpringPondContext Context { get; }



        
    }
}
