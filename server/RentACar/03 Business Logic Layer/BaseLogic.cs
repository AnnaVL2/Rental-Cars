using System;

namespace MySpace
{
    public class BaseLogic : IDisposable
    {
        protected RentalCarsEntities DB = new RentalCarsEntities();

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
