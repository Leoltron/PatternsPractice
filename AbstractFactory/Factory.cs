namespace AbstractFactory
{
    public abstract class Body
    {
    }

    public abstract class Engine
    {
    }

    public abstract class Interior
    {
    }

    public abstract class Windows
    {
    }

    public abstract class Headlights
    {
    }

    public abstract class AbstractCarFactory
    {
        public abstract Body CreateBody();
        public abstract Engine CreateEngine();
        public abstract Interior CreateInterior();
        public abstract Windows CreateWindows();
        public abstract Headlights CreateHeadlights();
    }

    public class BmwBody : Body
    {
    }

    public class BmwEngine : Engine
    {
    }

    public class BmwInterior : Interior
    {
    }

    public class BmwWindows : Windows
    {
    }

    public class BmwHeadlights : Headlights
    {
    }

    public class BmwCarFactory : AbstractCarFactory
    {
        public override Body CreateBody() => new BmwBody();
        public override Engine CreateEngine() => new BmwEngine();
        public override Interior CreateInterior() => new BmwInterior();
        public override Windows CreateWindows() => new BmwWindows();
        public override Headlights CreateHeadlights() => new BmwHeadlights();
    }

    public class AudiBody : Body
    {
    }

    public class AudiEngine : Engine
    {
    }

    public class AudiInterior : Interior
    {
    }

    public class AudiWindows : Windows
    {
    }

    public class AudiHeadlights : Headlights
    {
    }

    public class AudiCarFactory : AbstractCarFactory
    {
        public override Body CreateBody() => new AudiBody();
        public override Engine CreateEngine() => new AudiEngine();
        public override Interior CreateInterior() => new AudiInterior();
        public override Windows CreateWindows() => new AudiWindows();
        public override Headlights CreateHeadlights() => new AudiHeadlights();
    }

    public class Car
    {
        public Body Body { get; }
        public Engine Engine { get; }
        public Interior Interior { get; }
        public Windows Windows { get; }
        public Headlights Headlights { get; }

        public Car(AbstractCarFactory carFactory)
        {
            Body = carFactory.CreateBody();
            Engine = carFactory.CreateEngine();
            Interior = carFactory.CreateInterior();
            Windows = carFactory.CreateWindows();
            Headlights = carFactory.CreateHeadlights();
        }
    }
}
