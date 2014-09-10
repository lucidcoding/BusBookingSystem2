using MongoDB.Driver;
using System;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization;

namespace BusBookingSystem.Data.Common
{
    public class Repository
    {
        protected string _connectionString;
        protected MongoClient _client;
        protected MongoServer _server;
        protected MongoDatabase _database;

        public Repository()
        {
            _connectionString = "mongodb://localhost";
            _client = new MongoClient(_connectionString);
            _server = _client.GetServer();
            _database = _server.GetDatabase("BusBookingSystem");

#warning This should be done properly http://stackoverflow.com/questions/21386347/how-do-i-detect-whether-a-mongodb-serializer-is-already-registered
            //var dateSerializationOptions = BsonSerializer.LookupSerializer(typeof(DateTime)).GetDefaultSerializationOptions() as DateTimeSerializationOptions;

            try
            {
                BsonSerializer.RegisterSerializer(typeof(DateTime), new DateTimeSerializer(DateTimeSerializationOptions.LocalInstance));
            }
            catch { }
        }
    }
}
