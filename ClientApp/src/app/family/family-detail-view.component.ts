//imports
import { Component, OnInit, Inject} from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { HttpClient } from "@angular/common/http";

//Decorators
@Component({
    selector: "family-detail-view",
    templateUrl: `./family-detail-view.component.html`
})

//Export
export class FamilyDetailViewComponent {
    title = "Detailed Family View";
    family: IFamily;
    url: string;
    id: number;

    constructor(//private familyService: FamilyService,
                private http: HttpClient,
                private router: Router,
                private activatedRoute: ActivatedRoute,
                @Inject('BASE_URL') baseUrl: string) {
      this.http = http;
      this.url = baseUrl + "api/families/getfamilybyid";
      this.id = this.activatedRoute.snapshot.params["id"];

      // this.http.get<IFamily>(this.url + "/" + this.id).subscribe(
      //     family => this.family = family
      //   );

      if (this.id) {
        this.http.get<IFamily>(this.url + "/" + this.id).subscribe(
        family => this.family = family);
      }
      else if (this.id === 0) {
        console.log("Id is 0: adding a new family unit...");
        this.router.navigate(["family/edit", 0]);
      }
      else {
        console.log("Invalid id: routing back to home");
        this.router.navigate([""]);
      }
    }


    onFamilyDetailEdit(family: IFamily) {
        this.router.navigate(["family/edit", family.Id]);
    }

    backToFamiliesList() {
        this.router.navigate(["families"]);
    }
}
