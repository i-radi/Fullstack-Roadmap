using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDB_CRUD_Project.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        [BsonElement("Address")]
        public Address PrimaryAddress { get; set; } = new();
        [BsonElement("dob")]
        public DateTime DateOfBitrth { get; set; }
    }
}
