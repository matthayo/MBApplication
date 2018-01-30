//Imports
import { Component } from "@angular/core";
import { Family } from "./Family";
import { FamilyService } from "./family.service";
import { Router } from "@angular/router";

//Decorator
@Component({
    selector: "family-list",
    templateUrl: "app/family/family-list.component.html"
})

//Exports
export class FamilyListComponent{  
    selectedFamily: Family;
    families: Family[];
    errorMessage: string;
     
    constructor(private familyService: FamilyService,
                private router: Router){ }

    ngOnInit(){
        this.getFamilies();
    }

    getFamilies(){
        this.familyService.getFamilies()
            .subscribe(
                families => this.families = families,
                error => this.errorMessage = <any>error
            );
    }

    onSelect(family: Family){
        this.selectedFamily = family;
        console.log("Family with Id " + this.selectedFamily.Id + " has been selected.\n" +
                    "Loading item view....");
        this.router.navigate(["family/view", this.selectedFamily.Id]);
    }

}