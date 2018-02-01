//Imports
import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs/Observable";

import { Family } from "./family";
import { FamilyService } from "./family.service";

//Decorators
@Component({
    selector: "family-detail-edit",
    templateUrl: `app/family/family-detail-edit.component.html`
})

//Export
export class FamilyDetailEditComponent {
    family: Family;

    constructor(private familyService: FamilyService, 
                private router: Router,
                private activatedRoute: ActivatedRoute){
    }
    
    ngOnInit(){
        var id = +this.activatedRoute.snapshot.params["id"];
        if(id){
            this.familyService.get(id).subscribe(
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
            this.router.navigate([""]);
        }
    }

    onInsert(family: Family){
        this.familyService.add(family).subscribe(
            (data) => {
                this.family = data;
                console.log("Family " + this.family.Id + " has been added")
                this.router.navigate(["family/view", this.family.Id]);
            },
            (error) => console.log(error)
        );
    }

    onUpdate(family: Family){
        this.familyService.update(family).subscribe(
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

        this.familyService.delete(id).subscribe(
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

    onBack(){
        this.router.navigate([""]);
    }
}