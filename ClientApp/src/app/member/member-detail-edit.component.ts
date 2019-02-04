//Imports
import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router, ActivatedRoute } from "@angular/router";
import { Member } from "./member";
//import { MemberService } from "./member.service";

//Decorators
@Component({
    selector: "member-detail-edit",
    templateUrl: `app/member/member-detail-edit.component.html`
})

//Export
export class MemberDetailEditComponent {
    title = "Editing member details"
    member: Member;
    url : any;

    constructor(//private memberService: MemberService,
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
            // this.memberService.get(id).subscribe(
            //     member => this.member = member
            // );
            this.http.get<Member>(this.url + "api/Members/" + id).subscribe(member => {
              this.member = member;
            }, error => console.error(error))
        }
        else if (id === 0) {
            console.log("Id is 0: adding a new member unit...");
            this.member = new Member(0, //Id
                                    null, // FamilyId
                                    "Add New Member", // FirstName
                                    null, // MiddleName
                                    null, // LastName
                                    null, // Email
                                    null, // Telephone
                                    null, // Gender
                                    null, // MaritalStatus
                                    null  // DateOfBirth
            );
        }
        else {
            console.log("Invalid id: routing back to home");
            this.router.navigate(["members"]);
        }
    }

    onInsert(member: Member) {
        // this.memberService.add(member).subscribe(
      this.http.post<Member>(this.url + "api/Members/" + member.Id, member).subscribe(
            (data) => {
                this.member = data;
                console.log("member " + member.Id + " has been added")
                this.router.navigate(["member/view", this.member.Id]);
            },
            (error) => console.log(error)
        );
    }

    onUpdate(member: Member) {
        // this.memberService.update(member).subscribe(
      this.http.put<Member>(this.url + "api/Members/" + member.Id, member).subscribe(
            (data) => {
                this.member = data;
                console.log("member " + member.Id + " has been updated.");
                this.router.navigate(["member/view", member.Id]);
            },
            (error) => console.log(error)
        );
    }

    onDelete(id: number) {
        var id = this.member.Id;
        // this.memberService.delete(id).subscribe(
      this.http.delete<Member>(this.url + "api/Members/" + id).subscribe(
            (data) => {
                console.log("member " + id + " has been deleted.");
                this.router.navigate(["members"]);
            },
            (error) => console.log(error)
        );
    }

    onMemberDetailView(member: Member) {
        this.router.navigate(["member/view", member.Id]);
        return false;
    }

    backToMembersList() {
        this.router.navigate(["members"]);
    }

    onBack() {
        this.router.navigate([""]);
    }
}
