using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB_CRUD_Project.Models;
using MongoDB_CRUD_Project.Repositories;

namespace MongoDB_CRUD_Project.Services;

public class StudentService
{
    private readonly IMongoCollection<Student> _studentsCollection;

    public StudentService(
        IOptions<SchoolDatabaseSettings> schoolDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            schoolDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            schoolDatabaseSettings.Value.DatabaseName);

        _studentsCollection = mongoDatabase.GetCollection<Student>(
            schoolDatabaseSettings.Value.StudentsCollectionName);
    }

    public async Task<List<Student>> GetAsync() =>
        await _studentsCollection.Find(_ => true).ToListAsync();

    public async Task<Student?> GetAsync(string id) =>
        await _studentsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Student newstudent) =>
        await _studentsCollection.InsertOneAsync(newstudent);

    public async Task UpdateAsync(string id, Student updatedstudent) =>
        await _studentsCollection.ReplaceOneAsync(x => x.Id == id, updatedstudent);

    public async Task RemoveAsync(string id) =>
        await _studentsCollection.DeleteOneAsync(x => x.Id == id);
}

