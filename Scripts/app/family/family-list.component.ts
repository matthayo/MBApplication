//Imports
import { Component } from "@angular/core";
import { Family } from "./Family";
import { FamilyService } from "./family.service";

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
     
    constructor(private familyService: FamilyService){ }

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
        console.log("Family with Id " + this.selectedFamily.Id + " has been selected.")
    }

}