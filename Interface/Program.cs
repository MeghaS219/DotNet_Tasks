namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gasolineRefuelAmount;
            Car car = new Car(0);
            Console.Write("Enter the amount of gasoline to refuel : ");
            gasolineRefuelAmount = Convert.ToInt32(Console.ReadLine());
            car.Refuel(gasolineRefuelAmount);
            car.Drive();
        }
    }
    
    interface IVehiculo       
    {            
        public void Drive();            
        public bool Refuel(int refuelamount);        
    }       
    class Car : IVehiculo        
    {           
        public int gasolineAmount;           
        public Car(int startingGasolineAmount)            
        {               
            gasolineAmount = startingGasolineAmount;
            
        }           
        public void Drive()           
        {               
            if (gasolineAmount > 0)               
            {                   
                Console.WriteLine("Driving");                
            }
            
        }           
        public bool Refuel(int refualamount)           
        {         
            gasolineAmount += refualamount;                
            return true;            
        }       
    }      
}
