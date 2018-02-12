import { Injectable } from "@angular/core";
import { Http, Response, RequestOptions, Headers } from "@angular/http";
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

    // API call to "Find by Name" /api/members/GetByLastName/{name}
    getByName(name: string){
        var url = this.baseUrl + "GetByLastName/" + name;

        return this.http.get(url)
                .map(response => response.json())
                .catch(this.handleError);
    }

    // POST
    add(member: Member){
        var url = this.baseUrl;

        return this.http.post(url, JSON.stringify(member), this.getRequestOptions())
            .map(response => response.json())
            .catch(this.handleError);
    }


    // PUT call for /api/members/{id}
    update(member: Member){
        var url = this.baseUrl + member.Id;

        return this.http.put(url, JSON.stringify(member), this.getRequestOptions())
            .map(response => response.json())
            .catch(this.handleError);
    }


    // DELETE call for /api/members/{id}
    delete(id: number){
        var url = this.baseUrl + id;

        return this.http.delete(url)
                .catch(this.handleError);
    }

    // Helper Methods

    //returns a viable RequestOptions object to handle Json requests
    private getRequestOptions() {
        return new RequestOptions({
            headers: new Headers({
                "Content-Type": "application/json"
            })
        })
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || "Server error");
    }
}