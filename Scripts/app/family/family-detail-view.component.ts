//imports
import { Component, OnInit} from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";

import { Family } from "./family";
import { FamilyService } from "./family.service";

//Decorators
@Component({
    selector: "family-detail-view",
    templateUrl: `app/family/family-detail-view.component.html`
})

//Export
export class FamilyDetailViewComponent {
    title = "Detailed Family View";
    family: Family;

    constructor(private familyService: FamilyService,
                private router: Router,
                private activatedRoute: ActivatedRoute) {
    }

    ngOnInit() {
        var id = +this.activatedRoute.snapshot.params["id"];
        if (id) {
            this.familyService.get(id).subscribe(
                family => this.family = family
            );
        }
        else if (id === 0) {
            console.log("Id is 0: adding a new family unit...");
            this.router.navigate(["family/edit", 0]);
        }
        else {
            console.log("Invalid id: routing back to home");
            this.router.navigate([""]);
        }
    }

    onFamilyDetailEdit(family: Family) {
        this.router.navigate(["family/edit", family.Id]);
    }

}