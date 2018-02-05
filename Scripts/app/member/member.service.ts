import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Member } from "./member";

//Decorator
@Injectable()

//Export
export class MemberService {
    constructor(private http: Http) {
        
    }

    //Web API URL
    private baseUrl = "api/members/"

    // GET call for api/members/get/{id}
    get(num?: number){
        var url = this.baseUrl + "Get/"

        if(num != null) url += num;

        return this.http.get(url)
                    .map(respose => respose.json())
                    .catch(this.handleError);
    }

    //API call to GetAllMembers "api/members/getallmembers"
    getAllMembers(){
        var url = this.baseUrl + "GetAllMembers/"

        return this.http.get(url)
                .map(response => response.json())
                .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || "Server error");
    }
}