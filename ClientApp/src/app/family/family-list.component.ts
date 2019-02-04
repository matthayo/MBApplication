//Imports
import { Component, Inject } from "@angular/core";
// import { IFamily } from "./Family";
// import { FamilyService } from "./family.service";
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
    selectedFamily: IFamily;
    families: IFamily[];
    errorMessage: string;


    constructor(//private familyService: FamilyService,
                private http: HttpClient,
                private router: Router,
                @Inject('BASE_URL') baseUrl: string) {
      this.http = http;
      var url = baseUrl + "api/Families/getfamilies";

      this.http.get<IFamily[]>(url).subscribe(list => {
        this.families = list;
      },
        error => this.errorMessage = <any>error
      );
     }


    onSelect(family: IFamily){
        this.selectedFamily = family;
        console.log("Family with Id " + this.selectedFamily.Id + " has been selected.\n" +
                    "Loading item view....");
        this.router.navigate(["family/view", this.selectedFamily.Id]);
    }

    backToHome(){
        this.router.navigate([""]);
    }

}
