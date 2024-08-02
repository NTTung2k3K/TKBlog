export class User {
    constructor(staffId: string, fullName: string, email: string, image: string, access_Token: string) {
        this.staffId = staffId;
        this.fullName = fullName;
        this.email = email;
        this.image = image;
        this.access_Token = access_Token;
    }

    public staffId: string;
    public fullName: string;
    public email: string;
    public image: string;
    public access_Token: string;

}