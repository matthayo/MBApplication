//imports
import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Family } from "./family";

//Decorator
@Injectable()

//Export
export class FamilyService {
    constructor(private http: Http) {
        
    }
    
    baseUrl = "api/families/"; //Web API URL

    //GET call for /api/families/getfamilies
    getFamilies(num?: number){
        var url = this.baseUrl + "GetFamilies/"
        
        if(num != null) url += num;

        return this.http.get(url)
                .map(response => response.json())
                .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || "Server error");
    }
}
