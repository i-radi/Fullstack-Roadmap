using Newtonsoft.Json;

namespace DesignPattern.CreationalPatterns.Prototype_Pattern
{
    public abstract class CloneablePrototype<T>
    {
        /// <summary>
        /// Shallow copy
        /// Copy Stack Memory Only
        /// </summary>
        public T Clone() => (T) this.MemberwiseClone();


        /// <summary>
        /// Deep copy
        /// Copy both stack and heep Memory
        /// </summary>
        public T DeepCopy() => JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(this));
        
    }
}