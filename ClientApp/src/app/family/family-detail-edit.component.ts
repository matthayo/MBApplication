//Imports
import { Component, OnInit, Inject } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Family } from "./family";
import { FamilyService } from "./family.service";
import { HttpClient } from "@angular/common/http";

//Decorators
@Component({
    selector: "family-detail-edit",
    templateUrl: `app/family/family-detail-edit.component.html`
})

//Export
export class FamilyDetailEditComponent {
    title = "Editing family details"
   family: Family;
   url: any;

    constructor(//private familyService: FamilyService,
                private http: HttpClient,
                private router: Router,
                private activatedRoute: ActivatedRoute,
                @Inject('BASE_URL') baseUrl: string) {
      this.http = http;
      this.url = baseUrl;
    }

    ngOnInit(){
        var id = +this.activatedRoute.snapshot.params["id"];
        if(id){
            // this.familyService.get(id).subscribe(
          this.http.get<Family>(this.url + "api/Families/" + id).subscribe(
                family => this.family = family
            );
        }
        else if (id === 0) {
            console.log("Id is 0: adding a new family unit...");
            this.family = new Family(0,
                                    "Add New",  //FamilyName
                                    null,       //AptNumber
                                    null,       //House
                                    null,       //Street
                                    null,       //City
                                    null,       //State
                                    null       //Zip
                                );
        }
        else{
            console.log("Invalid id: routing back to home");
            this.router.navigate(["families"]);
        }
    }

    onInsert(family: Family){
        // this.familyService.add(family).subscribe(
      this.http.put<Family>(this.url + "api/Families/" + family.Id, family).subscribe(
            (data) => {
                this.family = data;
                console.log("Family " + this.family.Id + " has been added")
                this.router.navigate(["family/view", this.family.Id]);
            },
            (error) => console.log(error)
        );
    }

    onUpdate(family: Family){
        // this.familyService.update(family).subscribe(
      this.http.post<Family>(this.url + "api/Families/" + family.Id, family).subscribe(
            (data) => {
                this.family = data;
                console.log("Family " + this.family.Id + " has been updated.");
                this.router.navigate(["family/view", this.family.Id]);
            },
            (error) => console.log(error)
        );
    }

    onDelete(id: number){
        var id = this.family.Id;

        // this.familyService.delete(id).subscribe(
      this.http.delete<Family>(this.url + "api/Families/" + id).subscribe(
            (data) => {
                console.log("Family " + id + " has been deleted.");
                this.router.navigate([""]);
            },
            (error) => console.log(error)
        );
    }

    onFamilyDetailView(family: Family){
        this.router.navigate(["family/view", family.Id]);
    }

    backToFamiliesList(){
        this.router.navigate(["families"]);
    }

    onBack(){
        this.router.navigate([""]);
    }
}
