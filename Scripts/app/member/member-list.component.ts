//Imports
import { Component } from "@angular/core";
import { Member } from "./member";
import { MemberService } from "./member.service";
import { Router } from "@angular/router";

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

    constructor(private memberService: MemberService, 
                private router: Router){}

    ngOnInit(){
        this.getAllMembers();
    }

    getAllMembers() {
        this.memberService.getAllMembers()
            .subscribe(
                allMembers => this.members = allMembers,
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