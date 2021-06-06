using webapi.Model;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

namespace webapi.DataBase{

    public class MongoDBClient{

        private const string dataBaseName = "asp_api_user";
        private const string collectionName = "user";

        private readonly IMongoCollection<User> userCollection;


        public MongoDBClient(IMongoClient mongoClient){
            IMongoDatabase database = mongoClient.GetDatabase(dataBaseName);
            userCollection = database.GetCollection<User>(collectionName);
        
        }

        public bool AddUser (User user){
            try
            {
                userCollection.InsertOne(user);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public IEnumerable<User> GetUsers(){
            return userCollection.Find(new  BsonDocument()).ToList();
        }

        public bool UpdateUser(string id,User user){
            try
            {
                var filter = Builders<User>.Filter.Eq("_id", id);
               var arrayUpdate = Builders<User>.Update.Set("user", user.user).Set("email",user.email).Set("password",user.password);
                userCollection.UpdateOne(filter,arrayUpdate);
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteUser(string id){
            try
            {
               var deleteFilter = Builders<User>.Filter.Eq("_id", id);
                userCollection.DeleteOne(deleteFilter);
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }


           public IEnumerable<User> GetUser(string id){
          
               var getFilter = Builders<User>.Filter.Eq("_id", id);
               
                return userCollection.Find(getFilter).ToList();
           
        }

        }

}