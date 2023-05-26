using System;

//Add a namespace for the Pattern used

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            #region CreationalPatterns

            #region Singletol
            /*
            //Same Instance
            SingletonClass s1= SingletonClass.GetInstance();
            SingletonClass s2= SingletonClass.GetInstance();
            */
            #endregion

            #region Factory
            /*
            Console.WriteLine("Select Type of Shape\n R => Rectangle\n S => Square\n C => Circle");
            string type = Console.ReadLine();

            Shape shape = (new ShapeFactory()).GetShape(type);
            Console.WriteLine($" Area of {shape.GetType().ToString().Split('.').Last()} : {shape.Area()}");
            */
            #endregion

            #region AbstractFactory
            /*
            Console.WriteLine("Select Type of Shape\n R => Rectangle\n S => Square\n C => Circle");
            string type = Console.ReadLine();

            AbstractFactory af = new ShapeFactory();

            Shape shape =af.GetShape(type);
            Console.WriteLine($" Area of {shape.GetType().ToString().Split('.').Last()} : {shape.Area()}");
            */
            #endregion

            #region Prototype
            /*
            Employee tempEmp1 = new Employee();
            tempEmp1.Name = "Ahmed";
            tempEmp1.Id = 1;
            tempEmp1.EmpAddress = new Address { City = "city 1", Building = "B1", StreetName = "street name" };

            Employee tempEmp2 = tempEmp1.Clone();
            Employee tempEmp3 = tempEmp1.DeepCopy();

            Console.WriteLine("========= Temp Emp 1 Original Values=============");
            Console.WriteLine(tempEmp1.ToString());
            Console.WriteLine("========= Temp Emp 2 Copy========================");
            Console.WriteLine(tempEmp2.ToString());
            Console.WriteLine("========= Temp Emp 3 Copy========================");
            Console.WriteLine(tempEmp3.ToString());

            tempEmp1.EmpAddress.City = "new city";
            tempEmp1.Name = "Mohamed";
            tempEmp1.Id = 10;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========= Temp Emp 1 After Change =============");
            Console.WriteLine(tempEmp1.ToString());
            Console.WriteLine("========= Temp Emp 2 ==========================");
            Console.WriteLine(tempEmp2.ToString());
            Console.WriteLine("========= Temp Emp 3 ==========================");
            Console.WriteLine(tempEmp3.ToString());
            */
            #endregion

            #region Builder
            /*
            Console.WriteLine("***Builder Pattern***");
            Director director = new Director();
            IBuilder carBuilder = new Car("Jeep");
            IBuilder motorCycleBuilder = new MotorCycle("Honda");

            // Making Car
            director.Construct(carBuilder);
            Product car = carBuilder.GetVehicle();
            Console.WriteLine($"Car {car.Show()}");
            
            //Making MotorCycle
            director.Construct(motorCycleBuilder);
            Product motorCycle = motorCycleBuilder.GetVehicle();
            Console.WriteLine($"MotorCycle {motorCycle.Show()}");
            */
            #endregion

            #endregion

            #region StructuralPatterns

            #region  Adapter

            /*
            Employee emp =new Employee ();
            MachineOperator machineOperator=new MachineOperator ();
            machineOperator.BasicSalary =1200;

            emp.Name ="test"; emp.BasicSalary=1000;
            SalaryAdapter calculator = new SalaryAdapter ();
            var salary= calculator.CalcSalary(machineOperator);
            WriteColoredLine(salary.ToString());
            */

            #endregion

            #region Composite
            /*
            IEmployee John = new Employee("John", "IT");
            IEmployee Mike = new Employee("Mike", "IT");
            IEmployee Jason = new Employee("Jason", "HR");
            IEmployee Eric = new Employee("Eric", "HR");
            IEmployee Henry = new Employee("Henry", "HR");

            IEmployee Ahmed = new Manager("Ahmed", "IT")
                {SubOrdinates = {John,Mike}};
            IEmployee Mohammed = new Manager("Mohammed", "HR")
                {SubOrdinates = { Jason, Eric , Henry } };

            IEmployee Mahmoud = new Manager("Mahmoud", "Project Manager")
                { SubOrdinates = { Ahmed, Mohammed } };
            
            Mahmoud.GetDetails(1);
            */
            #endregion

            #region Proxy
            /*
            SMSServiceProxy proxy = new SMSServiceProxy ();

            Console.WriteLine(proxy.SendSMS("123", "01100000", "message 1"));
            Console.WriteLine(proxy.SendSMS("123", "01100000", "message 1"));
            Console.WriteLine(proxy.SendSMS("123", "01100000", "message 1"));
            */
            #endregion

            #region Flyweight
            /*
            DiscountCalcFactory discountFactory = new DiscountCalcFactory();
            var calculator = discountFactory.GetDiscountCalc("day");
            var val = calculator.GetDiscountValue(DateTime.Now.Date);
            Console.WriteLine(val.ToString());
            */
            #endregion

            #region Facade 
            /*
            ShoppingBasket basket = new ShoppingBasket();
            basket.AddItem(new BasketItem { ItemID = "123", ItemPrice = 50, Quantity = 3 });
            basket.AddItem(new BasketItem { ItemID = "456", ItemPrice = 40, Quantity = 2 });

            PurchaseOrder order = new PurchaseOrder();
            order.CreateOrder(basket, "name:mohammed,bank:123456789,mobile:0100000");
            */
            #endregion

            #region  Decorator 
            /*
            //Add Behavior to Proxy Pattern
            //Send Email after sent SMS
            ConcereteSMSService smsService = new ConcereteSMSService ();
            NotificationEmailDecorator emailDecorator = new NotificationEmailDecorator();             
             
            emailDecorator.SetService(smsService);
            Console.WriteLine(emailDecorator.SendSMS("123","01100000","message 1"));
            */
            #endregion

            #region Bridge
            /*
            PToolPSystemBridge payment1 =new PToolPSystemBridge(new CardPaymentTool());
            payment1.Pay(new CDUPaymentSystem());
            payment1.Pay(new MCAPaymentSystem());

            PToolPSystemBridge payment2 = new PToolPSystemBridge(new NetBankingPaymentTool());
            payment2.Pay(new CDUPaymentSystem());
            payment2.Pay(new MCAPaymentSystem());
            */
            #endregion

            #endregion

            #region BehavioralPatterns

            #region ChainOfResponsibility
            
    //         var monkey = new MonkeyHandler();
    //         var squirrel = new SquirrelHandler();
    //         var dog = new DogHandler();
    //
    //         monkey.setNext(squirrel).setNext(dog);
    //
    //         Console.WriteLine("Chain: Monkey > Squirerel > Dog\n");
    //         Client.ClientCode(monkey);
    //         Console.WriteLine();
    //
    //         Console.WriteLine("Subchain: Squirrel > Dog\n");
    //         Client.ClientCode(squirrel);
            
            #endregion

            #endregion

            Console.ReadKey(true);
        }
    }
}
