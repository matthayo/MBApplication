//Imports
import { Component, Inject } from "@angular/core";
import { Family } from "./Family";
import { FamilyService } from "./family.service";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";

//Decorator
@Component({
    selector: "family-list",
    templateUrl: "./family-list.component.html"
})

//Exports
export class FamilyListComponent{
    title = "List of Families";
    selectedFamily: Family;
    families: Family[];
    errorMessage: string;
    url: any;

    constructor(//private familyService: FamilyService,
                private http: HttpClient,
                private router: Router,
                @Inject('BASE_URL') baseUrl: string) {
      this.http = http;
      this.url = baseUrl;
     }

    ngOnInit(){
        this.getFamilies();
    }

    getFamilies(){
        // this.familyService.getFamilies().subscribe(
      this.http.get<Family[]>(this.url + "api/Families/").subscribe(list => {
        this.families = list;
      },
                // families => this.families = families,
                error => this.errorMessage = <any>error
            );
    }

    onSelect(family: Family){
        this.selectedFamily = family;
        console.log("Family with Id " + this.selectedFamily.Id + " has been selected.\n" +
                    "Loading item view....");
        this.router.navigate(["family/view", this.selectedFamily.Id]);
    }

    backToHome(){
        this.router.navigate([""]);
    }

}
