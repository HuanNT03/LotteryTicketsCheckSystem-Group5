export class TicketViewModel 
{
    ticketNumber!:string;
    publicDate?:Date;
    prize!:string;
    company?:string;
    status!:TicketStatus
}

export enum TicketStatus
{
    Publish = "publish",
    Unpublish = "unpublish"
}