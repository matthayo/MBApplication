//Imports
import { Component, OnInit, Inject } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
// import { Family } from "./family";
import { FamilyService } from "./family.service";
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

      this.id = this.activatedRoute.snapshot.params["id"];

      if (this.id) {

        this.editMode = true;

        var url = this.baseUrl + "api/families/GetFamilyById/" + this.id;

        this.http.get<IFamily>(url).subscribe(
          family => this.family = family
        );
      }
      else {
        this.editMode = false;
        this.router.navigate(["families"]);
      }
    }

    // ngOnInit(){
    //     var id = +this.activatedRoute.snapshot.params["id"];
    //     if(id){
    //         // this.familyService.get(id).subscribe(
    //       this.http.get<IFamily>(this.url + "api/Families/" + id).subscribe(
    //             family => this.family = family
    //         );
    //     }
    //     else if (id === 0) {
    //         console.log("Id is 0: adding a new family unit...");
    //         // this.family = new IFamily(0,
    //         //                         "Add New",  //FamilyName
    //         //                         null,       //AptNumber
    //         //                         null,       //House
    //         //                         null,       //Street
    //         //                         null,       //City
    //         //                         null,       //State
    //         //                         null       //Zip
    //         //                     );
    //     }
    //     else{
    //         console.log("Invalid id: routing back to home");
    //         this.router.navigate(["families"]);
    //     }
    // }

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
      var url = this.baseUrl + "api/families/" + family.Id;

      if(this.editMode){
      this.http.post<IFamily>(url, family).subscribe(
        data => {
            this.family = data;
            console.log("Family " + this.family.Id + " has been updated.");
            this.router.navigate(["family/view", this.family.Id]);
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
