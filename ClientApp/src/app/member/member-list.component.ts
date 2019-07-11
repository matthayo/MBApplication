//Imports
import { Component, Inject } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";

//Decorator
@Component({
    selector: "member-list",
    templateUrl: `./member-list.component.html`
})

//Export
export class MemberListComponent{
    title = "List of Members";
    selectedMember: IMember;
    members: IMember[];
    errorMessage: string;


    constructor(private http: HttpClient,
                private router: Router,
                @Inject('BASE_URL') private baseUrl: string) {
      this.http = http;

      this.getAllMembers();
    }

    getAllMembers() {
      var url = this.baseUrl + "api/Members/GetAllMembers"

      this.http.get<IMember[]>(url).subscribe(
                allMembers => this.members = allMembers,
            ), error => console.log(error);
    }

    onSelect(member: IMember){
        this.selectedMember = member;
        console.log("Member with Id " + this.selectedMember.Id + " has been selected.")
        this.router.navigate(["member/view", this.selectedMember.Id]);
    }

    backToHome(){
        this.router.navigate([""]);
    }
}
