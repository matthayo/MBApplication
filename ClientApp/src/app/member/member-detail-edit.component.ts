//Imports
import { Component, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router, ActivatedRoute } from "@angular/router";

//Decorators
@Component({
    selector: "member-detail-edit",
    templateUrl: `./member-detail-edit.component.html`
})

//Export
export class MemberDetailEditComponent {
    title = "Editing member details"
    member: IMember;

    constructor(private http: HttpClient,
                private router: Router,
                private activatedRoute: ActivatedRoute,
                @Inject('BASE_URL') private baseUrl: string) {
        this.http = http;

      this.loadData();
    }

    loadData() {
      var id = +this.activatedRoute.snapshot.params["id"];
      var url = this.baseUrl + "api/Members/GetMemberById/" + id

      if (id) {
          this.http.get<IMember>(url).subscribe(member => {
            this.member = member;
          }, error => console.error(error))
      }
      else if (id === 0) {
          console.log("Id is 0: adding a new member unit...");
          // this.member = new Member(0, //Id
          //                         null, // FamilyId
          //                         "Add New Member", // FirstName
          //                         null, // MiddleName
          //                         null, // LastName
          //                         null, // Email
          //                         null, // Telephone
          //                         null, // Gender
          //                         null, // MaritalStatus
          //                         null  // DateOfBirth
          // );
      }
      else {
          console.log("Invalid id: routing back to home");
          this.router.navigate(["members"]);
      }
    }

    onInsert(member: IMember) {
      var url = this.baseUrl + "api/Members/" + member.Id;
      this.http.put<IMember>(url, member).subscribe(
            (data) => {
                this.member = data;
                console.log("member " + member.Id + " has been added")
                this.router.navigate(["member/view", this.member.Id]);
            },
            (error) => console.log(error)
        );
    }

    onUpdate(member: IMember) {
      var url = this.baseUrl + "api/Members/";
      this.http.post<IMember>(url, member).subscribe(
            data => {
                this.member = data;
                console.log("member " + member.Id + " has been updated.");
                this.router.navigate(["member/view", member.Id]);
            },
            (error) => console.log(error)
        );
    }

    onDelete(id: number) {
      var url = this.baseUrl + "api/Members/" + id;
      this.http.delete<IMember>(url).subscribe(
            (data) => {
                console.log("member " + id + " has been deleted.");
                this.router.navigate(["members"]);
            },
            (error) => console.log(error)
        );
    }

    onMemberDetailView(member: IMember) {
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
