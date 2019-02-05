//Imports
import { Component, Inject } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { HttpClient } from "@angular/common/http";
// import { MemberDetailEditComponent } from "./member-detail-edit.component";

// Decorators
@Component({
    selector: "member-detail-view",
    templateUrl: "./member-detail-view.component.html"
})

//Export
export class MemberDetailViewComponent {
    title = "Member Detail View";
    member: IMember;

    constructor(private http: HttpClient,
                private router: Router,
                private activatedRoute: ActivatedRoute,
                @Inject('BASE_URL') private baseUrl: string) {

      this.http = http;

      this.loadData();
      }

    loadData(){
      var id = +this.activatedRoute.snapshot.params["id"];

      var url = this.baseUrl + "api/Members/GetMemberById/" + id

      if(id){
        this.http.get<IMember>(url).subscribe(
              member => this.member = member
          );
      }
      else if (id === 0){
          console.log("Id is 0: Adding a new member ...");
          this.router.navigate(["member/edit", 0]);
      }
      else{
          console.log("Invalid id: routing to members list");
          this.router.navigate(["members"]);
      }
    }

    onMemberDetailEdit(member: IMember){
        this.router.navigate(["member/edit", member.Id]);
        return false;
    }

    backToMembersList(){
        this.router.navigate(["members"]);
    }

}
