//Imports
import { Component } from "@angular/core";
import { Family } from "./Family";
import { FamilyService } from "./family.service";

//Decorator
@Component({
    selector: "family-list",
    // templateUrl: "./family-list.component.html"
    template:
        `
        <div class="list">
        <h2>Family List</h2>
        <ol class="list">
            <hr/>
            <li *ngFor="let family of families"
                [class.selected]="family === selectedFamily"
                (click) = "onSelect(family)">
                <span *ngIf="family.AptNumber != null; else displayWithoutAptNumber">
                    Family Name: {{family.FamilyName}} <br/>
                    Apt #: {{family.AptNumber}}, House #: {{family.House}} <br/> 
                    Street: {{family.Street}}<br/>
                    City: {{family.City}}, State: {{family.State}},<br/> 
                    Zip: {{family.Zip}}<br/>
                 </span>
 
                <ng-template #displayWithoutAptNumber>
                    Family Name: {{family.FamilyName}}<br/> 
                    House #:{{family.House}} 
                    Street: {{family.Street}}<br/>
                    City: {{family.City}}, State: {{family.State}}<br/> 
                    Zip: {{family.Zip}}<br/>
                </ng-template>
               
                <hr/>
            </li>
        </ol>
    </div>
    `
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