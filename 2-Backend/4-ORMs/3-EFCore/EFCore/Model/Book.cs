namespace EFCore.Model
{
    public class Book
    {
        public int BookKey { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        //[ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
    }
}
