//imports
import { Injectable } from "@angular/core";
import { Http, Response, Headers, RequestOptions } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Family } from "./family";

//Decorator
@Injectable()

//Export
export class FamilyService {
    
    baseUrl = "api/families/"; //Web API URL

    constructor(private http: Http) {
        
    }

    //GET call for /api/families/get/{id}
    get(num?: number){
        var url = this.baseUrl + "Get/";

        if(num != null) url += num;

        return this.http.get(url)
            .map(response => response.json())
            .catch(this.handleError);
    }

    //GET call for /api/families/GetByName/{name}
    getByName(name?: string){
        var url = this.baseUrl + "GetByName/";

        if(name != null){
            url + name;
            return this.http.get(url)
                .map(response => response.json())
                .catch(this.handleError);
        }
        else
            return this.getFamilies();
    }

    //GET call for /api/families/getfamilies
    getFamilies(num?: number){
        var url = this.baseUrl + "GetFamilies/"
        
        if(num != null) url += num;

        return this.http.get(url)
                .map(response => response.json())
                .catch(this.handleError);
    }

    //POST call for /api/families/
    add(family: Family){
        var url = this.baseUrl;

        return this.http.post(url, JSON.stringify(family), this.getRequestOptions())
            .map(response => response.json())
            .catch(this.handleError);
    }

    //PUT call for /api/families/{id}
    update(family: Family){
        var url = this.baseUrl + family.Id;

        return this.http.put(url, JSON.stringify(family), this.getRequestOptions())
            .map(response => response.json())
            .catch(this.handleError);
    }

    //DELETE call for /api/families/{id}
    delete(id: number){
        var url = this.baseUrl + id;

        return this.http.delete(url)
            .catch(this.handleError);
    }

    //Helper Methods
    
    //returns a viable RequestOptions object to handle Json requests.
    private getRequestOptions() {
        return new RequestOptions({
            headers: new Headers ({
                "Content-Type": "application/json"
            })
        });
    }

    //handle errors.
    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || "Server error");
    }
}
