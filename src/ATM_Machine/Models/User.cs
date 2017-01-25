using MongoDB.Bson;
using System;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

public class User{

    public BsonObjectId _id;
    public string name { get; private set;}
    public double balance {get; private set;}
    public int age { get; private set; }

    //model log
    [BsonElement(elementName: "logs")]
    public IEnumerable<BsonDocument> logs;


    public string email {get; private set;}
    public string password{get; private set;}

    public void setName(string nameToSet){
        this.name = nameToSet;
    }

    public void setBalance(double balanceToSet){
        this.balance = balanceToSet;
    }

    public void setAge(int ageToSet){
        this.age = ageToSet;
    }

    public void setPassWord(string passwordToSet){
        this.password = passwordToSet;
    }

    public void setEmail(string emailToSet){
        this.email = emailToSet;
    }
}

