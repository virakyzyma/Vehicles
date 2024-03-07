namespace ConsoleApp27
{
    internal class Program
    {
        static void Main()
        {
            Vehicles[] vehicles =
            {
                new Truck("TRUCK", 20),
                new Fighter("FIGHTER", 130) {TypeOfConstruction = "A", MaxSpeed = 100},
                new Helicopter("HELICOPTER", 40) {TypeOfConstruction = "B", MaxSpeed = 22}
            };
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
                vehicle.Drive();
            }
        }
        public abstract class Vehicles
        {
            protected Vehicles(string model, float fuelConsumption)
            {
                Model = model;
                FuelConsumption = fuelConsumption;
            }
            public string Model { get; set; }
            protected float fuelConsumption;
            public abstract float FuelConsumption { get; set; }
            public abstract void Drive();
            public override string ToString()
            {
                return $"Model: {Model}, FuelConsumption: {FuelConsumption}";
            }
        }
        public class Truck : Vehicles
        {
            public Truck(string model, float fuelConsumption) : base(model, fuelConsumption) { }
            public override float FuelConsumption
            {
                get => fuelConsumption;
                set => fuelConsumption = value > 5 && value < 40 ? value : throw new Exception("Not valid fuelConsumption");
            }
            public override void Drive()
            {
                Console.WriteLine("The truck is moving\n");
            }
            public override string ToString()
            {
                return $"{base.ToString()}";
            }
        }
        public abstract class Aircraft : Vehicles
        {
            public Aircraft(string model, float fuelConsumption) : base(model, fuelConsumption) { }
            protected string typeOfConstruction;
            public abstract string TypeOfConstruction { get; set; }
            protected float maxSpeed;
            public abstract float MaxSpeed { get; set; }
            public override string ToString()
            {
                return $"{base.ToString()}, TypeOfConstruction: {typeOfConstruction}, MaxSpeed: {maxSpeed}";
            }
        }
        public class Helicopter : Aircraft
        {
            public Helicopter(string model, float fuelConsumption) : base(model, fuelConsumption) { }
            public override string TypeOfConstruction { get; set; }
            public override float MaxSpeed
            {
                get => maxSpeed;
                set => maxSpeed = value > 10 && value < 110 ? value : throw new Exception("Not valid maxSpeed");
            }
            public override float FuelConsumption
            {
                get => fuelConsumption;
                set => fuelConsumption = value > 10 && value < 60 ? value : throw new Exception("Not valid fuelConsumption");
            }
            public override void Drive()
            {
                Console.WriteLine("Helicopter flies\n");
            }
        }
        public class Fighter : Aircraft
        {
            public Fighter(string model, float fuelConsumption) : base(model, fuelConsumption) { }
            public override string TypeOfConstruction { get; set; }
            public override float MaxSpeed
            {
                get => maxSpeed;
                set => maxSpeed = value > 30 && value < 300 ? value : throw new Exception("Not valid maxSpeed");
            }
            public override float FuelConsumption
            {
                get => fuelConsumption;
                set => fuelConsumption = value > 10 && value < 175 ? value : throw new Exception("Not valid fuelConsumption");
            }
            public override void Drive()
            {
                Console.WriteLine("Fighter plane flies\n");
            }
        }
    }
}