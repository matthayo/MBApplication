//imports
import { Injectable } from "@angular/core";
import { Http, Response, Headers, RequestOptions } from "@angular/http";
import "rxjs";
import { map } from "rxjs/operators";
// import { Family } from "./family";
import { throwError } from "rxjs";

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
          .pipe(map(response => response.json())), error => console.error(error);
    }

    //GET call for /api/families/GetByName/{name}
    getByName(name?: string){
        var url = this.baseUrl + "GetByName/";

        if(name != null){
            url + name;
            return this.http.get(url)
              .pipe(map(response => response.json())), error => console.error(error);
        }
        else
            return this.getFamilies();
    }

    //GET call for /api/families/getfamilies
    getFamilies(num?: number){
        var url = this.baseUrl + "GetFamilies/"

        if(num != null) url += num;

        return this.http.get(url)
          .pipe(map(response => response.json())), error => console.error(error);
    }

    //POST call for /api/families/
    add(family: IFamily){
        var url = this.baseUrl;

        return this.http.post(url, JSON.stringify(family), this.getRequestOptions())
          .pipe(map(response => response.json())), error => console.error(error);
    }

    //PUT call for /api/families/{id}
    update(family: IFamily){
        var url = this.baseUrl + family.Id;

        return this.http.put(url, JSON.stringify(family), this.getRequestOptions())
          .pipe(map(response => response.json())), error => console.error(error);
    }

    //DELETE call for /api/families/{id}
    delete(id: number){
        var url = this.baseUrl + id;

        return this.http.delete(url), error => console.error(error);
        ;
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
        return throwError(error.json().error || "Server error");
    }
}
