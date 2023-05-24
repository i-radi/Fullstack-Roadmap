namespace DesignPattern.CreationalPatterns.Builder_Pattern
{
    // Builders Interface
    public interface IBuilder
    {
         void StartUpOperations();
         void BuildBody();
         void InsertWheels();
         void AddHeadlights();
         void  EndOperations();
         Product GetVehicle();
    }
}