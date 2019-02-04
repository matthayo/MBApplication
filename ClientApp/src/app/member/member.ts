export class Member {
    constructor(
      public Id: number,
      public FamilyId: number,
      public FirstName: string,
      public MiddleName: string,
      public LastName: string,
      public Email: string,
      public Telephone: string,
      public Gender: string,
      public MaritalStatus: string,
      public DateOfBirth: Date
    ){ }
}