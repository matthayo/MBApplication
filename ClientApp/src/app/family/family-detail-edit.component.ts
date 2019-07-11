//Imports
import { Component, Inject } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { HttpClient } from "@angular/common/http";

//Decorators
@Component({
    selector: "family-detail-edit",
    templateUrl: `./family-detail-edit.component.html`
})

//Export
export class FamilyDetailEditComponent {
  title = "Editing family details"
  family: IFamily;
  id: number;
  editMode: boolean;

    constructor(//private familyService: FamilyService,
                private http: HttpClient,
                private router: Router,
                private activatedRoute: ActivatedRoute,
                @Inject('BASE_URL') private baseUrl: string) {
      this.http = http;

      this.family = <IFamily>{};

      this.id = +this.activatedRoute.snapshot.params["id"];

      this.editMode = (this.activatedRoute.snapshot.url[1].path === "edit");

      if (this.editMode) {

        var url = this.baseUrl + "api/families/GetFamilyById/" + this.id;

        this.http.get<IFamily>(url).subscribe(
          family => this.family = family,
          error => console.log(error));
      }
      else {
        this.family.Id = this.id;
        this.title = "Create a new Family Entry";
      }
    }

    onInsert(family: IFamily){
      var url = this.baseUrl + "api/families/" + family.Id
      if(!this.editMode){
        this.http.put<IFamily>(url, family).subscribe(
          (data) => {
              this.family = data;
              console.log("Family " + this.family.Id + " has been added")
              this.router.navigate(["family/view", this.family.Id]);
          },
          (error) => console.log(error));
      }
    }

    onUpdate(family: IFamily){
      var url = this.baseUrl + "api/families/";

      if(this.editMode){
      this.http.post<IFamily>(url, family).subscribe(
        data => {
          var updateFamily = data;
            console.log("Family " + updateFamily.Id + " has been updated.");
            this.router.navigate(["family/view", updateFamily.Id]);
        },
        (error) => console.log(error));
      }
    }

    onDelete(id: number){
      var id = this.family.Id;
      var url = this.baseUrl + "api/families/" + id;
        // this.familyService.delete(id).subscribe(
      this.http.delete<IFamily>(url).subscribe(
            (data) => {
                console.log("Family " + id + " has been deleted.");
                this.router.navigate([""]);
            },
            (error) => console.log(error)
        );
    }

    onFamilyDetailView(family: IFamily){
        this.router.navigate(["family/view", family.Id]);
    }

    backToFamiliesList(){
        this.router.navigate(["families"]);
    }

    onBack(){
        this.router.navigate([""]);
    }
}
