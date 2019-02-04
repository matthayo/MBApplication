//Imports
import { Component, Inject } from "@angular/core";
import { Member } from "./member";
import { MemberService } from "./member.service";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";

//Decorator
@Component({
    selector: "member-list",
    templateUrl: `app/member/member-list.component.html`
})

//Export
export class MemberListComponent{
    title = "List of Members";
    selectedMember: Member;
    members: Member[];
    errorMessage: string;
    url: any;

    constructor(//private memberService: MemberService,
                private http: HttpClient,
                private router: Router,
                @Inject('BASE_URL') baseUrl: string) {
      this.http = http;
      this.url = baseUrl;
    }

    ngOnInit(){
        this.getAllMembers();
    }

    getAllMembers() {
      this.http.get<Member[]>(this.url + "api/Families/").subscribe(
                allMembers => {this.members = allMembers;},
                error => this.errorMessage = <any>error
            );
    }

    onSelect(member: Member){
        this.selectedMember = member;
        console.log("Member with Id " + this.selectedMember.Id + " has been selected.")
        this.router.navigate(["member/view", this.selectedMember.Id]);
    }

    backToHome(){
        this.router.navigate([""]);
    }
}
