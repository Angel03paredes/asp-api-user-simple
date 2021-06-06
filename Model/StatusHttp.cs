namespace webapi.Model{

public class StatusHttp{

    public string message {get;set;}
    public int status{get;set;}

    public StatusHttp(string message, int status){

        this.message = message;
        this.status = status;

    }


} 

}