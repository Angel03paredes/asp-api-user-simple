using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using webapi.Model;
using webapi.DataBase;

namespace webapi.Controllers{

    [ApiController]
    [Route("/api/user")]
    public class UserController:ControllerBase{

        private readonly MongoDBClient  userPersitence;

        public UserController( MongoDBClient  userPersitence){
            this.userPersitence = userPersitence;
        }

        [HttpGet]
        public IEnumerable<User> Get(){
            return userPersitence.GetUsers();
    }

    [HttpPost]
    public StatusHttp Post(User user){
        user._id = Guid.NewGuid().ToString();
        var action = this.userPersitence.AddUser(user);
        StatusHttp response =  action ?  new StatusHttp("User was created successfully",200): new StatusHttp("Error",404);
        return response;
    }

    [HttpPut("{id}")]
    public StatusHttp Put(string id, User user){
        var action = this.userPersitence.UpdateUser(id,user);
        StatusHttp response =  action ?  new StatusHttp("User was updated successfully",200): new StatusHttp("Error",404);
        return response;
    }

    [HttpDelete("{id}")]
    public StatusHttp Delete(string id){
        var action = this.userPersitence.DeleteUser(id);
        StatusHttp response =  action ?  new StatusHttp("User was deleted successfully",200): new StatusHttp("Error",404);
        return response;
    }

     [HttpGet("{id}")]
    public User GetOne(string id){
        
        List<User> user = this.userPersitence.GetUser(id).ToList();

        return user[0];
    }

}
}

