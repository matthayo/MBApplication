//Imports
import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";

import { Family } from "./family";
import { FamilyService } from "./family.service";

//Decorators
@Component({
    selector: "family-detail",
    templateUrl: `app/family/family-detail.component.html`
})

//Export
export class FamilyDetailComponent {
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
                                    "Add New",
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null);
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
                console.log("Family " +  family.Id + " has been added.");
                this.router.navigate([""]);
            },
            (error) => console.log(error)
        );
    }

    onUpdate(family: Family){
        this.familyService.update(family).subscribe(
            (data) => {
                this.family = data;
                console.log("Family " + family.Id + " has been updated.");
                this.router.navigate([""]);
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

    onBack(){
        this.router.navigate([""]);
    }
}