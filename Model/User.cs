namespace webapi.Model{
    public class User{
        public string user {get;set;}
        public string email {get;set;}
        public string password{get;set;}

        public string _id {get;set;}

        public User(string user,string email,string password){
            this.user = user;
            this.email = email;
            this.password = password;
            this._id = "";
        }
    
    }
}