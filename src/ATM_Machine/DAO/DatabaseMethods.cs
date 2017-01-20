using MongoDB.Driver;
using System.Linq;
using MongoDB.Driver.Linq;
using MongoDB.Bson;

public class DatabaseMethods{

    public bool registerSingedUp(User user){ 
        try{
            var client = new MongoClient();
            var database = client.GetDatabase("ATM_Machine");
            var collection = database.GetCollection<User>("Users");    
            collection.InsertOne(user);
            return true;
            }
            catch
            {
            return false;
            }
        }
    public bool verifyCadastredEmail(string email){
        var client = new MongoClient();
        var database = client.GetDatabase("ATM_Machine");
        var collection = database.GetCollection<User>("Users");
        //criar validação de e-mail igual, não deixar passar
        var count = collection.AsQueryable().Where(u => u.email == email).Count();

        if(count == 0){
            return true;
        }else{
            return false;
        }
    }


    public bool loginDatabase(string email, string password){
        var client = new MongoClient();
        var database = client.GetDatabase("ATM_Machine");
        var collection = database.GetCollection<User>("Users");
        //criar validação de e-mail igual, não deixar passar
        var countLogin = collection.AsQueryable().Where(u => u.email == email && u.password == password).Count();
        
        if(countLogin == 1){
            return true;
        }else{
            return false;
        }
    }

    public User montUser(string email){
        var client = new MongoClient();
        var database = client.GetDatabase("ATM_Machine");
        var collection = database.GetCollection<User>("Users");
        var query = collection.AsQueryable<User>().Where(e => e.email == email).Select(User => User);
        

        return query.First();
    }

    public void changeCredits(string email, double valueToChange)
    {
        var client = new MongoClient();
        var database = client.GetDatabase("ATM_Machine");
        var collection = database.GetCollection<User>("Users");
        var user = new User();
        user.setBalance(valueToChange);
        var update = new BsonDocument("$inc", new BsonDocument { { "balance", user.balance } });
        var filter = new BsonDocument( new BsonDocument { { "email", email} });
        // var filter = MongoDB.Driver.Builders<User>.Filter.Eq("email", email);
        collection.FindOneAndUpdate(filter, update);
       

    }

  

}