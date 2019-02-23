using DesignPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    #region Decorator pattern 

    public interface ICar
    {
        string GetDescription();
        double GetCost();
    }

    /// <summary>   
    /// Concrete Car   
    /// </summary>   
    public class EconomyCar : ICar
    {
        public string GetDescription()
        {
            return "Economy Car";
        }

        public double GetCost()
        {
            return 450000.0;
        }
    }


    public class DeluxCar : ICar
    {
        public string GetDescription()
        {
            return "Delux Car";
        }

        public double GetCost()
        {
            return 750000.0;
        }
    }


    public abstract class CarAccessoriesDecorator : ICar
    {

        private ICar _car;

        public CarAccessoriesDecorator(ICar aCar)
        {
            this._car = aCar;
        }

        public virtual string GetDescription()
        {
            return this._car.GetDescription();
        }

        public virtual double GetCost()
        {
            return this._car.GetCost();
        }
    }


    public class BasicAccessories : CarAccessoriesDecorator
    {
        public BasicAccessories(ICar aCar)
        : base(aCar)
        {

        }

        public override string GetDescription()
        {
            return base.GetDescription() + ",Basic Accessories Package";

        }

        public override double GetCost()
        {
            return base.GetCost() + 2000.0;
        }
    }



    public class AdvancedAccessories : CarAccessoriesDecorator
    {

        public ICar _car { get; set; }
        public AdvancedAccessories(ICar aCar)
        : base(aCar)
        {
            _car = aCar;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ",Advanced Accessories Package";
        }

        public override double GetCost()
        {
            return base.GetCost() + 10000.0;
        }
    }

    #endregion


    //public abstract class GraphicObject
    public abstract class GraphicObject
    {
        public virtual string Name { get; set; } = "Group";
        public string Color;
        private Lazy<List<GraphicObject>> children = new Lazy<List<GraphicObject>>();
        public List<GraphicObject> Children => children.Value;

        public int Id { get; set; }

        public GraphicObject(int id )
        {
            Id = id;
        }

        public  virtual void DrawMe() {
            Console.WriteLine("Hello from base class ");
        }

        private void Print(StringBuilder sb, int depth)
        {
            sb.Append(new string('*', depth))
              .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color} ")
              .AppendLine($"{Name}");
            foreach (var child in Children)
                child.Print(sb, depth + 1);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }

    }


    public class Circle : GraphicObject
    {
        public Circle() : base (1)
        {

        }

        public override string Name => "Circle";

        public override void DrawMe()
        {

            Console.WriteLine("Hellow from circle");
          //  base.DrawMe();
        }
    }

    public class Square : GraphicObject
    {

        public Square() : base(2)
        {

        }

        public override string Name => "Square";

        // In case of parent object point to child object 
        // this method will not be called, the base method will be invoked
        public  new  void DrawMe()
        {

            Console.WriteLine("Hellow from squre");
            //  base.DrawMe();
        }
    }





    class Program
    {
        static void Print(StringBuilder sb, int val )
        {

            sb.Append(val);

            if (val != 0)
            {
                Print(sb,val-1 );
            }

            Console.WriteLine(sb);
           
        }

        static void Main(string[] args)

        {

            Worker a = new Worker("Worker Tom", 5);
            Supervisor b = new Supervisor("Supervisor Mary", 6);
            Supervisor c = new Supervisor("Supervisor Jerry", 7);
            Supervisor d = new Supervisor("Supervisor Bob", 9);
            Worker e = new Worker("Worker Jimmy", 8);

            //set up the relationships
            b.AddSubordinate(a); //Tom works for Mary
            c.AddSubordinate(b); //Mary works for Jerry
            c.AddSubordinate(d); //Bob works for Jerry
            d.AddSubordinate(e); //Jimmy works for Bob

            //Jerry shows his happiness and asks everyone else to do the same
            if (c is IEmployee)
                (c as IEmployee).ShowHappiness();

            Console.Read();

            // ICar objCar = new EconomyCar();

            // //Wrp EconomyCar instancw with BasicAccessories.   
            // CarAccessoriesDecorator objAccessoriesDecorator = new BasicAccessories(objCar);

            //objAccessoriesDecorator = new AdvancedAccessories(objAccessoriesDecorator);



            // Console.Write("Car Detials: " + objAccessoriesDecorator.GetDescription());
            // Console.WriteLine("\n\n");
            // Console.Write("Total Price: " + objAccessoriesDecorator.GetCost());

            //var listOfShape = new List<GraphicObject> {
            //    new Square(),
            //    new Circle()
            //};

            //foreach (var item in listOfShape)
            //{
            //    item.DrawMe();
            //}




            // Print(new StringBuilder(), 2);
            //Composition pattern 
            //var drawing = new GraphicObject { Name = "My Drawing" };
            //drawing.Children.Add(new Square { Color = "Red" });
            //drawing.Children.Add(new Circle { Color = "Yellow" });

            //var group = new GraphicObject();
            //group.Children.Add(new Circle { Color = "Blue" });
            //group.Children.Add(new Square { Color = "Blue" });
            //drawing.Children.Add(group);

            // Console.WriteLine(drawing);

        }
    }
}

