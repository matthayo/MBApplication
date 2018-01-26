//Imports
import { Component, Input } from "@angular/core";
import { Family } from "./family";

//Decorators
@Component({
    selector: "family-detail",
    templateUrl: `app/family/family-detail.component.html`
})

//Export
export class FamilyDetailComponent {
    @Input("Family") family: Family;
}