//Imports
import { Component, Inject, Input, SimpleChange, SimpleChanges } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";

//Decorator
@Component({
    selector: "family-list",
    templateUrl: "./family-list.component.html"
})

//Exports
export class FamilyListComponent{
    title = "List of Families";
    @Input() selectedFamily: IFamily;
    families: IFamily[];
    errorMessage: string;


    constructor(//private familyService: FamilyService,
                private http: HttpClient,
                private router: Router,
                @Inject('BASE_URL') private baseUrl: string) {

      this.http = http;
      this.families = [];

      this.loadData();
    }

    ngOnChanges(changes: SimpleChanges){
      if(typeof changes['family'] !== "undefined"){
        //retrieve family variable change info
        var change = changes['family'];

        //only perform the task if the value changes
        if(change.isFirstChange()){
          //execute the Http request and retrieve the results
          this.loadData();
        }
      }
    }

    loadData(){
      var url = this.baseUrl + "api/Families/getfamilies";

      this.http.get<IFamily[]>(url).subscribe(list => {
        this.families = list;
      },
        error => this.errorMessage = <any>error
      );
    }

    onSelect(family: IFamily){
        this.selectedFamily = family;
        console.log("Family with Id " + this.selectedFamily.Id + " has been selected.\n" +
                    "Loading item view....");
        this.router.navigate(["family/view", this.selectedFamily.Id]);
    }

    backToHome(){
        this.router.navigate([""]);
    }

}
