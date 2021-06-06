namespace webapi.Settings{
    public class MongoDBSettings{
        

        public string Host {get;set;}
        public string Port {get;set;}

        public string connectionSettings{
            get{
                return $"mongodb://{Host}:{Port}";
            }
        }

    }
}