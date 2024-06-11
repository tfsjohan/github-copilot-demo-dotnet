namespace DemoApp.Models
{
    public class A
    {
        public B BInstance { get; set; }

        public A(B b)
        {
            BInstance = b;
        }

        public void DoSomething()
        {
            BInstance.DoSomethingElse();
        }
    }

    public class B
    {
        public A AInstance { get; set; }

        public B(A a)
        {
            AInstance = a;
        }

        public void DoSomethingElse()
        {
            AInstance.DoSomething();
        }
    }
}