namespace DesignPattern.BehavioralPatterns.TemplateMethod
{
    class Client
    {
        public static void ClientCode(AbstractClass ac)
        {
            ac.templateMethod();
        }
    }
}