//imports
import { Component, OnInit, Inject} from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Family } from "./family";
import { FamilyService } from "./family.service";
import { HttpClient } from "@angular/common/http";

//Decorators
@Component({
    selector: "family-detail-view",
    templateUrl: `./family-detail-view.component.html`
})

//Export
export class FamilyDetailViewComponent {
    title = "Detailed Family View";
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

    ngOnInit() {
        var id = +this.activatedRoute.snapshot.params["id"];
        if (id) {
            // this.familyService.get(id).subscribe(
          this.http.get<Family>(this.url + "api/Families/" + id).subscribe(
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

    backToFamiliesList() {
        this.router.navigate(["families"]);
    }
}
