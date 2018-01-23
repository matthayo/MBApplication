import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Member } from "./member";

//Decorator
@Injectable()

//Export
export class MemberService {
    constructor(private http: Http) { }

    //Web API URL
    private baseUrl = "api/members/"

    //API call to GetAllMembers "api/members/getallmembers"
    getAllMembers(){
        var url = this.baseUrl + "GetAllMembers/"

        return this.http.get(url)
                .map(response => response.json())
                .catch(this.handleErrors);
    }

    private handleErrors(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || "Server error");
    }
}