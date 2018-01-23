//Imports
import { Component } from "@angular/core";
import { Member } from "./member";
import { MemberService } from "./member.service";

//Decorator
@Component({
    selector: "member-list",
    templateUrl: `./member-list.component.html`
})

//Export
export class MemberListComponent{

    selectedMember: Member;
    members: Member[];
    errorMessage: string;

    constructor(private memberService: MemberService){}

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
    }
}