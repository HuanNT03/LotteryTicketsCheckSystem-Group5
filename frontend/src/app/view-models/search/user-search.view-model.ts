export class UserSearchViewModel
{
    public id!:number;
    public username!:string;
    public email!:string;
    public status!:Status;
    public selected!:boolean;
}

export enum Status 
{
    Inactive = "inactive",
    Active = "active"
}